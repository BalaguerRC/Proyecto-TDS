namespace ProyectoFinal
{
    partial class FormInventarioAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabInventario = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label24 = new System.Windows.Forms.Label();
            this.btndeselect = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.proyect_tdsDataSet = new ProyectoFinal.proyect_tdsDataSet();
            this.productoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productoTableAdapter = new ProyectoFinal.proyect_tdsDataSetTableAdapters.productoTableAdapter();
            this.idprodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodpriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proddateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodtypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabInventario.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proyect_tdsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tabInventario, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.77504F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.22495F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(674, 462);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tabInventario
            // 
            this.tabInventario.Controls.Add(this.tabPage1);
            this.tabInventario.Controls.Add(this.tabPage2);
            this.tabInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInventario.Location = new System.Drawing.Point(2, 56);
            this.tabInventario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabInventario.Name = "tabInventario";
            this.tabInventario.SelectedIndex = 0;
            this.tabInventario.Size = new System.Drawing.Size(670, 404);
            this.tabInventario.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(662, 378);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Productos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.72014F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.27986F));
            this.tableLayoutPanel2.Controls.Add(this.dgvInventario, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.50216F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.49783F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(658, 374);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dgvInventario
            // 
            this.dgvInventario.AutoGenerateColumns = false;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idprodDataGridViewTextBoxColumn,
            this.prodnameDataGridViewTextBoxColumn,
            this.prodpriceDataGridViewTextBoxColumn,
            this.proddateDataGridViewTextBoxColumn,
            this.prodtypeDataGridViewTextBoxColumn});
            this.dgvInventario.DataSource = this.productoBindingSource;
            this.dgvInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventario.Location = new System.Drawing.Point(2, 56);
            this.dgvInventario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.RowHeadersWidth = 51;
            this.dgvInventario.RowTemplate.Height = 24;
            this.dgvInventario.Size = new System.Drawing.Size(481, 316);
            this.dgvInventario.TabIndex = 0;
            this.dgvInventario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellClick);
            this.dgvInventario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellContentClick);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.45483F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.54517F));
            this.tableLayoutPanel3.Controls.Add(this.label24, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btndeselect, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(481, 50);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Dock = System.Windows.Forms.DockStyle.Left;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(2, 0);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(92, 50);
            this.label24.TabIndex = 6;
            this.label24.Text = "Selecciona:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btndeselect
            // 
            this.btndeselect.Location = new System.Drawing.Point(119, 2);
            this.btndeselect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btndeselect.Name = "btndeselect";
            this.btndeselect.Size = new System.Drawing.Size(124, 44);
            this.btndeselect.TabIndex = 7;
            this.btndeselect.Text = "Deseleccion";
            this.btndeselect.UseVisualStyleBackColor = true;
            this.btndeselect.Visible = false;
            this.btndeselect.Click += new System.EventHandler(this.btndeselect_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.btnExcel, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.btnAdd, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnEdit, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnDelete, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(487, 56);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.15528F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.84472F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(169, 316);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(2, 238);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(124, 45);
            this.btnExcel.TabIndex = 11;
            this.btnExcel.Text = "Descargar Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(2, 2);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(124, 45);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(2, 81);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(124, 45);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(2, 159);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(124, 45);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Borrar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(662, 378);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Page2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.71672F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.28328F));
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.txtName, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.txtPrice, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.cbCategory, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.btnSave, 1, 4);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 5;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.33333F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(658, 374);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Agregar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 148);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Precio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 222);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Categoria:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(204, 66);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(292, 20);
            this.txtName.TabIndex = 4;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(204, 150);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(292, 20);
            this.txtPrice.TabIndex = 5;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(204, 224);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(292, 21);
            this.cbCategory.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(204, 298);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(157, 47);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inventario";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // proyect_tdsDataSet
            // 
            this.proyect_tdsDataSet.DataSetName = "proyect_tdsDataSet";
            this.proyect_tdsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productoBindingSource
            // 
            this.productoBindingSource.DataMember = "producto";
            this.productoBindingSource.DataSource = this.proyect_tdsDataSet;
            // 
            // productoTableAdapter
            // 
            this.productoTableAdapter.ClearBeforeFill = true;
            // 
            // idprodDataGridViewTextBoxColumn
            // 
            this.idprodDataGridViewTextBoxColumn.DataPropertyName = "id_prod";
            this.idprodDataGridViewTextBoxColumn.HeaderText = "id_prod";
            this.idprodDataGridViewTextBoxColumn.Name = "idprodDataGridViewTextBoxColumn";
            this.idprodDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prodnameDataGridViewTextBoxColumn
            // 
            this.prodnameDataGridViewTextBoxColumn.DataPropertyName = "prod_name";
            this.prodnameDataGridViewTextBoxColumn.HeaderText = "prod_name";
            this.prodnameDataGridViewTextBoxColumn.Name = "prodnameDataGridViewTextBoxColumn";
            // 
            // prodpriceDataGridViewTextBoxColumn
            // 
            this.prodpriceDataGridViewTextBoxColumn.DataPropertyName = "prod_price";
            this.prodpriceDataGridViewTextBoxColumn.HeaderText = "prod_price";
            this.prodpriceDataGridViewTextBoxColumn.Name = "prodpriceDataGridViewTextBoxColumn";
            // 
            // proddateDataGridViewTextBoxColumn
            // 
            this.proddateDataGridViewTextBoxColumn.DataPropertyName = "prod_date";
            this.proddateDataGridViewTextBoxColumn.HeaderText = "prod_date";
            this.proddateDataGridViewTextBoxColumn.Name = "proddateDataGridViewTextBoxColumn";
            // 
            // prodtypeDataGridViewTextBoxColumn
            // 
            this.prodtypeDataGridViewTextBoxColumn.DataPropertyName = "prod_type";
            this.prodtypeDataGridViewTextBoxColumn.HeaderText = "prod_type";
            this.prodtypeDataGridViewTextBoxColumn.Name = "prodtypeDataGridViewTextBoxColumn";
            // 
            // FormInventarioAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 462);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormInventarioAdmin";
            this.Text = "FormInventarioAdmin";
            this.Load += new System.EventHandler(this.FormInventarioAdmin_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabInventario.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proyect_tdsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabInventario;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btndeselect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExcel;
        private proyect_tdsDataSet proyect_tdsDataSet;
        private System.Windows.Forms.BindingSource productoBindingSource;
        private proyect_tdsDataSetTableAdapters.productoTableAdapter productoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idprodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodpriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proddateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodtypeDataGridViewTextBoxColumn;
    }
}