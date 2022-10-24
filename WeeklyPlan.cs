using deneme.Models;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deneme
{
    public partial class WeeklyPlan : Form
    {
        List<WeeklyPlanDays> weeklyPlanDays = new List<WeeklyPlanDays>();
        List<WeeklyPlanMidWeek> weeklyPlanMidWeek = new List<WeeklyPlanMidWeek>();
        List<WeeklyPlanWeekEnd> weeklyPlanWeekEnd = new List<WeeklyPlanWeekEnd>();

        public WeeklyPlan()
        {
            InitializeComponent();
            /*
            tabPage1.BackColor = Color.Black;
            tabPage2.BackColor= Color.Black;
            tabPage3.BackColor= Color.Black;
            */

            //dosyadan parametre okuyor
            weeklyPlanDays = Program.readObjectJson<List<WeeklyPlanDays>>(Program.weeklyPlanDaysPath);
            tablefill(weeklyPlanDays);

            weeklyPlanMidWeek = Program.readObjectJson<List<WeeklyPlanMidWeek>>(Program.weeklyPlanMidWeekPath);
            tablefill(weeklyPlanMidWeek);

            weeklyPlanWeekEnd = Program.readObjectJson<List<WeeklyPlanWeekEnd>>(Program.weeklyPlanWeekEndPath);
            tablefill(weeklyPlanWeekEnd);




        }
        void tablefill(List<WeeklyPlanDays> weeklyPlanDays)
        {
            dataGridView1.Rows.Clear();

            foreach (var weeklyPlanDay in weeklyPlanDays)
            {
                object[] values = new object[] { weeklyPlanDay.Saat, weeklyPlanDay.Pazartesi, weeklyPlanDay.Salı, weeklyPlanDay.Çarşamba, weeklyPlanDay.Perşembe, weeklyPlanDay.Cuma, weeklyPlanDay.Cumartesi, weeklyPlanDay.Pazar };
                dataGridView1.Rows.Add(values);
               
            }


            dataGridView1.Refresh();
            dataGridView1.RefreshEdit();
        }
        void tablefill(List<WeeklyPlanMidWeek> weeklyPlanMidWeek)
        {
            dataGridView4.Rows.Clear();

            foreach (var weeklyPlanMidWek in weeklyPlanMidWeek)
            {
                object[] values = new object[] { weeklyPlanMidWek.Saat, weeklyPlanMidWek.Pazartesi};
                dataGridView4.Rows.Add(values);

            }


            dataGridView4.Refresh();
            dataGridView4.RefreshEdit();
        }
        void tablefill(List<WeeklyPlanWeekEnd> weeklyPlanWeekEnd)
        {
            dataGridView3.Rows.Clear();

            foreach (var weeklyPlanWekEnd in weeklyPlanWeekEnd)
            {
                object[] values = new object[] { weeklyPlanWekEnd.Saat, weeklyPlanWekEnd.Cumartesi};
                dataGridView3.Rows.Add(values);

            }


            dataGridView3.Refresh();
            dataGridView3.RefreshEdit();
        }

        private void WeeklyPlan_Load(object sender, EventArgs e)
        {

            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
