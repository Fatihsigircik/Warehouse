namespace SimpleWarehouseWindows.NewForm.Customer
{
    partial class frmCustomerList
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
            this.tsmiNewCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.kgbFilter = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kbtnClearFilter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ktxtCity = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtPhone = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtSurname = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtCompanyName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtCustomerCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kdgvList = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter.Panel)).BeginInit();
            this.kgbFilter.Panel.SuspendLayout();
            this.kgbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsCustomer
            // 
            this.cmsCustomer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomer.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsCustomer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewCustomer,
            this.tsmiUpdate,
            this.tsmiDelete});
            this.cmsCustomer.Name = "cmsCustomer";
            this.cmsCustomer.Size = new System.Drawing.Size(181, 92);
            // 
            // tsmiNewCustomer
            // 
            this.tsmiNewCustomer.Name = "tsmiNewCustomer";
            this.tsmiNewCustomer.Size = new System.Drawing.Size(180, 22);
            this.tsmiNewCustomer.Text = "Yeni Cari ";
            this.tsmiNewCustomer.Click += new System.EventHandler(this.tsmiNewCustomer_Click);
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
            // kgbFilter
            // 
            this.kgbFilter.CaptionOverlap = 0D;
            this.kgbFilter.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.kgbFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.kgbFilter.Location = new System.Drawing.Point(0, 0);
            this.kgbFilter.Margin = new System.Windows.Forms.Padding(4);
            this.kgbFilter.Name = "kgbFilter";
            // 
            // kgbFilter.Panel
            // 
            this.kgbFilter.Panel.Controls.Add(this.kbtnClearFilter);
            this.kgbFilter.Panel.Controls.Add(this.ktxtCity);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel4);
            this.kgbFilter.Panel.Controls.Add(this.ktxtPhone);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel5);
            this.kgbFilter.Panel.Controls.Add(this.ktxtSurname);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel6);
            this.kgbFilter.Panel.Controls.Add(this.ktxtName);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel3);
            this.kgbFilter.Panel.Controls.Add(this.ktxtCompanyName);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel2);
            this.kgbFilter.Panel.Controls.Add(this.ktxtCustomerCode);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel1);
            this.kgbFilter.Size = new System.Drawing.Size(316, 762);
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
            this.kgbFilter.TabIndex = 0;
            this.kgbFilter.Values.Heading = "Filtre";
            this.kgbFilter.Values.Image = global::SimpleWarehouseWindows.Properties.Resources.traceable;
            // 
            // kbtnClearFilter
            // 
            this.kbtnClearFilter.Location = new System.Drawing.Point(15, 561);
            this.kbtnClearFilter.Margin = new System.Windows.Forms.Padding(4);
            this.kbtnClearFilter.Name = "kbtnClearFilter";
            this.kbtnClearFilter.Size = new System.Drawing.Size(253, 31);
            this.kbtnClearFilter.TabIndex = 12;
            this.kbtnClearFilter.Values.Text = "Filtreyi Temizle";
            this.kbtnClearFilter.Click += new System.EventHandler(this.kbtnClearFilter_Click);
            // 
            // ktxtCity
            // 
            this.ktxtCity.Location = new System.Drawing.Point(13, 484);
            this.ktxtCity.Margin = new System.Windows.Forms.Padding(4);
            this.ktxtCity.Name = "ktxtCity";
            this.ktxtCity.Size = new System.Drawing.Size(255, 23);
            this.ktxtCity.TabIndex = 11;
            this.ktxtCity.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(15, 452);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(18, 20);
            this.kryptonLabel4.TabIndex = 10;
            this.kryptonLabel4.Values.Text = "İl";
            // 
            // ktxtPhone
            // 
            this.ktxtPhone.Location = new System.Drawing.Point(13, 400);
            this.ktxtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.ktxtPhone.Name = "ktxtPhone";
            this.ktxtPhone.Size = new System.Drawing.Size(255, 23);
            this.ktxtPhone.TabIndex = 9;
            this.ktxtPhone.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel5.Location = new System.Drawing.Point(15, 368);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(54, 20);
            this.kryptonLabel5.TabIndex = 8;
            this.kryptonLabel5.Values.Text = "Telefon";
            // 
            // ktxtSurname
            // 
            this.ktxtSurname.Location = new System.Drawing.Point(13, 316);
            this.ktxtSurname.Margin = new System.Windows.Forms.Padding(4);
            this.ktxtSurname.Name = "ktxtSurname";
            this.ktxtSurname.Size = new System.Drawing.Size(255, 23);
            this.ktxtSurname.TabIndex = 7;
            this.ktxtSurname.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel6.Location = new System.Drawing.Point(15, 284);
            this.kryptonLabel6.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(76, 20);
            this.kryptonLabel6.TabIndex = 6;
            this.kryptonLabel6.Values.Text = "Cari Soyadı";
            // 
            // ktxtName
            // 
            this.ktxtName.Location = new System.Drawing.Point(13, 229);
            this.ktxtName.Margin = new System.Windows.Forms.Padding(4);
            this.ktxtName.Name = "ktxtName";
            this.ktxtName.Size = new System.Drawing.Size(255, 23);
            this.ktxtName.TabIndex = 5;
            this.ktxtName.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(15, 197);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(57, 20);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Cari Adı";
            // 
            // ktxtCompanyName
            // 
            this.ktxtCompanyName.Location = new System.Drawing.Point(13, 145);
            this.ktxtCompanyName.Margin = new System.Windows.Forms.Padding(4);
            this.ktxtCompanyName.Name = "ktxtCompanyName";
            this.ktxtCompanyName.Size = new System.Drawing.Size(255, 23);
            this.ktxtCompanyName.TabIndex = 3;
            this.ktxtCompanyName.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(15, 113);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(67, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Firma Adı";
            // 
            // ktxtCustomerCode
            // 
            this.ktxtCustomerCode.Location = new System.Drawing.Point(13, 62);
            this.ktxtCustomerCode.Margin = new System.Windows.Forms.Padding(4);
            this.ktxtCustomerCode.Name = "ktxtCustomerCode";
            this.ktxtCustomerCode.Size = new System.Drawing.Size(255, 23);
            this.ktxtCustomerCode.TabIndex = 1;
            this.ktxtCustomerCode.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(15, 30);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(60, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Cari Kod";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanel1.Controls.Add(this.kdgvList);
            this.kryptonPanel1.Location = new System.Drawing.Point(316, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1527, 762);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kdgvList
            // 
            this.kdgvList.AllowUserToAddRows = false;
            this.kdgvList.AllowUserToDeleteRows = false;
            this.kdgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column12,
            this.Column13,
            this.Telefon,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.kdgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kdgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.kdgvList.Location = new System.Drawing.Point(0, 0);
            this.kdgvList.Margin = new System.Windows.Forms.Padding(4);
            this.kdgvList.MultiSelect = false;
            this.kdgvList.Name = "kdgvList";
            this.kdgvList.ReadOnly = true;
            this.kdgvList.RowHeadersWidth = 10;
            this.kdgvList.RowTemplate.ContextMenuStrip = this.cmsCustomer;
            this.kdgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kdgvList.Size = new System.Drawing.Size(1527, 762);
            this.kdgvList.TabIndex = 0;
            this.kdgvList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.kdgvList_MouseDoubleClick);
            this.kdgvList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kdgvList_MouseDown);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CustomerCode";
            this.Column1.HeaderText = "Cari Kodu";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CompanyName";
            this.Column2.HeaderText = "Firma Adı";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "CustomerName";
            this.Column3.HeaderText = "Cari Adı";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "CustomerSurname";
            this.Column4.HeaderText = "Cari Soyadı";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "TaxNumber";
            this.Column12.HeaderText = "Vergi Numarası";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "TaxOffice";
            this.Column13.HeaderText = "Vergi Dairesi";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Telefon
            // 
            this.Telefon.DataPropertyName = "Phone";
            this.Telefon.HeaderText = "Telefon";
            this.Telefon.Name = "Telefon";
            this.Telefon.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Phone2";
            this.Column5.HeaderText = "Telefon2";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Mail";
            this.Column6.HeaderText = "E-Mail";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "CountryName";
            this.Column7.HeaderText = "Ülke";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "CityName";
            this.Column8.HeaderText = "İl";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "TownName";
            this.Column9.HeaderText = "İlçe";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Address";
            this.Column10.HeaderText = "Adres";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "Address2";
            this.Column11.HeaderText = "Adres2";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // frmCustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1843, 762);
            this.Controls.Add(this.kgbFilter);
            this.Controls.Add(this.kryptonPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCustomerList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cari Listesi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCustomerList_FormClosed);
            this.Load += new System.EventHandler(this.frmCustomerList_Load);
            this.cmsCustomer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter.Panel)).EndInit();
            this.kgbFilter.Panel.ResumeLayout(false);
            this.kgbFilter.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter)).EndInit();
            this.kgbFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kdgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kgbFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kdgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtCompanyName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtCustomerCode;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtCity;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtPhone;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtSurname;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnClearFilter;
        private System.Windows.Forms.ContextMenuStrip cmsCustomer;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewCustomer;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
    }
}