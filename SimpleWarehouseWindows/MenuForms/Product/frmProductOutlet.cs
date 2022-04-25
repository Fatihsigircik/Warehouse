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
using SimpleWarehouseWindows.Models;
using SimpleWarehouseWindows.UserControls;

namespace SimpleWarehouseWindows.MenuForms.Product
{
    public partial class frmProductOutlet : BaseForm
    {
        private readonly short _inOrOut;
        private Warehouse _warehouse;
        private string _docNumber;
        private Warehouse Warehouse
        {
            get => _warehouse;
            set
            {
                _warehouse = value;
                lblWarehouseName.Text = value.WarehouseName;
            }
        }

        public string DocNumber
        {
            get => _docNumber;
            set
            {
                _docNumber = value;
                lblDocNember.Text = value;
            }
        }

        public frmProductOutlet(short inOrOut)
        {
            _inOrOut = inOrOut;
            InitializeComponent();
            lblHeader.Text = $"Ürün {(inOrOut == 1 ? "Girişi" : "Çıkışı")}";
        }

        private async void frmProductOutlet_Load(object sender, EventArgs e)
        {
            var frmWarehouseSelect = new frmWerahouseSelect();
            if (frmWarehouseSelect.ShowDialog() != DialogResult.OK)
            {
                await Task.Delay(100);
                Close();
            }
            DocNumber = frmWarehouseSelect.Info.DocNumber;
            Warehouse = frmWarehouseSelect.Info.Warehouse;
            txtBarcode.Focus();

            OpenLoader();
            await LoadDocumentDetailsByDocNumber();
            CloseLoader();
        }

        private async Task LoadDocumentDetailsByDocNumber()
        {
            var detailList = await ApiHelper.GetProductByDocumentNumber(_docNumber);
            if (detailList == null || detailList.Count == 0)
                return;
            foreach (var detail in detailList)
            {
                pnl.Controls.Add(new ProductDetailControl(detail) { OpenLoader = OpenLoader, CloseLoader = CloseLoader });
            }

        }

        private async void btn_Click(object sender, EventArgs e)
        {
            var name = (sender as Button).Name.Replace("btn", "");
            var txtText = gbProductInfo.Controls.Cast<Control>().FirstOrDefault(q => q.Name == $"txt{name}");
            if (txtText == null || txtText.Text.Length == 0)
                return;

            try
            {
                var product = name == "ProductCode"
                            ? await Helpers.ApiHelper.GetProductByCode(txtText.Text)
                            : await Helpers.ApiHelper.GetProductByBarcode(txtText.Text);
                if (product == null)
                {
                    MessageBox.Show("Ürün Bulunamadı...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var productQuantity = new frmProductQuantity(product);
                if (productQuantity.ShowDialog() == DialogResult.OK)
                {
                    var productDetail = new ProductDetail()
                    {
                        CreatedDate = DateTime.Now,
                        Price = 0,
                        CreatedId = SettingsHelper.UserName.UserId,
                        WarehouseId = Warehouse.WarehouseId,
                        UnitId = product.UnitId,
                        IsApproved = false,
                        ProductId = product.ProductId,
                        CustomerId = 0,
                        //CurrencyId = product.CurrencyId,
                        DocumentCode = DocNumber,
                        InOrOut = _inOrOut,
                        Stock = productQuantity.Quantity,
                        VatPercent = product.VatPercent
                    };
                    OpenLoader();
                    var detail = await ApiHelper.AddProductDetail(productDetail);
                    await LoadDocumentDetails(detail);
                    CloseLoader();
                    txtText.Text = "";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task LoadDocumentDetails(ProductDetail detail)
        {
            pnl.Controls.Add(new ProductDetailControl(detail) {OpenLoader = OpenLoader, CloseLoader = CloseLoader});
        }

        private void pnl_ControlAdded(object sender, ControlEventArgs e)
        {
            var index = pnl.Controls.GetChildIndex(e.Control);
            e.Control.Top = (e.Control.Height * index) + (1 * index);
        }

        private void pnl_ControlRemoved(object sender, ControlEventArgs e)
        {
            var scrollPosition = pnl.VerticalScroll.Value;
            pnl.VerticalScroll.Value = 0;
            var controls = pnl.Controls.Cast<Control>();
            foreach (var control in controls)
            {
                if (control == e.Control)
                    continue;

                var index = pnl.Controls.GetChildIndex(control);
                control.Top = (control.Height * index) + (1 * index);
            }

            pnl.VerticalScroll.Value = scrollPosition;
            pnl.Refresh();
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_Click(btnBarcode, null);
                e.Handled = true;
            }
        }

        private async void btnApproveAll_Click(object sender, EventArgs e)
        {
            OpenLoader();
            var detailList = await ApiHelper.GetProductByDocumentNumber(_docNumber);
            await ApiHelper.ApproveDetails(detailList.Select(q => q.ProductDetailId).ToList());
            foreach (Control control in pnl.Controls)
            {
                (control as ProductDetailControl)?.SetApprove(true);
            }
            CloseLoader();
        }


        private void lblClose_MouseDown(object sender, MouseEventArgs e)
        {
            lblClose.BackColor = Color.Coral;
        }

        private void lblClose_MouseUp(object sender, MouseEventArgs e)
        {
            lblClose.BackColor = Color.Red;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
