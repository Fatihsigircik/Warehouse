namespace SimpleWarehouseWindows.NewForm.Order
{
    partial class frmOrderList
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
            this.cmsOrder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiNewOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewRetailOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.kgbFilter = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kdtpEndDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kdtpStartDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kcbOrderType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kbtnClearFilter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ktxtCustomer = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtDocumentNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtOrderCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kdgvList = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsmiNewInternetOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter.Panel)).BeginInit();
            this.kgbFilter.Panel.SuspendLayout();
            this.kgbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcbOrderType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsOrder
            // 
            this.cmsOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsOrder.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsOrder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewOrder,
            this.tsmiNewRetailOrder,
            this.tsmiNewInternetOrder,
            this.toolStripSeparator1,
            this.tsmiUpdate,
            this.tsmiDelete});
            this.cmsOrder.Name = "cmsCustomer";
            this.cmsOrder.Size = new System.Drawing.Size(192, 142);
            // 
            // tsmiNewOrder
            // 
            this.tsmiNewOrder.Name = "tsmiNewOrder";
            this.tsmiNewOrder.Size = new System.Drawing.Size(191, 22);
            this.tsmiNewOrder.Text = "Yeni Toptan Sipariş";
            this.tsmiNewOrder.Click += new System.EventHandler(this.tsmiNewOrder_Click);
            // 
            // tsmiNewRetailOrder
            // 
            this.tsmiNewRetailOrder.Name = "tsmiNewRetailOrder";
            this.tsmiNewRetailOrder.Size = new System.Drawing.Size(191, 22);
            this.tsmiNewRetailOrder.Text = "Yeni Perakende Sipariş";
            this.tsmiNewRetailOrder.Click += new System.EventHandler(this.tsmiNewRetailOrder_Click);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(191, 22);
            this.tsmiUpdate.Text = "Düzenle";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(191, 22);
            this.tsmiDelete.Text = "Sil";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
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
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel4);
            this.kgbFilter.Panel.Controls.Add(this.kcbOrderType);
            this.kgbFilter.Panel.Controls.Add(this.kbtnClearFilter);
            this.kgbFilter.Panel.Controls.Add(this.ktxtCustomer);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel3);
            this.kgbFilter.Panel.Controls.Add(this.ktxtDocumentNumber);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel2);
            this.kgbFilter.Panel.Controls.Add(this.ktxtOrderCode);
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
            this.kgbFilter.TabIndex = 4;
            this.kgbFilter.Values.Heading = "Filtre";
            this.kgbFilter.Values.Image = global::SimpleWarehouseWindows.Properties.Resources.traceable;
            // 
            // kdtpEndDate
            // 
            this.kdtpEndDate.CalendarTodayDate = new System.DateTime(2021, 2, 20, 0, 0, 0, 0);
            this.kdtpEndDate.CustomFormat = "dd.MM.yyyy dddd";
            this.kdtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kdtpEndDate.Location = new System.Drawing.Point(12, 370);
            this.kdtpEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.kdtpEndDate.Name = "kdtpEndDate";
            this.kdtpEndDate.Size = new System.Drawing.Size(189, 21);
            this.kdtpEndDate.TabIndex = 25;
            this.kdtpEndDate.ValueChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel8.Location = new System.Drawing.Point(12, 348);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel8.TabIndex = 24;
            this.kryptonLabel8.Values.Text = "Bitiş Tarihi";
            // 
            // kdtpStartDate
            // 
            this.kdtpStartDate.CalendarTodayDate = new System.DateTime(2021, 2, 20, 0, 0, 0, 0);
            this.kdtpStartDate.CustomFormat = "dd.MM.yyyy dddd";
            this.kdtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kdtpStartDate.Location = new System.Drawing.Point(11, 316);
            this.kdtpStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.kdtpStartDate.Name = "kdtpStartDate";
            this.kdtpStartDate.Size = new System.Drawing.Size(189, 21);
            this.kdtpStartDate.TabIndex = 23;
            this.kdtpStartDate.ValueChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel9.Location = new System.Drawing.Point(12, 294);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(102, 20);
            this.kryptonLabel9.TabIndex = 22;
            this.kryptonLabel9.Values.Text = "Başlangıç Tarihi";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(11, 224);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(74, 20);
            this.kryptonLabel4.TabIndex = 14;
            this.kryptonLabel4.Values.Text = "Sipariş Tipi";
            // 
            // kcbOrderType
            // 
            this.kcbOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcbOrderType.DropDownWidth = 190;
            this.kcbOrderType.IntegralHeight = false;
            this.kcbOrderType.Items.AddRange(new object[] {
            "Tümü",
            "Perakende Satış",
            "Toptan Satış",
            "E-Ticaret Satış"});
            this.kcbOrderType.Location = new System.Drawing.Point(11, 250);
            this.kcbOrderType.Name = "kcbOrderType";
            this.kcbOrderType.Size = new System.Drawing.Size(190, 20);
            this.kcbOrderType.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kcbOrderType.StateActive.ComboBox.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcbOrderType.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kcbOrderType.StateCommon.ComboBox.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcbOrderType.StateDisabled.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kcbOrderType.StateDisabled.ComboBox.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcbOrderType.StateNormal.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kcbOrderType.StateNormal.ComboBox.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcbOrderType.StateTracking.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kcbOrderType.TabIndex = 13;
            this.kcbOrderType.SelectedIndexChanged += new System.EventHandler(this.kcbOrderType_SelectedIndexChanged);
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
            // ktxtCustomer
            // 
            this.ktxtCustomer.Location = new System.Drawing.Point(10, 186);
            this.ktxtCustomer.Name = "ktxtCustomer";
            this.ktxtCustomer.Size = new System.Drawing.Size(191, 23);
            this.ktxtCustomer.TabIndex = 5;
            this.ktxtCustomer.TextChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(11, 160);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(55, 20);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Müşteri";
            // 
            // ktxtDocumentNumber
            // 
            this.ktxtDocumentNumber.Location = new System.Drawing.Point(10, 118);
            this.ktxtDocumentNumber.Name = "ktxtDocumentNumber";
            this.ktxtDocumentNumber.Size = new System.Drawing.Size(191, 23);
            this.ktxtDocumentNumber.TabIndex = 3;
            this.ktxtDocumentNumber.TextChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(11, 92);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(102, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Belge Numarası";
            // 
            // ktxtOrderCode
            // 
            this.ktxtOrderCode.Location = new System.Drawing.Point(10, 50);
            this.ktxtOrderCode.Name = "ktxtOrderCode";
            this.ktxtOrderCode.Size = new System.Drawing.Size(191, 23);
            this.ktxtOrderCode.TabIndex = 1;
            this.ktxtOrderCode.TextChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(11, 24);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(83, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Sipariş Kodu";
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
            this.kryptonPanel1.TabIndex = 5;
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
            this.Column5,
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
            this.kdgvList.RowTemplate.ContextMenuStrip = this.cmsOrder;
            this.kdgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kdgvList.Size = new System.Drawing.Size(1145, 619);
            this.kdgvList.TabIndex = 0;
            this.kdgvList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kdgvList_MouseDown);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "OrderCode";
            this.Column1.HeaderText = "Sipariş Kodu";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CustomerTitle";
            this.Column2.HeaderText = "Müşteri";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "DocNumber";
            this.Column3.HeaderText = "Belge Numarası";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "OrderStatusName";
            this.Column6.HeaderText = "Sipariş Durumu";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TotalPrice";
            this.Column4.HeaderText = "Toplam Fiyat";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "TotalVal";
            this.Column5.HeaderText = "Toplam KDV";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "CurrencyCode";
            this.Column7.HeaderText = "Para Birimi";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "OrderTypeName";
            this.Column8.HeaderText = "Sipariş Tipi";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "OrderDate";
            this.Column9.HeaderText = "Tarih";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // tsmiNewInternetOrder
            // 
            this.tsmiNewInternetOrder.Name = "tsmiNewInternetOrder";
            this.tsmiNewInternetOrder.Size = new System.Drawing.Size(191, 22);
            this.tsmiNewInternetOrder.Text = "Yeni İnternet Satışı";
            this.tsmiNewInternetOrder.Click += new System.EventHandler(this.tsmiNewInternetOrder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // frmOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 619);
            this.Controls.Add(this.kgbFilter);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "frmOrderList";
            this.Text = "Sipariş Listesi";
            this.Load += new System.EventHandler(this.frmOrderList_Load);
            this.cmsOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter.Panel)).EndInit();
            this.kgbFilter.Panel.ResumeLayout(false);
            this.kgbFilter.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter)).EndInit();
            this.kgbFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcbOrderType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kdgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnClearFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtCustomer;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtDocumentNumber;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kgbFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtOrderCode;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kdgvList;
        private System.Windows.Forms.ContextMenuStrip cmsOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kcbOrderType;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kdtpEndDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kdtpStartDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewRetailOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewInternetOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}