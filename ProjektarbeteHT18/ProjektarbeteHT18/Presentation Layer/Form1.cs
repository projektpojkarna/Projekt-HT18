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
        PodManager PodManager; //Hanterar kommunikation mellan UI och bakomliggande data
        string CatFilter; //Används för att filtrera pods på kategori

        public frmRSSReader()
        {
            InitializeComponent();
            //Skapa PodManager och sätt event handlers
            PodManager = PodManager.FromJsonOrDefault("jsonData.json");
            PodManager.OnPodUpdate += UpdatePodList;
            PodManager.OnError += PrintError;
            PodManager.ExceptionHandler.OnException += PrintError;
            
            //Nollställ kategorifilter
            CatFilter = "";

            //Välj standard uppdataringsdfrekvens
            cbUpdateInterval.SelectedIndex = 0;

            //Uppdatera podlistan
            UpdatePodList();
        }

        //Skriver ut felmeddelande
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

        //Uppdaterar textfältet med avsnittsdetaljer
        private void UpdateEpisodeDetails(IEpisode episode)
        {
            lbEpisodeDetails.Text = episode.Name;
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
        
        //Uppdaterar listan med podcasts       
        private void UpdatePodList()
        {
            if (lv_Podcast.InvokeRequired)
            {
                lv_Podcast.Invoke((MethodInvoker)delegate
                {
                    lv_Podcast.Items.Clear();
                    foreach (PodCast p in PodManager.PodCastList.GetAll())
                    {
                        if(p.Category.StartsWith(CatFilter, StringComparison.InvariantCultureIgnoreCase))
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
                foreach (PodCast p in PodManager.PodCastList.GetAll())
                {
                    if(p.Category.StartsWith(CatFilter, StringComparison.InvariantCultureIgnoreCase))
                    {
                        string numberOfEpisodes = (p.Episodes != null) ? p.Episodes.Count.ToString() : "0";
                        ListViewItem lvItem = new ListViewItem(new[] { numberOfEpisodes, p.Name, p.UpdateInterval.ToString(), p.Category });
                        lv_Podcast.Items.Add(lvItem);
                    }

                }
            }
        }

        //Uppdaterar kategorilistan
        private void UpdateCategory()
        {
            lvCategories.Items.Clear();
            cbCategory.Items.Clear();
            cbCategory.ResetText();

            lvCategories.Items.AddRange(PodManager.CategoryList.ToListViewItems());

            foreach (Category c in PodManager.CategoryList.GetAll())
            {
                cbCategory.Items.Add(c.CategoryName);
            }

            if(cbCategory.Items.Count >= 1)
            {
                cbCategory.SelectedIndex = 0;
            }

            cbCategory.Refresh();

        }

        //Ny podcast
        private async void btnAddNewPodCast_Click(object sender, EventArgs e)
        {
            var url = txtURL.Text;
            var category = cbCategory.SelectedItem.ToString();
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
                int.TryParse(cbUpdateInterval.SelectedItem.ToString(), out int interval);
                await PodManager.AddNewPod(url, category, interval);
            }

        }

        private void lvPodCast_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvPodCastEpisodes.Items.Clear();

            if(lv_Podcast.FocusedItem != null)
            {
                var selectedIndex = lv_Podcast.FocusedItem.Index;
                var pod = PodManager.PodCastList.Get(selectedIndex);
                txtURL.Text = pod.Url;
                cbCategory.Text = lv_Podcast.Items[selectedIndex].SubItems[3].Text;
                cbUpdateInterval.Text = lv_Podcast.Items[selectedIndex].SubItems[2].Text;
                UpdateEpisodeList(pod);
            }

        }

        private void lvEpisodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvPodCastEpisodes.FocusedItem != null && lv_Podcast.FocusedItem != null)
            {
                var selectedPodIndex = lv_Podcast.FocusedItem.Index;
                var selectedEpisodeIndex = lvPodCastEpisodes.FocusedItem.Index;
                var pod = PodManager.PodCastList.Get(selectedPodIndex);
                var episode = pod.Episodes.Get(selectedEpisodeIndex);
                UpdateEpisodeDetails(episode);
            }
        }

        private void btnAddNewCategory_Click(object sender, EventArgs e)
        {
            PodManager.CategoryList.Add(new Category(txtCategory.Text));
            UpdateCategory();
            txtCategory.Clear();
        }

        private void btnSaveCategoryDetails_Click(object sender, EventArgs e)
        {
            string selected = lvCategories.FocusedItem.Text;
            PodManager.CategoryList.Rename(selected, txtCategory.Text);

            UpdateCategory();
            txtCategory.Clear();
        }

        private void lvCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvCategories.FocusedItem != null)
            {
                string selected = lvCategories.FocusedItem.Text;
                txtCategory.Text = selected;
            }
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            if(lvCategories.FocusedItem != null)
            {
                string selected = lvCategories.FocusedItem.Text;
                PodManager.RemoveCategory(selected);
                UpdateCategory();
            }

        }

        private void frmRSSReader_FormClosing(object sender, FormClosingEventArgs e)
        {
            PodManager.Serialize();
        }

        private async void btnRemovePod_Click(object sender, EventArgs e)
        {
            await PodManager.RemovePod(txtURL.Text);
        }

        private async void btnSavePodDetails_Click(object sender, EventArgs e)
        {
            if(lv_Podcast.FocusedItem != null)
            {
                var selectedPodIndex = lv_Podcast.FocusedItem.Index;
                var newUrl = txtURL.Text;
                int.TryParse(cbUpdateInterval.SelectedItem.ToString(), out int newInterval);
                var newCategory = cbCategory.SelectedItem.ToString();
                await PodManager.UpdatePodProperties(selectedPodIndex, newUrl, newInterval, newCategory);
            }
          
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            CatFilter = txtSortCategory.Text;
            UpdatePodList();
        }

        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            CatFilter = "";
            txtSortCategory.Clear();
            UpdatePodList();
        }
    }
}
