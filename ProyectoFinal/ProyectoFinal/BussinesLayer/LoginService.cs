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
    public class LoginService
    {
        private LoginRepo repo;
        public LoginService(SqlConnection connection)
        {
            repo = new LoginRepo(connection);
        }
        public bool Add(Login item)
        {
            return repo.Add(item);
        }
        public bool Edit(Login item)
        {
            return repo.Edit(item);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
        public Login GetId(int id)
        {
            return repo.GetId(id);
        }
        public DataTable GetAll()
        {
            return repo.GetAll();
        }
    }
}
