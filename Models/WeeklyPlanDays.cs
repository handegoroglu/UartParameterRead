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
        public string? Pazartesi { get; set; }
        public string? Salı { get; set; }
        public string? Çarşamba { get; set; }
        public string? Perşembe { get; set; }
        public string? Cuma { get; set; }
        public string? Cumartesi { get; set; }
        public string? Pazar { get; set; }
    }
}
