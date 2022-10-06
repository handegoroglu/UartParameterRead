using Newtonsoft.Json;
using System.IO.Ports;
using System.Reflection.Metadata.Ecma335;
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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new Form2());


        }

        public static string basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Mysia\\Hosseven\\";
        public static string defaultParametersPath = basePath + @"Files\\paramaters.json";
        public static string defaulserialPortSettings = basePath + @"Files\\serialPortSettings.json";

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
    }

}