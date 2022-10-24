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

        private void WeeklyPlan_Load(object sender, EventArgs e)
        {

            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
