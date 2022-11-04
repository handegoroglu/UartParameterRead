using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme.Models
{
    static class RunTimeParamaters
    {
        public static float AmbientTemperature { get; set; }
        public static float ExhaustGasTemperature { get; set; }
        public static UInt16 RoomFanSpeed { get; set; }
        public static UInt16 ExhaustFanSpeed { get; set; }
        public static UInt16 Duration { get; set; }
        public static byte IgnitionPhaseName { get; set; }
        public static byte ErrorStatus { get; set; }


    }
}
