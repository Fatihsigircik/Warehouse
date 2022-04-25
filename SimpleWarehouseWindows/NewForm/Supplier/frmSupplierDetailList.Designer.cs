namespace SimpleWarehouseWindows.NewForm.Supplier
{
    partial class frmSupplierDetailList
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
            this.kdtpEndDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kdgvList = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsCustomerDetail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiNewSupplierDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.kgbFilter = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kdtpStartDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kbtnClearFilter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ktxtCompanyName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtSurname = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtNane = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtSupplierCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtSupplierDetailCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdgvList)).BeginInit();
            this.cmsCustomerDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter.Panel)).BeginInit();
            this.kgbFilter.Panel.SuspendLayout();
            this.kgbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // kdtpEndDate
            // 
            this.kdtpEndDate.CalendarTodayDate = new System.DateTime(2021, 2, 20, 0, 0, 0, 0);
            this.kdtpEndDate.CustomFormat = "dd.MM.yyyy dddd";
            this.kdtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kdtpEndDate.Location = new System.Drawing.Point(11, 100);
            this.kdtpEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.kdtpEndDate.Name = "kdtpEndDate";
            this.kdtpEndDate.Size = new System.Drawing.Size(189, 21);
            this.kdtpEndDate.TabIndex = 15;
            this.kdtpEndDate.ValueChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel7.Location = new System.Drawing.Point(11, 78);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel7.TabIndex = 14;
            this.kryptonLabel7.Values.Text = "Bitiş Tarihi";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(11, 24);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(102, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Başlangıç Tarihi";
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
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column1,
            this.Column2,
            this.Column3});
            this.kdgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kdgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.kdgvList.Location = new System.Drawing.Point(0, 0);
            this.kdgvList.MultiSelect = false;
            this.kdgvList.Name = "kdgvList";
            this.kdgvList.ReadOnly = true;
            this.kdgvList.RowHeadersWidth = 10;
            this.kdgvList.RowTemplate.ContextMenuStrip = this.cmsCustomerDetail;
            this.kdgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kdgvList.Size = new System.Drawing.Size(1145, 619);
            this.kdgvList.TabIndex = 0;
            this.kdgvList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kdgvList_MouseDown);
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "DetailDate";
            this.Column5.HeaderText = "Tarih";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "DetailCode";
            this.Column6.HeaderText = "Hareket Kodu";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "SupplierCode";
            this.Column7.HeaderText = "Tedarikçi Kodu";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "SupplierName";
            this.Column8.HeaderText = "Adı";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "SupplierSurname";
            this.Column9.HeaderText = "Soyadı";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "CompanyName";
            this.Column10.HeaderText = "Firma";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "DetailTypeName";
            this.Column11.HeaderText = "Hareket Tipi";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Credit";
            this.Column1.HeaderText = "Alacak";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Debt";
            this.Column2.HeaderText = "Borç";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Detail";
            this.Column3.HeaderText = "Açıklama";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // cmsCustomerDetail
            // 
            this.cmsCustomerDetail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomerDetail.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsCustomerDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewSupplierDetail,
            this.tsmiUpdate,
            this.tsmiDelete});
            this.cmsCustomerDetail.Name = "cmsCustomer";
            this.cmsCustomerDetail.Size = new System.Drawing.Size(193, 92);
            // 
            // tsmiNewSupplierDetail
            // 
            this.tsmiNewSupplierDetail.Name = "tsmiNewSupplierDetail";
            this.tsmiNewSupplierDetail.Size = new System.Drawing.Size(192, 22);
            this.tsmiNewSupplierDetail.Text = "Yeni Tedarikçi Hareketi";
            this.tsmiNewSupplierDetail.Click += new System.EventHandler(this.tsmiNewCustomerDetail_Click);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(192, 22);
            this.tsmiUpdate.Text = "Düzenle";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(192, 22);
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
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel7);
            this.kgbFilter.Panel.Controls.Add(this.kdtpStartDate);
            this.kgbFilter.Panel.Controls.Add(this.kbtnClearFilter);
            this.kgbFilter.Panel.Controls.Add(this.ktxtCompanyName);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel4);
            this.kgbFilter.Panel.Controls.Add(this.ktxtSurname);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel5);
            this.kgbFilter.Panel.Controls.Add(this.ktxtNane);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel6);
            this.kgbFilter.Panel.Controls.Add(this.ktxtSupplierCode);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel3);
            this.kgbFilter.Panel.Controls.Add(this.ktxtSupplierDetailCode);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel2);
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
            // kdtpStartDate
            // 
            this.kdtpStartDate.CalendarTodayDate = new System.DateTime(2021, 2, 20, 0, 0, 0, 0);
            this.kdtpStartDate.CustomFormat = "dd.MM.yyyy dddd";
            this.kdtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kdtpStartDate.Location = new System.Drawing.Point(10, 46);
            this.kdtpStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.kdtpStartDate.Name = "kdtpStartDate";
            this.kdtpStartDate.Size = new System.Drawing.Size(189, 21);
            this.kdtpStartDate.TabIndex = 13;
            this.kdtpStartDate.ValueChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kbtnClearFilter
            // 
            this.kbtnClearFilter.Location = new System.Drawing.Point(11, 499);
            this.kbtnClearFilter.Name = "kbtnClearFilter";
            this.kbtnClearFilter.Size = new System.Drawing.Size(190, 25);
            this.kbtnClearFilter.TabIndex = 12;
            this.kbtnClearFilter.Values.Text = "Filtreyi Temizle";
            this.kbtnClearFilter.Click += new System.EventHandler(this.kbtnClearFilter_Click);
            // 
            // ktxtCompanyName
            // 
            this.ktxtCompanyName.Location = new System.Drawing.Point(10, 436);
            this.ktxtCompanyName.Name = "ktxtCompanyName";
            this.ktxtCompanyName.Size = new System.Drawing.Size(191, 23);
            this.ktxtCompanyName.TabIndex = 11;
            this.ktxtCompanyName.TextChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(11, 410);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(67, 20);
            this.kryptonLabel4.TabIndex = 10;
            this.kryptonLabel4.Values.Text = "Firma Adı";
            // 
            // ktxtSurname
            // 
            this.ktxtSurname.Location = new System.Drawing.Point(10, 368);
            this.ktxtSurname.Name = "ktxtSurname";
            this.ktxtSurname.Size = new System.Drawing.Size(191, 23);
            this.ktxtSurname.TabIndex = 9;
            this.ktxtSurname.TextChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel5.Location = new System.Drawing.Point(11, 342);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(106, 20);
            this.kryptonLabel5.TabIndex = 8;
            this.kryptonLabel5.Values.Text = "Tedarikçi Soyadı";
            // 
            // ktxtNane
            // 
            this.ktxtNane.Location = new System.Drawing.Point(10, 300);
            this.ktxtNane.Name = "ktxtNane";
            this.ktxtNane.Size = new System.Drawing.Size(191, 23);
            this.ktxtNane.TabIndex = 7;
            this.ktxtNane.TextChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel6.Location = new System.Drawing.Point(11, 274);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(87, 20);
            this.kryptonLabel6.TabIndex = 6;
            this.kryptonLabel6.Values.Text = "Tedarikçi Adı";
            // 
            // ktxtSupplierCode
            // 
            this.ktxtSupplierCode.Location = new System.Drawing.Point(10, 229);
            this.ktxtSupplierCode.Name = "ktxtSupplierCode";
            this.ktxtSupplierCode.Size = new System.Drawing.Size(191, 23);
            this.ktxtSupplierCode.TabIndex = 5;
            this.ktxtSupplierCode.TextChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(11, 203);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(98, 20);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Tedarikçi Kodu";
            // 
            // ktxtSupplierDetailCode
            // 
            this.ktxtSupplierDetailCode.Location = new System.Drawing.Point(10, 161);
            this.ktxtSupplierDetailCode.Name = "ktxtSupplierDetailCode";
            this.ktxtSupplierDetailCode.Size = new System.Drawing.Size(191, 23);
            this.ktxtSupplierDetailCode.TabIndex = 3;
            this.ktxtSupplierDetailCode.TextChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(11, 135);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(91, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Hareket Kodu";
            // 
            // frmSupplierDetailList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 619);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kgbFilter);
            this.Name = "frmSupplierDetailList";
            this.Text = "Tedarikçi Hareketleri";
            this.Load += new System.EventHandler(this.frmSupplierDetailList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kdgvList)).EndInit();
            this.cmsCustomerDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter.Panel)).EndInit();
            this.kgbFilter.Panel.ResumeLayout(false);
            this.kgbFilter.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter)).EndInit();
            this.kgbFilter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kdtpEndDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kdgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ContextMenuStrip cmsCustomerDetail;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewSupplierDetail;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kgbFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kdtpStartDate;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnClearFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtCompanyName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtSurname;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtNane;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtSupplierCode;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtSupplierDetailCode;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
    }
}