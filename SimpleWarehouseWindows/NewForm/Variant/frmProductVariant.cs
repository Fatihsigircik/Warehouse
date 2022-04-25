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

namespace SimpleWarehouseWindows.NewForm.Variant
{
    public partial class frmProductVariant : BaseForm
    {

        internal event EventHandler Saved;
        private readonly int _productId;
        private int _variantId;
        private List<VariantGroup> _variantGroups;
        private ProductVariant _currentProductVariant;

        public frmProductVariant(int productId, int VariantId = 0)
        {
            _productId = productId;
            _variantId = VariantId;
            InitializeComponent();
        }

        private async void frmProductVariant_Load(object sender, EventArgs e)
        {
            OpenLoader();
            await LoadProductInfo();
            await LoadVariantGroups();
            await SetVariants();
            CloseLoader();
        }

        private async Task SetVariants()
        {
            var variants = await ApiHelper.GetProductVariants(_productId);
            if (_variantId > 0)
            {
                _currentProductVariant = variants.FirstOrDefault(q => q.VariantId == _variantId);
                if (_currentProductVariant != null)
                    ktxtVariantBarcode.Text = _currentProductVariant.Barcode;
            }

            var productVariant = variants.FirstOrDefault();
            if (productVariant == null)
                return;
            var hasVariant = false;
            if (productVariant.P1GroupId.HasValue)
            {
                hasVariant = true;
                kcbGroup1.SelectedValue = productVariant.P1GroupId;
                kcbGroup1.Enabled = false;
            }
            if (productVariant.P2GroupId.HasValue)
            {
                hasVariant = true;
                kcbGroup2.SelectedValue = productVariant.P2GroupId;
                kcbGroup2.Enabled = false;
            }

            if (productVariant.P3GroupId.HasValue)
            {
                hasVariant = true;
                kcbGroup3.SelectedValue = productVariant.P3GroupId;
                kcbGroup3.Enabled = false;
            }

            if (productVariant.P4GroupId.HasValue)
            {
                hasVariant = true;
                kcbGroup4.SelectedValue = productVariant.P4GroupId;
                kcbGroup4.Enabled = false;
            }

            if (productVariant.P5GroupId.HasValue)
            {
                hasVariant = true;
                kcbGroup5.SelectedValue = productVariant.P5GroupId;
                kcbGroup5.Enabled = false;
            }
            
        }

        private async Task LoadVariantGroups()
        {
            _variantGroups = await ApiHelper.GetVariantGroupList();
            _variantGroups.Insert(0, new VariantGroup() { Name = "Seçiniz", VariantGroupId = -1 });
            SetComboBoxDataSource(new[] { kcbGroup1, kcbGroup2, kcbGroup3, kcbGroup4, kcbGroup5 });
        }

        private void SetComboBoxDataSource(KryptonComboBox[] kcbArray)
        {
            foreach (var cb in kcbArray)
            {
                cb.DataSource = new BindingSource() { DataSource = _variantGroups };
                cb.DisplayMember = "Name";
                cb.ValueMember = "VariantGroupId";
            }
        }

        private async Task LoadProductInfo()
        {
            var product = await ApiHelper.GetProductById(_productId);
            ktxtProductCode.Text = product.ProductCode;
            ktxtBarcode.Text = product.Barcode;
            ktxtProductName.Text = product.ProductName;
        }

        private async void kcbGroup5_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (sender as KryptonComboBox);
            if ((comboBox.SelectedItem as VariantGroup).VariantGroupId == -1)
                return;
            OpenLoader();
            var index = comboBox.Name.Replace("kcbGroup", "");
            if (!(kgbProperty.Panel.Controls.Cast<Control>()
                .FirstOrDefault(q => q.Name == "kcbProperty" + index) is KryptonComboBox valueComboBox))
                return;
            valueComboBox.DataSource = await ApiHelper.GetVariantPropertyListByGroupId((comboBox.SelectedItem as VariantGroup).VariantGroupId);
            valueComboBox.DisplayMember = "Name";
            valueComboBox.ValueMember = "VariantPropertyId";
            if (_currentProductVariant != null)
                valueComboBox.SelectedValue = _currentProductVariant.GetType().GetProperty($"P{index}Id")?
                    .GetValue(_currentProductVariant)??"";

            CloseLoader();
        }

        private async void kbtnSave_Click(object sender, EventArgs e)
        {
            OpenLoader();
            await SaveVariant();
            Saved?.Invoke(this, null);
            CloseLoader();
        }

        private async Task SaveVariant()
        {
            try
            {
                var variant = GetVariant();
                if (_variantId > 0)
                {
                    variant.VariantId = _variantId;
                    await ApiHelper.UpdateVariant(variant);
                }
                else
                {
                    var addedVariant = await ApiHelper.AddVariant(variant);
                    _variantId = addedVariant.VariantId;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private Models.Variant GetVariant()
        {
            return new Models.Variant()
            {
                ProductId = _productId,
                Barcode = ktxtVariantBarcode.Text,
                CreatedDate = DateTime.Now,
                CreatedId = SettingsHelper.UserName.UserGroupId,
                PropertyId1 = (kcbProperty1.SelectedItem as VariantProperty)?.VariantPropertyId,
                PropertyId2 = (kcbProperty2.SelectedItem as VariantProperty)?.VariantPropertyId,
                PropertyId3 = (kcbProperty3.SelectedItem as VariantProperty)?.VariantPropertyId,
                PropertyId4 = (kcbProperty4.SelectedItem as VariantProperty)?.VariantPropertyId,
                PropertyId5 = (kcbProperty5.SelectedItem as VariantProperty)?.VariantPropertyId,

            };
        }

        private void kbtnNewVariant_Click(object sender, EventArgs e)
        {
            ktxtVariantBarcode.Text = "";
            kcbProperty1.SelectedIndex = -1;
            kcbProperty2.SelectedIndex = -1;
            kcbProperty3.SelectedIndex = -1;
            kcbProperty4.SelectedIndex = -1;
            kcbProperty5.SelectedIndex = -1;
            _variantId = 0;
        }
    }
}
