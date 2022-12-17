using BussinesLayer;
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
    public partial class FormCategoria : Form
    {
        CategoriaService service;
        public int? id = null;
        public FormCategoria()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            service = new CategoriaService(connection);
        }

        private void FormCategoria_Load(object sender, EventArgs e)
        {
            LoadCategoria();
        }

        private void btndeselect_Click(object sender, EventArgs e)
        {
            Deselect();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(id== null)
            {
                Add();
            }
            else
            {
                Edit();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edicion();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                id = Convert.ToInt32(dgvCategoria.Rows[e.RowIndex].Cells[0].Value.ToString());
                btndeselect.Visible = true;
            }
        }

        private void Add()
        {
            TipoProducto tipo = new TipoProducto();

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Ingrese el nombre de la categoria", "Aviso");
            }
            else
            {
                tipo.Name= txtName.Text;

                service.Add(tipo);
                MessageBox.Show("Se Guardo", "Aviso");
                LoadCategoria();
            }
        }
        private void LoadCategoria()
        {
            dgvCategoria.DataSource = service.GetAll();
            dgvCategoria.ClearSelection();
        }
        private void Edit()
        {
            TipoProducto tipo = new TipoProducto();

            tipo.Name= txtName.Text;
            tipo.Id = id.Value;

            service.Edit(tipo);
            MessageBox.Show("Se Edito", "Aviso");
            LoadCategoria();
            ClearData();
            Deselect();
        }
        private void Edicion()
        {
            if (id == null)
            {
                MessageBox.Show("Selecciona la categoria", "Aviso");
            }
            else
            {
                TipoProducto tipo = new TipoProducto();
                tipo = service.GetById(id.Value);
                txtName.Text = tipo.Name;

            }
        }
        private void Delete()
        {
            if (id == null)
            {
                MessageBox.Show("Selecciona la categoria", "Aviso");
            }
            else
            {
                DialogResult result = MessageBox.Show("Estas seguro que desea eliminar la categoria", "Aviso", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    service.Delete(id.Value);
                    MessageBox.Show("Se elimino", "Aviso");
                    LoadCategoria();
                    Deselect();
                }
            }
        }
        private void Deselect()
        {
            dgvCategoria.ClearSelection();
            btndeselect.Visible= false;
            id = null;
            ClearData();
        }
        private void ClearData()
        {
            txtName.Clear();
        }
    }
}
