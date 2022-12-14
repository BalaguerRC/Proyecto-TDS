using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinal
{
    class Funciones
    {

        public static SqlConnection conex()
        {
            SqlConnection strconect = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
            return strconect;
        }

    }
}
