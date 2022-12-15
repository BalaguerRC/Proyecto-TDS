using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoFinal
{
    public partial class FormLogin : Form
    {
        public SqlConnection _connection;
        public FormLogin()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            _connection = new SqlConnection(connectionString);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Logear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Program.boolAuthentication = false;
            this.Close();
        }
        public void Logear()
        {
            //Program.boolAuthentication = true;
            //this.Close();
            try
            {
                Boolean r = false;
                _connection.Open();

                SqlCommand command = new SqlCommand("select nombre, pass from log_in where nombre=@user and pass=@password", _connection);

                command.Parameters.AddWithValue("@user", TxtUser.Text);
                command.Parameters.AddWithValue("@password", TxtPassword.Text);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    r = true;
                }
                if (r)
                {

                    /*while (reader.Read())
                    {
                        LoginCache.id = reader.GetInt32(0);
                        LoginCache.name = reader.GetString(16);
                    }*/

                    Program.boolAuthentication = true;
                    
                    this.Close();
                    //FormMenuPrincipal menu = new FormMenuPrincipal();
                    //menu.Show();
                    TxtUser.Clear();
                    TxtPassword.Clear();

                }
                else
                {
                    MessageBox.Show("Datos Erroneos", "Aviso");
                }
                _connection.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un error", "aviso");
                //textBox2.Clear();
            }
        }
    }
}
