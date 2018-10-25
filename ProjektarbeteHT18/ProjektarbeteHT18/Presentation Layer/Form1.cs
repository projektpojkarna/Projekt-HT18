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
        CategoryList CategoryList;

        public Form1()
        {
            b = new Buisiness();
            CategoryList = new CategoryList();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void UpdateCategory()
        {
            lv_Categories.Items.Clear();
            cb_Kategori.Items.Clear();
            foreach (string c in CategoryList)
            {
             
                ListViewItem lvItem = new ListViewItem(new[] { c });
                
                lv_Categories.Items.Add(lvItem);
                cb_Kategori.Items.Add(c);
            }

        }

        private void UpdateList()
        {
            foreach (PodCastFeed p in b.PodCastFeedList)
            {
                string numberOfEpisodes = p.Episodes.Count.ToString();
                ListViewItem lvItem = new ListViewItem(new[] { numberOfEpisodes, p.Name });
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
            
        }

        private void btn_NyKategori_Click(object sender, EventArgs e)
        {
           
                CategoryList.AddCategory(txt_Category.Text);
                UpdateCategory();
                txt_Category.Clear();
            
        }

        private void cb_Kategori_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lv_Categories_SelectedIndexChanged(object sender, EventArgs e)
        {
           string selected = lv_Categories.FocusedItem.Text;
            txt_Category.Text = selected;
        }

        private void btn_TaBortKategori_Click(object sender, EventArgs e)
        {
            string selected = lv_Categories.FocusedItem.Text;
            CategoryList.RemoveCategory(selected);
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
    }
}
