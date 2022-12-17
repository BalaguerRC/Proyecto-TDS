using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public class ListasService
    {
        private ListasTipos repo;
        public ListasService(SqlConnection connection)
        {
            repo = new ListasTipos(connection);
        }
        public List<TipoUsuario> GetUsersType()
        {
            return repo.GetUsersType();
        }
        public List<TipoProducto> GetProductType()
        {
            return repo.GetProductType();
        }
    }
}
