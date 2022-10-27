﻿using deneme.Models;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using CheckBox = System.Windows.Forms.CheckBox;

namespace deneme
{
    public partial class WeeklyPlan : Form
    {
        List<WeeklyPlanDays> weeklyPlanDays = new List<WeeklyPlanDays>();

        public WeeklyPlan()
        {
            InitializeComponent();
            //Form ismini aldığımız yer
            this.Text = Program.appSettings.WeeklyPlanTitle;

            //icon'u icon.ico isimli dosyadan çek
            this.Icon = Program.iconLogo;

            //dosyadan parametre okuyor
            weeklyPlanDays = Program.readObjectJson<List<WeeklyPlanDays>>(Program.weeklyPlanDaysPath);
            tablefill(weeklyPlanDays);


            themaSet(Program.appSettings.thema);



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
                dataGridView1.BackgroundColor = Color.Black; dataGridView1.BorderStyle= BorderStyle.None;
                tableLayoutPanel1.BackColor = Color.Black;
                this.BackColor = Color.Black;
            }
            else
            {


                dataGridView1.BackgroundColor = Color.WhiteSmoke; dataGridView1.BorderStyle = BorderStyle.None;
                tableLayoutPanel1.BackColor = Color.WhiteSmoke;
                this.BackColor = Color.WhiteSmoke;

            }

        }

        void tablefill(List<WeeklyPlanDays> weeklyPlanDays)
        {
            /*
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            */
            dataGridView1.Rows.Clear();


            foreach (var weeklyPlanDay in weeklyPlanDays)
            {
                object[] values = new object[] { weeklyPlanDay.Saat, weeklyPlanDay.Pazartesi, weeklyPlanDay.Salı, weeklyPlanDay.Çarşamba, weeklyPlanDay.Perşembe, weeklyPlanDay.Cuma, weeklyPlanDay.Cumartesi, weeklyPlanDay.Pazar, weeklyPlanDay.Haftaiçi, weeklyPlanDay.Haftasonu };
                dataGridView1.Rows.Add(values);
                dataGridView1.AllowUserToAddRows = false; //son satırı kaldır

            }

            dataGridView1.Refresh();
            dataGridView1.RefreshEdit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                bool a = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                if (a == true)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[6].Value = true;
                    dataGridView1.Rows[e.RowIndex].Cells[7].Value = true;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[6].Value = false;
                    dataGridView1.Rows[e.RowIndex].Cells[7].Value = false;
                }
            }
            if (e.ColumnIndex == 8)
            {
                bool a = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                if (a == true)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[5].Value = true;
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value = true;
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = true;
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = true;
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value = true;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[5].Value = false;
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value = false;
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = false;
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = false;
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value = false;
                }
            }
        }

        private void WeeklyPlan_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
