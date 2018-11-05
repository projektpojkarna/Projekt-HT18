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
            this.btnAddNewPod = new System.Windows.Forms.Button();
            this.lvCategories = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.btnAddeNewCategory = new System.Windows.Forms.Button();
            this.btnSaveCategoryChanges = new System.Windows.Forms.Button();
            this.btnRemoveCategory = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.cbUpdateInterval = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRemovePod = new System.Windows.Forms.Button();
            this.btnSavePodProperties = new System.Windows.Forms.Button();
            this.lvPodCastEpisodes = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbCategorys = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbEpisodeDetails = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbPodCast = new System.Windows.Forms.Label();
            this.txtEpisodeDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFilterCategory = new System.Windows.Forms.Button();
            this.txtSortCategory = new System.Windows.Forms.TextBox();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.btnRemoveFilter = new System.Windows.Forms.Button();
            this.grpFilter.SuspendLayout();
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
            this.lv_Podcast.SelectedIndexChanged += new System.EventHandler(this.lvPodCast_SelectedIndexChanged);
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
            // btnAddNewPod
            // 
            this.btnAddNewPod.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewPod.Location = new System.Drawing.Point(12, 252);
            this.btnAddNewPod.Name = "btnAddNewPod";
            this.btnAddNewPod.Size = new System.Drawing.Size(102, 35);
            this.btnAddNewPod.TabIndex = 1;
            this.btnAddNewPod.Text = "Ny...";
            this.btnAddNewPod.UseVisualStyleBackColor = true;
            this.btnAddNewPod.Click += new System.EventHandler(this.btnAddNewPodCast_Click);
            // 
            // lvCategories
            // 
            this.lvCategories.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6});
            this.lvCategories.FullRowSelect = true;
            this.lvCategories.Location = new System.Drawing.Point(744, 32);
            this.lvCategories.MultiSelect = false;
            this.lvCategories.Name = "lvCategories";
            this.lvCategories.Size = new System.Drawing.Size(316, 131);
            this.lvCategories.TabIndex = 2;
            this.lvCategories.UseCompatibleStateImageBehavior = false;
            this.lvCategories.View = System.Windows.Forms.View.Details;
            this.lvCategories.SelectedIndexChanged += new System.EventHandler(this.lvCategories_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Kategorinamn";
            this.columnHeader6.Width = 275;
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(744, 179);
            this.txtCategory.Multiline = true;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(316, 26);
            this.txtCategory.TabIndex = 3;
            // 
            // btnAddeNewCategory
            // 
            this.btnAddeNewCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddeNewCategory.Location = new System.Drawing.Point(744, 222);
            this.btnAddeNewCategory.Name = "btnAddeNewCategory";
            this.btnAddeNewCategory.Size = new System.Drawing.Size(102, 35);
            this.btnAddeNewCategory.TabIndex = 4;
            this.btnAddeNewCategory.Text = "Ny...";
            this.btnAddeNewCategory.UseVisualStyleBackColor = true;
            this.btnAddeNewCategory.Click += new System.EventHandler(this.btnAddNewCategory_Click);
            // 
            // btnSaveCategoryChanges
            // 
            this.btnSaveCategoryChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveCategoryChanges.Location = new System.Drawing.Point(852, 222);
            this.btnSaveCategoryChanges.Name = "btnSaveCategoryChanges";
            this.btnSaveCategoryChanges.Size = new System.Drawing.Size(102, 35);
            this.btnSaveCategoryChanges.TabIndex = 5;
            this.btnSaveCategoryChanges.Text = "Spara";
            this.btnSaveCategoryChanges.UseVisualStyleBackColor = true;
            this.btnSaveCategoryChanges.Click += new System.EventHandler(this.btnSaveCategoryDetails_Click);
            // 
            // btnRemoveCategory
            // 
            this.btnRemoveCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveCategory.Location = new System.Drawing.Point(960, 222);
            this.btnRemoveCategory.Name = "btnRemoveCategory";
            this.btnRemoveCategory.Size = new System.Drawing.Size(102, 35);
            this.btnRemoveCategory.TabIndex = 6;
            this.btnRemoveCategory.Text = "Ta bort...";
            this.btnRemoveCategory.UseVisualStyleBackColor = true;
            this.btnRemoveCategory.Click += new System.EventHandler(this.btnRemoveCategory_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(12, 222);
            this.txtURL.Multiline = true;
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(318, 24);
            this.txtURL.TabIndex = 7;
            // 
            // cbUpdateInterval
            // 
            this.cbUpdateInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUpdateInterval.FormattingEnabled = true;
            this.cbUpdateInterval.Items.AddRange(new object[] {
            "5",
            "10",
            "15"});
            this.cbUpdateInterval.Location = new System.Drawing.Point(209, 325);
            this.cbUpdateInterval.Name = "cbUpdateInterval";
            this.cbUpdateInterval.Size = new System.Drawing.Size(52, 24);
            this.cbUpdateInterval.TabIndex = 8;
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbCategory.Location = new System.Drawing.Point(17, 325);
            this.cbCategory.MaxDropDownItems = 50;
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(183, 24);
            this.cbCategory.TabIndex = 9;
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
            this.label2.Location = new System.Drawing.Point(206, 305);
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
            // btnRemovePod
            // 
            this.btnRemovePod.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemovePod.Location = new System.Drawing.Point(228, 252);
            this.btnRemovePod.Name = "btnRemovePod";
            this.btnRemovePod.Size = new System.Drawing.Size(102, 35);
            this.btnRemovePod.TabIndex = 13;
            this.btnRemovePod.Text = "Ta bort...";
            this.btnRemovePod.UseVisualStyleBackColor = true;
            this.btnRemovePod.Click += new System.EventHandler(this.btnRemovePod_Click);
            // 
            // btnSavePodProperties
            // 
            this.btnSavePodProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePodProperties.Location = new System.Drawing.Point(120, 252);
            this.btnSavePodProperties.Name = "btnSavePodProperties";
            this.btnSavePodProperties.Size = new System.Drawing.Size(102, 35);
            this.btnSavePodProperties.TabIndex = 14;
            this.btnSavePodProperties.Text = "Spara";
            this.btnSavePodProperties.UseVisualStyleBackColor = true;
            this.btnSavePodProperties.Click += new System.EventHandler(this.btnSavePodDetails_Click);
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
            this.lvPodCastEpisodes.SelectedIndexChanged += new System.EventHandler(this.lvEpisodes_SelectedIndexChanged);
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
            // lbCategorys
            // 
            this.lbCategorys.AutoSize = true;
            this.lbCategorys.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategorys.Location = new System.Drawing.Point(740, 9);
            this.lbCategorys.Name = "lbCategorys";
            this.lbCategorys.Size = new System.Drawing.Size(96, 20);
            this.lbCategorys.TabIndex = 16;
            this.lbCategorys.Text = "Kategorier";
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
            // lbEpisodeDetails
            // 
            this.lbEpisodeDetails.AutoSize = true;
            this.lbEpisodeDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEpisodeDetails.Location = new System.Drawing.Point(730, 305);
            this.lbEpisodeDetails.Name = "lbEpisodeDetails";
            this.lbEpisodeDetails.Size = new System.Drawing.Size(78, 25);
            this.lbEpisodeDetails.TabIndex = 18;
            this.lbEpisodeDetails.Text = "Avsnitt";
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
            // lbPodCast
            // 
            this.lbPodCast.AutoSize = true;
            this.lbPodCast.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPodCast.Location = new System.Drawing.Point(14, 368);
            this.lbPodCast.Name = "lbPodCast";
            this.lbPodCast.Size = new System.Drawing.Size(98, 17);
            this.lbPodCast.TabIndex = 21;
            this.lbPodCast.Text = "Podcast titel";
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
            this.label7.Location = new System.Drawing.Point(267, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = ":e minut";
            // 
            // btnFilterCategory
            // 
            this.btnFilterCategory.Location = new System.Drawing.Point(217, 21);
            this.btnFilterCategory.Name = "btnFilterCategory";
            this.btnFilterCategory.Size = new System.Drawing.Size(75, 23);
            this.btnFilterCategory.TabIndex = 26;
            this.btnFilterCategory.Text = "Sortera";
            this.btnFilterCategory.UseVisualStyleBackColor = true;
            this.btnFilterCategory.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // txtSortCategory
            // 
            this.txtSortCategory.Location = new System.Drawing.Point(6, 24);
            this.txtSortCategory.Name = "txtSortCategory";
            this.txtSortCategory.Size = new System.Drawing.Size(205, 22);
            this.txtSortCategory.TabIndex = 27;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.btnRemoveFilter);
            this.grpFilter.Controls.Add(this.txtSortCategory);
            this.grpFilter.Controls.Add(this.btnFilterCategory);
            this.grpFilter.Location = new System.Drawing.Point(385, 199);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(298, 88);
            this.grpFilter.TabIndex = 28;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Sortera";
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
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEpisodeDescription);
            this.Controls.Add(this.lbPodCast);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbEpisodeDetails);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbCategorys);
            this.Controls.Add(this.lvPodCastEpisodes);
            this.Controls.Add(this.btnSavePodProperties);
            this.Controls.Add(this.btnRemovePod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.cbUpdateInterval);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btnRemoveCategory);
            this.Controls.Add(this.btnSaveCategoryChanges);
            this.Controls.Add(this.btnAddeNewCategory);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.lvCategories);
            this.Controls.Add(this.btnAddNewPod);
            this.Controls.Add(this.lv_Podcast);
            this.Name = "frmRSSReader";
            this.Text = "Lägg till en kategori först..";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRSSReader_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_Podcast;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnAddNewPod;
        private System.Windows.Forms.ListView lvCategories;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Button btnAddeNewCategory;
        private System.Windows.Forms.Button btnSaveCategoryChanges;
        private System.Windows.Forms.Button btnRemoveCategory;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.ComboBox cbUpdateInterval;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRemovePod;
        private System.Windows.Forms.Button btnSavePodProperties;
        private System.Windows.Forms.ListView lvPodCastEpisodes;
        private System.Windows.Forms.Label lbCategorys;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbEpisodeDetails;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbPodCast;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.TextBox txtEpisodeDescription;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFilterCategory;
        private System.Windows.Forms.TextBox txtSortCategory;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Button btnRemoveFilter;
    }
}

