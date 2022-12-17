using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class ListasTipos
    {
        private SqlConnection _connection;
        public ListasTipos(SqlConnection connection)
        {
            _connection = connection;
        }
        public List<TipoUsuario> GetUsersType()
        {
            try
            {
                List<TipoUsuario> list = new List<TipoUsuario>();
                _connection.Open();

                SqlCommand command = new SqlCommand("select id_type,tipo_usuario from tipo_user", _connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new TipoUsuario
                    {
                        Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? "" : reader.GetString(1)
                    });

                }

                reader.Close();
                reader.Dispose();

                _connection.Close();

                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<TipoProducto> GetProductType()
        {
            try
            {
                List<TipoProducto> list = new List<TipoProducto>();
                _connection.Open();

                SqlCommand command = new SqlCommand("select id_typProd,type_names from prod_type", _connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new TipoProducto
                    {
                        Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? "" : reader.GetString(1)
                    });

                }

                reader.Close();
                reader.Dispose();

                _connection.Close();

                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
