using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFX_CSV_Data_Extractor
{
   public class TestStatistic
    {
        public string TEST_NAM { get; set; }
        public UInt32 TEST_NUM { get; set; }
        public float? LO_LIMIT { get; set; }
        public float? HI_LIMIT { get; set; }
        public string UNIT { get; set; }
        public float? Mean { get; set; }
        public float? Stdev { get; set; }
        public float? Min { get; set; }
        public float? Max { get; set; }
        public float? Median { get; set; }
        public float? Cpk { get; set; }
        public float? Q1 { get; set; }
        public float? Q3 { get; set; }
        public float? IQR { get; set; }
   }
}
