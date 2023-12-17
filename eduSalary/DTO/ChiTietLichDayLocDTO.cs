using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietLichDayLocDTO
    {
        public string malich { get; set; }
        public string magv { get; set; }
        public string hoten { get; set; }
        public string tenmh { get; set; }
        public string tenlp { get; set; }
        public int tietday { get; set; }
        public DateTime ngayday { get; set; }
        public bool hoanthanh { get; set; }
    }
}
