using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Pedidos
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
