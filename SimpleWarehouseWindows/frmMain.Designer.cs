namespace SimpleWarehouseWindows
{
    partial class frmMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmsDefinition = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOrderStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUnits = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVariantGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVariantGroupValues = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsProduct = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProductIn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProductOut = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.btnDefinitions = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.cmsDefinition.SuspendLayout();
            this.cmsProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Khaki;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.btnDefinitions);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.btnProduct);
            this.panel1.Controls.Add(this.btnCustomer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 734);
            this.panel1.TabIndex = 0;
            // 
            // cmsDefinition
            // 
            this.cmsDefinition.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsDefinition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOrderStatus,
            this.tsmiUnits,
            this.tsmiVariantGroup,
            this.tsmiVariantGroupValues});
            this.cmsDefinition.Name = "cmsDefinition";
            this.cmsDefinition.Size = new System.Drawing.Size(230, 100);
            // 
            // tsmiOrderStatus
            // 
            this.tsmiOrderStatus.Name = "tsmiOrderStatus";
            this.tsmiOrderStatus.Size = new System.Drawing.Size(229, 24);
            this.tsmiOrderStatus.Text = "Sipariş Durumları";
            this.tsmiOrderStatus.Click += new System.EventHandler(this.tsmiOrderStatus_Click);
            // 
            // tsmiUnits
            // 
            this.tsmiUnits.Name = "tsmiUnits";
            this.tsmiUnits.Size = new System.Drawing.Size(229, 24);
            this.tsmiUnits.Text = "Birimler";
            this.tsmiUnits.Click += new System.EventHandler(this.tsmiUnits_Click);
            // 
            // tsmiVariantGroup
            // 
            this.tsmiVariantGroup.Name = "tsmiVariantGroup";
            this.tsmiVariantGroup.Size = new System.Drawing.Size(229, 24);
            this.tsmiVariantGroup.Text = "Varyant Grupları";
            this.tsmiVariantGroup.Visible = false;
            this.tsmiVariantGroup.Click += new System.EventHandler(this.tsmiVariantGroup_Click);
            // 
            // tsmiVariantGroupValues
            // 
            this.tsmiVariantGroupValues.Name = "tsmiVariantGroupValues";
            this.tsmiVariantGroupValues.Size = new System.Drawing.Size(229, 24);
            this.tsmiVariantGroupValues.Text = "Varyant Grup Değerleri";
            this.tsmiVariantGroupValues.Visible = false;
            this.tsmiVariantGroupValues.Click += new System.EventHandler(this.tsmiVariantGroupValues_Click);
            // 
            // cmsProduct
            // 
            this.cmsProduct.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsProduct.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiProduct,
            this.tsmiProductIn,
            this.tsmiProductOut});
            this.cmsProduct.Name = "cmsProduct";
            this.cmsProduct.Size = new System.Drawing.Size(211, 104);
            // 
            // tsmiProduct
            // 
            this.tsmiProduct.Name = "tsmiProduct";
            this.tsmiProduct.Size = new System.Drawing.Size(210, 24);
            this.tsmiProduct.Text = "Ürün Bilgileri";
            this.tsmiProduct.Click += new System.EventHandler(this.tsmiProduct_Click);
            // 
            // tsmiProductIn
            // 
            this.tsmiProductIn.Name = "tsmiProductIn";
            this.tsmiProductIn.Size = new System.Drawing.Size(210, 24);
            this.tsmiProductIn.Text = "Ürün Girişi";
            this.tsmiProductIn.Click += new System.EventHandler(this.tsmiProductIn_Click);
            // 
            // tsmiProductOut
            // 
            this.tsmiProductOut.Name = "tsmiProductOut";
            this.tsmiProductOut.Size = new System.Drawing.Size(210, 24);
            this.tsmiProductOut.Text = "Ürün Çıkışı";
            this.tsmiProductOut.Click += new System.EventHandler(this.tsmiProductOut_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackgroundImage = global::SimpleWarehouseWindows.Properties.Resources.My_Post;
            this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(200, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1179, 734);
            this.pnlMain.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(152)))), ((int)(((byte)(222)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button5.Image = global::SimpleWarehouseWindows.Properties.Resources.online_learning;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button5.Location = new System.Drawing.Point(21, 574);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(153, 118);
            this.button5.TabIndex = 4;
            this.button5.Text = "Kullanıcı";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // btnDefinitions
            // 
            this.btnDefinitions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(152)))), ((int)(((byte)(222)))));
            this.btnDefinitions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDefinitions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDefinitions.Image = global::SimpleWarehouseWindows.Properties.Resources.high_definition_multimedia_interface;
            this.btnDefinitions.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDefinitions.Location = new System.Drawing.Point(21, 437);
            this.btnDefinitions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDefinitions.Name = "btnDefinitions";
            this.btnDefinitions.Size = new System.Drawing.Size(153, 118);
            this.btnDefinitions.TabIndex = 3;
            this.btnDefinitions.Text = "Tanımlar ";
            this.btnDefinitions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDefinitions.UseVisualStyleBackColor = false;
            this.btnDefinitions.Click += new System.EventHandler(this.btnDefinitions_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(152)))), ((int)(((byte)(222)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.Image = global::SimpleWarehouseWindows.Properties.Resources.shopping_basket;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(21, 300);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(153, 118);
            this.button3.TabIndex = 2;
            this.button3.Text = "Sipariş";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(152)))), ((int)(((byte)(222)))));
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnProduct.Image = global::SimpleWarehouseWindows.Properties.Resources.open_box;
            this.btnProduct.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProduct.Location = new System.Drawing.Point(21, 162);
            this.btnProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(153, 118);
            this.btnProduct.TabIndex = 1;
            this.btnProduct.Text = "Ürün";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(152)))), ((int)(((byte)(222)))));
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCustomer.Image = global::SimpleWarehouseWindows.Properties.Resources._3741756_bussiness_ecommerce_marketplace_onlinestore_store_user_108907;
            this.btnCustomer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCustomer.Location = new System.Drawing.Point(21, 26);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(153, 118);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.Text = "Cari";
            this.btnCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 734);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kolay Depo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.cmsDefinition.ResumeLayout(false);
            this.cmsProduct.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnDefinitions;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ContextMenuStrip cmsDefinition;
        private System.Windows.Forms.ToolStripMenuItem tsmiOrderStatus;
        private System.Windows.Forms.ToolStripMenuItem tsmiUnits;
        private System.Windows.Forms.ToolStripMenuItem tsmiVariantGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmiVariantGroupValues;
        private System.Windows.Forms.ContextMenuStrip cmsProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmiProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmiProductIn;
        private System.Windows.Forms.ToolStripMenuItem tsmiProductOut;
    }
}