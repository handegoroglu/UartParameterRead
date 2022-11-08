using deneme.Models;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using static deneme.Program;
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

            Program.serial.DataReceived += Serial_DataReceived;
        }

        private void Serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Program.dataReceived();

            byte[]? value;
            do
            {
                value = Program.findData();
                if (value != null)
                {
                    dataProcess(value);
                }
            } while (value != null);
        }

        bool dataProcess(byte[] data)
        {
            if (data[1] >= (byte)Program.COMMUNICATION_INFO_BYTES.WEEKLY_PLAN1 && data[1] <= (byte)Program.COMMUNICATION_INFO_BYTES.WEEKLY_PLAN7)
            {//haftalık plan bir sayı olmadığı için onu sola dayalı yaptık he tama her 32 bit te 24 tane gönderiyoruz ya sen sonuncuyu 01 yapınca o yüzden birşey olmadı son 8 bit boş okii son byte boş 32tımımm

                byte[] content = new byte[4];
                Array.Copy(data, 2, content, 0, 4);

                BitArray Bitarray = new BitArray(content);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[(data[1] - (byte)Program.COMMUNICATION_INFO_BYTES.WEEKLY_PLAN1) + 1].Value = Bitarray[i];//bittiii hadi dene
                }
            }

            return true;
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

        private void WeeklyPlan_Load(object sender, EventArgs e)
        {
            /* dataProcess(new byte[]{ 0x01, (byte)Program.COMMUNICATION_INFO_BYTES.WEEKLY_PLAN1, 0x01,0x00,0x00,0x00});
             dataProcess(new byte[]{ 0x01, (byte)Program.COMMUNICATION_INFO_BYTES.WEEKLY_PLAN2, 0x01,0x00,0x00,0x00});//Göndermeye de bakalım mı yaz coolterm e
             dataProcess(new byte[]{ 0x01, (byte)Program.COMMUNICATION_INFO_BYTES.WEEKLY_PLAN3, 0x01,0x00,0x00,0x00});
             dataProcess(new byte[]{ 0x01, (byte)Program.COMMUNICATION_INFO_BYTES.WEEKLY_PLAN4, 0x01,0x00,0x00,0x00});
             dataProcess(new byte[]{ 0x01, (byte)Program.COMMUNICATION_INFO_BYTES.WEEKLY_PLAN5, 0x01,0x00,0x00,0x00});
             dataProcess(new byte[]{ 0x01, (byte)Program.COMMUNICATION_INFO_BYTES.WEEKLY_PLAN6, 0x01,0x00,0x00,0x00});
             dataProcess(new byte[]{ 0x01, (byte)Program.COMMUNICATION_INFO_BYTES.WEEKLY_PLAN7, 0x01,0x00,0x00,0x00});*/
        }

        private void WeeklyPlan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.serial.DataReceived -= Serial_DataReceived;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            Task t = Task.Run(async () =>
            {

                byte[] weeklyPlan = new byte[4];
                BitArray weeklyPlanBits = new BitArray(weeklyPlan); //baytları bitlerine böldük 


                for (byte x = 0; x < 7; x++)
                {
                    try
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {

                            try
                            {
                                weeklyPlanBits[i] = Convert.ToBoolean(dataGridView1.Rows[i].Cells[x + 1].Value);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        weeklyPlanBits.CopyTo(weeklyPlan, 0);
                        bool result = true;//okuma kısmını düzenlemedik
                        int errorCounter = 0;
                        do
                        {
                            result = await Program.sendData(1, Convert.ToByte(((byte)Program.COMMUNICATION_INFO_BYTES.WEEKLY_PLAN1) + x), weeklyPlan, true);

                        } while (result == false && errorCounter < Program.MAX_ERROR_COUNT_PER_DATA);
                    }
                    catch (Exception)
                    {
                    }
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendReadWeeklyPlanRequest();
        }

        async Task sendReadWeeklyPlanRequest()
        {
            byte[] results = new byte[] { (byte)COMMUNICATION_INFO_BYTES.WEEKLY_PLAN1, (byte)COMMUNICATION_INFO_BYTES.WEEKLY_PLAN2, (byte)COMMUNICATION_INFO_BYTES.WEEKLY_PLAN3, (byte)COMMUNICATION_INFO_BYTES.WEEKLY_PLAN4, (byte)COMMUNICATION_INFO_BYTES.WEEKLY_PLAN5, (byte)COMMUNICATION_INFO_BYTES.WEEKLY_PLAN6 };

            bool result = true;
            int errorCounter = 0;
            do
            {
                result = await Program.sendData(1, (byte)Program.COMMUNICATION_INFO_BYTES.WEEKLY_PLAN_READ, new byte[] { 0x00, 0x00, 0x00, 0x00 }, isWaitAnswer: true, results);
                errorCounter++;
            } while (result == false && errorCounter < Program.MAX_ERROR_COUNT_PER_DATA);
        }
    }



}

