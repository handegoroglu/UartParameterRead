using deneme.Models;
using ExcelDataReader;
using Newtonsoft.Json;
using System.Data;
using System.IO.Ports;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using System.Runtime.InteropServices;
using System.IO;
using Newtonsoft.Json.Linq;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.ApplicationModel.Store.Preview;
using System.Diagnostics;
using System.ComponentModel;
using Microsoft.Office.Interop.Outlook;
using Application = System.Windows.Forms.Application;
using Exception = System.Exception;
using System;
using static deneme.Program;

namespace deneme
{
    public partial class FormService : Form
    {
        System.Windows.Forms.Timer requesteRuntimeParametersTimer = new System.Windows.Forms.Timer();
        bool isFormClosing = false;


        private int receiveCounter1;

        public int GetreceiveCounter()
        {
            return receiveCounter1;
        }
        const int TABLE_MAX_PARAMATER_INDEX = 32;
        public void SetreceiveCounter(int value)
        {
            receiveCounter1 = value;

            lbl_communicationCounter.Invoke(() =>
            {
                lbl_communicationCounter.Text = value.ToString() + "/" + TABLE_MAX_PARAMATER_INDEX;
            });
        }

        private int transmitCounter1;

        public int GettransmitCounter()
        {
            return transmitCounter1;
        }

        public void SettransmitCounter(int value)
        {
            transmitCounter1 = value;

            lbl_communicationCounter.Invoke(() =>
            {
                lbl_communicationCounter.Text = value.ToString() + "/" + TABLE_MAX_PARAMATER_INDEX;
            });
        }

        List<Parameter> parameters = new List<Parameter>();


        public FormService()
        {
            InitializeComponent();

            requesteRuntimeParametersTimer.Tick += requesteRuntimeParametersTimer_Tick;
            requesteRuntimeParametersTimer.Interval = 10000;
            requesteRuntimeParametersTimer.Start();

            //Form ismini aldığımız yer
            this.Text = Program.appSettings.ServiceFormTitle;

            //icon'u icon.ico isimli dosyadan çek
            this.Icon = Program.iconLogo;

            //picturebox logo.png isimli dosyayı çek
            pictureBox1.Image = Program.imgLogo;

            //dosyadan parametre okuyor
            parameters = Program.readObjectJson<List<Parameter>>(Program.defaultParametersPath);

            //Eski modelde oluşturduklarımız otomatik gelmesin diye 
            dataGridView1.AutoGenerateColumns = false;
            tablefill(parameters);

             

            Program.serial.DataReceived += SerialPort_DataReceived;


            themaSet(Program.appSettings.thema);

            //byte[] array = new byte[] { 0x48, 0x4E, 0x44, 0x01, 0xCB, 0x00, 0x00, 0x00, 0x00, 0x55 };
            //byte checksum = Program.checksum_calculate(array, array.Length);

            

        }

        private void requesteRuntimeParametersTimer_Tick(object? sender, EventArgs e)
        {
            Program.sendData(1, (byte)Program.COMMUNICATION_INFO_BYTES.READ_RUNTIME_PARAMATERS, new byte[] { });//okeyy
        }




        // 0x01, 0x03, 0x48, 0x4E, 0x44, 0x01, 0x30, 0x00, 0x01, 0x02, 0x03, 'U', 0x01, 0x48, 0x4E, 0x44, 0x01, 0x30, 0x00, 0x01, 0x02, 0x03, 'U'



        int receiveCounter = 0;
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
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

        const byte TABLE_MAX_PARAMATER_NUMBER = 48;


        bool dataProcess(byte[] data)
        {
            byte[] valueArray = new byte[4];
            Array.Copy(data, 2, valueArray, 0, 4);

            if (data[1] >= 1 && data[1] <= TABLE_MAX_PARAMATER_NUMBER)
            {
                object? value = null;

                if (BitConverter.IsLittleEndian)//Big endian
                {
                    Array.Reverse(valueArray);
                }

                if (data[1] == 4 || data[1] == 5 || data[1] == 6 || data[1] == 7 || data[1] == 9 || data[1] == 43)
                {
                    value = BitConverter.ToSingle(valueArray);
                }
                else
                {
                    value = BitConverter.ToInt32(valueArray);
                }

                tableSetUSerValueByCode(data[1], value);

                SetreceiveCounter(GetreceiveCounter() + 1);
            }
            else if (data[1] == (byte)COMMUNICATION_INFO_BYTES.AMBIENT_TEMPERATURE)
            {
                RunTimeParamaters.AmbientTemperature = BitConverter.ToSingle(valueArray);
                UpdateRuntimeValues();
            }
            else if (data[1] == (byte)COMMUNICATION_INFO_BYTES.EXHAUST_GAS_TEMPERATURE)
            {
                RunTimeParamaters.ExhaustGasTemperature = BitConverter.ToSingle(valueArray);
                UpdateRuntimeValues();
            }
            else if (data[1] == (byte)COMMUNICATION_INFO_BYTES.ROOM_FAN_SPEED)
            {
                RunTimeParamaters.RoomFanSpeed = BitConverter.ToUInt16(valueArray);
                UpdateRuntimeValues();
            }
            else if (data[1] == (byte)COMMUNICATION_INFO_BYTES.EXHAUST_FAN_SPEED)
            {
                RunTimeParamaters.ExhaustFanSpeed = BitConverter.ToUInt16(valueArray);
                UpdateRuntimeValues();
            }
            else if (data[1] == (byte)COMMUNICATION_INFO_BYTES.DURATION)
            {
                RunTimeParamaters.Duration = BitConverter.ToUInt16(valueArray);
                UpdateRuntimeValues();
            }
            else if (data[1] == (byte)COMMUNICATION_INFO_BYTES.IGNITION_PHASE_NAME)
            {
                if (BitConverter.IsLittleEndian)//Big endian
                {
                    RunTimeParamaters.IgnitionPhaseName = valueArray[0];
                }
                else
                {
                    RunTimeParamaters.IgnitionPhaseName = valueArray[1];
                }
                UpdateRuntimeValues();
            }
            else if (data[1] == (byte)COMMUNICATION_INFO_BYTES.ERROR_STATUS)
            {
                if (BitConverter.IsLittleEndian)//Big endian
                {
                    RunTimeParamaters.ErrorStatus = valueArray[0];
                }
                else
                {
                    RunTimeParamaters.ErrorStatus = valueArray[3];
                }
                UpdateRuntimeValues();
            }


            return true;
        }

        private byte getParameterCode(int rowNo)
        {
            string? codeStr = dataGridView1.Rows[rowNo].Cells[0].Value.ToString();
            codeStr = codeStr.Trim('#').Trim('*');
            return Convert.ToByte(codeStr.Substring(2, codeStr.Length - 2));
        }

        void tableSetUSerValueByCode(byte code, object value)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++) //son satır boşya ona hata veriyormuş. dataGridView1.Rows.Count -> dataGridView1.Rows.Count - 1 yaptım
            {
                try
                {
                    byte paramaterCode = getParameterCode(i);
                    if (paramaterCode == code)
                    {

                        dataGridView1.Rows[i].Cells[6].Value = value;
                    }


                }
                catch (Exception)
                {
                }
            }
        }

        void tablefill(List<Parameter> parameters)
        {
            /*
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            */
            dataGridView1.Rows.Clear();

            foreach (var parameter in parameters)
            {
                object[] values = new object[] { parameter.Code, parameter.Description, parameter.MinValue, parameter.MaxValue, parameter.DefaultValue, parameter.Unit, parameter.Value };
                dataGridView1.Rows.Add(values);
                dataGridView1.AllowUserToAddRows = false; //son satırı kaldır
            }


            dataGridView1.Refresh();
            dataGridView1.RefreshEdit();
        }


        private async void ToggleChangeState(string prefix = "", bool delay = true, int rowNo = -1)
        {
            if (rowNo == -1)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    try
                    {
                        //fabrika ayarları butonuna tıklandığında hem fabrika değerleri çekilir hemde PR başına # işareti getirilir.
                        row.Cells[0].Value = prefix + row.Cells[0].Value.ToString()?.TrimStart('#').TrimStart('*') ?? String.Empty; //trim # ve * butona birkaç kez basıldığında kırpar
                    }
                    catch (Exception)
                    {
                    }

                    if (delay) await Task.Delay(100);
                }

            }
            else
            {
                //fabrika ayarları butonuna tıklandığında hem fabrika değerleri çekilir hemde PR başına # işareti getirilir.
                dataGridView1.Rows[rowNo].Cells[0].Value = prefix + dataGridView1.Rows[rowNo].Cells[0].Value.ToString()?.TrimStart('#').TrimStart('*') ?? String.Empty; //trim # ve * butona birkaç kez basıldığında kırpar
            }

        }

        private async Task<bool> parameterSend(int rowNo)
        {
            try
            {
                byte parameterCode = getParameterCode(rowNo);
                object parameterValue = dataGridView1.Rows[rowNo].Cells[6].Value;

                byte[] content = new byte[4];

                if (parameterCode == 4 || parameterCode == 5 || parameterCode == 6 || parameterCode == 7 || parameterCode == 9 || parameterCode == 43)
                {
                    content = BitConverter.GetBytes(Convert.ToSingle(parameterValue));
                }
                else
                {
                    content = BitConverter.GetBytes(Convert.ToInt32(parameterValue));
                }

                if (BitConverter.IsLittleEndian)//Big endian
                {
                    Array.Reverse(content);
                }

                var result = await Program.sendData(1, parameterCode, content, isWaitAnswer: true);
                if (result)
                {
                    ToggleChangeState(delay: false, rowNo: rowNo);
                }


                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            SettransmitCounter(0);
            Task t = Task.Run(() =>
           {
               readParametersRequest();
           });
        }
        public async Task readParametersRequest()
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value.ToString()?[0] == '*' || row.Cells[0].Value.ToString()?[0] == '#')
                    {
                        bool result = true;
                        int errorCounter = 0;
                        do
                        {
                            if (isFormClosing == true) //form kapantığında veri göndermeyi kes
                            {
                                return;
                            }
                            result = await parameterSend(row.Index);
                            if (result)
                            {
                                ToggleChangeState(delay: false, rowNo: row.Index);
                                SettransmitCounter(GettransmitCounter() + 1);
                            }
                            else
                            {
                                errorCounter++;
                            }
                        } while (result == false && errorCounter < Program.MAX_ERROR_COUNT_PER_DATA);
                    }
                }
                catch (Exception)
                {
                }


            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //fabrika ayarlarını kullanıcı girişine yerleştir

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    row.Cells[6].Value = row.Cells[4].Value;
                }
                catch (Exception)
                {
                }
            }

            ToggleChangeState("#", false);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", Program.appSettings.webSite);
        }





        private void button2_Click(object sender, EventArgs e)
        {

            SetreceiveCounter(0);
            Task t = Task.Run(() =>
            {
                sendReadParametersRequest();
            });

        }

        async Task sendReadParametersRequest()
        {
            
                byte[] results = new byte[49];

                for (byte i = 0; i < results.Length; i++)
                {
                    results[i] = i;
                }

                bool result = true;
                int errorCounter = 0;
                do
                {
                    
                    result = await Program.sendData(1, (byte)Program.COMMUNICATION_INFO_BYTES.PARAMATERS_READ, new byte[] { 0x00, 0x00, 0x00, 0x00 }, isWaitAnswer: true, results);
                    errorCounter++;
                    

                } while (result == false && errorCounter < Program.MAX_ERROR_COUNT_PER_DATA);
            
        }

        public static bool IsAllDigits(string s)
        {
            // digit . veya , olmadığında false düşsün.
            foreach (char c in s)
            {
                if (!Char.IsDigit(c) && c != '.' && c != ',')
                    return false;
            }
            return true;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Bir değişiklik algılandıktan  sonrası ..
            //değişkeni valuenin içine attık

            try
            {
                var value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                var minValue = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                var maxValue = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value);

                //null veya boş mu diye kontrol ettik
                if (String.IsNullOrEmpty(value) == false)
                {
                    //bu bir real yada decimal bir sayı mı diye kontrol ettik.
                    if (IsAllDigits(value) == false)
                    {
                        //sayı değilse girilen değeri sildik.
                        MessageBox.Show("Lütfen doğru formatta giriş yapınız!");
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                    else
                    {
                        var userValue = Convert.ToDouble(value);

                        //min ve max aralığında değilse..
                        if (!(minValue <= userValue && maxValue >= userValue))
                        {
                            MessageBox.Show("Min. ve max. değerleri arasında giriş yapınız!");
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen boş alanları doldurunuz!");
                }
            }
            catch (Exception)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            }
            //elle değiştirilen satırlarda * işareti göstermek için
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = "*" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().TrimStart('#').TrimStart('*'); //trim # ve * butona birkaç kez basıldığında kırpar

        }

        private void button6_Click(object sender, EventArgs e)
        {

            ComPortForm comPortForm = new ComPortForm(Program.serial);
            comPortForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //json sys dosyasına kaydetme
            SaveFileDialog sysSave = new SaveFileDialog();
            sysSave.Filter = "sys files (*.sys)|*.sys";
            sysSave.OverwritePrompt = true;
            if (sysSave.ShowDialog() == DialogResult.OK)
            {
                int row = 0;
                foreach (var parameter in parameters)
                {
                    parameter.Code = dataGridView1.Rows[row].Cells[0].Value.ToString();
                    parameter.Description = dataGridView1.Rows[row].Cells[1].Value.ToString();
                    parameter.MinValue = Convert.ToDouble(dataGridView1.Rows[row].Cells[2].Value);
                    parameter.MaxValue = Convert.ToDouble(dataGridView1.Rows[row].Cells[3].Value);
                    parameter.DefaultValue = dataGridView1.Rows[row].Cells[4].Value.ToString();
                    parameter.Unit = dataGridView1.Rows[row].Cells[5].Value.ToString();
                    parameter.Value = dataGridView1.Rows[row].Cells[6].Value.ToString();
                    row++;
                }

                // if(saveParameters(sysSave.FileName, parameters) == false)
                if (Program.saveObjectJson<List<Parameter>>(parameters, sysSave.FileName) == false)
                {
                    MessageBox.Show("Dosya kaydedilirken bir hata oluştu.");
                }
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            //json sys dosyasına import
            OpenFileDialog sysSave = new OpenFileDialog();
            sysSave.Filter = "sys files (*.sys)|*.sys";

            if (sysSave.ShowDialog() == DialogResult.OK)
            {
                parameters = Program.readObjectJson<List<Parameter>>(sysSave.FileName);
                tablefill(parameters);
            }

        }

        private void şifreDeğiştirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SifreDegistir sifreDegistir = new SifreDegistir();
            sifreDegistir.ShowDialog();
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
                panel1.BackColor = Color.Black;
                menuStrip1.BackColor = Color.Black;
                dataGridView1.BackgroundColor = Color.Black;
                uygulamaAyarlarıToolStripMenuItem.BackColor = Color.Black;
                uygulamaAyarlarıToolStripMenuItem.ForeColor = Color.Gray;
                düzenleToolStripMenuItem.BackColor = Color.Black;
                düzenleToolStripMenuItem.ForeColor = Color.Gray;
                yardımToolStripMenuItem.BackColor = Color.Black;
                yardımToolStripMenuItem.ForeColor = Color.Gray;
                pictureBox1.BackColor = Color.Black;
                tableLayoutPanel1.BackColor = Color.Black;
                this.BackColor = Color.Black;
                lbl_communicationCounter.ForeColor = Color.Gray;
                lbl_anlikveri.ForeColor = Color.Gray;
                //kumanda formunada anında tema değişimi
                FormRemotControl frm = (FormRemotControl)Application.OpenForms["FormRemotControl"];
                frm.BackColor = Color.Black;
            }
            else
            {
                lbl_communicationCounter.ForeColor = Color.Black;
                panel1.BackColor = Color.WhiteSmoke;
                menuStrip1.BackColor = Color.WhiteSmoke;
                menuStrip1.ForeColor = Color.Black;
                uygulamaAyarlarıToolStripMenuItem.BackColor = Color.WhiteSmoke;
                uygulamaAyarlarıToolStripMenuItem.ForeColor = Color.Black;
                düzenleToolStripMenuItem.BackColor = Color.WhiteSmoke;
                düzenleToolStripMenuItem.ForeColor = Color.Black;
                yardımToolStripMenuItem.BackColor = Color.WhiteSmoke;
                yardımToolStripMenuItem.ForeColor = Color.Black;
                dataGridView1.BackgroundColor = Color.WhiteSmoke;
                pictureBox1.BackColor = Color.WhiteSmoke;
                tableLayoutPanel1.BackColor = Color.WhiteSmoke;
                this.BackColor = Color.WhiteSmoke;
                lbl_communicationCounter.ForeColor = Color.Black;
                lbl_anlikveri.ForeColor = Color.Black;
                //kumanda formunada anında tema değişimi
                FormRemotControl frm = (FormRemotControl)Application.OpenForms["FormRemotControl"];
                frm.BackColor = Color.WhiteSmoke;

            }

        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themaSet("dark");
        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themaSet("light");
        }

        private void exceleAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Excel Uygulaması oluşturma  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // Excel uygulaması içinde yeni Çalışma Kitabı oluşturma  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            //çalışma kitabında yeni Excel sayfası oluşturma
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // programın arkasındaki excel sayfasına bakın
            app.Visible = true;
            // ilk sayfanın referansını al. Varsayılan olarak adı Sayfa1'dir.
            // referansını çalışma sayfasına kaydet
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // aktif sayfanın adını değiştirme
            worksheet.Name = "Exported from gridview";
            // başlık kısmını Excel'de depolamak
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            // Her satır ve sütun değerini excel sayfasına kaydetme
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }

        }

        private void exceldenTabloyaAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string file = "";   // Excel Dosya Konumu için değişken
            DataTable dt = new DataTable();   //excel verilerimiz için kapsayıcı
            DataRow row;
            DialogResult result = openFileDialog1.ShowDialog();  //İletişim kutusunu göster.
            if (result == DialogResult.OK)   //Sonuç == "Tamam" olup olmadığını kontrol edin.
            {
                file = openFileDialog1.FileName; //dosya adını dosyanın konumuyla birlikte alın
                try

                {
                    //Excel dosyasını okumak için kullanılacak Microsoft.Office.Interop.Excel için Nesne Oluşturma

                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(file);

                    Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];

                    Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;


                    int rowCount = excelRange.Rows.Count;  //excel verilerinin satır sayısını al

                    int colCount = excelRange.Columns.Count; //excel verilerinin sütun sayısını al

                    //Sütun Adı olan excel dosyasının ilk Sütununu alın
                    //excel verilerinin sütun sayısını al


                    for (int i = 2; i <= rowCount; i++)
                    {
                        for (int j = 7; j <= colCount; j++)
                        {
                            try
                            {
                                dataGridView1.Rows[i - 2].Cells[j - 1].Value = excelRange.Cells[i, j].Value2.ToString();
                            }
                            catch (Exception ex)
                            {
                                dataGridView1.Rows[i - 2].Cells[j - 1].Value = "";

                            }

                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



            }
        }

        private void ayarlarıYükleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4_Click(button3, null);
        }

        private void ayarlarıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button5_Click(button5, null);
        }

        private void bağlantıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button6_Click(button6, null);
        }

        private void fabrikaAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3_Click(button3, null);
        }

        private void kullanımKılavuzuToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            try
            {
                System.Diagnostics.Process.Start("explorer.exe", Program.userManuelPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya bulunamadı" + Environment.NewLine + Environment.NewLine + ex.Message);
            }

        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void windowsTemasıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themaSet("windows_thema");

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //datagrid ilk açılışta hücre seçimini kapat
            dataGridView1.ClearSelection();
        }

        private async void FormService_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.serial.DataReceived -= SerialPort_DataReceived; 
            isFormClosing = true;


        }

        private void FormService_Load(object sender, EventArgs e)
        {
            UpdateRuntimeValues();
        }

        void UpdateRuntimeValues()
        {
            string errorStatus = "";
            if (RunTimeParamaters.ErrorStatus == 1)
            {
                errorStatus = "Black Out Alarm";
            }
            else if (RunTimeParamaters.ErrorStatus == 2)
            {
                errorStatus = "Flue Gas Temperature Alarm";
            }
            else if (RunTimeParamaters.ErrorStatus == 3)
            {
                errorStatus = "Flue Gas Over Temperature Alarm";
            }
            else if (RunTimeParamaters.ErrorStatus == 4)
            {
                errorStatus = "Flue Encoder Alarm";
            }
            else if (RunTimeParamaters.ErrorStatus == 5)
            {
                errorStatus = "Ignation Failure Alarm";
            }
            else if (RunTimeParamaters.ErrorStatus == 6)
            {
                errorStatus = "Pellet Absence Alarm";
            }
            else if (RunTimeParamaters.ErrorStatus == 7)
            {
                errorStatus = "Over Temperature Thermal Safety Alarm";
            }
            else if (RunTimeParamaters.ErrorStatus == 8)
            {
                errorStatus = "Depression Failure Alarm";
            }

            lbl_anlikveri.Invoke(() =>
            {
                lbl_anlikveri.Text = "Ortam Sıcaklığı:" + RunTimeParamaters.AmbientTemperature + " / " + "Egzoz Gazı Sıcaklığı:" + RunTimeParamaters.ExhaustGasTemperature + " / " + "Oda Fan Hızı:" + RunTimeParamaters.RoomFanSpeed +
" / " + "Egzoz Fanı Hızı:" + RunTimeParamaters.ExhaustFanSpeed + " / " + "Süre:" + RunTimeParamaters.Duration +
" / " + "Ateşleme Aşaması:" + RunTimeParamaters.IgnitionPhaseName + " / " + "Alarm Modu:" + errorStatus;
            });




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}