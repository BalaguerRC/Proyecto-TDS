using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Login
    {
        public int IdLogin { get; set; }
        public string UserName { get; set; }
        public string PasswordH { get; set; }
        public int IdTipo { get; set; }
        public string Type { get; set; }
    }
}
