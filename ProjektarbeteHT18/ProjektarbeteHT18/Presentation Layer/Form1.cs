using System;
using System.Windows.Forms;
using System.ServiceModel.Syndication;
using System.Xml;
using ProjektarbeteHT18.Business_Logic_Layer;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections.Generic;
using ProjektarbeteHT18.Business_Logic_Layer.Exceptions;
using ProjektarbeteHT18.Business_Logic_Layer.Categories;
using ProjektarbeteHT18.Business_Logic_Layer.Pod;

namespace ProjektarbeteHT18
{
    public partial class frmRSSReader : Form
    {
        PodManager Fm;
        string Filter;

        public frmRSSReader()
        {
            InitializeComponent();
            Fm = PodManager.FromJsonOrDefault("jsonData.json");
            Fm.OnPodUpdate += UpdatePodList;
            Fm.OnError += PrintError;

            Fm.ExceptionHandler.OnException += PrintError;

            Filter = "";

            cb_frekvens.SelectedIndex = 0;
            

            UpdatePodList();
        }

        private void PrintError(string msg)
        {
            if(lblErrorMsg.InvokeRequired)
            {
                lblErrorMsg.Invoke((MethodInvoker)delegate
                {
                    lblErrorMsg.Text = msg;
                });
            } else
            {
                lblErrorMsg.Text = msg;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void UpdateEpisodeDetails(IEpisode episode)
        {
            lb_PodcastAvsnitt.Text = episode.Name;
            txtEpisodeDescription.Text = episode.Description;
        }
        

        //Uppdaterar listan med podcastavsnitt
        private void UpdateEpisodeList(PodCast feed)
        {
            EpisodeList<Episode> epList = feed.Episodes;

            lvPodCastEpisodes.Items.Clear();
            lvPodCastEpisodes.Items.AddRange(epList.ToListViewItems());
            if(epList != null && epList.Count > 0)
            {
                UpdateEpisodeDetails(epList.Get(0));
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
                    foreach (PodCast p in Fm.PodCastList.GetAll())
                    {
                        if(p.Category.StartsWith(Filter, StringComparison.InvariantCultureIgnoreCase))
                        {
                            string numberOfEpisodes = (p.Episodes != null) ? p.Episodes.Count.ToString() : "0";
                            ListViewItem lvItem = new ListViewItem(new[] {
                            numberOfEpisodes, p.Name, p.UpdateInterval.ToString(), p.Category
                        });
                            lv_Podcast.Items.Add(lvItem);
                        }

                    }

            });
            } else
            {
                UpdateCategory();
                lv_Podcast.Items.Clear();
                foreach (PodCast p in Fm.PodCastList.GetAll())
                {
                    if(p.Category.StartsWith(Filter, StringComparison.InvariantCultureIgnoreCase))
                    {
                        string numberOfEpisodes = (p.Episodes != null) ? p.Episodes.Count.ToString() : "0";
                        ListViewItem lvItem = new ListViewItem(new[] { numberOfEpisodes, p.Name, p.UpdateInterval.ToString(), p.Category });
                        lv_Podcast.Items.Add(lvItem);
                    }

                }
            }
        }

        private void UpdateCategory()
        {
            lv_Categories.Items.Clear();
            cb_Kategori.Items.Clear();
            cb_Kategori.ResetText();

            lv_Categories.Items.AddRange(Fm.CategoryList.ToListViewItems());

            foreach (Category c in Fm.CategoryList.GetAll())
            {
                cb_Kategori.Items.Add(c.CategoryName);
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
            if (!Validator.ValidateUrl(url))
            {
                PrintError("Ange giltig URL.");
            }
            else if(!Validator.ValidateUrl(category))
            {
                PrintError("Ange en kategori.");
            }
            else
            {
                int.TryParse(cb_frekvens.SelectedItem.ToString(), out int interval);
                await Fm.AddNewPod(url, category, interval);
            }

        }

        private void lv_Podcast_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvPodCastEpisodes.Items.Clear();

            if(lv_Podcast.FocusedItem != null)
            {
                var selectedIndex = lv_Podcast.FocusedItem.Index;
                var pod = Fm.PodCastList.Get(selectedIndex);
                txt_Url.Text = pod.Url;
                cb_Kategori.Text = lv_Podcast.Items[selectedIndex].SubItems[3].Text;
                cb_frekvens.Text = lv_Podcast.Items[selectedIndex].SubItems[2].Text;
                UpdateEpisodeList(pod);
            }

        }

        private void lv_PodcastAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvPodCastEpisodes.FocusedItem != null && lv_Podcast.FocusedItem != null)
            {
                var selectedPodIndex = lv_Podcast.FocusedItem.Index;
                var selectedEpisodeIndex = lvPodCastEpisodes.FocusedItem.Index;
                var pod = Fm.PodCastList.Get(selectedPodIndex);
                var episode = pod.Episodes.Get(selectedEpisodeIndex);
                UpdateEpisodeDetails(episode);
            }
        }

        private void btn_NyKategori_Click(object sender, EventArgs e)
        {
            Fm.CategoryList.Add(new Category(txt_Category.Text));
            UpdateCategory();
            txt_Category.Clear();
        }

        private void btn_SparaKategori_Click(object sender, EventArgs e)
        {
            string selected = lv_Categories.FocusedItem.Text;
            Fm.CategoryList.Rename(selected, txt_Category.Text);

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
            if(lv_Categories.FocusedItem != null)
            {
                string selected = lv_Categories.FocusedItem.Text;
                Fm.RemoveCategory(selected);
                UpdateCategory();
            }

        }

        private void frmRSSReader_FormClosing(object sender, FormClosingEventArgs e)
        {
            Fm.Serialize();
        }

        private async void btn_TaBortPodcast_Click(object sender, EventArgs e)
        {
            await Fm.RemovePod(txt_Url.Text);
        }

        private async void btn_SparaPodcast_Click(object sender, EventArgs e)
        {
            if(lv_Podcast.FocusedItem != null)
            {
                var selectedPodIndex = lv_Podcast.FocusedItem.Index;
                var newUrl = txt_Url.Text;
                int.TryParse(cb_frekvens.SelectedItem.ToString(), out int newInterval);
                var newCategory = cb_Kategori.SelectedItem.ToString();
                await Fm.UpdatePodProperties(selectedPodIndex, newUrl, newInterval, newCategory);
            }
          
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            Filter = txtSortCategory.Text;
            UpdatePodList();
        }

        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            Filter = "";
            txtSortCategory.Clear();
            UpdatePodList();
        }
    }
}
