using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;




namespace ProyectoFinal
{
    
        
    

    public partial class FormLogin : Form
    {


        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);


        public FormLogin()
        {
            InitializeComponent();
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
            cnn.Open();
        }
    }
}
