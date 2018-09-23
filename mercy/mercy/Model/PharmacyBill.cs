using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercy.Model
{
    class PharmacyBill
    {
        public int id_Bill { get; set; }
        public int Product_Id { get; set; }
        public Double Price { get; set; }
        public int Quantity { get; set; }
        public Double SubTotal { get; set; }
        public DateTime Bill_Date { get; set; }
        public int Added_by { get; set; }

    }
}
