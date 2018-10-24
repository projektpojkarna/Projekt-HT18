using System;
using System.Windows.Forms;
using System.ServiceModel.Syndication;
using System.Xml;
using ProjektarbeteHT18.Business_Logic_Layer;
using System.Threading.Tasks;

namespace ProjektarbeteHT18
{
    public partial class Form1 : Form
    {
        Buisiness b;

        public Form1()
        {
            b = new Buisiness();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void UpdateList()
        {
            foreach (PodCastFeed p in b.PodCastFeedList)
            {
                string numberOfEpisodes = p.Episodes.Count.ToString();
                ListViewItem lvItem = new ListViewItem(new[] {numberOfEpisodes, p.Name });
                lv_Podcast.Items.Add(lvItem);
            }
        }


        private async void btn_NyPodcast_Click(object sender, EventArgs e)
        {
            string url = "https://api.sr.se/api/rss/pod/itunes/3966";
            var pod = await b.ReadRSSAsync(url);
            UpdateList();
        }

        private void lv_Podcast_SelectedIndexChanged(object sender, EventArgs e)
        {
            PodCastEpisodeList epList = b.PodCastFeedList.GetPodByURL
            foreach()
            {

            }
        }
    }
}
