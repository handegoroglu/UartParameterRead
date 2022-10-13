using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace deneme
{
    public partial class SifreDegistir : Form
    {
        Timer labelTimer = new Timer();
        public SifreDegistir()
        {
            InitializeComponent();

            //icon'u icon.ico isimli dosyadan çek
            this.Icon = Program.iconLogo;
            themaSet(Program.appSettings.thema);

            //Form ismini aldığımız yer
            this.Text = Program.appSettings.FormSifreDegistir;

            labelTimer.Interval = 1500;
            labelTimer.Tick += LabelTimer_Tick;
        }

        private void LabelTimer_Tick(object? sender, EventArgs e)
        {
            label4.Text = String.Empty;
            labelTimer.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string sifre = Properties.Settings.Default.sifre;
            string defaultsifre = Properties.Settings.Default.defaultsifre;

            if (textBox1.Text == Properties.Settings.Default.sifre || textBox1.Text == Properties.Settings.Default.defaultsifre)
            {
                if (textBox2.Text == textBox3.Text && textBox2.Text != "" && textBox3.Text != "")
                {

                    Properties.Settings.Default.sifre = textBox2.Text;
                    Properties.Settings.Default.Save();
                    label4.Text = "Şifre kaydedildi!";
                    label4.ForeColor = Color.Green;
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();



                }

                else if (textBox2.Text != textBox3.Text)
                {
                    label4.Text = "Girilen şifreler eşleşmiyor!";
                    label4.ForeColor = Color.Red;

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    int PagePositionX = this.Left;
                    Task t = Task.Run(() =>
                    {



                        for (int i = 0; i < 15; i++)
                        {
                            Thread.Sleep(20);
                            this.Invoke(() => this.Left = this.Left == PagePositionX ? PagePositionX - 5 : PagePositionX);

                        }


                        this.Invoke(() => this.Left = PagePositionX);

                    });

                }

                else if (textBox2.Text == "" || textBox3.Text == "")
                {

                    label4.Text = "Lütfen yeni şifreyi giriniz!";
                    label4.ForeColor = Color.Red;

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    int PagePositionX = this.Left;
                    Task t = Task.Run(() =>
                    {



                        for (int i = 0; i < 15; i++)
                        {
                            Thread.Sleep(20);
                            this.Invoke(() => this.Left = this.Left == PagePositionX ? PagePositionX - 5 : PagePositionX);

                        }


                        this.Invoke(() => this.Left = PagePositionX);

                    });


                }

            }
            else if (textBox1.Text != Properties.Settings.Default.sifre && textBox1.Text !="")
            {
                label4.Text = "Eski şifre doğru değil!";
                label4.ForeColor = Color.Red;

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                int PagePositionX = this.Left;
                Task t = Task.Run(() =>
                {



                    for (int i = 0; i < 15; i++)
                    {
                        Thread.Sleep(20);
                        this.Invoke(() => this.Left = this.Left == PagePositionX ? PagePositionX - 5 : PagePositionX);

                    }


                    this.Invoke(() => this.Left = PagePositionX);

                });
            }
            else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {

                label4.Text = "Lütfen şifreyi giriniz!";
                label4.ForeColor = Color.Red;

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                int PagePositionX = this.Left;
                Task t = Task.Run(() =>
                {



                    for (int i = 0; i < 15; i++)
                    {
                        Thread.Sleep(20);
                        this.Invoke(() => this.Left = this.Left == PagePositionX ? PagePositionX - 5 : PagePositionX);

                    }


                    this.Invoke(() => this.Left = PagePositionX);

                });
            }

            labelTimer.Start();
/*
            Task t = Task.Run(() =>
            {
                Thread.Sleep(1000);
                label4.Invoke(() => label4.Text = String.Empty);
            });

*/
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            //label4.Text = "";
        }

        private void SifreDegistir_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void SifreDegistir_Load(object sender, EventArgs e)
        {

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
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
