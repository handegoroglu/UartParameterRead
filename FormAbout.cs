using MailKit.Net.Smtp;
using SendGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Threading;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.IO;


namespace deneme
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();

            //picturebox logoyu çek
            pictureBox1.Image = Program.manufactureLogo;

            //Versiyon yazdırdığımız label
            label1.Text = "Yazılım Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            label10.Text = "Donanım Version: 1.0.0.0";
            label11.Text = "Gömülü Version: 1.0.0.0";
           
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //resim kutusuna dokununca url ye gidecek.
            System.Diagnostics.Process.Start("explorer.exe", Program.appSettings.manufactureWebSite);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //resim kutusuna dokununca url ye gidecek.
            System.Diagnostics.Process.Start("explorer.exe", @"https://www.google.com/maps/place/ul.+%22General+Nikola+Genev%22+12,+1324+zh.k.+Lyulin+10,+Sofia,+Bulgaristan/@42.714982,23.2703789,17z/data=!3m1!4b1!4m5!3m4!1s0x40aa9a98936512bd:0x243f3f2621372ed8!8m2!3d42.714982!4d23.2703789");

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //resim kutusuna dokununca url ye gidecek.
            System.Diagnostics.Process.Start("explorer.exe", @"https://www.google.com/maps/place/MYSIA+Elektronik+A.%C5%9E./@40.2095943,28.927952,17z/data=!3m1!4b1!4m5!3m4!1s0x14ca11532d4bf3db:0x80e517b631d5ba4a!8m2!3d40.2095943!4d28.927952");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //resim kutusuna dokununca url ye gidecek.
            System.Diagnostics.Process.Start("explorer.exe", @"https://www.mysiaxware.com/");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("explorer.exe", @"mailto:info@mysiaelectric.com");



        }

    }
}
