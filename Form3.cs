using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Point = System.Drawing.Point;
using Rectangle = System.Drawing.Rectangle;

namespace deneme
{
    public partial class Hosseven : Form
    {
        
        public Hosseven()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "123")
            {
                //şifre doğru ise


                this.DialogResult = DialogResult.Yes;

                this.Close();
            }
            else
            {

                //şifre yanlış 
                label2.Text = "Hatalı Giriş";
                label2.ForeColor = Color.Red;
                timer1.Start();
                textBox1.Clear();


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

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Hatalı giriş mesajını belli süre sonra kaldırma
            label2.Text = "";
            timer1.Stop();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //şifreyi * ile gizleme
            textBox1.UseSystemPasswordChar = true;
        }
    }
}
