using deneme.Models;
using Microsoft.Office.Interop.Excel;
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
                var serialSettings = Program.readObjectJson<SerialPortSettings>(Program.defaulserialPortSettings);
                comboBox1.Text = serialSettings.port;
                comboBox2.Text = serialSettings.baudrate.ToString();
            }
            catch (Exception)
            {
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
            if (Program.serial.IsOpen == false)
            {
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
                    label1.Text = "Bağlantı Açık.";

                   

                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata:" + hata.Message);
                }
            }
            else
            {
                label1.Text = "Bağlantı Zaten Açık!";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //BAĞLANTIYI KES BUTONU
            timer1.Stop();
            if (Program.serial.IsOpen == true)
            {
                Program.serial.Close();
                label1.BackColor = Color.Transparent;
                label1.ForeColor = Color.Red;
                label1.Text = "Bağlantı Kapalı.";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SerialPortSettings portSettings = new SerialPortSettings();
            portSettings.baudrate = Convert.ToInt32(comboBox2.Text);
            portSettings.port = comboBox1.Text.ToString();

            Program.saveObjectJson<SerialPortSettings>(portSettings, Program.defaulserialPortSettings);

            //kaydet butonuyla Form2'yi kapatıyoruz.
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //resim kutusuna dokununca url ye gidecek.
            System.Diagnostics.Process.Start("explorer.exe", @"https://hosseven.com.tr/");
        }
    }
}
