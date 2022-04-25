namespace SimpleWarehouseWindows.FormHelper
{
    partial class frmSelectVariant
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
            this.kbtnSelectVariant = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kpnlVariant = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kclbVariant = new ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox();
            this.kryptonHeader1 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlVariant)).BeginInit();
            this.kpnlVariant.SuspendLayout();
            this.SuspendLayout();
            // 
            // kbtnSelectVariant
            // 
            this.kbtnSelectVariant.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnSelectVariant.Location = new System.Drawing.Point(87, 244);
            this.kbtnSelectVariant.Name = "kbtnSelectVariant";
            this.kbtnSelectVariant.Size = new System.Drawing.Size(90, 25);
            this.kbtnSelectVariant.TabIndex = 15;
            this.kbtnSelectVariant.Values.Text = "Seç";
            // 
            // kpnlVariant
            // 
            this.kpnlVariant.Controls.Add(this.kbtnSelectVariant);
            this.kpnlVariant.Controls.Add(this.kclbVariant);
            this.kpnlVariant.Controls.Add(this.kryptonHeader1);
            this.kpnlVariant.Location = new System.Drawing.Point(-1, 0);
            this.kpnlVariant.Name = "kpnlVariant";
            this.kpnlVariant.Size = new System.Drawing.Size(264, 273);
            this.kpnlVariant.TabIndex = 14;
            // 
            // kclbVariant
            // 
            this.kclbVariant.CheckOnClick = true;
            this.kclbVariant.Dock = System.Windows.Forms.DockStyle.Top;
            this.kclbVariant.Location = new System.Drawing.Point(0, 24);
            this.kclbVariant.Name = "kclbVariant";
            this.kclbVariant.Size = new System.Drawing.Size(264, 218);
            this.kclbVariant.TabIndex = 9;
            this.kclbVariant.SelectedValueChanged += new System.EventHandler(this.kclbVariant_SelectedValueChanged);
            this.kclbVariant.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.kclbVariant_ItemCheck);
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeader1.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Calendar;
            this.kryptonHeader1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(264, 24);
            this.kryptonHeader1.TabIndex = 14;
            this.kryptonHeader1.Values.Description = "";
            this.kryptonHeader1.Values.Heading = "Varyantlar";
            this.kryptonHeader1.Values.Image = null;
            // 
            // frmSelectVariant
            // 
            this.AcceptButton = this.kbtnSelectVariant;
            this.AdministratorText = "fs";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 273);
            this.Controls.Add(this.kpnlVariant);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSelectVariant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Varyant Seçimi";
            ((System.ComponentModel.ISupportInitialize)(this.kpnlVariant)).EndInit();
            this.kpnlVariant.ResumeLayout(false);
            this.kpnlVariant.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kpnlVariant;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnSelectVariant;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox kclbVariant;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader1;
    }
}