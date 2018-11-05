using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Newtonsoft.Json;
using System.IO;
using ProjektarbeteHT18.Business_Logic_Layer.Exceptions;
using ProjektarbeteHT18.Business_Logic_Layer.Categories;
using ProjektarbeteHT18.Business_Logic_Layer.Pod;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    class PodManager
    {
        //*** Properties
        public PodCastList<PodCast> PodCastList { get; }
        public CategoryList<Category> CategoryList { get; }
        public RSSManager RSSManager;
        [JsonIgnore] public ExceptionHandler ExceptionHandler { get; set; }

        //Används för uppdatering av pods
        private Timer t;
        int ElapsedMinutes;

        //*** Event handlers
        //När en listan med pods uppdetaras
        public delegate void PodUpdatedHandler();
        public event PodUpdatedHandler OnPodUpdate;
        //När ett fel uppstår
        public delegate void ErrorHandler(string msg);
        public event ErrorHandler OnError;

        //Statisk metod för att återskapa från serialiserad JSON
        public static PodManager FromJsonOrDefault(string jsonFile)
        {
            var serializer = new Serializer<PodManager>(jsonFile);
            if (File.Exists(jsonFile))
            {
                var fm = serializer.Deserialize();
                //Uppdaterar alla podcasts 
                foreach(var p in fm.PodCastList.GetAll())
                {
                    fm.UpdatePodCast(p);
                }
                return fm;
            }
            else
            {
                return new PodManager();
            }
        }

        [JsonConstructor]public PodManager()
        {
            CategoryList = new CategoryList<Category>();
            PodCastList = new PodCastList<PodCast>();

            //Timer anropar Elapsed-eventet var 5:e minut,
            //RefreshPods kollar vilka pods behöver uppdatering
            //Användaren kan enbart välja uppdateringsintervaller med 5-minutersintervall
            t = new Timer();
            t.Interval = 30000;
            t.Elapsed += new ElapsedEventHandler(RefreshPods);
            t.Start();

            ExceptionHandler = new ExceptionHandler();
            RSSManager = new RSSManager(ExceptionHandler);

        }

        //Serialiserar PodManager till JSON
        //Listan med podcastavsnitt kommer ignoreras (markerad med [JsonIgnore])
        public void Serialize()
        {
            Serializer<PodManager> Serializer = new Serializer<PodManager>("jsonData.json");
            Serializer.Serialize(this);
        }

        public void AddCategory(string categoryName)
        {
            CategoryList.Add(new Category(categoryName));
        }

        public void RenameCategory(string categoryName, string newCategoryName)
        {
            CategoryList.Rename(categoryName, newCategoryName);
            var podsToUpdate = PodCastList.GetPodsByCategory(categoryName);
            podsToUpdate.Where((p) => p.Category == categoryName).ToList()
                .ForEach((p) => p.Category = newCategoryName);
            FirePodUpdated();
        }

        //Tar bort en kategori; kollar först att kategorin inte används
        public void RemoveCategory(string category)
        {
            bool isUsed = PodCastList.GetAll().Any((p) => p.Category == category);
            if (isUsed)
            {
                OnError("Kategorin används av en eller flera podcasts.");
            }
            else
            {
                CategoryList.Remove(category);
            }
        }

        //Lägger till en ny podcast
        public async Task AddNewPod(string url, string category, int updateInterval)
        {
            //Läser in RSS-feed, skapar och skapar PodCast under förutsättning att
            //ingenting gått fel
            await RSSManager.GetPodCast(url).ContinueWith((t) => {
                //Lägger bara till poden om ingenting gick fel
                if (t.Exception == null && t.Result != null)
                {
                    var pod = t.Result;
                    pod.Category = category;
                    pod.UpdateInterval = updateInterval;
                    PodCastList.Add(pod);
                    FirePodUpdated();
                }
            }); 
        }

        //Ta bort en pod ur listan och uppdatera UI
        public async Task RemovePod(string url)
        {
            await Task.Run(() =>
            {
                PodCastList.Remove(url);
            });
            FirePodUpdated();
        }

        //Uppdaterar egenskaper hos en existerande podcast
        public async Task UpdatePodProperties(int index, string newUrl, int newInterval, string newCategory)
        {
            var pod = PodCastList.Get(index);
            pod.UpdateInterval = newInterval;
            pod.Category = newCategory;
            //Om podens URL är uppdaterad; kolla efter nya avsnitt
            if (newUrl != pod.Url)
            {
                pod.Url = newUrl;
                await CheckForPodUpdates(pod);
            }
            else
            {
                FirePodUpdated();
            }
        }

        //Uppdaterar en podcast
        private async Task UpdatePodCast(PodCast pod)
        {
            await RSSManager.UpdatePodCast(pod);
            FirePodUpdated();
        }

        //Uppdaterar en podcast om det finns ett nytt avsnitt
        private async Task CheckForPodUpdates(PodCast pod)
        {
            bool updated = await RSSManager.UpdatePodIfNeeded(pod);
            if (updated) {
                FirePodUpdated();
            }
        }

        //Anropas av timern; kollar vilka pods vars uppdateringsintervall stämmer överrens med timern
        public async void RefreshPods(object source, ElapsedEventArgs eArgs)
        {
            ElapsedMinutes +=5;
            var podsToUpdate = PodCastList.GetAll().Where((p) => (ElapsedMinutes % p.UpdateInterval == 0)).ToList();
            foreach (PodCast p in podsToUpdate)
            {
                await CheckForPodUpdates(p);
            }
        }

        //Metod för att hantera uppdatering av UI
        private void FirePodUpdated()
        {
            if (OnPodUpdate != null)
            {
                OnPodUpdate();
            }
        }
    }
}