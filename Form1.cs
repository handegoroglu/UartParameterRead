using deneme.Models;
using Newtonsoft.Json;
using System.Data;
using System.IO.Ports;
using System.Windows.Forms;

namespace deneme
{
    public partial class Form1 : Form
    {
        List<Parameter> parameters = new List<Parameter>();
        
        

        public Form1()
        {
            
            InitializeComponent();

            //dosyadan parametre okuyor
            parameters = readParameters();
            

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


        public static string readFile()
        {
            string dosya_yolu = Application.StartupPath + "Files\\paramaters.json";
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
        private static void saveFile(string value)
        {
            string dosya_yolu = Application.StartupPath + "Files\\paramaters.json";
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
        private void saveParameters(List<Parameter> remindings)
        {
            string json = JsonConvert.SerializeObject(remindings);
            saveFile(json);

        }

        private List<Parameter> readParameters()
        {
            try
            {
                return JsonConvert.DeserializeObject<List<Parameter>>(readFile());
            }
            catch (Exception)
            {
                return new List<Parameter>();
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
            // uygulamayı kaydet
            workbook.SaveAs(Application.StartupPath + "Files\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Uygulamadan çık
            app.Quit();

        }

        private void button4_Click(object sender, EventArgs e)
        {
             
        }
    }
}