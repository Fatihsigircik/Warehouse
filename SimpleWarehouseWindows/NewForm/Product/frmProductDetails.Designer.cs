namespace SimpleWarehouseWindows.NewForm.Product
{
    partial class frmProductDetails
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
            this.kbtnClearFilter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtWareHouse = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtDocumentNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtCompanyName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtProductName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtProductCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kdgvList = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.cmsCustomer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiNewCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kgbFilter = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kdtpEndDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kdtpStartDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.krbApproved = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.krbNotApproved = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.krbIn = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.krbOut = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.kdgvList)).BeginInit();
            this.cmsCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter.Panel)).BeginInit();
            this.kgbFilter.Panel.SuspendLayout();
            this.kgbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kbtnClearFilter
            // 
            this.kbtnClearFilter.Location = new System.Drawing.Point(11, 548);
            this.kbtnClearFilter.Name = "kbtnClearFilter";
            this.kbtnClearFilter.Size = new System.Drawing.Size(190, 25);
            this.kbtnClearFilter.TabIndex = 12;
            this.kbtnClearFilter.Values.Text = "Filtreyi Temizle";
            this.kbtnClearFilter.Click += new System.EventHandler(this.kbtnClearFilter_Click);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(11, 298);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(76, 20);
            this.kryptonLabel4.TabIndex = 10;
            this.kryptonLabel4.Values.Text = "Grişi / Çıkış";
            // 
            // ktxtWareHouse
            // 
            this.ktxtWareHouse.Location = new System.Drawing.Point(10, 266);
            this.ktxtWareHouse.Name = "ktxtWareHouse";
            this.ktxtWareHouse.Size = new System.Drawing.Size(191, 23);
            this.ktxtWareHouse.TabIndex = 9;
            this.ktxtWareHouse.TextChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel5.Location = new System.Drawing.Point(11, 240);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(42, 20);
            this.kryptonLabel5.TabIndex = 8;
            this.kryptonLabel5.Values.Text = "Depo";
            // 
            // ktxtDocumentNumber
            // 
            this.ktxtDocumentNumber.Location = new System.Drawing.Point(10, 209);
            this.ktxtDocumentNumber.Name = "ktxtDocumentNumber";
            this.ktxtDocumentNumber.Size = new System.Drawing.Size(191, 23);
            this.ktxtDocumentNumber.TabIndex = 7;
            this.ktxtDocumentNumber.TextChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel6.Location = new System.Drawing.Point(11, 183);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(102, 20);
            this.kryptonLabel6.TabIndex = 6;
            this.kryptonLabel6.Values.Text = "Belge Numarası";
            // 
            // ktxtCompanyName
            // 
            this.ktxtCompanyName.Location = new System.Drawing.Point(10, 151);
            this.ktxtCompanyName.Name = "ktxtCompanyName";
            this.ktxtCompanyName.Size = new System.Drawing.Size(191, 23);
            this.ktxtCompanyName.TabIndex = 5;
            this.ktxtCompanyName.TextChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(11, 125);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(67, 20);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Firma Adı";
            // 
            // ktxtProductName
            // 
            this.ktxtProductName.Location = new System.Drawing.Point(10, 93);
            this.ktxtProductName.Name = "ktxtProductName";
            this.ktxtProductName.Size = new System.Drawing.Size(191, 23);
            this.ktxtProductName.TabIndex = 3;
            this.ktxtProductName.TextChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(11, 67);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(63, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Ürün Adı";
            // 
            // ktxtProductCode
            // 
            this.ktxtProductCode.Location = new System.Drawing.Point(10, 38);
            this.ktxtProductCode.Name = "ktxtProductCode";
            this.ktxtProductCode.Size = new System.Drawing.Size(191, 23);
            this.ktxtProductCode.TabIndex = 1;
            this.ktxtProductCode.TextChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
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
            this.Column9});
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
            this.kdgvList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.kdgvList_CellFormatting);
            this.kdgvList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kdgvList_MouseDown);
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
            this.cmsCustomer.Size = new System.Drawing.Size(124, 70);
            // 
            // tsmiNewCustomer
            // 
            this.tsmiNewCustomer.Name = "tsmiNewCustomer";
            this.tsmiNewCustomer.Size = new System.Drawing.Size(123, 22);
            this.tsmiNewCustomer.Text = "Yeni Cari ";
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(123, 22);
            this.tsmiUpdate.Text = "Düzenle";
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(123, 22);
            this.tsmiDelete.Text = "Sil";
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
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(11, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(73, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Ürün Kodu";
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
            this.kgbFilter.Panel.Controls.Add(this.kdtpEndDate);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel8);
            this.kgbFilter.Panel.Controls.Add(this.kdtpStartDate);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel9);
            this.kgbFilter.Panel.Controls.Add(this.kryptonPanel3);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel7);
            this.kgbFilter.Panel.Controls.Add(this.kryptonPanel2);
            this.kgbFilter.Panel.Controls.Add(this.kbtnClearFilter);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel4);
            this.kgbFilter.Panel.Controls.Add(this.ktxtWareHouse);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel5);
            this.kgbFilter.Panel.Controls.Add(this.ktxtDocumentNumber);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel6);
            this.kgbFilter.Panel.Controls.Add(this.ktxtCompanyName);
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
            // kdtpEndDate
            // 
            this.kdtpEndDate.CalendarTodayDate = new System.DateTime(2021, 2, 20, 0, 0, 0, 0);
            this.kdtpEndDate.CustomFormat = "dd.MM.yyyy dddd";
            this.kdtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kdtpEndDate.Location = new System.Drawing.Point(12, 512);
            this.kdtpEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.kdtpEndDate.Name = "kdtpEndDate";
            this.kdtpEndDate.Size = new System.Drawing.Size(189, 21);
            this.kdtpEndDate.TabIndex = 21;
            this.kdtpEndDate.ValueChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel8.Location = new System.Drawing.Point(12, 490);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel8.TabIndex = 20;
            this.kryptonLabel8.Values.Text = "Bitiş Tarihi";
            // 
            // kdtpStartDate
            // 
            this.kdtpStartDate.CalendarTodayDate = new System.DateTime(2021, 2, 20, 0, 0, 0, 0);
            this.kdtpStartDate.CustomFormat = "dd.MM.yyyy dddd";
            this.kdtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kdtpStartDate.Location = new System.Drawing.Point(11, 458);
            this.kdtpStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.kdtpStartDate.Name = "kdtpStartDate";
            this.kdtpStartDate.Size = new System.Drawing.Size(189, 21);
            this.kdtpStartDate.TabIndex = 19;
            this.kdtpStartDate.ValueChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel9.Location = new System.Drawing.Point(12, 436);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(102, 20);
            this.kryptonLabel9.TabIndex = 18;
            this.kryptonLabel9.Values.Text = "Başlangıç Tarihi";
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.krbApproved);
            this.kryptonPanel3.Controls.Add(this.krbNotApproved);
            this.kryptonPanel3.Location = new System.Drawing.Point(11, 392);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(191, 28);
            this.kryptonPanel3.TabIndex = 17;
            // 
            // krbApproved
            // 
            this.krbApproved.Location = new System.Drawing.Point(17, 5);
            this.krbApproved.Name = "krbApproved";
            this.krbApproved.Size = new System.Drawing.Size(57, 20);
            this.krbApproved.TabIndex = 14;
            this.krbApproved.Values.Text = "Onaylı";
            this.krbApproved.CheckedChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // krbNotApproved
            // 
            this.krbNotApproved.Location = new System.Drawing.Point(108, 5);
            this.krbNotApproved.Name = "krbNotApproved";
            this.krbNotApproved.Size = new System.Drawing.Size(65, 20);
            this.krbNotApproved.TabIndex = 13;
            this.krbNotApproved.Values.Text = "Onaysız";
            this.krbNotApproved.CheckedChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel7.Location = new System.Drawing.Point(12, 366);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(105, 20);
            this.kryptonLabel7.TabIndex = 16;
            this.kryptonLabel7.Values.Text = "Onaylı / Onaysız";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.krbIn);
            this.kryptonPanel2.Controls.Add(this.krbOut);
            this.kryptonPanel2.Location = new System.Drawing.Point(10, 324);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(191, 28);
            this.kryptonPanel2.TabIndex = 15;
            // 
            // krbIn
            // 
            this.krbIn.Location = new System.Drawing.Point(17, 5);
            this.krbIn.Name = "krbIn";
            this.krbIn.Size = new System.Drawing.Size(47, 20);
            this.krbIn.TabIndex = 14;
            this.krbIn.Values.Text = "Giriş";
            this.krbIn.CheckedChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // krbOut
            // 
            this.krbOut.Location = new System.Drawing.Point(108, 5);
            this.krbOut.Name = "krbOut";
            this.krbOut.Size = new System.Drawing.Size(48, 20);
            this.krbOut.TabIndex = 13;
            this.krbOut.Values.Text = "Çıkış";
            this.krbOut.CheckedChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
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
            this.Column3.DataPropertyName = "CompanyName";
            this.Column3.HeaderText = "Firma Adı";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DocumentCode";
            this.Column4.HeaderText = "Belge Numarası";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "Stock";
            this.Column12.HeaderText = "Stok";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "UnitName";
            this.Column13.HeaderText = "Stok Birimi";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Telefon
            // 
            this.Telefon.DataPropertyName = "Price";
            this.Telefon.HeaderText = "Fiyatı";
            this.Telefon.Name = "Telefon";
            this.Telefon.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "CurrencyCode";
            this.Column5.HeaderText = "Para Birimi";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "WarehouseName";
            this.Column6.HeaderText = "Depo";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "InOrOutText";
            this.Column7.HeaderText = "Giriş Çıkış";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "IsApprovedText";
            this.Column8.HeaderText = "Onaylı";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "CreatedDate";
            this.Column9.HeaderText = "Tarih";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // frmProductDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 619);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kgbFilter);
            this.Name = "frmProductDetails";
            this.Text = "frmProductDetails";
            this.Load += new System.EventHandler(this.frmProductDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kdgvList)).EndInit();
            this.cmsCustomer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter.Panel)).EndInit();
            this.kgbFilter.Panel.ResumeLayout(false);
            this.kgbFilter.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter)).EndInit();
            this.kgbFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            this.kryptonPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnClearFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtWareHouse;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtDocumentNumber;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtCompanyName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtProductName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtProductCode;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kdgvList;
        private System.Windows.Forms.ContextMenuStrip cmsCustomer;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewCustomer;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kgbFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton krbApproved;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton krbNotApproved;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton krbIn;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton krbOut;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kdtpEndDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kdtpStartDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
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
    }
}