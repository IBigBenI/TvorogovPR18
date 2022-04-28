using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TvorogovPR18
{
    public class RateInfo
    {
        public string Text { get; set; }
        public bool Found { get; set; }
        public decimal Number { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }

}
