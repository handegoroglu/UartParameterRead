using deneme.Models;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Application = System.Windows.Forms.Application;

namespace deneme
{
    public partial class ComPortForm : Form
    {
        //Port Numaralarını ports isimli diziye atıyoruz.
        string[] ports = SerialPort.GetPortNames();

        SerialPort port;

        public ComPortForm(SerialPort SP)
        {
            InitializeComponent();

            //icon'u icon.ico isimli dosyadan çek
            this.Icon = Program.iconLogo;
            //picturebox logo.png isimli dosyayı çek
            pictureBox1.Image = Program.imgLogo;
            //Form ismini aldığımız yer
            this.Text = Program.appSettings.ComPortFormTitle;


            themaSet(Program.appSettings.thema);

            port = SP;
        }

        private void ComPortForm_Load(object sender, EventArgs e)
        {
            
            foreach (string port in ports)
            {
                // Port isimlerini combobox1'de gösteriyoruz.
                comboBox1.Items.Add(port);
                comboBox1.SelectedIndex = 0;
            }
            // Baudrate'leri kendimiz combobox2'ye giriyoruz.
            comboBox2.Items.Add("2400");
            comboBox2.Items.Add("4800");
            comboBox2.Items.Add("9600");
            comboBox2.Items.Add("19200");
            comboBox2.Items.Add("115200");
            comboBox2.SelectedIndex = 2;

            //Bu esnada bağlantı yok.
            label1.Text = "Bağlantı Kapalı";


            try
            {
                var serialSettings = Program.readObjectJson<SerialPortSettings>(Program.serialPortSettingsPath);
                comboBox1.Text = serialSettings.port;
                comboBox2.Text = serialSettings.baudrate.ToString();

            }
            catch (Exception)
            {
            }

            if (Program.serial.IsOpen == true)
            {
                label1.Text = "Bağlantı açık "+ port.PortName;
                label1.ForeColor = Color.Green;
                
            }
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

        private void ComPortForm_Load(object sender, FormClosingEventArgs e)
        {
            


            // Form kapandığında Seri Port Kapatılmış Olacak.
            if (Program.serial.IsOpen == true)
            {
                Program.serial.Close();
            }


        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            timer1.Start();
            if (Program.serial.IsOpen)
            {
                Program.serial.Close();
            }

            if (comboBox1.Text == "")
                return;

            // combobox1'e zaten port isimlerini aktarmıştık.
            Program.serial.PortName = comboBox1.Text;

            //Seri Haberleşme baudrate'i combobox2 'de seçilene göre belirliyoruz.
            Program.serial.BaudRate = Convert.ToInt16(comboBox2.Text);

            try
            {
                //Haberleşme için port açılıyor
                Program.serial.Open();
                label1.ForeColor = Color.Green;
                label1.Text = "Bağlantı açık " + port.PortName;


                try
                {
                    var serialSettings = new SerialPortSettings();
                    serialSettings.port = comboBox1.Text;
                    serialSettings.baudrate = Convert.ToInt32(comboBox2.Text);
                    Program.saveObjectJson<SerialPortSettings>(serialSettings, Program.serialPortSettingsPath);
                }
                catch (Exception)
                {

                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata:" + hata.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*BAĞLANTIYI KES BUTONU
            
            */
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //resim kutusuna dokununca url ye gidecek.
            System.Diagnostics.Process.Start("explorer.exe", Program.appSettings.webSite);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
