using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataBase.Models;

namespace DataBase
{
    public class ProductRepo
    {
        private SqlConnection _connection;
        public ProductRepo(SqlConnection connection)
        {
            _connection = connection;
        }
        public bool Add(Product item)
        {
            SqlCommand command = new SqlCommand("insert into product(prod_name,prod_price,prod_type) values(@name,@price,@idtipo)", _connection);
            command.Parameters.AddWithValue("@name", item.ProductName);
            command.Parameters.AddWithValue("@price", item.ProductPrice);
            command.Parameters.AddWithValue("@idtipo", item.IdProductType);

            return ExecuteDml(command);
        }
        public bool Edit(Product item)
        {
            SqlCommand command = new SqlCommand("update product set prod_name=@name, prod_price=@price, prod_type=@idtipo,prod_date=getdate() where id_prod=@id", _connection);
            command.Parameters.AddWithValue("@name", item.ProductName);
            command.Parameters.AddWithValue("@price", item.ProductPrice);
            command.Parameters.AddWithValue("@idtipo", item.IdProductType);
            command.Parameters.AddWithValue("@id", item.IdProduct);

            return ExecuteDml(command);
        }
        public bool Delete(int id)
        {
            SqlCommand command = new SqlCommand("delete product where id_prod=@id", _connection);
            command.Parameters.AddWithValue("@id", id);

            return ExecuteDml(command);
        }
        public Product GetId(int id)
        {
            try
            {
                _connection.Open();
                Product data = new Product();

                SqlCommand command = new SqlCommand("Select pr.id_prod,pr.prod_name,pr.prod_price,prt.type_names as ProductTipo from product pr join prod_type prt on pr.prod_type=prt.id_typProd where pr.id_prod=@id", _connection);
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data.IdProduct = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    data.ProductName = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    data.ProductPrice = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    data.ProductTipo = reader.IsDBNull(3) ? "" : reader.GetString(3);

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
            SqlDataAdapter query = new SqlDataAdapter("Select pr.id_prod as Id,pr.prod_name as Name,pr.prod_price as Price,prt.type_names as ProductType,pr.prod_date as Date from product pr join prod_type prt on pr.prod_type=prt.id_typProd", _connection);
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
