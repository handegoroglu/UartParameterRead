using deneme.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.IO.Ports;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Markup;

namespace deneme
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            try
            {
                //başlangıçta logo bulunamazsa program hata vermesin diye try catch içine aldık dosyayı bulamazsa logosuz başlayacak
                imgLogo = new Bitmap(pathLogo);
                manufactureLogo = new Bitmap(pathManufactureLogo);
                iconLogo = new Icon(pathIconLogo);
                appSettings = readObjectJson<AppSettings>(AppSettingsPath);

                //program başlangıçta son kayıtlı port ayarlarını okur
                var serialPortSettings = readObjectJson<SerialPortSettings>(serialPortSettingsPath);
                if (serialPortSettings != null)
                {
                    serial.PortName = serialPortSettings.port;
                    serial.BaudRate = serialPortSettings.baudrate;
                }
            }
            catch (Exception)
            {
            }

            try
            { //son okunan portu açar
                serial.Open();
                
            }
            catch (Exception)
            {
                //açamazsa 
            }


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //Application.Run(new Form1());
            Application.Run(new FormRemotControl());


        }

        public static string basePath = Application.StartupPath + "\\Files\\";
        public static string appDataBasePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Mysia\\Hosseven\\";
        public static string defaultParametersPath = appDataBasePath + @"Files\\default_paramaters.json";
        public static string serialPortSettingsPath = appDataBasePath + @"Files\\serialPortSettings.json";
        public static string userManuelPath = appDataBasePath + @"Files\user_manuel.pdf";
        public static string AppSettingsPath = appDataBasePath + @"Files\app_settings.json";
        public static string formNameItem = appDataBasePath + @"Files\app_settings.json";
        public static string weeklyPlanDaysPath = appDataBasePath + @"Files\\weeklyPlanDays.json";

        public static string pathLogo = basePath + @"images\logo.png";
        public static string pathIconLogo = basePath + @"images\icon.ico";
        public static string pathManufactureLogo = basePath + @"images\manufacture.png";



        public static Image imgLogo;
        public static Icon iconLogo;
        public static AppSettings appSettings;
        public static Image manufactureLogo;


        public static SerialPort serial = new SerialPort();


        private static string readFile(string path)
        {
            if (File.Exists(path) == false)
            {
                Directory.CreateDirectory(Path.Combine(Path.GetDirectoryName(path)));
            }

            return File.ReadAllText(path);
        }
        private static void saveFile(string path, string value)
        {
            if (File.Exists(path) == false)
            {
                Directory.CreateDirectory(Path.Combine(Path.GetDirectoryName(path)));
            }
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(value);
            }
        }

        public static bool saveObjectJson<T>(T object_, string path)
        {
            try
            {
                string json = JsonConvert.SerializeObject(object_);
                saveFile(path, json);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void themaSave(string thema)
        {
            Program.appSettings.thema = thema;

            Program.saveObjectJson<AppSettings>(Program.appSettings, Program.AppSettingsPath);
        }

        public static T readObjectJson<T>(string path)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(readFile(path));
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        [DllImport("UXTheme.dll", SetLastError = true, EntryPoint = "#138")]
        public static extern bool ShouldSystemUseDarkMode();

    }

}