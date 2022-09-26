using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme.Models
{
    public class Parameter
    {
        
        public string Code { get; set; }
        public string Description { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public string DefaultValue { get; set; }
        public string Unit { get; set; }
        public string Value { get; set; }
    }
}
