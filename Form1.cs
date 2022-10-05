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

namespace deneme
{
    public partial class Form1 : Form
    {
        List<Parameter> parameters = new List<Parameter>();



        public Form1()
        {

            InitializeComponent();

            //dosyadan parametre okuyor
            parameters = readParameters(Application.StartupPath + @"Files\\paramaters.json");


            //Eski modelde oluşturduklarımız otomatik gelmesin diye 
            dataGridView1.AutoGenerateColumns = false;
            tablefill(parameters);


            //VERİ ALACAĞIN YER BURASI
            //göndereceğin veriyi bytlara çevir. (TAMAMLA)
            int i = 0x010003;
            byte[] array = BitConverter.GetBytes(i);


            Program.serial.DataReceived += SerialPort_DataReceived;
            Program.serial.ReadTimeout = 1000;
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


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        public static string readFile(string path)
        {
            string dosya_yolu = path;
            //Okuma işlem yapacağımız dosyanın yolunu belirtiyoruz.
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            //Bir file stream nesnesi oluşturuyoruz. 1.parametre dosya yolunu,
            //2.parametre dosyanın açılacağını,
            //3.parametre dosyaya erişimin veri okumak için olacağını gösterir.
            StreamReader sw = new StreamReader(fs);
            //Okuma işlemi için bir StreamReader nesnesi oluşturduk.
            string yazi = sw.ReadToEnd();
            //Satır satır okuma işlemini gerçekleştirdik 
            //Son satır okunduktan sonra okuma işlemini bitirdik
            sw.Close();
            fs.Close();
            //İşimiz bitince kullandığımız nesneleri iade ettik.

            return yazi;
        }
        private static void saveFile(string path, string value)
        {
            string dosya_yolu = path;
            //İşlem yapacağımız dosyanın yolunu belirtiyoruz.
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            //Bir file stream nesnesi oluşturuyoruz. 1.parametre dosya yolunu,
            //2.parametre dosya varsa açılacağını yoksa oluşturulacağını belirtir,
            //3.parametre dosyaya erişimin veri yazmak için olacağını gösterir.
            StreamWriter sw = new StreamWriter(fs);
            //Yazma işlemi için bir StreamWriter nesnesi oluşturduk.
            sw.Write(value);
            //Dosyaya ekleyeceğimiz iki satırlık yazıyı WriteLine() metodu ile yazacağız.
            sw.Flush();
            //Veriyi tampon bölgeden dosyaya aktardık.
            sw.Close();
            fs.Close();
            //İşimiz bitince kullandığımız nesneleri iade ettik..
        }

        private List<Parameter> readParameters(string path)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<Parameter>>(readFile(path));
            }
            catch (Exception)
            {
                return new List<Parameter>();
            }

        }

        private bool saveParameters(string path, List<Parameter> new_parameters)
        {
            try
            {
                string json = JsonConvert.SerializeObject(new_parameters);
                saveFile(path, json);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox1_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //resim kutusuna dokununca url ye gidecek.
            System.Diagnostics.Process.Start("explorer.exe", @"https://hosseven.com.tr/");
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
            //Bir değişiklik algılandıktan sonrası ..
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

            }

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

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[6].Value = row.Cells[4].Value;
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

                if(saveParameters(sysSave.FileName, parameters) == false)
                {
                    MessageBox.Show("Dosya kaydedilirken bir hata oluştu.");
                }
            }



            /*
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
            */


        }

        private void button4_Click(object sender, EventArgs e)
        {
            //json sys dosyasına import
            OpenFileDialog sysSave = new OpenFileDialog();
            sysSave.Filter = "sys files (*.sys)|*.sys";

            if (sysSave.ShowDialog() == DialogResult.OK)
            {
                parameters = readParameters(sysSave.FileName);
                tablefill(parameters);
            }
               

            /*
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
            */


        }
    }


}