using System;
using System.Windows.Forms;
using System.ServiceModel.Syndication;
using System.Xml;
using ProjektarbeteHT18.Business_Logic_Layer;
using System.Threading.Tasks;
using System.Drawing;

namespace ProjektarbeteHT18
{
    public partial class frmRSSReader : Form
    {
        Buisiness b;
        CategoryList CategoryList;

        public frmRSSReader()
        {
            b = new Buisiness();
            CategoryList = new CategoryList();
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }


        private void UpdateEpisodeDetails(PodCastEpisode episode)
        {
            lb_PodcastAvsnitt.Text = episode.Name;
            txtEpisodeDescription.Text = episode.Description;
        }
        

        //Uppdaterar listan med podcastavsnitt
        private void UpdateEpisodeList(PodCastFeed feed)
        {
            PodCastEpisodeList<IPodCastEpisode> epList = feed.Episodes;
            foreach (var episode in epList)
            {
                var episodeNumber = (epList.IndexOf(episode) + 1);
                var displayEpisodeNumber = String.Format("#{0}",
                                         episodeNumber.ToString());
                ListViewItem lvItem = new ListViewItem(new[] { displayEpisodeNumber, episode.Name });
                lvPodCastEpisodes.Items.Add(lvItem);
            }


        }
        
        //Uppdaterar listan med podcast-feeds         
        private void UpdatePodList()
        {
            lv_Podcast.Items.Clear();
            foreach (PodCastFeed p in b.PodCastFeedList)
            {
                string numberOfEpisodes = p.Episodes.Count.ToString();
                ListViewItem lvItem = new ListViewItem(new[] {numberOfEpisodes, p.Name });
                lv_Podcast.Items.Add(lvItem);
            }
        }

        private void UpdateCategory()
        {
            lv_Categories.Items.Clear();
            cb_Kategori.Items.Clear();
            cb_Kategori.ResetText();
            foreach (string c in CategoryList)
            {

                ListViewItem lvItem = new ListViewItem(new[] { c });

                lv_Categories.Items.Add(lvItem);
                cb_Kategori.Items.Add(c);
            }
            if(cb_Kategori.Items.Count >= 1)
            {
                cb_Kategori.SelectedIndex = 0;
            }
            cb_Kategori.Refresh();

        }


        private async void btn_NyPodcast_Click(object sender, EventArgs e)
        {
            string url = "https://api.sr.se/api/rss/pod/itunes/3966";
            var pod = await b.ReadRSSAsync(url);
            UpdatePodList();
        }

        private void lv_Podcast_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvPodCastEpisodes.Items.Clear();
            var selectedIndex = lv_Podcast.SelectedIndices[0];
            var feed = b.PodCastFeedList[selectedIndex];
            UpdateEpisodeList(feed);
        }

        private void lv_PodcastAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPodIndex = lv_Podcast.SelectedIndices[0];

            if(lvPodCastEpisodes.FocusedItem != null)
            {
                var selectedEpisodeIndex = lvPodCastEpisodes.FocusedItem.Index;
                var episode = (PodCastEpisode)b.PodCastFeedList[selectedPodIndex].Episodes[selectedEpisodeIndex];
                UpdateEpisodeDetails(episode);
            }
        }

        private void btn_NyKategori_Click(object sender, EventArgs e)
        {
            CategoryList.AddCategory(txt_Category.Text);
            UpdateCategory();
            txt_Category.Clear();
        }

        private void btn_SparaKategori_Click(object sender, EventArgs e)
        {
            string selected = lv_Categories.FocusedItem.Text;
            CategoryList.ReNameCategory(selected, txt_Category.Text);
            UpdateCategory();
            txt_Category.Clear();
        }

        private void lv_Kategorier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lv_Categories.FocusedItem != null)
            {
                string selected = lv_Categories.FocusedItem.Text;
                txt_Category.Text = selected;
            }
        }

        private void btn_TaBortKategori_Click(object sender, EventArgs e)
        {
            string selected = lv_Categories.FocusedItem.Text;
            CategoryList.RemoveCategory(selected);
            UpdateCategory();
        }
    }
}
