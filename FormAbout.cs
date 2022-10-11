using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            label1.Text = "V" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //resim kutusuna dokununca url ye gidecek.
            System.Diagnostics.Process.Start("explorer.exe", Program.appSettings.manufactureWebSite);
        }
    }
}
