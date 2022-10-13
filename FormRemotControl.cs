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
    public partial class FormRemotControl : Form
    {
        public FormRemotControl()
        {
            InitializeComponent();

            //picturebox'a logo.png isimli dosyayı çek
            pictureBox1.Image = Program.imgLogo;

            //icon'u icon.ico isimli dosyadan çek
            this.Icon = Program.iconLogo;

            formEnable(Program.serial.IsOpen);
            themaSet(Program.appSettings.thema);

            //Form ismini aldığımız yer
            this.Text = Program.appSettings.FormRemoteControlTitle;



        }

        void formEnable(bool enable)
        {
            foreach (Control x in this.Controls)
            {
                x.Enabled = enable;

            }
            baglantı_ayarbutton.Enabled = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Form2'yi sağ alt köşede başlatma
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);

        }
        void themaSet(string thema)
        {
            Program.themaSave(thema);
            if (thema == "windows_thema")
            {
                var themaIsDark = Program.ShouldSystemUseDarkMode();
                thema = themaIsDark ? "dark" : "light";
            }

            if (thema == "dark")
            {
                this.BackColor = Color.Black;
            }
            else
            {
                this.BackColor = Color.WhiteSmoke;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
           
            //şifre arayüzünü aç
            FormPassword sifre = new FormPassword();

            if (sifre.ShowDialog() == DialogResult.Yes)
            {

                //şifre doğru ise
                FormService parametrearayüz = new FormService();
                parametrearayüz.ShowDialog();
                
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Comport aç
            ComPortForm comPortForm = new ComPortForm(Program.serial);
            comPortForm.ShowDialog();

            formEnable(Program.serial.IsOpen);

        }

    }
}
