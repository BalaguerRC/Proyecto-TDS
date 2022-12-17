using BussinesLayer;
using DataBase.Models;
using ProyectoFinal.Customs;
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
    public partial class FormInventarioAdmin : Form
    {
        ProductService productService;
        ListasService listasService;
        public int? id = null;
        public FormInventarioAdmin()
        {
            InitializeComponent();
            tabPage2.Parent = null;
            string connectionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            productService= new ProductService(connection);
            listasService = new ListasService(connection);
        }

        private void LoadProduct()
        {
            dgvInventario.DataSource = productService.GetAll();
            dgvInventario.ClearSelection();
        }


        private void FormInventarioAdmin_Load(object sender, EventArgs e)
        {
            LoadCombobox();
            LoadProduct();
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
        private void btndeselect_Click(object sender, EventArgs e)
        {
            Deselect();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }


        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(dgvInventario.Rows[e.RowIndex].Cells[0].Value.ToString());
                btndeselect.Visible = true;
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edicion();
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (tabPage2.Parent == null)
            {
                tabInventario.TabPages.Insert(0, tabPage2);
                
            }
            id = null;
            tabPage2.Text = "Agregar";
            tabPage1.Parent = null;
            tabInventario.SelectedTab = tabPage2;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (tabPage1.Parent == null)
            {
                tabInventario.TabPages.Insert(0, tabPage1);
            }
            tabPage2.Parent = null;
            tabInventario.SelectedTab = tabPage1;
            ClearData();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportarDatos(dgvInventario);
        }        
        #region metodos
        private void Add()
        {
            Product p = new Product();
            ComboboxItem select = cbCategory.SelectedItem as ComboboxItem;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Ingrese una nombre", "Aviso");
            }
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Ingrese un precio", "Aviso");
            }
            else if (select == null)
            {
                MessageBox.Show("Seleccione la categoria del producto", "Aviso");
            }
            else
            {
                p.ProductName = txtName.Text;
                p.ProductPrice= txtPrice.Text;
                p.IdProductType= Convert.ToInt32(select.Value); ;

                productService.Add(p);
                MessageBox.Show("Se Guardo", "Aviso");
                if (tabPage1.Parent == null)
                {
                    tabInventario.TabPages.Insert(0, tabPage1);
                }
                tabPage2.Parent = null;
                tabInventario.SelectedTab = tabPage1;
                LoadProduct();
                ClearData();
            }
        }
        private void Edit()
        {
            Product p = new Product();
            ComboboxItem select = cbCategory.SelectedItem as ComboboxItem;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Ingrese una nombre", "Aviso");
            }
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Ingrese un precio", "Aviso");
            }
            else if (select == null)
            {
                MessageBox.Show("Seleccione la categoria del producto", "Aviso");
            }
            else
            {
                p.ProductName = txtName.Text;
                p.ProductPrice = txtPrice.Text;
                p.IdProductType = Convert.ToInt32(select.Value);
                p.IdProduct = id.Value;

                productService.Edit(p);
                MessageBox.Show("Se Edito", "Aviso");
                if (tabPage1.Parent == null)
                {
                    tabInventario.TabPages.Insert(0, tabPage1);
                }
                tabPage2.Parent = null;
                tabInventario.SelectedTab = tabPage1;
                LoadProduct();
                Deselect();
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
                    productService.Delete(id.Value);
                    MessageBox.Show("Se elimino", "Aviso");
                    LoadProduct();
                    Deselect();
                }
            }
        }
        private void LoadCombobox()
        {
            ComboboxItem opcion = new ComboboxItem();
            opcion.Text = "Seleccione una opcion";
            opcion.Value = null;

            cbCategory.Items.Add(opcion);

            List<TipoProducto> list = listasService.GetProductType();

            foreach (TipoProducto item in list)
            {
                ComboboxItem cbx = new ComboboxItem
                {
                    Text = item.Name,
                    Value = item.Id
                };
                cbCategory.Items.Add(cbx);
            }
            cbCategory.SelectedItem = opcion;
        }
        private void Edicion()
        {
            if (id == null)
            {
                MessageBox.Show("Selecciona el producto", "Aviso");
            }
            else
            {
                if (tabPage2.Parent == null)
                {
                    tabInventario.TabPages.Insert(0, tabPage2);

                }
                tabPage2.Text = "Editar";
                tabPage1.Parent = null;
                tabInventario.SelectedTab = tabPage2;

                Product p = new Product();
                p = productService.GetId(id.Value);
                txtName.Text = p.ProductName;
                txtPrice.Text = p.ProductPrice;
                if (string.IsNullOrEmpty(p.ProductTipo))
                {
                    cbCategory.SelectedIndex = 0;
                }
                else
                {
                    cbCategory.SelectedIndex = cbCategory.FindStringExact(p.ProductTipo);
                }
            }
        }
        private void Deselect()
        {
            dgvInventario.ClearSelection();
            btndeselect.Visible = false;
            id = null;
        }
        private void ClearData()
        {
            txtName.Clear();
            txtPrice.Clear();
            cbCategory.SelectedIndex = 0;
        }        
        public void ExportarDatos(DataGridView dataGrid)
        {
            Microsoft.Office.Interop.Excel.Application exportar = new Microsoft.Office.Interop.Excel.Application();

            exportar.Application.Workbooks.Add(true);

            int indicecolum = 0;
            foreach (DataGridViewColumn column in dataGrid.Columns)
            {
                indicecolum++;
                exportar.Cells[1, indicecolum] = column.Name;

            }
            int indicefila = 0;
            foreach (DataGridViewRow fila in dataGrid.Rows)
            {
                indicefila++;
                indicecolum = 0;
                foreach (DataGridViewColumn column in dataGrid.Columns)
                {
                    indicecolum++;
                    exportar.Cells[indicefila + 1, indicecolum] = fila.Cells[column.Name].Value;
                }
            }
            exportar.Visible = true;
        }
        #endregion
    }
}
