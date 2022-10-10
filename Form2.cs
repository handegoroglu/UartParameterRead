using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deneme
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Form2'yi sağ alt köşede başlatma
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
           
            //şifre arayüzünü aç
            Hosseven sifre = new Hosseven();

            if (sifre.ShowDialog() == DialogResult.Yes)
            {

                //şifre doğru ise
                Form1 parametrearayüz = new Form1();
                parametrearayüz.ShowDialog();
                
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Comport aç
            ComPortForm comPortForm = new ComPortForm(Program.serial);
            comPortForm.ShowDialog();

        }

    }
}
