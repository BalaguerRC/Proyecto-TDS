using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public class CategoriaService
    {
        private CategoriaRepo repo;
        public CategoriaService(SqlConnection connection)
        {
            repo = new CategoriaRepo(connection);
        }
        public bool Add(TipoProducto item)
        {
            return repo.Add(item);
        }
        public bool Edit(TipoProducto item)
        {
            return repo.Edit(item);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
        public TipoProducto GetById(int id)
        {
            return repo.GetById(id);
        }
        public DataTable GetAll()
        {
            return repo.GetAll();
        }
    }
}
