using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using SimpleWarehouseWindows.FormHelper;
using SimpleWarehouseWindows.Helpers;
using SimpleWarehouseWindows.Models;
using SimpleWarehouseWindows.NewForm.Variant;

namespace SimpleWarehouseWindows.NewForm.Product
{
    public partial class frmNewProduct : BaseForm
    {
        private int _id;
        private static Dictionary<int, frmNewProduct> _newProducts = new Dictionary<int, frmNewProduct>();
        private Models.Product _updateProduct;
        private List<Currency> _currencies;
        private Models.Product Product
        {
            get
            {
                var product = new Models.Product()
                {
                    ProductCode = ktxtProductCode.Text,
                    CreatedDate = DateTime.Now,
                    CreatedId = SettingsHelper.UserName.UserGroupId,
                    IsDeleted = false,
                    Barcode = ktxtBarcode.Text,
                    Description = ktxtDetail.Text,
                    HasVariant = kcbHasVariant.Checked,
                    ProductName = ktxtProductName.Text,
                    VatPercent = Convert.ToByte(ktxtVat.Text),
                    UnitId = (kcbStokUnit.SelectedItem as Unit)?.UnitId
                };
                return product;
            }
        }
        public static frmNewProduct GetInstance(int id = 0)
        {
            if (!_newProducts.ContainsKey(id))
                _newProducts.Add(id, new frmNewProduct(id));
            return _newProducts[id];
        }

        public static void RemoveInstance(frmNewProduct frm)
        {
            var finded = _newProducts.Values.FirstOrDefault(q => q == frm);
            if (finded == null)
                return;
            _newProducts.Remove(finded._id);
            finded.Close();
            finded.Dispose();
        }
        public frmNewProduct(int id)
        {
            _id = id;
            IsOnlyOne = true;
            InitializeComponent();
            kdgvPriceList.AutoGenerateColumns = false;
            kdgvVariants.AutoGenerateColumns = false;
            ktxtVat.KeyPress += new Utility.ControlEvents().KeyPress;
            kdgvProductDetail.AutoGenerateColumns = false;

            if (id == 0)

            {
                Text = "Yeni Ürün Ekle";
                kgbCustomerDetails.Visible = false;
            }

            LoadCurrency();
            LoadPriceGroup();
        }

        private async void LoadCurrency()
        {
            _currencies = await ApiHelper.GetCurrencyList();
        }

        private async void LoadPriceGroup()
        {
            var priceGroups = await ApiHelper.GetPriceListGroups();
            kdgvPriceList.DataSource = priceGroups;
        }

        private async void frmNewProduct_Load(object sender, EventArgs e)
        {
            await LoadStokUnit();
            if (_id > 0)
            {
                await LoadProductDetail();
                kgbPriceList.Enabled = true;
            }
        }

        private async Task LoadProductDetail()
        {
            try
            {
                _updateProduct = await ApiHelper.GetProductById(_id);
                LoadControls(_updateProduct);
                await LoadPrice();
                await LoadStockMovements();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private async Task LoadStockMovements()
        {
            kdgvProductDetail.DataSource = await ApiHelper.GetProductDetailByProductCode(_id);
        }

        private async Task LoadPrice()
        {
            var prices = await ApiHelper.GetProductPrices(_id);
            foreach (var rowView in kdgvPriceList.Rows.Cast<DataGridViewRow>())
            {
                var item = rowView.DataBoundItem as PriceListGroup;
                var price = prices.FirstOrDefault(q => q.PriceListGroupId == item.PriceListGroupId);
                if (price == null)
                    continue;
                rowView.Cells[1].Value = price.Price;
                rowView.Cells[3].Value = price.IsDefaultPrice;
                var cur = _currencies.FirstOrDefault(q => q.CurrencyId == price.CurrencyId);
                if (cur == null)
                    continue;
                rowView.Cells[2].Value = cur.CurrencyCode;
                rowView.Cells[2].Tag = cur;
            }
        }

        private void LoadControls(Models.Product product)
        {
            ktxtProductCode.Text = product.ProductCode;
            ktxtBarcode.Text = product.Barcode;
            ktxtDetail.Text = product.Description;
            kcbHasVariant.Checked = product.HasVariant;
            ktxtProductName.Text = product.ProductName;
            ktxtVat.Text = product.VatPercent.ToString();
            kcbStokUnit.SelectedValue = product.UnitId;
            this.Parent.Text = $"{product.ProductName}({product.ProductCode})";
        }

        private async Task LoadStokUnit()
        {
            kcbStokUnit.DataSource = await ApiHelper.GetUnitList();
            kcbStokUnit.DisplayMember = "UnitName";
            kcbStokUnit.ValueMember = "UnitId";
        }

        private async void bsaGenerateCustomerCode_Click(object sender, EventArgs e)
        {
            try
            {
                var currentCode = await ApiHelper.GetCurrentCustomerCode(ktxtProductCode.Text);
                if (string.IsNullOrEmpty(currentCode))
                {
                    throw new Exception($"{ktxtProductCode.Text} Prefixi İle Başlayan Kayıt Bulunamadı...");
                }
                ktxtProductCode.Text = currentCode;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void kryptonButton1_Click(object sender, EventArgs e)
        {
            await SaveProduct();
        }

        private async Task SaveProduct()
        {
            try
            {
                OpenLoader();
                var product = Product;
                if (_updateProduct != null)
                {
                    product.ProductId = _updateProduct.ProductId;
                    await ApiHelper.ProductUpdate(product);
                }
                else
                {
                    _updateProduct = await ApiHelper.AddProduct(product);
                    _newProducts.Remove(0);
                    _newProducts[_updateProduct.ProductId] = this;
                    Text = $"{_updateProduct.ProductName}({_updateProduct.ProductCode})";
                    this.Parent.Text = Text;
                    _id = _updateProduct.ProductId;
                }
                CloseLoader();
                MessageBox.Show("Kayıt İşlemi Başarılı...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //DialogResult = DialogResult.OK;
                kgbPriceList.Enabled = true;
                kgbVariant.Enabled = kcbHasVariant.Checked;

            }
            catch (Exception e)
            {
                MessageBox.Show($"Kayıt Gerçekleştirilemedi...{Environment.NewLine}HATA : {e.Message}");
            }
            finally
            {
                CloseLoader();
            }

        }

        private void frmNewProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            _newProducts.Remove(_id);
        }

        private async void kcbHasVariant_CheckedChanged(object sender, EventArgs e)
        {
            kgbVariant.Enabled = kcbHasVariant.Checked && _id > 0;
            if (kcbHasVariant.Checked && _id > 0)
            {

                OpenLoader();
                await LoadVariant();
                CloseLoader();
            }
        }

        private async Task LoadVariant()
        {
            var variants = await ApiHelper.GetProductVariantsWithGroup(_id);
            if (variants == null || variants.Count == 0)
                return;
            var firstItem = variants.FirstOrDefault();
            for (int i = 1; i < 6; i++)
            {
                var value = firstItem.GetType().GetProperty($"P{i}Id").GetValue(firstItem);
                if (value != null && Convert.ToInt32(value) > 0)
                {
                    var column = kdgvVariants.Columns[$"Property{i}"];
                    column.Visible = true;
                    column.HeaderText = firstItem.GetType().GetProperty($"P{i}GroupName")?.GetValue(firstItem)?.ToString();
                }
            }
            kdgvVariants.DataSource = variants;
        }

        private void tsmiNewVariant_Click(object sender, EventArgs e)
        {
            var frmProductVariant = new frmProductVariant(_id);
            frmProductVariant.Saved += FrmProductVariant_Saved;
            frmProductVariant.ShowDialog();
        }

        private async void FrmProductVariant_Saved(object sender, EventArgs e)
        {
            OpenLoader();
            await LoadVariant();
            CloseLoader();
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            UpdateVariant();
        }

        private void UpdateVariant()
        {
            var variant = kdgvVariants.SelectedRows[0].DataBoundItem as ProductVariantWithGroupName;
            var frmProductVariant = new frmProductVariant(_id, variant.VariantId);
            frmProductVariant.Saved += FrmProductVariant_Saved;
            frmProductVariant.ShowDialog();
        }

        private void kdgvVariants_MouseDown(object sender, MouseEventArgs e)
        {
            var test = kdgvVariants.HitTest(e.X, e.Y);
            if (test.RowIndex == -1)
                return;
            kdgvVariants.Rows[test.RowIndex].Selected = true;
        }

        private async void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kaydı Silmek İstediğinizden Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var variant = kdgvVariants.SelectedRows[0].DataBoundItem as ProductVariantWithGroupName;
                await ApiHelper.DeleteVariant(variant.VariantId);
                await LoadVariant();
            }
        }

        private void kdgvVariants_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UpdateVariant();
        }

        private void kdgvPriceList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (kdgvPriceList.CurrentCell.ColumnIndex == 1) //Desired Column
            {
                if (e.Control is KryptonTextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            else if (kdgvPriceList.CurrentCell.ColumnIndex == 2)
            {
                if (e.Control is KryptonComboBox cb)
                {
                    cb.DataSource = new BindingSource() { DataSource = _currencies };
                    cb.DisplayMember = "CurrencyCode";
                    cb.SelectedIndexChanged += Cb_SelectedIndexChanged;
                }
            }
        }

        private void Cb_SelectedIndexChanged(object sender, EventArgs e)
        {

            var cb = sender as KryptonComboBox;
            if (cb.SelectedItem == null)
                return;
            kdgvPriceList.CurrentCell.Tag = cb.SelectedItem as Currency;
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFormatInfo nfi = Thread.CurrentThread.CurrentCulture.NumberFormat;

            var decSeparator = nfi.CurrencyDecimalSeparator[0];

            if (!char.IsControl(e.KeyChar) && !(char.IsDigit(e.KeyChar)
                                                | e.KeyChar == decSeparator))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if (e.KeyChar == decSeparator
                && ((KryptonTextBox)sender).Text.IndexOf(decSeparator) > -1)
            {
                e.Handled = true;
            }
        }

        private void kdgvPriceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 3 || e.RowIndex == -1)
                return;

            foreach (DataGridViewRow row in kdgvPriceList.Rows)
            {
                if (row.Index != e.RowIndex && Convert.ToBoolean(row.Cells[3].Value))
                    row.Cells[3].Value = false;
            }
        }

        private async void btnPriceSave_Click(object sender, EventArgs e)
        {
            try
            {
                OpenLoader();
                await SavePrice();
                MessageBox.Show("Kayıt Gerçekleşti...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show($@"Hata Oluştu. KAyıt Yapılamadı...{Environment.NewLine},{exception.Message}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            CloseLoader();

        }

        private async Task SavePrice()
        {
            var prices = kdgvPriceList.Rows.Cast<DataGridViewRow>().Select(q => new ProductPriceList()
            {
                ProductId = _id,
                Price = Convert.ToDecimal(q.Cells[1].Value ?? 0),
                CurrencyId = (q.Cells[2].Tag as Currency)?.CurrencyId ?? 0,
                IsDefaultPrice = Convert.ToBoolean(q.Cells[3].Value ?? false),
                PriceListGroupId = (q.DataBoundItem as PriceListGroup).PriceListGroupId
            }).Where(q => q.CurrencyId > 0).ToList();

            await ApiHelper.SetPriceList(prices);
        }
    }
}
