using BussinesLayer;
using ClosedXML.Excel;
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
            // TODO: esta línea de código carga datos en la tabla 'proyect_tdsDataSet.producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter.Fill(this.proyect_tdsDataSet.producto);
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
                MessageBox.Show("Ingrese una contrase;a", "Aviso");
            }
            else if (select == null)
            {
                MessageBox.Show("Seleccione la categoria del producto", "Aviso");
            }
            else
            {
                p.ProductName = txtName.Text;
                p.ProductPrice= txtPrice.Text;
                p.IdProductType= 0;

                productService.Add(p);
                MessageBox.Show("Se Guardo", "Aviso");
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
                MessageBox.Show("Ingrese una contrase;a", "Aviso");
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
        #endregion

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog sfd = new SaveFileDialog(){ Filter = "Excel Workbook|*.xlsx" })
            {
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            workbook.Worksheets.Add(this.proyect_tdsDataSet.producto.CopyToDataTable(), "producto");
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("ha guardado correctamente su documento tipo Excel.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
