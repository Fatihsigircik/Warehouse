namespace SimpleWarehouseWindows
{
    partial class test
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
            this.kryptonDockingManager1 = new ComponentFactory.Krypton.Docking.KryptonDockingManager();
            this.krMain = new ComponentFactory.Krypton.Ribbon.KryptonRibbon();
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.krtCustomer = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
            this.krgCustomerInfo = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.krgtCustomer = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.krgbAddCustomer = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.krgbCustomerList = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kcmiExit = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.knMain = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.krMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knMain)).BeginInit();
            this.knMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // krMain
            // 
            this.krMain.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny1});
            this.krMain.InDesignHelperMode = false;
            this.krMain.Name = "krMain";
            this.krMain.QATLocation = ComponentFactory.Krypton.Ribbon.QATLocation.Hidden;
            this.krMain.RibbonAppButton.AppButtonMenuItems.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kcmiExit});
            this.krMain.RibbonAppButton.AppButtonText = "Dosya";
            this.krMain.RibbonTabs.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab[] {
            this.krtCustomer});
            this.krMain.SelectedContext = null;
            this.krMain.SelectedTab = this.krtCustomer;
            this.krMain.Size = new System.Drawing.Size(1172, 115);
            this.krMain.TabIndex = 1;
            // 
            // buttonSpecAny1
            // 
            this.buttonSpecAny1.UniqueName = "c83dc9c5ef054fffbdd247e1d9bb1607";
            // 
            // krtCustomer
            // 
            this.krtCustomer.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.krgCustomerInfo});
            this.krtCustomer.Text = "Cari";
            // 
            // krgCustomerInfo
            // 
            this.krgCustomerInfo.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.krgtCustomer});
            this.krgCustomerInfo.TextLine1 = "Cari İşlemleri";
            // 
            // krgtCustomer
            // 
            this.krgtCustomer.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.krgbAddCustomer,
            this.krgbCustomerList});
            // 
            // krgbAddCustomer
            // 
            this.krgbAddCustomer.TextLine1 = "Yeni Cari";
            this.krgbAddCustomer.Click += new System.EventHandler(this.krgbAddCustomer_Click);
            // 
            // krgbCustomerList
            // 
            this.krgbCustomerList.TextLine1 = "Cari Listesi";
            this.krgbCustomerList.Click += new System.EventHandler(this.krgbCustomerList_Click);
            // 
            // kcmiExit
            // 
            this.kcmiExit.Text = "Çıkış";
            // 
            // knMain
            // 
            this.knMain.Location = new System.Drawing.Point(0, 121);
            this.knMain.Name = "knMain";
            this.knMain.Size = new System.Drawing.Size(1172, 622);
            this.knMain.TabIndex = 2;
            this.knMain.Text = "kryptonNavigator1";
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 744);
            this.Controls.Add(this.knMain);
            this.Controls.Add(this.krMain);
            this.CustomCaptionArea = new System.Drawing.Rectangle(124, 0, 1016, 26);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "test";
            this.Text = "test";
            this.Load += new System.EventHandler(this.test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.krMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knMain)).EndInit();
            this.knMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Docking.KryptonDockingManager kryptonDockingManager1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbon krMain;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab krtCustomer;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup krgCustomerInfo;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple krgtCustomer;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton krgbAddCustomer;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton krgbCustomerList;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kcmiExit;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator knMain;
    }
}