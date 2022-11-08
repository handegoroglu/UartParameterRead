using Microsoft.Office.Interop.Outlook;
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
using static deneme.Program;

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

            Program.serial.DataReceived += Serial_DataReceived; ;

        }

        private void Serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Program.dataReceived();

            byte[]? value;
            do
            {
                value = Program.findData();
            } while (value != null);
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


        private void button7_Click(object sender, EventArgs e)
        {

            //şifre arayüzünü aç
            FormPassword sifre = new FormPassword();

            if (sifre.ShowDialog() == DialogResult.Yes)
            {

                Program.serial.DataReceived -= Serial_DataReceived;
                //şifre doğru ise
                FormService parametrearayüz = new FormService();
                parametrearayüz.ShowDialog();

                Program.serial.DataReceived += Serial_DataReceived;

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Comport aç
            ComPortForm comPortForm = new ComPortForm(Program.serial);
            comPortForm.ShowDialog();

            formEnable(Program.serial.IsOpen);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Program.serial.DataReceived -= Serial_DataReceived;
            WeeklyPlan weeklyPlan = new WeeklyPlan();
            weeklyPlan.ShowDialog();
            Program.serial.DataReceived += Serial_DataReceived;
        }
        async Task sendLevelAsync(COMMUNICATION_INFO_BYTES level)
        {
            bool result = true;
            int errorCounter = 0;
            do
            {
                result = await Program.sendData(1, (byte)level, new byte[] { 0x00, 0x00, 0x00, 0x00 }, isWaitAnswer: true);
                errorCounter++;
            } while (result == false && errorCounter < Program.MAX_ERROR_COUNT_PER_DATA);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendLevelAsync(COMMUNICATION_INFO_BYTES.LEVELOPEN);
        }

        private void kademe1_button_Click(object sender, EventArgs e)
        {
            sendLevelAsync(COMMUNICATION_INFO_BYTES.LEVEL1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sendLevelAsync(COMMUNICATION_INFO_BYTES.LEVEL2);
        }

        private void kademe3_button_Click(object sender, EventArgs e)
        {
            sendLevelAsync(COMMUNICATION_INFO_BYTES.LEVEL3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sendLevelAsync(COMMUNICATION_INFO_BYTES.LEVEL4);
        }

        private void kademe2_button_Click(object sender, EventArgs e)
        {
            sendLevelAsync(COMMUNICATION_INFO_BYTES.LEVEL5);
        }

        private void kapat_button_Click(object sender, EventArgs e)
        {
            sendLevelAsync(COMMUNICATION_INFO_BYTES.LEVEL0);
        }
    }
}
