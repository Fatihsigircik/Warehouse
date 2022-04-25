using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouseWindows.FormHelper;
using SimpleWarehouseWindows.Helpers;

namespace SimpleWarehouseWindows
{
    public partial class frmLogin : BaseForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            OpenLoader();
            await CheckUser();
            CloseLoader();
        }

        private async Task CheckUser()
        {
            if (await CheckUserInfo(txtUserName.Text,txtPassword.Text))
            {
                this.DialogResult = DialogResult.OK;
                return;
            }

        }
        private async Task<bool> CheckUserInfo(string userName, string password)
        {
            try
            {
                string token = await ApiHelper.GetToken(userName, password);
                SettingsHelper.Token = token;
                SettingsHelper.UserName = await ApiHelper.GetUserByUserName(userName);


                return true;
            }
            catch (Exception e)when(e.Message== "Unauthorized")
            {
                MessageBox.Show("Kullanıcı Adı Veya Şifre Hatalı...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception e)
            {
                NotifyIcon notifyIcon1 = new NotifyIcon();
                notifyIcon1.Icon = SystemIcons.Exclamation;
                notifyIcon1.BalloonTipTitle = "Uyarı";
                notifyIcon1.BalloonTipText = e.Message;
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(5000);
                return false;
            }


        }
    }
}
