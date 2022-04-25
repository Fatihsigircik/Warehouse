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

namespace SimpleWarehouseWindows.NewForm.Customer
{
    public partial class frmNewCustomer : BaseForm
    {
        private readonly int _id;
        private static Dictionary<int, frmNewCustomer> newCustomers = new Dictionary<int, frmNewCustomer>();
        private Models.Customer _updateCustomer;
        private Models.Customer Customer
        {
            get
            {
                var customer = new Models.Customer()
                {
                    CityId = (kcbCity.SelectedItem as City)?.CityId,
                    CreatedDate = DateTime.Now,
                    CountryId = (kcbCountry.SelectedItem as Country)?.CountryId,
                    CreatedId = SettingsHelper.UserName.UserId,
                    Address = ktxtAddress.Text,
                    //Address2 = ktxtAddress2.Text,
                    CompanyName = ktxtCompany.Text,
                    CustomerCode = ktxtCustomerCode.Text,
                    CustomerName = ktxtName.Text,
                    CustomerSurname = ktxtSurname.Text,
                    Mail = ktxtMail.Text,
                    Phone = ktxtPhone.Text,
                    Phone2 = ktxtPhone2.Text,
                    TaxNumber = ktxtTaxNo.Text,
                    TaxOffice = ktxtTaxDept.Text,
                    TownId = (kcbTown.SelectedItem as Town)?.TownId,
                    IsDeleted = false,
                    WholesaleGroupId = (kcbWholesale.SelectedItem as Models.PriceListGroup).PriceListGroupId,
                    RetailGroupId = (kcbRetail.SelectedItem as PriceListGroup).PriceListGroupId
                };
                return customer;
            }
        }
        public static frmNewCustomer GetInstance(int id = 0)
        {
            if (!newCustomers.ContainsKey(id))
                newCustomers.Add(id, new frmNewCustomer(id));
            return newCustomers[id];
        }

        public static void RemoveInstance(frmNewCustomer frm)
        {
            var finded = newCustomers.Values.FirstOrDefault(q => q == frm);
            if (finded == null)
                return;
            newCustomers.Remove(finded._id);
            finded.Close();
            finded.Dispose();
        }
        private frmNewCustomer(int id)
        {
            _id = id;
            IsOnlyOne = true;
            InitializeComponent();
            kdgvCustomerDetails.AutoGenerateColumns = false;
            if (id == 0)
            {
                Text = "Yeni Cari Ekle";
                kgbCustomerDetails.Visible = false;
            }
        }
        private void LoadCountry()
        {
            OpenLoader();
            var countryList = ApiHelper.GetCountryListSynchronous();
            kcbCountry.DataSource = countryList;
            kcbCountry.DisplayMember = "Name";
            CloseLoader();
        }
        private void LoadPriceListGroup()
        {
            OpenLoader();
            var groupPriceList = ApiHelper.GetPriceListGroupSynchronous();

            var retailList = groupPriceList.Where(q => q.GroupType == 1).ToList();
            var wholesaleList = groupPriceList.Where(q => q.GroupType == 2).ToList();
            kcbRetail.DataSource = retailList;
            kcbRetail.DisplayMember = "GroupName";
            kcbRetail.ValueMember = "PriceListGroupId";

            kcbWholesale.DataSource = wholesaleList;
            kcbWholesale.DisplayMember = "GroupName";
            kcbWholesale.ValueMember = "PriceListGroupId";

            CloseLoader();
        }
        private void LoadCity()
        {
            var country = kcbCountry.SelectedItem as Country;
            OpenLoader();
            var cityList = ApiHelper.GetCityListSynchronous(country.CountryId);
            kcbCity.DataSource = cityList;
            kcbCity.DisplayMember = "Name";
            //kcbCity.SelectedIndex = 33;
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
        private void SetSelectedItem<T>(KryptonComboBox cb, string field, int? value)
        {
            var list = (cb.DataSource as List<T>);
            if (list == null || list.Count == 0)
                return;
            var item = list.FirstOrDefault(q => Convert.ToInt32(q.GetType().GetProperty(field)?.GetValue(q)) == value.Value);
            cb.SelectedItem = item;
        }
        private async void LoadCustomerInfo()
        {
            OpenLoader();
            _updateCustomer = await ApiHelper.GetCustomer(_id);
            SetSelectedItem<Country>(kcbCountry, "CountryId", _updateCustomer.CountryId);
            SetSelectedItem<City>(kcbCity, "CityId", _updateCustomer.CityId);
            SetSelectedItem<Town>(kcbTown, "TownId", _updateCustomer.TownId);

            ktxtAddress.Text = _updateCustomer.Address;
            //txtAddress2.Text = _updateCustomer.Address2;
            ktxtCompany.Text = _updateCustomer.CompanyName;
            ktxtCustomerCode.Text = _updateCustomer.CustomerCode;
            ktxtName.Text = _updateCustomer.CustomerName;
            ktxtSurname.Text = _updateCustomer.CustomerSurname;
            ktxtMail.Text = _updateCustomer.Mail;
            ktxtPhone.Text = _updateCustomer.Phone;
            ktxtPhone2.Text = _updateCustomer.Phone2;
            ktxtTaxNo.Text = _updateCustomer.TaxNumber;
            ktxtTaxDept.Text = _updateCustomer.TaxOffice;
            kcbRetail.SelectedValue = _updateCustomer.RetailGroupId??0;
            kcbWholesale.SelectedValue = _updateCustomer.WholesaleGroupId??0;
            this.Parent.Text = _updateCustomer.CompanyName;
            CloseLoader();
            LoadCustomerDetails();
        }

        private async void LoadCustomerDetails()
        {
            kdgvCustomerDetails.DataSource = await ApiHelper.GetCustomerDetailListByCustomerId(_id);
        }

        private void frmNewCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            newCustomers.Remove(_id);
        }

        private void frmNewCustomer_Load(object sender, EventArgs e)
        {

            LoadCountry();
            LoadPriceListGroup();
            if (_id > 0)
                LoadCustomerInfo();
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
                var currentCode = await ApiHelper.GetCurrentCustomerCode(ktxtCustomerCode.Text);
                if (string.IsNullOrEmpty(currentCode))
                {
                    throw new Exception($"{ktxtCustomerCode.Text} Prefixi İle Başlayan Kayıt Bulunamadı...");
                }
                ktxtCustomerCode.Text = currentCode;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private async void kryptonButton1_Click(object sender, EventArgs e)
        {
            await SaveCustomer();
        }

        private async Task SaveCustomer()
        {
            try
            {
                OpenLoader();
                var customer = Customer;
                if (_updateCustomer != null)
                {
                    customer.CustomerId = _updateCustomer.CustomerId;
                    await ApiHelper.UpdateCustomer(customer);
                }
                else
                {
                    _updateCustomer=await ApiHelper.AddCustomer(customer);
                    newCustomers.Remove(0);
                    newCustomers[_updateCustomer.CustomerId] = this;
                    Text = _updateCustomer.CompanyName;
                    this.Parent.Text = Text;
                }
                CloseLoader();
                MessageBox.Show("Kayıt İşlemi Başarılı...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
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


    }
}
