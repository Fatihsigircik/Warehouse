namespace SimpleWarehouseWindows.MenuForms.Product
{
    partial class frmProductOutlet
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gbProductInfo = new System.Windows.Forms.GroupBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDocNember = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblWarehouseName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnl = new System.Windows.Forms.Panel();
            this.btnApproveAll = new System.Windows.Forms.Button();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.btnProductCode = new System.Windows.Forms.Button();
            this.lblClose = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbProductInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.gbProductInfo);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 635);
            this.panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnApproveAll);
            this.groupBox3.Controls.Add(this.pnl);
            this.groupBox3.Location = new System.Drawing.Point(14, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(767, 416);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Eklenen Ürünler";
            // 
            // gbProductInfo
            // 
            this.gbProductInfo.Controls.Add(this.btnBarcode);
            this.gbProductInfo.Controls.Add(this.btnProductCode);
            this.gbProductInfo.Controls.Add(this.txtBarcode);
            this.gbProductInfo.Controls.Add(this.label3);
            this.gbProductInfo.Controls.Add(this.txtProductCode);
            this.gbProductInfo.Controls.Add(this.label2);
            this.gbProductInfo.Location = new System.Drawing.Point(14, 83);
            this.gbProductInfo.Name = "gbProductInfo";
            this.gbProductInfo.Size = new System.Drawing.Size(767, 109);
            this.gbProductInfo.TabIndex = 3;
            this.gbProductInfo.TabStop = false;
            this.gbProductInfo.Text = "Ürün Bilgisi";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBarcode.Location = new System.Drawing.Point(407, 65);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(284, 26);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarcode_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(404, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Barkod";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtProductCode.Location = new System.Drawing.Point(22, 65);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(284, 26);
            this.txtProductCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(19, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ürün Kodu ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDocNember);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblWarehouseName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(767, 62);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "İşlem Bilgileri";
            // 
            // lblDocNember
            // 
            this.lblDocNember.AutoSize = true;
            this.lblDocNember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDocNember.Location = new System.Drawing.Point(562, 28);
            this.lblDocNember.Name = "lblDocNember";
            this.lblDocNember.Size = new System.Drawing.Size(13, 18);
            this.lblDocNember.TabIndex = 3;
            this.lblDocNember.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(404, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Belge Numarası  :";
            // 
            // lblWarehouseName
            // 
            this.lblWarehouseName.AutoSize = true;
            this.lblWarehouseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWarehouseName.Location = new System.Drawing.Point(116, 28);
            this.lblWarehouseName.Name = "lblWarehouseName";
            this.lblWarehouseName.Size = new System.Drawing.Size(13, 18);
            this.lblWarehouseName.TabIndex = 1;
            this.lblWarehouseName.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(19, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Depo Adı  :";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(362, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(59, 20);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "label1";
            // 
            // pnl
            // 
            this.pnl.AutoScroll = true;
            this.pnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl.Location = new System.Drawing.Point(6, 63);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(755, 341);
            this.pnl.TabIndex = 0;
            this.pnl.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnl_ControlAdded);
            this.pnl.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnl_ControlRemoved);
            // 
            // btnApproveAll
            // 
            this.btnApproveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApproveAll.Image = global::SimpleWarehouseWindows.Properties.Resources.check;
            this.btnApproveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApproveAll.Location = new System.Drawing.Point(592, 13);
            this.btnApproveAll.Name = "btnApproveAll";
            this.btnApproveAll.Size = new System.Drawing.Size(169, 45);
            this.btnApproveAll.TabIndex = 1;
            this.btnApproveAll.Text = "Tümünü Onayla";
            this.btnApproveAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApproveAll.UseVisualStyleBackColor = true;
            this.btnApproveAll.Click += new System.EventHandler(this.btnApproveAll_Click);
            // 
            // btnBarcode
            // 
            this.btnBarcode.AutoEllipsis = true;
            this.btnBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBarcode.ForeColor = System.Drawing.Color.Green;
            this.btnBarcode.Image = global::SimpleWarehouseWindows.Properties.Resources.right_arrow__1_;
            this.btnBarcode.Location = new System.Drawing.Point(700, 62);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(37, 29);
            this.btnBarcode.TabIndex = 2;
            this.btnBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBarcode.UseVisualStyleBackColor = false;
            this.btnBarcode.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnProductCode
            // 
            this.btnProductCode.AutoEllipsis = true;
            this.btnProductCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnProductCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProductCode.ForeColor = System.Drawing.Color.Green;
            this.btnProductCode.Image = global::SimpleWarehouseWindows.Properties.Resources.right_arrow__1_;
            this.btnProductCode.Location = new System.Drawing.Point(317, 62);
            this.btnProductCode.Name = "btnProductCode";
            this.btnProductCode.Size = new System.Drawing.Size(37, 29);
            this.btnProductCode.TabIndex = 4;
            this.btnProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductCode.UseVisualStyleBackColor = false;
            this.btnProductCode.Click += new System.EventHandler(this.btn_Click);
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.BackColor = System.Drawing.Color.Red;
            this.lblClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(797, 2);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(19, 18);
            this.lblClose.TabIndex = 3;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblClose_MouseDown);
            this.lblClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblClose_MouseUp);
            // 
            // frmProductOutlet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 667);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.panel1);
            this.Name = "frmProductOutlet";
            this.Text = "Ürün Giriş / Çıkış";
            this.Load += new System.EventHandler(this.frmProductOutlet_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.gbProductInfo.ResumeLayout(false);
            this.gbProductInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDocNember;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblWarehouseName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbProductInfo;
        private System.Windows.Forms.Button btnProductCode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Button btnApproveAll;
        private System.Windows.Forms.Label lblClose;
    }
}