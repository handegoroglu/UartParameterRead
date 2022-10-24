 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme.Models
{
    internal class WeeklyPlanDays
    {
        public string? Saat { get; set; }
        public bool? Pazartesi { get; set; }
        public bool? Salı { get; set; }
        public bool? Çarşamba { get; set; }
        public bool? Perşembe { get; set; }
        public bool? Cuma { get; set; }
        public bool? Cumartesi { get; set; }
        public bool? Pazar { get; set; }
    }
}
