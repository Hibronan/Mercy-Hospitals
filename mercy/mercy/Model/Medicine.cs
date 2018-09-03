using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercy.Model
{
    class Medicine
    {
        public int Id
        {
            get;
            set;
        }
        public String Name { get; set; }
        public String CompanyName { get; set; }
        public int Qty { get; set; }
        public double Cost { get; set; }
        public double Sprice { get; set; }
        public DateTime MenuDate { get; set; }
        public DateTime ExpDate { get; set; }
    }
}
