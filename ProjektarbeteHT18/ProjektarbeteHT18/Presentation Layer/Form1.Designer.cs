﻿namespace ProjektarbeteHT18
{
    partial class Form1
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
            this.lv_Kategorier = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.lv_PodcastAvsnitt = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_PodcastAvsnitt = new System.Windows.Forms.Label();
            this.lb_PodcastInfo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_Podcast = new System.Windows.Forms.Label();
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
            this.lv_Podcast.Location = new System.Drawing.Point(12, 12);
            this.lv_Podcast.Name = "lv_Podcast";
            this.lv_Podcast.Size = new System.Drawing.Size(674, 167);
            this.lv_Podcast.TabIndex = 0;
            this.lv_Podcast.UseCompatibleStateImageBehavior = false;
            this.lv_Podcast.View = System.Windows.Forms.View.Details;
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
            this.btn_NyPodcast.Location = new System.Drawing.Point(368, 252);
            this.btn_NyPodcast.Name = "btn_NyPodcast";
            this.btn_NyPodcast.Size = new System.Drawing.Size(102, 35);
            this.btn_NyPodcast.TabIndex = 1;
            this.btn_NyPodcast.Text = "Ny...";
            this.btn_NyPodcast.UseVisualStyleBackColor = true;
            this.btn_NyPodcast.Click += new System.EventHandler(this.btn_NyPodcast_Click);
            // 
            // lv_Kategorier
            // 
            this.lv_Kategorier.Location = new System.Drawing.Point(744, 32);
            this.lv_Kategorier.Name = "lv_Kategorier";
            this.lv_Kategorier.Size = new System.Drawing.Size(316, 131);
            this.lv_Kategorier.TabIndex = 2;
            this.lv_Kategorier.UseCompatibleStateImageBehavior = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(744, 179);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(316, 26);
            this.textBox1.TabIndex = 3;
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
            // 
            // txt_Url
            // 
            this.txt_Url.Location = new System.Drawing.Point(12, 222);
            this.txt_Url.Multiline = true;
            this.txt_Url.Name = "txt_Url";
            this.txt_Url.Size = new System.Drawing.Size(290, 24);
            this.txt_Url.TabIndex = 7;
            // 
            // cb_frekvens
            // 
            this.cb_frekvens.FormattingEnabled = true;
            this.cb_frekvens.Location = new System.Drawing.Point(333, 222);
            this.cb_frekvens.Name = "cb_frekvens";
            this.cb_frekvens.Size = new System.Drawing.Size(169, 24);
            this.cb_frekvens.TabIndex = 8;
            // 
            // cb_Kategori
            // 
            this.cb_Kategori.FormattingEnabled = true;
            this.cb_Kategori.Location = new System.Drawing.Point(525, 219);
            this.cb_Kategori.Name = "cb_Kategori";
            this.cb_Kategori.Size = new System.Drawing.Size(161, 24);
            this.cb_Kategori.TabIndex = 9;
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
            this.label2.Location = new System.Drawing.Point(330, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Uppdateringsfrekvens";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.4F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(522, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Kategori";
            // 
            // btn_TaBortPodcast
            // 
            this.btn_TaBortPodcast.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TaBortPodcast.Location = new System.Drawing.Point(584, 252);
            this.btn_TaBortPodcast.Name = "btn_TaBortPodcast";
            this.btn_TaBortPodcast.Size = new System.Drawing.Size(102, 35);
            this.btn_TaBortPodcast.TabIndex = 13;
            this.btn_TaBortPodcast.Text = "Ta bort...";
            this.btn_TaBortPodcast.UseVisualStyleBackColor = true;
            // 
            // btn_SparaPodcast
            // 
            this.btn_SparaPodcast.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SparaPodcast.Location = new System.Drawing.Point(476, 252);
            this.btn_SparaPodcast.Name = "btn_SparaPodcast";
            this.btn_SparaPodcast.Size = new System.Drawing.Size(102, 35);
            this.btn_SparaPodcast.TabIndex = 14;
            this.btn_SparaPodcast.Text = "Spara";
            this.btn_SparaPodcast.UseVisualStyleBackColor = true;
            // 
            // lv_PodcastAvsnitt
            // 
            this.lv_PodcastAvsnitt.Location = new System.Drawing.Point(16, 318);
            this.lv_PodcastAvsnitt.Name = "lv_PodcastAvsnitt";
            this.lv_PodcastAvsnitt.Size = new System.Drawing.Size(486, 164);
            this.lv_PodcastAvsnitt.TabIndex = 15;
            this.lv_PodcastAvsnitt.UseCompatibleStateImageBehavior = false;
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
            this.lb_PodcastAvsnitt.Location = new System.Drawing.Point(739, 306);
            this.lb_PodcastAvsnitt.Name = "lb_PodcastAvsnitt";
            this.lb_PodcastAvsnitt.Size = new System.Drawing.Size(70, 25);
            this.lb_PodcastAvsnitt.TabIndex = 18;
            this.lb_PodcastAvsnitt.Text = "label6";
            // 
            // lb_PodcastInfo
            // 
            this.lb_PodcastInfo.AutoSize = true;
            this.lb_PodcastInfo.Location = new System.Drawing.Point(741, 359);
            this.lb_PodcastInfo.Name = "lb_PodcastInfo";
            this.lb_PodcastInfo.Size = new System.Drawing.Size(46, 17);
            this.lb_PodcastInfo.TabIndex = 19;
            this.lb_PodcastInfo.Text = "label7";
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
            this.lb_Podcast.Location = new System.Drawing.Point(17, 295);
            this.lb_Podcast.Name = "lb_Podcast";
            this.lb_Podcast.Size = new System.Drawing.Size(52, 17);
            this.lb_Podcast.TabIndex = 21;
            this.lb_Podcast.Text = "label7";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 494);
            this.Controls.Add(this.lb_Podcast);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lb_PodcastInfo);
            this.Controls.Add(this.lb_PodcastAvsnitt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lv_PodcastAvsnitt);
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
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lv_Kategorier);
            this.Controls.Add(this.btn_NyPodcast);
            this.Controls.Add(this.lv_Podcast);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.ListView lv_Kategorier;
        private System.Windows.Forms.TextBox textBox1;
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
        private System.Windows.Forms.ListView lv_PodcastAvsnitt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_PodcastAvsnitt;
        private System.Windows.Forms.Label lb_PodcastInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_Podcast;
    }
}

