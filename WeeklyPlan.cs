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
        public WeeklyPlan()
        {
            InitializeComponent();
            string günler = "Günler ";
            TabPage myTabPage1 = new TabPage(günler);
            tabControl1.TabPages.Add(myTabPage1);

            string haftaIçi = "Hafta İçi ";
            TabPage myTabPage2 = new TabPage(haftaIçi);
            tabControl1.TabPages.Add(myTabPage2);

            string haftaSonu = "Hafta Sonu ";
            TabPage myTabPage3 = new TabPage(haftaSonu);
            tabControl1.TabPages.Add(myTabPage3);

            myTabPage1.BackColor = Color.Black;
            myTabPage2.BackColor = Color.Black;
            myTabPage3.BackColor = Color.Black;



                

        }

        private void WeeklyPlan_Load(object sender, EventArgs e)
        {

            
        }
    }
}
