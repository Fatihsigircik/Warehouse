using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using SimpleWarehouseWindows.FormHelper;
using SimpleWarehouseWindows.Helpers;
using SimpleWarehouseWindows.Models;

namespace SimpleWarehouseWindows.NewForm.Supplier
{
    public partial class frmNewSupplier : BaseForm
    {
        private readonly int _id;
        private static Dictionary<int, frmNewSupplier> newCustomers = new Dictionary<int, frmNewSupplier>();
        private Models.Supplier _updateSupplier;
        private Models.Supplier Supplier
        {
            get
            {
                var supplier = new Models.Supplier()
                {
                    CityId = (kcbCity.SelectedItem as City)?.CityId,
                    CreatedDate = DateTime.Now,
                    CountryId = (kcbCountry.SelectedItem as Country)?.CountryId,
                    CreatedId = SettingsHelper.UserName.UserGroupId,
                    Address = ktxtAddress.Text,
                    //Address2 = ktxtAddress2.Text,
                    CompanyName = ktxtCompany.Text,
                    SupplierCode = ktxtSupplierCode.Text,
                    SupplierName = ktxtName.Text,
                    SupplierSurname = ktxtSurname.Text,
                    Mail = ktxtMail.Text,
                    Phone = ktxtPhone.Text,
                    Phone2 = ktxtPhone2.Text,
                    TaxNumber = ktxtTaxNo.Text,
                    TaxOffice = ktxtTaxDept.Text,
                    TownId = (kcbTown.SelectedItem as Town)?.TownId,
                    IsDeleted = false,
                    DefaultCurrencyId = (kcbCurrency.SelectedItem as Models.Currency).CurrencyId,
                    //RetailGroupId = (kcbRetail.SelectedItem as PriceListGroup).PriceListGroupId
                };
                return supplier;
            }
        }
        public static frmNewSupplier GetInstance(int id = 0)
        {
            if (!newCustomers.ContainsKey(id))
                newCustomers.Add(id, new frmNewSupplier(id));
            return newCustomers[id];
        }

        public static void RemoveInstance(frmNewSupplier frm)
        {
            var finded = newCustomers.Values.FirstOrDefault(q => q == frm);
            if (finded == null)
                return;
            newCustomers.Remove(finded._id);
            finded.Close();
            finded.Dispose();
        }
        public frmNewSupplier(int id)
        {
            _id = id;
            IsOnlyOne = true;
            InitializeComponent();
            kdgvSupplierDetails.AutoGenerateColumns = false;
            if (id > 0)
                LoadSupplierInfo();
            else
            {
                Text = "Yeni Tedarikçi Ekle";
                kgbCustomerDetails.Visible = false;
            }
        }
        private void SetSelectedItem<T>(KryptonComboBox cb, string field, int? value)
        {
            var list = (cb.DataSource as List<T>);
            if (list == null || list.Count == 0)
                return;
            var item = list.FirstOrDefault(q => Convert.ToInt32(q.GetType().GetProperty(field)?.GetValue(q)) == value.Value);
            cb.SelectedItem = item;
        }
        private async void LoadSupplierInfo()
        {
            OpenLoader();
            _updateSupplier = await ApiHelper.GetSupplier(_id);
            SetSelectedItem<Country>(kcbCountry, "CountryId", _updateSupplier.CountryId);
            SetSelectedItem<City>(kcbCity, "CityId", _updateSupplier.CityId);
            SetSelectedItem<Town>(kcbTown, "TownId", _updateSupplier.TownId);

            ktxtAddress.Text = _updateSupplier.Address;
            //txtAddress2.Text = _updateCustomer.Address2;
            ktxtCompany.Text = _updateSupplier.CompanyName;
            ktxtSupplierCode.Text = _updateSupplier.SupplierCode;
            ktxtName.Text = _updateSupplier.SupplierName;
            ktxtSurname.Text = _updateSupplier.SupplierSurname;
            ktxtMail.Text = _updateSupplier.Mail;
            ktxtPhone.Text = _updateSupplier.Phone;
            ktxtPhone2.Text = _updateSupplier.Phone2;
            ktxtTaxNo.Text = _updateSupplier.TaxNumber;
            ktxtTaxDept.Text = _updateSupplier.TaxOffice;
            //kcbRetail.SelectedValue = _updateCustomer.RetailGroupId ?? 0;
            kcbCurrency.SelectedValue = _updateSupplier.DefaultCurrencyId ?? 0;
            this.Parent.Text = _updateSupplier.CompanyName;
            CloseLoader();
            LoadSupplierDetails();
        }

        private async void LoadSupplierDetails()
        {
            //burasını api helper içinde düzelt.
            kdgvSupplierDetails.DataSource = await ApiHelper.GetSupplierDetailListByCustomerId(_id);
        }

        private void frmNewSupplier_FormClosed(object sender, FormClosedEventArgs e)
        {
            newCustomers.Remove(_id);
        }

        private void frmNewSupplier_Load(object sender, EventArgs e)
        {
            LoadCountry();
            LoadCurrency();
            //if (_id > 0)
            //    LoadCustomerInfo();
        }
        private void LoadCurrency()
        {
            OpenLoader();
            var currencyList = ApiHelper.GetCurrencyListSencron();

          

            kcbCurrency.DataSource = currencyList;
            kcbCurrency.DisplayMember = "CurrencyName";
            kcbCurrency.ValueMember = "CurrencyId";

            CloseLoader();
        }
        private void LoadCountry()
        {
            OpenLoader();
            var countryList = ApiHelper.GetCountryListSynchronous();
            kcbCountry.DataSource = countryList;
            kcbCountry.DisplayMember = "Name";
            CloseLoader();
        }

        private void LoadCity()
        {
            var country = kcbCountry.SelectedItem as Country;
            OpenLoader();
            var cityList = ApiHelper.GetCityListSynchronous(country.CountryId);
            kcbCity.DataSource = cityList;
            kcbCity.DisplayMember = "Name";
            kcbCity.SelectedIndex = 33;
            CloseLoader();
        }
        private void LoadTown()
        {
            var city = kcbCity.SelectedItem as City;
            OpenLoader();
            var townList = ApiHelper.GetTownListSynchronous(city.CityId);
            if (townList.Count > 0)
            {
                kcbTown.DataSource = townList;
                kcbTown.DisplayMember = "Name";
            }
            CloseLoader();
        }

        private void kcbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kcbCountry.SelectedIndex == -1)
                return;
            LoadCity();
        }

        private void kcbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kcbCity.SelectedIndex == -1)
                return;
            LoadTown();
        }

        private async void bsaGenerateCustomerCode_Click(object sender, EventArgs e)
        {
            try
            {
                OpenLoader();
                var currentCode = await ApiHelper.GetCurrentCustomerCode(ktxtSupplierCode.Text);
                if (string.IsNullOrEmpty(currentCode))
                {
                    throw new Exception($"{ktxtSupplierCode.Text} Prefixi İle Başlayan Kayıt Bulunamadı...");
                }
                ktxtSupplierCode.Text = currentCode;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CloseLoader();
        }

        private async void kbtnSave_Click(object sender, EventArgs e)
        {
            await SaveSupplier();
        }

        private async Task SaveSupplier()
        {
            try
            {
                OpenLoader();
                var supplier = Supplier;
                if (_updateSupplier != null)
                {
                    supplier.SupplierId = _updateSupplier.SupplierId;
                    await ApiHelper.UpdateSupplier(supplier);
                }
                else
                {
                    _updateSupplier = await ApiHelper.AddSupplier(supplier);
                    newCustomers.Remove(0);
                    newCustomers[_updateSupplier.SupplierId] = this;
                    Text = _updateSupplier.CompanyName;
                    this.Parent.Text = Text;
                }
                CloseLoader();
                MessageBox.Show("Kayıt İşlemi Başarılı...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Kayıt Gerçekleştirilemedi...{Environment.NewLine}HATA : {e.Message}");
            }
            finally
            {
                CloseLoader();
            }
        }
    }
}
