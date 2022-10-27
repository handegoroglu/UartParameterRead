using deneme.Models;
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
using Exception = System.Exception;

namespace deneme
{
    public partial class WeeklyPlan : Form
    {
        List<WeeklyPlanDays> weeklyPlanDays = new List<WeeklyPlanDays>();

        public WeeklyPlan()
        {
            InitializeComponent();

            //Form ismini aldığımız yer
            this.Text = Program.appSettings?.WeeklyPlanTitle;

            //icon'u icon.ico isimli dosyadan çek
            this.Icon = Program.iconLogo;

            //dosyadan parametre okuyor
            weeklyPlanDays = Program.readObjectJson<List<WeeklyPlanDays>>(Program.weeklyPlanDaysPath);

            tablefill(weeklyPlanDays);

            themaSet(Program.appSettings?.thema);
        }
        const int DATA_PACKET_LEN = 11;
        const int ACK_WAIT_TIMEOUT = 2000;
        const int MAX_ERROR_COUNT_PER_DATA = 3;
        bool isReceiveAck = false;

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
                dataGridView1.BackgroundColor = Color.Black; dataGridView1.BorderStyle = BorderStyle.None;
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
            //haftasonunu seçince diğer checkboxlarıda işaretle
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

            //haftaiçini seçince diğer checkboxlarıda işaretle
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
            //haftaiçini seçtikten sonra günlerden birinin tik işaretini kaldırırsak haftaiçi seçimi silinsin

            if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                bool a = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                bool b = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                bool c = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                bool d = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                bool f = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                if (a == false || b == false || c == false || d == false || f == false)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[8].Value = false;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[8].Value = true;
                }

            }
            //haftasonu seçtikten sonra günlerden birinin tik işaretini kaldırırsak haftasonu seçimi silinsin
            if (e.ColumnIndex == 6 || e.ColumnIndex == 7)
            {
                bool a = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
                bool b = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
                if (a == false || b == false)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[9].Value = false;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[9].Value = true;
                }

            }
        }



        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            //datagrid ilk açılışta hücre seçimini kapat
            dataGridView1.ClearSelection();

        }


        private byte checksum_calculate(byte[] array, int len)
        {
            int checksum_total = 0;

            for (int i = 0; i < len; i++)
            {
                checksum_total += array[i];
            }

            checksum_total = ((checksum_total ^ 255) + 1);


            if (BitConverter.IsLittleEndian)//Big endian
                return BitConverter.GetBytes(checksum_total)[0];
            else
                return BitConverter.GetBytes(checksum_total)[3];
        }


    }



}

