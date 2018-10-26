using System;
using System.Windows.Forms;
using System.ServiceModel.Syndication;
using System.Xml;
using ProjektarbeteHT18.Business_Logic_Layer;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections.Generic;

namespace ProjektarbeteHT18
{
    public partial class frmRSSReader : Form
    {
        private string[] INTERVALS = new[] { "", "Var 5:e minut", "Var 10:e minut", "Var 15:e minut" };

        FeedManager fm;
        CategoryList CategoryList;

        public frmRSSReader()
        {
            fm = new FeedManager();
            CategoryList = new CategoryList();
             
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fm.OnPodAdded += UpdatePodList;
        }


        private void UpdateEpisodeDetails(IPodCastEpisode episode)
        {
            lb_PodcastAvsnitt.Text = episode.Name;
            txtEpisodeDescription.Text = episode.Description;
        }
        

        //Uppdaterar listan med podcastavsnitt
        private void UpdateEpisodeList(PodCastFeed feed)
        {
            PodCastEpisodeList<IPodCastEpisode> epList = feed.Episodes;
            var episodeNumber = epList.Count;
            foreach (var episode in epList)
            {
                var displayEpisodeNumber = String.Format("#{0}",
                                         episodeNumber.ToString());
                episodeNumber--;
                ListViewItem lvItem = new ListViewItem(new[] { displayEpisodeNumber, episode.Name });
                lvPodCastEpisodes.Items.Add(lvItem);
                UpdateEpisodeDetails(epList[0]);
            }
        }
        
        //Uppdaterar listan med podcast-feeds         
        private void UpdatePodList()
        {
            if (lv_Podcast.InvokeRequired)
            {
                lv_Podcast.Invoke((MethodInvoker)delegate
                {
                    lv_Podcast.Items.Clear();
                    foreach (PodCastFeed p in fm.PodCastFeedList)
                    {
                        string numberOfEpisodes = p.Episodes.Count.ToString();
                        ListViewItem lvItem = new ListViewItem(new[] {
                            numberOfEpisodes, p.Name, p.UpdateInterval.ToString(), p.Category
                        });
                        lv_Podcast.Items.Add(lvItem);
                    }

            });
            } else
            {
                lv_Podcast.Items.Clear();
                foreach (PodCastFeed p in fm.PodCastFeedList)
                {
                    string numberOfEpisodes = p.Episodes.Count.ToString();
                    ListViewItem lvItem = new ListViewItem(new[] { numberOfEpisodes, p.Name, p.UpdateInterval.ToString(), p.Category });
                    lv_Podcast.Items.Add(lvItem);
                }
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
            var url = txt_Url.Text;
            var category = cb_Kategori.SelectedItem.ToString();
            int.TryParse(cb_frekvens.SelectedItem.ToString(), out int interval);
            await fm.AddNewPod(url, category, interval);


            //var pod = await fm.ReadRSSAsync(url);
            //pod.Category = cb_Kategori.SelectedItem.ToString();
            //pod.UpdateInterval = int.Parse(cb_frekvens.SelectedItem.ToString());
        }

        private void lv_Podcast_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvPodCastEpisodes.Items.Clear();

            if(lv_Podcast.FocusedItem != null)
            {
                var selectedIndex = lv_Podcast.FocusedItem.Index;
                var feed = fm.PodCastFeedList[selectedIndex];
                txt_Url.Text = feed.Url;
                UpdateEpisodeList(feed);
            }

        }

        private void lv_PodcastAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPodIndex = lv_Podcast.SelectedIndices[0];

            if(lvPodCastEpisodes.FocusedItem != null)
            {
                var selectedEpisodeIndex = lvPodCastEpisodes.FocusedItem.Index;
                var episode = (PodCastEpisode)fm.PodCastFeedList[selectedPodIndex].Episodes[selectedEpisodeIndex];
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
