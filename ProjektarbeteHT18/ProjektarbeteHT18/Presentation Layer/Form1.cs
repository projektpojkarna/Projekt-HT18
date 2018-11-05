using System;
using System.Windows.Forms;
using ProjektarbeteHT18.Business_Logic_Layer;
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
            PrintError(msg, "Något gick fel");
        }

        private void PrintError(string msg, string title)
        {
            MessageBox.Show(msg, title,
            MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string category = "";

            if (cbCategory.SelectedItem != null)
            {
                category = cbCategory.SelectedItem.ToString();
            }
           
            if (!Validator.ValidateUrl(url))
            {
                PrintError("Ange giltig Url", "Ogiltligt URL");
            }
            else if(!Validator.ValidateCategory(category))
            {
                PrintError("Ange en kategori", "Ingen kategori valt");
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
            var catToAdd = txtCategory.Text;
            if (Validator.ValidateCategory(catToAdd))
            {
                PodManager.CategoryList.Add(new Category(catToAdd));
                UpdateCategory();
                txtCategory.Clear();
            }
            else
            {
                PrintError("Giltigt kategorinamn innehåller minst 3 tecken och kan innehålla både bokstäver " +
                    "eller siffror. Inga specialtecken", "Felaktigt kategorinamn");
            }

        }

        private void btnSaveCategoryDetails_Click(object sender, EventArgs e)
        {
            string selectedCat = lvCategories.FocusedItem != null ? lvCategories.FocusedItem.Text : "";
            var newCatName = txtCategory.Text;
            if (!Validator.ValidateCategory(newCatName))
            {
                PrintError("Giltigt kategorinamn innehåller minst 3 tecken och kan innehålla både bokstäver " +
                    "eller siffror. Inga specialtecken.", "Felaktigt kategorinamn");
            }
            else if(String.IsNullOrEmpty(selectedCat))
            {
                PrintError("För att spara ändringar i en kategori måste du först välja" +
                    "en kattegori i listan.", "Välj en kategori");
            }
            else
            {
                PodManager.RenameCategory(selectedCat, newCatName);
                UpdateCategory();
                txtCategory.Clear();
            }
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
