namespace SimpleWarehouseWindows.NewForm.Product
{
    partial class frmProductList
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
            this.cmsCustomer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiNewProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kdgvList = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kgbFilter = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kbtnClearFilter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ktxtBarcode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtProductName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtProductCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tsmiProductImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter.Panel)).BeginInit();
            this.kgbFilter.Panel.SuspendLayout();
            this.kgbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsCustomer
            // 
            this.cmsCustomer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomer.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsCustomer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewProduct,
            this.tsmiUpdate,
            this.tsmiDelete,
            this.toolStripSeparator1,
            this.tsmiProductImage});
            this.cmsCustomer.Name = "cmsCustomer";
            this.cmsCustomer.Size = new System.Drawing.Size(181, 120);
            // 
            // tsmiNewProduct
            // 
            this.tsmiNewProduct.Name = "tsmiNewProduct";
            this.tsmiNewProduct.Size = new System.Drawing.Size(180, 22);
            this.tsmiNewProduct.Text = "Yeni Ürün";
            this.tsmiNewProduct.Click += new System.EventHandler(this.tsmiNewProduct_Click);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(180, 22);
            this.tsmiUpdate.Text = "Düzenle";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(180, 22);
            this.tsmiDelete.Text = "Sil";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanel1.Controls.Add(this.kdgvList);
            this.kryptonPanel1.Location = new System.Drawing.Point(237, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1145, 619);
            this.kryptonPanel1.TabIndex = 3;
            // 
            // kdgvList
            // 
            this.kdgvList.AllowUserToAddRows = false;
            this.kdgvList.AllowUserToDeleteRows = false;
            this.kdgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column6,
            this.Column4,
            this.Column5});
            this.kdgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kdgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.kdgvList.Location = new System.Drawing.Point(0, 0);
            this.kdgvList.MultiSelect = false;
            this.kdgvList.Name = "kdgvList";
            this.kdgvList.ReadOnly = true;
            this.kdgvList.RowHeadersWidth = 10;
            this.kdgvList.RowTemplate.ContextMenuStrip = this.cmsCustomer;
            this.kdgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kdgvList.Size = new System.Drawing.Size(1145, 619);
            this.kdgvList.TabIndex = 0;
            this.kdgvList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.kdgvList_MouseDoubleClick);
            this.kdgvList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kdgvList_MouseDown);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ProductCode";
            this.Column1.HeaderText = "Ürün Kodu";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ProductName";
            this.Column2.HeaderText = "Ürün Adı";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Barcode";
            this.Column3.HeaderText = "Barkod";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "VatPercent";
            this.Column6.HeaderText = "KDV Oranı";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "UnitName";
            this.Column4.HeaderText = "Birim";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "CreatedDate";
            this.Column5.HeaderText = "Eklenme Tarihi";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // kgbFilter
            // 
            this.kgbFilter.CaptionOverlap = 0D;
            this.kgbFilter.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.kgbFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.kgbFilter.Location = new System.Drawing.Point(0, 0);
            this.kgbFilter.Name = "kgbFilter";
            // 
            // kgbFilter.Panel
            // 
            this.kgbFilter.Panel.Controls.Add(this.kbtnClearFilter);
            this.kgbFilter.Panel.Controls.Add(this.ktxtBarcode);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel3);
            this.kgbFilter.Panel.Controls.Add(this.ktxtProductName);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel2);
            this.kgbFilter.Panel.Controls.Add(this.ktxtProductCode);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel1);
            this.kgbFilter.Size = new System.Drawing.Size(237, 619);
            this.kgbFilter.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.kgbFilter.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.kgbFilter.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kgbFilter.StateCommon.Border.Width = 1;
            this.kgbFilter.StateDisabled.Border.Color1 = System.Drawing.Color.Black;
            this.kgbFilter.StateDisabled.Border.Color2 = System.Drawing.Color.Black;
            this.kgbFilter.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kgbFilter.StateDisabled.Border.Width = 1;
            this.kgbFilter.StateNormal.Border.Color1 = System.Drawing.Color.Black;
            this.kgbFilter.StateNormal.Border.Color2 = System.Drawing.Color.Black;
            this.kgbFilter.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kgbFilter.StateNormal.Border.Width = 1;
            this.kgbFilter.TabIndex = 2;
            this.kgbFilter.Values.Heading = "Filtre";
            this.kgbFilter.Values.Image = global::SimpleWarehouseWindows.Properties.Resources.traceable;
            // 
            // kbtnClearFilter
            // 
            this.kbtnClearFilter.Location = new System.Drawing.Point(11, 456);
            this.kbtnClearFilter.Name = "kbtnClearFilter";
            this.kbtnClearFilter.Size = new System.Drawing.Size(190, 25);
            this.kbtnClearFilter.TabIndex = 12;
            this.kbtnClearFilter.Values.Text = "Filtreyi Temizle";
            this.kbtnClearFilter.Click += new System.EventHandler(this.kbtnClearFilter_Click);
            // 
            // ktxtBarcode
            // 
            this.ktxtBarcode.Location = new System.Drawing.Point(10, 186);
            this.ktxtBarcode.Name = "ktxtBarcode";
            this.ktxtBarcode.Size = new System.Drawing.Size(191, 23);
            this.ktxtBarcode.TabIndex = 5;
            this.ktxtBarcode.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(11, 160);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(52, 20);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Barkod";
            // 
            // ktxtProductName
            // 
            this.ktxtProductName.Location = new System.Drawing.Point(10, 118);
            this.ktxtProductName.Name = "ktxtProductName";
            this.ktxtProductName.Size = new System.Drawing.Size(191, 23);
            this.ktxtProductName.TabIndex = 3;
            this.ktxtProductName.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(11, 92);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(63, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Ürün Adı";
            // 
            // ktxtProductCode
            // 
            this.ktxtProductCode.Location = new System.Drawing.Point(10, 50);
            this.ktxtProductCode.Name = "ktxtProductCode";
            this.ktxtProductCode.Size = new System.Drawing.Size(191, 23);
            this.ktxtProductCode.TabIndex = 1;
            this.ktxtProductCode.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(11, 24);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(73, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Ürün Kodu";
            // 
            // tsmiProductImage
            // 
            this.tsmiProductImage.Name = "tsmiProductImage";
            this.tsmiProductImage.Size = new System.Drawing.Size(180, 22);
            this.tsmiProductImage.Text = "Ürün Resimleri";
            this.tsmiProductImage.Click += new System.EventHandler(this.tsmiProductImage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // frmProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 619);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kgbFilter);
            this.Name = "frmProductList";
            this.Text = "frmProductList";
            this.Load += new System.EventHandler(this.frmProductList_Load);
            this.cmsCustomer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kdgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter.Panel)).EndInit();
            this.kgbFilter.Panel.ResumeLayout(false);
            this.kgbFilter.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter)).EndInit();
            this.kgbFilter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnClearFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtBarcode;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtProductName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtProductCode;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kdgvList;
        private System.Windows.Forms.ContextMenuStrip cmsCustomer;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kgbFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiProductImage;
    }
}