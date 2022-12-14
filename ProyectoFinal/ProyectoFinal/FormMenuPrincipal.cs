using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class FormMenuPrincipal : Form
    {

        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);


        public FormMenuPrincipal()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        private void Fecha()
        {
            //toolstripfecha.Text= DataTime.Now.ToString()
        }

        private void btnCorreo_Click(object sender, EventArgs e)
        {
            FormCorreo correo = new FormCorreo();
            correo.TopLevel = false;
            correo.Dock= DockStyle.Fill;
            panelMostrar.Controls.Add(correo);
            correo.Show();
        }
    }
}
