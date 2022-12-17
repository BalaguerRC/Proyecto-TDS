using DataBase.Models;
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
    public partial class FormMenuPrincipalEmpleado : Form
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
        public FormMenuPrincipalEmpleado()
        {
            InitializeComponent();
            //Program.boolAuthentication = false;
            //MessageBox.Show($"Usuario {Cache.Name}", "Aviso");
            //Validation(Cache.Name);
        }
        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            OpenForm(new FormInicio());
            Date();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Date();
        }


        private void btnCorreo_Click(object sender, EventArgs e)
        {
            OpenForm(new FormCorreo());
        }       
       
        private void btnsalir_Click(object sender, EventArgs e)
        {
            AlLogin();
        }


        private void btnInventario_Click(object sender, EventArgs e)
        {
            OpenForm(new FormInventarioAdmin());
        }
        private void Date()
        {
            toolstripfecha.Text = DateTime.Now.ToString("dddd MMMM yyyy");
            toolStripfecha2.Text = DateTime.Now.ToString("h:mm:ss");
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            OpenForm(new FormInicio());
        }


        private void btnUsers_Click(object sender, EventArgs e)
        {
            OpenForm(new FormUsers());
        }

        #region metodos
        private void AlLogin()
        {
            this.Close();
        }        
        private void OpenForm(object formHijo)
        {
            if (this.panelMostrar.Controls.Count > 0)
                this.panelMostrar.Controls.RemoveAt(0);
            Form form = formHijo as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panelMostrar.Controls.Add(form);
            this.panelMostrar.Tag = form;
            form.Show();
        }
        #endregion

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            OpenForm(new FormCategoria());
        }
    }
}
