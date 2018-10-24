using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProjektarbeteHT18
{
    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            async Task<string> AccessTheWebAsync()
            {
                // You need to add a reference to System.Net.Http to declare client.  
                HttpClient client = new HttpClient();

                // GetStringAsync returns a Task<string>. That means that when you await the  
                // task you'll get a string (urlContents).  

                string url = await client.GetStringAsync("https://rss.acast.com/cafekampen");


                // You can do work here that doesn't rely on the string from GetStringAsync.  
                DoIndependentWork();

                // The await operator suspends AccessTheWebAsync.  
                //  - AccessTheWebAsync can't continue until getStringTask is complete.  
                //  - Meanwhile, control returns to the caller of AccessTheWebAsync.  
                //  - Control resumes here when getStringTask is complete.   
                //  - The await operator then retrieves the string result from getStringTask.  



                // The return statement specifies an integer result.  
                // Any methods that are awaiting AccessTheWebAsync retrieve the length value.  
                return url;
            }
        }

        public void DoIndependentWork()

        {

            lv_Podcast.Items.Add(AccessTheWebAsync().Result);

        }



        private void btn_NyPodcast_Click(object sender, EventArgs e)
        {

        }



    }
    
}
