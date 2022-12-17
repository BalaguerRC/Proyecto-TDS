using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using DataBase.Models;

namespace DataBase
{
    
    public class LoginRepo
    {
        private SqlConnection _connection;
        public LoginRepo(SqlConnection connection)
        {
            _connection = connection;
        }
        public bool Add(Login item)
        {
            SqlCommand command= new SqlCommand("insert into log_in(nombre,pass,id_Tipo) values(@name,@pass,@idtipo)", _connection);
            command.Parameters.AddWithValue("@name", item.UserName);
            command.Parameters.AddWithValue("@pass", item.PasswordH);
            command.Parameters.AddWithValue("@idtipo", item.IdTipo);

            return ExecuteDml(command);
        }
        public bool Edit(Login item)
        {
            SqlCommand command = new SqlCommand("update log_in set nombre=@name, pass=@pass,id_Tipo=@idtipo,Fecha=getdate() where id_user=@id", _connection);
            command.Parameters.AddWithValue("@name", item.UserName);
            command.Parameters.AddWithValue("@pass", item.PasswordH);
            command.Parameters.AddWithValue("@idtipo", item.IdTipo);
            command.Parameters.AddWithValue("@id", item.IdLogin);

            return ExecuteDml(command);
        }
        public bool Delete(int id)
        {
            SqlCommand command = new SqlCommand("delete log_in where id_user=@id", _connection);
            command.Parameters.AddWithValue("@id", id);

            return ExecuteDml(command);
        }

        public Login GetId(int id)
        {
            try
            {
                _connection.Open();
                Login data = new Login();

                SqlCommand command = new SqlCommand("Select lg.id_user,lg.nombre,lg.pass,u.tipo_usuario as Type from log_in lg join tipo_user u on lg.id_Tipo=u.id_type where lg.id_user=@id", _connection);
                
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data.IdTipo = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    data.UserName = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    data.PasswordH = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    data.Type = reader.IsDBNull(3) ? "" : reader.GetString(3);

                }
                reader.Close();
                reader.Dispose();
                _connection.Close();
                return data;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public DataTable GetAll()
        {
            SqlDataAdapter query = new SqlDataAdapter("Select lg.id_user as ID,lg.nombre as UserName,lg.pass Password,u.tipo_usuario as Type,lg.Fecha as Date from log_in lg join tipo_user u on lg.id_Tipo=u.id_type", _connection);
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
