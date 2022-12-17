using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public int IdProductType { get; set; }
        public string ProductTipo { get; set; }
    }
}
