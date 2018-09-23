using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercy.Model
{
    class PharmacySale
    {
        public int id_Sale { get; set; }
        public Double Total { get; set; }
        public DateTime Sale_Date { get; set; }
        public int Discount { get; set; }
        public int Added_by { get; set; }
        public DataTable PharmacyBill { get; set; }

    }
}
