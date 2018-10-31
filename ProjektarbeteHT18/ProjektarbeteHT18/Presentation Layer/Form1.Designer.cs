namespace ProjektarbeteHT18
{
    partial class frmRSSReader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lv_Podcast = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_NyPodcast = new System.Windows.Forms.Button();
            this.lv_Categories = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txt_Category = new System.Windows.Forms.TextBox();
            this.btn_NyKategori = new System.Windows.Forms.Button();
            this.btn_SparaKategori = new System.Windows.Forms.Button();
            this.btn_TaBortKategori = new System.Windows.Forms.Button();
            this.txt_Url = new System.Windows.Forms.TextBox();
            this.cb_frekvens = new System.Windows.Forms.ComboBox();
            this.cb_Kategori = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_TaBortPodcast = new System.Windows.Forms.Button();
            this.btn_SparaPodcast = new System.Windows.Forms.Button();
            this.lvPodCastEpisodes = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_PodcastAvsnitt = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_Podcast = new System.Windows.Forms.Label();
            this.txtEpisodeDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtSortCategory = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemoveFilter = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_Podcast
            // 
            this.lv_Podcast.BackColor = System.Drawing.Color.White;
            this.lv_Podcast.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lv_Podcast.ForeColor = System.Drawing.Color.Black;
            this.lv_Podcast.FullRowSelect = true;
            this.lv_Podcast.Location = new System.Drawing.Point(12, 12);
            this.lv_Podcast.MultiSelect = false;
            this.lv_Podcast.Name = "lv_Podcast";
            this.lv_Podcast.Size = new System.Drawing.Size(674, 167);
            this.lv_Podcast.TabIndex = 0;
            this.lv_Podcast.UseCompatibleStateImageBehavior = false;
            this.lv_Podcast.View = System.Windows.Forms.View.Details;
            this.lv_Podcast.SelectedIndexChanged += new System.EventHandler(this.lv_Podcast_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Avsnitt";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Namn";
            this.columnHeader2.Width = 220;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Frekvens";
            this.columnHeader3.Width = 180;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Kategori";
            this.columnHeader4.Width = 180;
            // 
            // btn_NyPodcast
            // 
            this.btn_NyPodcast.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NyPodcast.Location = new System.Drawing.Point(12, 252);
            this.btn_NyPodcast.Name = "btn_NyPodcast";
            this.btn_NyPodcast.Size = new System.Drawing.Size(102, 35);
            this.btn_NyPodcast.TabIndex = 1;
            this.btn_NyPodcast.Text = "Ny...";
            this.btn_NyPodcast.UseVisualStyleBackColor = true;
            this.btn_NyPodcast.Click += new System.EventHandler(this.btn_NyPodcast_Click);
            // 
            // lv_Categories
            // 
            this.lv_Categories.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6});
            this.lv_Categories.FullRowSelect = true;
            this.lv_Categories.Location = new System.Drawing.Point(744, 32);
            this.lv_Categories.MultiSelect = false;
            this.lv_Categories.Name = "lv_Categories";
            this.lv_Categories.Size = new System.Drawing.Size(316, 131);
            this.lv_Categories.TabIndex = 2;
            this.lv_Categories.UseCompatibleStateImageBehavior = false;
            this.lv_Categories.View = System.Windows.Forms.View.Details;
            this.lv_Categories.SelectedIndexChanged += new System.EventHandler(this.lv_Kategorier_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Kategorinamn";
            this.columnHeader6.Width = 275;
            // 
            // txt_Category
            // 
            this.txt_Category.Location = new System.Drawing.Point(744, 179);
            this.txt_Category.Multiline = true;
            this.txt_Category.Name = "txt_Category";
            this.txt_Category.Size = new System.Drawing.Size(316, 26);
            this.txt_Category.TabIndex = 3;
            // 
            // btn_NyKategori
            // 
            this.btn_NyKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NyKategori.Location = new System.Drawing.Point(744, 222);
            this.btn_NyKategori.Name = "btn_NyKategori";
            this.btn_NyKategori.Size = new System.Drawing.Size(102, 35);
            this.btn_NyKategori.TabIndex = 4;
            this.btn_NyKategori.Text = "Ny...";
            this.btn_NyKategori.UseVisualStyleBackColor = true;
            this.btn_NyKategori.Click += new System.EventHandler(this.btn_NyKategori_Click);
            // 
            // btn_SparaKategori
            // 
            this.btn_SparaKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SparaKategori.Location = new System.Drawing.Point(852, 222);
            this.btn_SparaKategori.Name = "btn_SparaKategori";
            this.btn_SparaKategori.Size = new System.Drawing.Size(102, 35);
            this.btn_SparaKategori.TabIndex = 5;
            this.btn_SparaKategori.Text = "Spara";
            this.btn_SparaKategori.UseVisualStyleBackColor = true;
            this.btn_SparaKategori.Click += new System.EventHandler(this.btn_SparaKategori_Click);
            // 
            // btn_TaBortKategori
            // 
            this.btn_TaBortKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TaBortKategori.Location = new System.Drawing.Point(960, 222);
            this.btn_TaBortKategori.Name = "btn_TaBortKategori";
            this.btn_TaBortKategori.Size = new System.Drawing.Size(102, 35);
            this.btn_TaBortKategori.TabIndex = 6;
            this.btn_TaBortKategori.Text = "Ta bort...";
            this.btn_TaBortKategori.UseVisualStyleBackColor = true;
            this.btn_TaBortKategori.Click += new System.EventHandler(this.btn_TaBortKategori_Click);
            // 
            // txt_Url
            // 
            this.txt_Url.Location = new System.Drawing.Point(12, 222);
            this.txt_Url.Multiline = true;
            this.txt_Url.Name = "txt_Url";
            this.txt_Url.Size = new System.Drawing.Size(318, 24);
            this.txt_Url.TabIndex = 7;
            // 
            // cb_frekvens
            // 
            this.cb_frekvens.FormattingEnabled = true;
            this.cb_frekvens.Items.AddRange(new object[] {
            "5",
            "10",
            "15"});
            this.cb_frekvens.Location = new System.Drawing.Point(217, 328);
            this.cb_frekvens.Name = "cb_frekvens";
            this.cb_frekvens.Size = new System.Drawing.Size(52, 24);
            this.cb_frekvens.TabIndex = 8;
            this.cb_frekvens.Text = "Välj frekvens...";
            // 
            // cb_Kategori
            // 
            this.cb_Kategori.FormattingEnabled = true;
            this.cb_Kategori.Location = new System.Drawing.Point(17, 325);
            this.cb_Kategori.MaxDropDownItems = 50;
            this.cb_Kategori.Name = "cb_Kategori";
            this.cb_Kategori.Size = new System.Drawing.Size(183, 24);
            this.cb_Kategori.TabIndex = 9;
            this.cb_Kategori.Text = "Lägg till en kategori först..";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Url:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.4F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(214, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Uppdatera var...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.4F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Kategori";
            // 
            // btn_TaBortPodcast
            // 
            this.btn_TaBortPodcast.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TaBortPodcast.Location = new System.Drawing.Point(228, 252);
            this.btn_TaBortPodcast.Name = "btn_TaBortPodcast";
            this.btn_TaBortPodcast.Size = new System.Drawing.Size(102, 35);
            this.btn_TaBortPodcast.TabIndex = 13;
            this.btn_TaBortPodcast.Text = "Ta bort...";
            this.btn_TaBortPodcast.UseVisualStyleBackColor = true;
            this.btn_TaBortPodcast.Click += new System.EventHandler(this.btn_TaBortPodcast_Click);
            // 
            // btn_SparaPodcast
            // 
            this.btn_SparaPodcast.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SparaPodcast.Location = new System.Drawing.Point(120, 252);
            this.btn_SparaPodcast.Name = "btn_SparaPodcast";
            this.btn_SparaPodcast.Size = new System.Drawing.Size(102, 35);
            this.btn_SparaPodcast.TabIndex = 14;
            this.btn_SparaPodcast.Text = "Spara";
            this.btn_SparaPodcast.UseVisualStyleBackColor = true;
            this.btn_SparaPodcast.Click += new System.EventHandler(this.btn_SparaPodcast_Click);
            // 
            // lvPodCastEpisodes
            // 
            this.lvPodCastEpisodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader7});
            this.lvPodCastEpisodes.FullRowSelect = true;
            this.lvPodCastEpisodes.Location = new System.Drawing.Point(13, 391);
            this.lvPodCastEpisodes.MultiSelect = false;
            this.lvPodCastEpisodes.Name = "lvPodCastEpisodes";
            this.lvPodCastEpisodes.Size = new System.Drawing.Size(670, 164);
            this.lvPodCastEpisodes.TabIndex = 15;
            this.lvPodCastEpisodes.UseCompatibleStateImageBehavior = false;
            this.lvPodCastEpisodes.View = System.Windows.Forms.View.Details;
            this.lvPodCastEpisodes.SelectedIndexChanged += new System.EventHandler(this.lv_PodcastAvsnitt_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Avsnitt";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Titel";
            this.columnHeader7.Width = 273;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(740, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Kategorier";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(713, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(3, 469);
            this.label5.TabIndex = 17;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_PodcastAvsnitt
            // 
            this.lb_PodcastAvsnitt.AutoSize = true;
            this.lb_PodcastAvsnitt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_PodcastAvsnitt.Location = new System.Drawing.Point(730, 305);
            this.lb_PodcastAvsnitt.Name = "lb_PodcastAvsnitt";
            this.lb_PodcastAvsnitt.Size = new System.Drawing.Size(70, 25);
            this.lb_PodcastAvsnitt.TabIndex = 18;
            this.lb_PodcastAvsnitt.Text = "label6";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(713, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(381, 3);
            this.label6.TabIndex = 20;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Podcast
            // 
            this.lb_Podcast.AutoSize = true;
            this.lb_Podcast.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Podcast.Location = new System.Drawing.Point(14, 368);
            this.lb_Podcast.Name = "lb_Podcast";
            this.lb_Podcast.Size = new System.Drawing.Size(52, 17);
            this.lb_Podcast.TabIndex = 21;
            this.lb_Podcast.Text = "label7";
            // 
            // txtEpisodeDescription
            // 
            this.txtEpisodeDescription.Cursor = System.Windows.Forms.Cursors.No;
            this.txtEpisodeDescription.Location = new System.Drawing.Point(735, 334);
            this.txtEpisodeDescription.Multiline = true;
            this.txtEpisodeDescription.Name = "txtEpisodeDescription";
            this.txtEpisodeDescription.ReadOnly = true;
            this.txtEpisodeDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEpisodeDescription.Size = new System.Drawing.Size(359, 139);
            this.txtEpisodeDescription.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(275, 331);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = ":e minut";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(217, 21);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 26;
            this.btnFilter.Text = "Sortera";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // txtSortCategory
            // 
            this.txtSortCategory.Location = new System.Drawing.Point(6, 24);
            this.txtSortCategory.Name = "txtSortCategory";
            this.txtSortCategory.Size = new System.Drawing.Size(205, 22);
            this.txtSortCategory.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoveFilter);
            this.groupBox1.Controls.Add(this.txtSortCategory);
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Location = new System.Drawing.Point(385, 199);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 88);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sortera";
            // 
            // btnRemoveFilter
            // 
            this.btnRemoveFilter.Location = new System.Drawing.Point(186, 53);
            this.btnRemoveFilter.Name = "btnRemoveFilter";
            this.btnRemoveFilter.Size = new System.Drawing.Size(106, 23);
            this.btnRemoveFilter.TabIndex = 28;
            this.btnRemoveFilter.Text = "Ta bort filter";
            this.btnRemoveFilter.UseVisualStyleBackColor = true;
            this.btnRemoveFilter.Click += new System.EventHandler(this.btnRemoveFilter_Click);
            // 
            // frmRSSReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 575);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEpisodeDescription);
            this.Controls.Add(this.lb_Podcast);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lb_PodcastAvsnitt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lvPodCastEpisodes);
            this.Controls.Add(this.btn_SparaPodcast);
            this.Controls.Add(this.btn_TaBortPodcast);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Kategori);
            this.Controls.Add(this.cb_frekvens);
            this.Controls.Add(this.txt_Url);
            this.Controls.Add(this.btn_TaBortKategori);
            this.Controls.Add(this.btn_SparaKategori);
            this.Controls.Add(this.btn_NyKategori);
            this.Controls.Add(this.txt_Category);
            this.Controls.Add(this.lv_Categories);
            this.Controls.Add(this.btn_NyPodcast);
            this.Controls.Add(this.lv_Podcast);
            this.Name = "frmRSSReader";
            this.Text = "Lägg till en kategori först..";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRSSReader_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_Podcast;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btn_NyPodcast;
        private System.Windows.Forms.ListView lv_Categories;
        private System.Windows.Forms.TextBox txt_Category;
        private System.Windows.Forms.Button btn_NyKategori;
        private System.Windows.Forms.Button btn_SparaKategori;
        private System.Windows.Forms.Button btn_TaBortKategori;
        private System.Windows.Forms.TextBox txt_Url;
        private System.Windows.Forms.ComboBox cb_frekvens;
        private System.Windows.Forms.ComboBox cb_Kategori;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_TaBortPodcast;
        private System.Windows.Forms.Button btn_SparaPodcast;
        private System.Windows.Forms.ListView lvPodCastEpisodes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_PodcastAvsnitt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_Podcast;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.TextBox txtEpisodeDescription;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox txtSortCategory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemoveFilter;
    }
}

