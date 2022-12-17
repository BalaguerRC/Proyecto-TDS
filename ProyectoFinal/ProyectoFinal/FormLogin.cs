using DataBase.Models;
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
        public Boolean validation = false;
        public FormLogin()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            _connection = new SqlConnection(connectionString);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Logear();
            cache();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Logear()
        {
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
                    validation= true;
                    Cache.Name = TxtUser.Text;
                    TxtUser.Clear();
                    TxtPassword.Clear();
                    //cache();
                }
                else
                {
                    Cache.Name = "";
                    MessageBox.Show("Datos Erroneos", "Aviso");
                }
                _connection.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un error", "Aviso Login");
                //textBox2.Clear();
            }
        }
        public void cache()
        {
            try
            {
                if (Cache.Name!="")
                {

                    _connection.Open();

                    SqlCommand command2 = new SqlCommand("Select id_tipo from log_in where nombre=@user", _connection);
                    command2.Parameters.AddWithValue("@user", Cache.Name);
                    SqlDataReader reader2 = command2.ExecuteReader();
                    while (reader2.Read())
                    {
                        Cache.IdLogin = reader2.IsDBNull(0) ? 0 : reader2.GetInt32(0);
                    }
                    if (Cache.IdLogin == 1)
                    {
                        this.Hide();
                        FormMenuPrincipalEmpleado form = new FormMenuPrincipalEmpleado();
                        form.ShowDialog(this);
                        this.Show();

                    }
                    else
                    {

                        this.Hide();
                        FormMenuE form = new FormMenuE();
                        form.ShowDialog(this);
                        this.Show();

                    }
                    _connection.Close();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
