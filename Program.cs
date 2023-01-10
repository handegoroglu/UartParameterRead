using deneme.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO.Ports;
using System.Reflection;
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

            serial.ReadTimeout = 10;

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


         /*   if (frameworkCheck() == false)
            {
                if(DialogResult.Yes == MessageBox.Show(".Net Core " + frameworkVersion + " gerekli, indirmek için yönlendirilmek ister misiniz?", "Framework not found", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    System.Diagnostics.Process.Start("explorer.exe", "https://dotnet.microsoft.com/en-us/download/dotnet");
                }
            }
         */
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

        private static string frameworkVersion = "6.0.0";

        public static Image? imgLogo;
        public static Icon? iconLogo;
        public static AppSettings? appSettings;
        public static Image? manufactureLogo;

        public static SerialPort serial = new SerialPort();

        static public bool isReceiveAck = false;
        static COMMUNICATION_INFO_BYTES requestInfo;

        const int ACK_WAIT_TIMEOUT = 500;
        public const int MAX_ERROR_COUNT_PER_DATA = 3;

        private static bool frameworkCheck()
        {
            try
            {
                UInt32 itNeedsVersionInt;
                string[] itNeedsVersionArr = (frameworkVersion).Split('.');
                if (BitConverter.IsLittleEndian)
                {
                    itNeedsVersionInt = BitConverter.ToUInt32(new byte[] { 0, Convert.ToByte(itNeedsVersionArr[2]), Convert.ToByte(itNeedsVersionArr[1]), Convert.ToByte(itNeedsVersionArr[0]) }, 0);
                }
                else
                {
                    itNeedsVersionInt = BitConverter.ToUInt32(new byte[] { 0, Convert.ToByte(itNeedsVersionArr[0]), Convert.ToByte(itNeedsVersionArr[1]), Convert.ToByte(itNeedsVersionArr[2]) }, 0);
                }


                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.WriteLine("dotnet --list-runtimes");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                string response = cmd.StandardOutput.ReadToEnd();
                string[] array = response.Split('\n');

                foreach (var item in array)
                {
                    bool isContain = item.IndexOf("Microsoft.NETCore.App") == -1 ? false : true;
                    if (isContain)
                    {
                        string version_str = item.Split(" ")[1];
                        string[] version_arr = version_str.Split('.');
                        UInt32 version;
                        if (BitConverter.IsLittleEndian)
                        {
                            version = BitConverter.ToUInt32(new byte[] { 0, Convert.ToByte(version_arr[2]), Convert.ToByte(version_arr[1]), Convert.ToByte(version_arr[0]) }, 0);
                        }
                        else
                        {
                            version = BitConverter.ToUInt32(new byte[] { 0, Convert.ToByte(version_arr[0]), Convert.ToByte(version_arr[1]), Convert.ToByte(version_arr[2]) }, 0);
                        }

                        if (version >= itNeedsVersionInt)
                        {
                            return true;
                        }
                    }

                }
            }
            catch (Exception)
            {
                return true;
            }

            return false;
        }

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



        const int DATA_PACKET_LEN = 11;
        static byte[] serialBuffer = new byte[DATA_PACKET_LEN * 10];
        static int serialBufferCounter = 0;
        static public void dataReceived()
        {
            while (true)
            {
                try
                {

                    serialBuffer[serialBufferCounter] = Convert.ToByte(Program.serial.ReadByte());
                    serialBufferCounter++;
                    if (serialBufferCounter >= serialBuffer.Length)
                    {
                        serialBufferCounter = 0;
                    }
                }
                catch (Exception)
                {
                    break;
                }
            }

        }

        static public byte[]? findData()
        {
            byte[]? value;
            value = packetFinder(serialBuffer);
            if (value != null)
            {
                if (serialBufferCounter >= value.Length)
                {
                    serialBufferCounter -= value.Length;//bufferda alan boşaldığı için serialbuffercounter'ı ilk boş indexe at 
                }

                if (dataCheck(value) == true)
                {
                    byte[] newData = new byte[DATA_PACKET_LEN - 5];
                    Array.Copy(value, 3, newData, 0, DATA_PACKET_LEN - 5);

                    if (commonDataProcess(newData) == false)
                    {
                        return newData;
                    }
                }
            }

            return null;
        }

        static public bool dataCheck(byte[] data)
        {
            if (data != null)
            {

                if (data[0] == 'H' && data[1] == 'N' && data[2] == 'D')
                {
                    if (data[10] == 'U')
                    {
                        byte calculated_checksum = checksum_calculate(data, DATA_PACKET_LEN - 2);

                        if (calculated_checksum == data[9])
                        {

                            return true;
                        }
                        else
                        {
                            Console.WriteLine("error data checksum");
                        }

                    }
                    else
                    {
                        Console.WriteLine("error data stop");
                    }
                }
                else
                {
                    Console.WriteLine("error data start");
                }
            }
            else
            {
                Console.WriteLine("nulll be nullllll");
            }

            return false;
        }
        static byte[] packetFinder(byte[] buffer)
        {
            byte[]? packet = null;

            for (int i = 0; i < buffer.Length - DATA_PACKET_LEN; i++)
            {//H N D İle başlayan paketi bul
                if (buffer[i] == (byte)'H' && buffer[i + 1] == (byte)'N' && buffer[i + 2] == (byte)'D')
                {//paket u ile mi bitiyor?
                    if (buffer[i + (DATA_PACKET_LEN - 1)] == (byte)'U')
                    {   //paketin içine bufferdaki bulunan paketi kopyala
                        packet = new byte[DATA_PACKET_LEN];

                        Array.Copy(buffer, i, packet, 0, DATA_PACKET_LEN);
                        int shiftIndex = i + DATA_PACKET_LEN + 1;
                        if (buffer.Length == shiftIndex)
                        {
                            serialBufferCounter = 0;
                        }
                        //bulunan paketi silmek için sağ tarafı sola kaydır 
                        bufferShiftLeft(buffer, shiftIndex, DATA_PACKET_LEN + 1);
                    }
                }

            }

            return packet;
        }
        //sola kaydırma
        static void bufferShiftLeft(byte[] buffer, int index/*5*/, int shiftCount/*2*/)
        {
            //kaydırılacak ilk byte: index , kaydırma sayısı:shiftCount 
            if (buffer.Length >= index)
            {
                for (int i = index - shiftCount; i < buffer.Length; i++)
                {
                    buffer[i] = 0;
                }
            }

            for (int i = index; i < buffer.Length; i++)//5, 6
            {
                buffer[i - shiftCount] = buffer[i];
                buffer[i] = 0;
            }
        }

        static void sendAck()
        {
            sendData(1, (byte)COMMUNICATION_INFO_BYTES.ACK, new byte[] { 0x00, 0x00, 0x00, 0x00 }).Wait();
        }

        static public async Task<bool> sendData(byte deviceId, byte parameterCode, byte[] content, bool isWaitAnswer = false, byte[]? results = null)
        {
            try
            {
                isReceiveAck = false;
                requestInfo = COMMUNICATION_INFO_BYTES.NONE;

                byte[] data = new byte[] { (byte)'H', (byte)'N', (byte)'D', deviceId, parameterCode, 0x00, 0x00, 0x00, 0x00, 0x00, (byte)'U' };

                Array.Copy(content, 0, data, 5, content.Length);
                data[9] = checksum_calculate(data, 9);

                if (Program.serial.IsOpen)
                {
                    Program.serial.Write(data, 0, data.Length);

                }


                if (isWaitAnswer)
                {
                    DateTime sendTime = DateTime.Now;

                    while ((DateTime.Now - sendTime) <= new TimeSpan(0, 0, 0, 0, ACK_WAIT_TIMEOUT))
                    {
                        if (results != null)
                        {
                            foreach (var info in results)
                            {
                                if (Convert.ToByte(requestInfo) == info)
                                {
                                    return true;
                                }
                            }
                        }

                        if (isReceiveAck == true)
                        {
                            return true;
                        }
                    }

                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public enum COMMUNICATION_INFO_BYTES
        {
            PING = 200,
            PONG,
            PARAMATERS_READ,
            ACK,
            WEEKLY_PLAN1 = 210,
            WEEKLY_PLAN2,
            WEEKLY_PLAN3,
            WEEKLY_PLAN4,
            WEEKLY_PLAN5,
            WEEKLY_PLAN6,
            WEEKLY_PLAN7,
            READ_RUNTIME_PARAMATERS = 220,
            AMBIENT_TEMPERATURE,
            EXHAUST_GAS_TEMPERATURE,
            ROOM_FAN_SPEED,
            EXHAUST_FAN_SPEED,
            DURATION,
            IGNITION_PHASE_NAME,
            ERROR_STATUS,
            LEVELOPEN = 230,
            LEVEL_CLOSE,
            LEVEL1,
            LEVEL2,
            LEVEL3,
            LEVEL4,
            LEVEL5,
            WEEKLY_PLAN_READ = 240,
            NONE
        }
        /*
        * 1. Kritik ve akış olmayan veriler
        * 2. Kritik ve akış olan veriler
        * 3. kritik olmayan ve akış olan veriler
        * 4. kritik olmayan ve akış olmayan veriler
        * 
        */
        static public byte checksum_calculate(byte[] array, int len)
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


        static bool commonDataProcess(byte[] data)
        {
            requestInfo = (COMMUNICATION_INFO_BYTES)data[1];

            byte[] valueArray = new byte[4];
            Array.Copy(data, 2, valueArray, 0, 4);
            if (BitConverter.IsLittleEndian)//Big endian
            {
                Array.Reverse(valueArray);
            }

            if (data[1] == Convert.ToByte(Program.COMMUNICATION_INFO_BYTES.ACK))
            {
                Program.isReceiveAck = true;

            }
            else
            {
                return false;
            }
            return true;
        }
    }

}