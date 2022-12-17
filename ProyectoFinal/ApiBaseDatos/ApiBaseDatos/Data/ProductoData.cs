using ApiBaseDatos.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace ApiBaseDatos.Data
{
    public class ProductoData
    {
        public static bool Registrar(Producto producto)
        {
            using(SqlConnection connection= new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar", connection);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", producto.Name);
                cmd.Parameters.AddWithValue("@precio", producto.Price);
                cmd.Parameters.AddWithValue("@tipo", producto.Type);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }
        public static List<Producto> Listar()
        {
            List<Producto> listProducto = new List<Producto>();
            using(SqlConnection connection= new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    //cmd.ExecuteNonQuery();
                    using(SqlDataReader dr= cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listProducto.Add(new Producto()
                            {
                                Id= Convert.ToInt32(dr["id_prod"]),
                                Name = dr["prod_name"].ToString(),
                                Price = dr["prod_price"].ToString(),
                                Date= Convert.ToDateTime(dr["prod_date"].ToString()),
                                Type = Convert.ToDouble(dr["prod_type"])
                            });
                        }
                    }
                    return listProducto;
                }
                catch (Exception ex)
                {
                    return listProducto;
                }
            }
        }

        public static Producto Obtener(int Id)
        {
            Producto producto = new Producto();
            using (SqlConnection connection = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", Id);

                try
                {
                    connection.Open();
                    //cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            producto=new Producto()
                            {
                                Id = Convert.ToInt32(dr["id_prod"]),
                                Name = dr["prod_name"].ToString(),
                                Price = dr["prod_price"].ToString(),
                                Date = Convert.ToDateTime(dr["prod_date"].ToString()),
                                Type = Convert.ToDouble(dr["prod_type"])
                            };
                        }
                    }
                    return producto;
                }
                catch (Exception ex)
                {
                    return producto;
                }
            }
        }
    }
}