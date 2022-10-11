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

namespace deneme
{
    public partial class FormService : Form
    {
        List<Parameter> parameters = new List<Parameter>();



        public FormService()
        {
            InitializeComponent();

            //icon'u icon.ico isimli dosyadan çek
            this.Icon = Program.iconLogo;

            //picturebox logo.png isimli dosyayı çek
            pictureBox1.Image = Program.imgLogo;

            //dosyadan parametre okuyor
            parameters = Program.readObjectJson<List<Parameter>>(Program.defaultParametersPath);

            //Eski modelde oluşturduklarımız otomatik gelmesin diye 
            dataGridView1.AutoGenerateColumns = false;
            tablefill(parameters);


            //VERİ ALACAĞIN YER BURASI
            //göndereceğin veriyi bytlara çevir. (TAMAMLA)
            int i = 0x010003;
            byte[] array = BitConverter.GetBytes(i);


            Program.serial.DataReceived += SerialPort_DataReceived;
            Program.serial.ReadTimeout = 1000;

            themaSet(Program.appSettings.thema);


        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            //Veri okuduğun alan
            string data = "";
            while (true)
            {
                try
                {
                    data += Program.serial.ReadByte().ToString("X") + " ";
                }
                catch (Exception)
                {
                    break;
                }
            }

            MessageBox.Show(data);

            Program.serial.DiscardInBuffer();
        }

        void tablefill(List<Parameter> parameters)
        {
            dataGridView1.Rows.Clear();

            foreach (var parameter in parameters)
            {
                object[] values = new object[] { parameter.Code, parameter.Description, parameter.MinValue, parameter.MaxValue, parameter.DefaultValue, parameter.Unit, parameter.Value };
                dataGridView1.Rows.Add(values);
            }


            dataGridView1.Refresh();
            dataGridView1.RefreshEdit();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //fabrika ayarlarını kullanıcı girişine yerleştir
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {

                    row.Cells[6].Value = row.Cells[4].Value;
                    //fabrika ayarları butonuna tıklandığında hem fabrika değerleri çekilir hemde PR başına # işareti getirilir.
                    row.Cells[0].Value = row.Cells[0].Value.ToString().TrimStart('#').TrimStart('*'); //trim # ve * butona birkaç kez basıldığında kırpar
                }
                catch (Exception)
                {
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //resim kutusuna dokununca url ye gidecek.
            System.Diagnostics.Process.Start("explorer.exe", Program.appSettings.webSite);
        }

        private void button2_Click(object sender, EventArgs e)
        {

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            ComPortForm comPortForm = new ComPortForm(Program.serial);
            comPortForm.ShowDialog();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //fabrika ayarlarını kullanıcı girişine yerleştir
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {

                    row.Cells[6].Value = row.Cells[4].Value;
                    //fabrika ayarları butonuna tıklandığında hem fabrika değerleri çekilir hemde PR başına # işareti getirilir.
                    row.Cells[0].Value = "#" + row.Cells[0].Value.ToString().TrimStart('#').TrimStart('*'); //trim # ve * butona birkaç kez basıldığında kırpar
                }
                catch (Exception)
                {
                }
            }


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

        private void temayıDeğiştirToolStripMenuItem1_Click(object sender, EventArgs e)
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

            if(thema == "dark")
            {
                panel1.BackColor = Color.Black;
                menuStrip1.BackColor = Color.Black;
                dataGridView1.BackgroundColor = Color.DarkGray;
                uygulamaAyarlarıToolStripMenuItem.BackColor = Color.Black;
                uygulamaAyarlarıToolStripMenuItem.ForeColor = Color.Gray;
                düzenleToolStripMenuItem.BackColor = Color.Black;
                düzenleToolStripMenuItem.ForeColor = Color.Gray;
                yardımToolStripMenuItem.BackColor = Color.Black;
                yardımToolStripMenuItem.ForeColor = Color.Gray;
                pictureBox1.BackColor = Color.Black;
                tableLayoutPanel1.BackColor = Color.Black;
            }
            else
            {
                panel1.BackColor = Color.DarkGray;
                menuStrip1.BackColor = Color.DarkGray;
                menuStrip1.ForeColor = Color.Black;
                uygulamaAyarlarıToolStripMenuItem.BackColor = Color.DarkGray;
                uygulamaAyarlarıToolStripMenuItem.ForeColor = Color.Black;
                düzenleToolStripMenuItem.BackColor = Color.DarkGray;
                düzenleToolStripMenuItem.ForeColor = Color.Black;
                yardımToolStripMenuItem.BackColor = Color.DarkGray;
                yardımToolStripMenuItem.ForeColor = Color.Black;
                dataGridView1.BackgroundColor = Color.DarkGray;
                pictureBox1.BackColor = Color.DarkGray;
                tableLayoutPanel1.BackColor = Color.DarkGray;
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
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
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

        private void FormService_Load(object sender, EventArgs e)
        {

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
    }
}