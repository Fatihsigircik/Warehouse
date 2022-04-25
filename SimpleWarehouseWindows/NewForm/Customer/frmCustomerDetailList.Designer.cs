namespace SimpleWarehouseWindows.NewForm.Customer
{
    partial class frmCustomerDetailList
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
            this.ktxtCompanyName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtSurname = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtNane = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtCustomerCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ktxtCustomerDetailCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
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
            this.tsmiNewCustomerDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kgbFilter = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kdtpEndDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kdtpStartDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kdgvList)).BeginInit();
            this.cmsCustomerDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter.Panel)).BeginInit();
            this.kgbFilter.Panel.SuspendLayout();
            this.kgbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // kbtnClearFilter
            // 
            this.kbtnClearFilter.Location = new System.Drawing.Point(15, 614);
            this.kbtnClearFilter.Margin = new System.Windows.Forms.Padding(4);
            this.kbtnClearFilter.Name = "kbtnClearFilter";
            this.kbtnClearFilter.Size = new System.Drawing.Size(253, 31);
            this.kbtnClearFilter.TabIndex = 12;
            this.kbtnClearFilter.Values.Text = "Filtreyi Temizle";
            this.kbtnClearFilter.Click += new System.EventHandler(this.kbtnClearFilter_Click);
            // 
            // ktxtCompanyName
            // 
            this.ktxtCompanyName.Location = new System.Drawing.Point(13, 537);
            this.ktxtCompanyName.Margin = new System.Windows.Forms.Padding(4);
            this.ktxtCompanyName.Name = "ktxtCompanyName";
            this.ktxtCompanyName.Size = new System.Drawing.Size(255, 23);
            this.ktxtCompanyName.TabIndex = 11;
            this.ktxtCompanyName.TextChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(15, 505);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(67, 20);
            this.kryptonLabel4.TabIndex = 10;
            this.kryptonLabel4.Values.Text = "Firma Adı";
            // 
            // ktxtSurname
            // 
            this.ktxtSurname.Location = new System.Drawing.Point(13, 453);
            this.ktxtSurname.Margin = new System.Windows.Forms.Padding(4);
            this.ktxtSurname.Name = "ktxtSurname";
            this.ktxtSurname.Size = new System.Drawing.Size(255, 23);
            this.ktxtSurname.TabIndex = 9;
            this.ktxtSurname.TextChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel5.Location = new System.Drawing.Point(15, 421);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(76, 20);
            this.kryptonLabel5.TabIndex = 8;
            this.kryptonLabel5.Values.Text = "Cari Soyadı";
            // 
            // ktxtNane
            // 
            this.ktxtNane.Location = new System.Drawing.Point(13, 369);
            this.ktxtNane.Margin = new System.Windows.Forms.Padding(4);
            this.ktxtNane.Name = "ktxtNane";
            this.ktxtNane.Size = new System.Drawing.Size(255, 23);
            this.ktxtNane.TabIndex = 7;
            this.ktxtNane.TextChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel6.Location = new System.Drawing.Point(15, 337);
            this.kryptonLabel6.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(57, 20);
            this.kryptonLabel6.TabIndex = 6;
            this.kryptonLabel6.Values.Text = "Cari Adı";
            // 
            // ktxtCustomerCode
            // 
            this.ktxtCustomerCode.Location = new System.Drawing.Point(13, 282);
            this.ktxtCustomerCode.Margin = new System.Windows.Forms.Padding(4);
            this.ktxtCustomerCode.Name = "ktxtCustomerCode";
            this.ktxtCustomerCode.Size = new System.Drawing.Size(255, 23);
            this.ktxtCustomerCode.TabIndex = 5;
            this.ktxtCustomerCode.TextChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(15, 250);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(67, 20);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Cari Kodu";
            // 
            // ktxtCustomerDetailCode
            // 
            this.ktxtCustomerDetailCode.Location = new System.Drawing.Point(13, 198);
            this.ktxtCustomerDetailCode.Margin = new System.Windows.Forms.Padding(4);
            this.ktxtCustomerDetailCode.Name = "ktxtCustomerDetailCode";
            this.ktxtCustomerDetailCode.Size = new System.Drawing.Size(255, 23);
            this.ktxtCustomerDetailCode.TabIndex = 3;
            this.ktxtCustomerDetailCode.TextChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(15, 166);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(91, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Hareket Kodu";
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
            this.kdgvList.Margin = new System.Windows.Forms.Padding(4);
            this.kdgvList.MultiSelect = false;
            this.kdgvList.Name = "kdgvList";
            this.kdgvList.ReadOnly = true;
            this.kdgvList.RowHeadersWidth = 10;
            this.kdgvList.RowTemplate.ContextMenuStrip = this.cmsCustomerDetail;
            this.kdgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kdgvList.Size = new System.Drawing.Size(1527, 762);
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
            this.Column7.DataPropertyName = "CustomerCode";
            this.Column7.HeaderText = "Cari Kodu";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "CustomerName";
            this.Column8.HeaderText = "Adı";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "CustomerSurname";
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
            this.tsmiNewCustomerDetail,
            this.tsmiUpdate,
            this.tsmiDelete});
            this.cmsCustomerDetail.Name = "cmsCustomer";
            this.cmsCustomerDetail.Size = new System.Drawing.Size(168, 70);
            // 
            // tsmiNewCustomerDetail
            // 
            this.tsmiNewCustomerDetail.Name = "tsmiNewCustomerDetail";
            this.tsmiNewCustomerDetail.Size = new System.Drawing.Size(167, 22);
            this.tsmiNewCustomerDetail.Text = "Yeni Cari Hareketi";
            this.tsmiNewCustomerDetail.Click += new System.EventHandler(this.tsmiNewCustomerDetail_Click);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(167, 22);
            this.tsmiUpdate.Text = "Düzenle";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(167, 22);
            this.tsmiDelete.Text = "Sil";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
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
            this.kryptonPanel1.TabIndex = 3;
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
            this.kgbFilter.Panel.Controls.Add(this.ktxtCustomerCode);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel3);
            this.kgbFilter.Panel.Controls.Add(this.ktxtCustomerDetailCode);
            this.kgbFilter.Panel.Controls.Add(this.kryptonLabel2);
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
            this.kgbFilter.TabIndex = 2;
            this.kgbFilter.Values.Heading = "Filtre";
            this.kgbFilter.Values.Image = global::SimpleWarehouseWindows.Properties.Resources.traceable;
            // 
            // kdtpEndDate
            // 
            this.kdtpEndDate.CalendarTodayDate = new System.DateTime(2021, 2, 20, 0, 0, 0, 0);
            this.kdtpEndDate.CustomFormat = "dd.MM.yyyy dddd";
            this.kdtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kdtpEndDate.Location = new System.Drawing.Point(15, 123);
            this.kdtpEndDate.Name = "kdtpEndDate";
            this.kdtpEndDate.Size = new System.Drawing.Size(252, 21);
            this.kdtpEndDate.TabIndex = 15;
            this.kdtpEndDate.ValueChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel7.Location = new System.Drawing.Point(15, 96);
            this.kryptonLabel7.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel7.TabIndex = 14;
            this.kryptonLabel7.Values.Text = "Bitiş Tarihi";
            // 
            // kdtpStartDate
            // 
            this.kdtpStartDate.CalendarTodayDate = new System.DateTime(2021, 2, 20, 0, 0, 0, 0);
            this.kdtpStartDate.CustomFormat = "dd.MM.yyyy dddd";
            this.kdtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kdtpStartDate.Location = new System.Drawing.Point(13, 57);
            this.kdtpStartDate.Name = "kdtpStartDate";
            this.kdtpStartDate.Size = new System.Drawing.Size(252, 21);
            this.kdtpStartDate.TabIndex = 13;
            this.kdtpStartDate.ValueChanged += new System.EventHandler(this.ktxtFilter_TextChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(15, 30);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(102, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Başlangıç Tarihi";
            // 
            // frmCustomerDetailList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1843, 762);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kgbFilter);
            this.Name = "frmCustomerDetailList";
            this.Text = "Cari Hareket Listesi";
            this.Load += new System.EventHandler(this.frmCustomerDetailList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kdgvList)).EndInit();
            this.cmsCustomerDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter.Panel)).EndInit();
            this.kgbFilter.Panel.ResumeLayout(false);
            this.kgbFilter.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbFilter)).EndInit();
            this.kgbFilter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnClearFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtCompanyName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtSurname;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtNane;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtCustomerCode;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktxtCustomerDetailCode;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kdgvList;
        private System.Windows.Forms.ContextMenuStrip cmsCustomerDetail;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewCustomerDetail;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kgbFilter;
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
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kdtpStartDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kdtpEndDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
    }
}