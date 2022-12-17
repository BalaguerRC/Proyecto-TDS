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
    public class ProductService
    {
        private ProductRepo repo;
        public ProductService(SqlConnection connection)
        {
            repo = new ProductRepo(connection);
        }
        public bool Add(Product item)
        {
            return repo.Add(item);
        }
        public bool Edit(Product item)
        {
            return repo.Edit(item);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
        public Product GetId(int id)
        {
            return repo.GetId(id);
        }
        public DataTable GetAll()
        {
            return repo.GetAll();
        }
    }
}
