using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Models;

namespace DataBase
{
    public class CategoriaRepo
    {
        private SqlConnection _connection;
        public CategoriaRepo(SqlConnection connection) 
        { 
            _connection = connection; 
        }
        public bool Add(TipoProducto item)
        {
            SqlCommand command = new SqlCommand("insert into prod_type(type_names) values(@name)", _connection);

            command.Parameters.AddWithValue("@name", item.Name);

            return ExecuteDml(command);
        }

        public bool Edit(TipoProducto item)
        {
            SqlCommand command = new SqlCommand("update prod_type set type_names=@name where id_typProd=@id", _connection);

            command.Parameters.AddWithValue("@name", item.Name);
            command.Parameters.AddWithValue("@id", item.Id);



            return ExecuteDml(command);
        }
        public bool Delete(int id)
        {
            SqlCommand command = new SqlCommand("delete prod_type where id_typProd=@id", _connection);

            command.Parameters.AddWithValue("@id", id);

            return ExecuteDml(command);
        }
        public TipoProducto GetById(int id)
        {
            try
            {
                _connection.Open();
                TipoProducto Data = new TipoProducto();

                SqlCommand command = new SqlCommand("Select id_typProd, type_names from prod_type where id_typProd=@id ", _connection);

                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Data.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    Data.Name = reader.IsDBNull(1) ? "" : reader.GetString(1);
                }
                reader.Close();
                reader.Dispose();

                _connection.Close();

                return Data;

            }
            catch (Exception)
            {

                return null;
            }
        }

        public DataTable GetAll()
        {
            SqlDataAdapter query = new SqlDataAdapter("Select id_typProd as Id, type_names as Name  from prod_type", _connection);
            return LoadData(query);
        }
        private DataTable LoadData(SqlDataAdapter query)  //numero de filas
        {
            try
            {
                DataTable data = new DataTable();
                _connection.Open();

                query.Fill(data);

                _connection.Close();

                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        private bool ExecuteDml(SqlCommand query)  //no data
        {
            try
            {
                _connection.Open();

                query.ExecuteNonQuery();

                _connection.Close();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}
