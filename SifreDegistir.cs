﻿using System;
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

            labelTimer.Interval = 1000;
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

                }

                else if (textBox2.Text == "" || textBox3.Text == "")
                {

                    label4.Text = "Lütfen şifre giriniz!";
                    label4.ForeColor = Color.Red;

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();


                }

            }
            else
            {
                if (textBox1.Text != Properties.Settings.Default.sifre && textBox1.Text != "")
                {
                    label4.Text = "Eski şifre doğru değil!";
                    label4.ForeColor = Color.Red;

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();

                }
                else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {

                    label4.Text = "Lütfen şifre giriniz!";
                    label4.ForeColor = Color.Red;

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();

                }



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
            label4.Text = "";
        }
    }
}