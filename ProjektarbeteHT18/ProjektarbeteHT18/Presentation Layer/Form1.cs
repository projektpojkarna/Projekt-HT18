using System;
using System.Windows.Forms;
using System.ServiceModel.Syndication;
using System.Xml;
using ProjektarbeteHT18.Business_Logic_Layer;
using System.Threading.Tasks;
using System.Drawing;

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
    }
}
