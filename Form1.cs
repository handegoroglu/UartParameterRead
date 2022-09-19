using deneme.Models;
using Newtonsoft.Json;
using System.IO.Ports;

namespace deneme
{
    public partial class Form1 : Form
    {
        List<Parameter> parameters = new List<Parameter>();
        SerialPort serialPort = new SerialPort();
        public Form1()
        {
            InitializeComponent();

            parameters = readParameters(); //dosyadan parametre okuyor

            dataGridView1.AutoGenerateColumns = false; // modelde oluşturduklarımız otomatik gelmesin diye 
            tablefill(parameters);

            //göndereceğin veriyi bytlara çevir. (TAMAMLA)
            int i = 0x010003;
            byte[] array = BitConverter.GetBytes(i);

            //int sayıyı bytelara çevir.(veriyi alırken böyle alacaksın) 
            int x = BitConverter.ToInt32(array, 0);

            serialPort.DataReceived += SerialPort_DataReceived;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
        }

        void tablefill(List<Parameter> parameters)
        {
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
            //Satır satır okuma işlemini gerçekleştirdik ve ekrana yazdırdık
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
            System.Diagnostics.Process.Start("explorer.exe", @"https://hosseven.com.tr/"); //ÇALIŞIYOR
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //datayı gönder
        //0XFF, 0X01, 0X02
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

            var value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
           
            var minValue = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            var maxValue = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            //null veya boş mu diye kontrol ettik
            if (String.IsNullOrEmpty(value) == false)
            {
                //bu bir real yada decimal bir sayı mı diye kontrol ettik.
                if(IsAllDigits(value) == false)
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


            //dataGridView1.UpdateCellValue(e.RowIndex, e.ColumnIndex);
            //MessageBox.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}