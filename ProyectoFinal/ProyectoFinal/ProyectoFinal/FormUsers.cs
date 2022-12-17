using BussinesLayer;
using DataBase.Models;
using ProyectoFinal.Customs;
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

namespace ProyectoFinal
{
    public partial class FormUsers : Form
    {
        LoginService service;
        ListasService listasService;
        public int? id = null;
        public FormUsers()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            SqlConnection _connection = new SqlConnection(connectionString);
            service = new LoginService(_connection);
            listasService = new ListasService(_connection);
        }
        private void LoadUser()
        {
            dgvUsers.DataSource = service.GetAll();
            dgvUsers.ClearSelection();
        }

        private void FormUsers_Load(object sender, EventArgs e)
        {
            LoadCombobox();
            LoadUser();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells[0].Value.ToString());
                btndeselect.Visible = true;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id == null)
            {
                try
                {
                    Add();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error", "Aviso");
                }
                
            }
            else
            {
                try
                { 
                    Edit();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error", "Aviso");
                }
               
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }


        private void btndeselect_Click(object sender, EventArgs e)
        {
            Deselect();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edicion();
        }

        #region metodos

        private void Add()
        {
            Login login = new Login();
            ComboboxItem select = cbxType.SelectedItem as ComboboxItem;
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("Ingrese una nombre", "Aviso");
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Ingrese una contrase;a", "Aviso");
            }
            else if (txtPassword.Text!=txtConfirmPass.Text)
            {
                MessageBox.Show("Confirme la contrase;a", "Aviso");
            }
            else if (select==null)
            {
                MessageBox.Show("Seleccione el tipo de usuario", "Aviso");
            }
            else
            {
                login.UserName = txtUser.Text;
                login.PasswordH=txtConfirmPass.Text;
                login.IdTipo = 1;

                service.Add(login);
                MessageBox.Show("Se Guardo", "Aviso");
                LoadUser();
                ClearData();
            }
        }
        private void Delete()
        {
            if (id == null)
            {
                MessageBox.Show("Selecciona el usuario", "Aviso");
            }
            else
            {
                DialogResult result = MessageBox.Show("Estas seguro que desea eliminar la entidad", "Aviso", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    service.Delete(id.Value);
                    MessageBox.Show("Se elimino", "Aviso");
                    LoadUser();
                    Deselect();
                }
            }
        }
        private void Edit()
        {
            Login l = new Login();
            ComboboxItem select = cbxType.SelectedItem as ComboboxItem;
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("Ingrese una nombre", "Aviso");
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Ingrese una contrase;a", "Aviso");
            }
            else if (txtPassword.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Confirme la contrase;a", "Aviso");
            }
            else if (select == null)
            {
                MessageBox.Show("Seleccione el tipo de usuario", "Aviso");
            }
            else
            {
                l.UserName = txtUser.Text;
                l.PasswordH = txtConfirmPass.Text;
                l.IdTipo = Convert.ToInt32(select.Value);
                l.IdLogin = id.Value;

                service.Edit(l);
                MessageBox.Show("Se Edito", "Aviso");
                LoadUser();
                Deselect();
                ClearData();
            }
        }        
        private void Edicion()
        {
            if (id == null)
            {
                MessageBox.Show("Selecciona el usuario", "Aviso");
            }
            else
            {
                Login login = new Login();
                login = service.GetId(id.Value);

                txtUser.Text = login.UserName;
                txtPassword.Text = login.PasswordH;
                if (string.IsNullOrEmpty(login.Type))
                {
                    cbxType.SelectedIndex = 0;
                }
                else
                {
                    cbxType.SelectedIndex = cbxType.FindStringExact(login.Type);
                }
            }
        }
        private void ClearData()
        {
            txtUser.Clear();
            txtPassword.Clear();
            txtConfirmPass.Clear();
            cbxType.SelectedIndex = 0;
        }
        private void LoadCombobox()
        {
            ComboboxItem opcion = new ComboboxItem();
            opcion.Text = "Seleccione una opcion";
            opcion.Value = null;

            cbxType.Items.Add(opcion);

            List<TipoUsuario> list = listasService.GetUsersType();

            foreach(TipoUsuario item in list)
            {
                ComboboxItem cbx = new ComboboxItem
                {
                    Text = item.Name,
                    Value = item.Id
                };
                cbxType.Items.Add(cbx);
            }
            cbxType.SelectedItem = opcion;
        }
        private void Deselect()
        {
            dgvUsers.ClearSelection();
            btndeselect.Visible = false;
            id = null;
        }
        #endregion
    }
}
