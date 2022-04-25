using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouseWindows.FormHelper
{
    public partial class frmMultiField : BaseForm
    {
        private readonly Type _type;
        private readonly object _updateObject;
        readonly string[] _keys = { "Name", "Description" };
        internal object GetObject
        {
            get
            {
                var t = Activator.CreateInstance(_type);

                foreach (var key in _keys)
                {
                    var prop = _type.GetProperties().FirstOrDefault(q => q.Name.EndsWith(key));
                    if (prop == null)
                        continue;
                    var value = gbMain.Controls.Cast<Control>().FirstOrDefault(q => q.Name == $"txt{key}");
                    if (value == null)
                        continue;
                    prop.SetValue(t, value.Text);
                }
                return t;
            }
        }

        public frmMultiField(Type type, object updateObject = null)
        {
            _type = type;
            _updateObject = updateObject;
            InitializeComponent();
            LoadInfo();
            if (updateObject != null)
                LoadControlInfo();
            LoadInfo();
        }

        private void LoadControlInfo()
        {
            txtName.Text = _updateObject.GetType().GetProperties().FirstOrDefault(q => q.Name.EndsWith("Name"))
                ?.GetValue(_updateObject)?.ToString();
            txtDescription.Text = _updateObject.GetType().GetProperties().FirstOrDefault(q => q.Name.EndsWith("Description"))?.GetValue(_updateObject)?.ToString();
        }

        private void LoadInfo()
        {
            var attr = _type.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attr.Length == 0)
                throw new Exception("DescriptionAttribute Uygulanmış Sınıf Tipi Gönderilmelidir..");
            var description = (attr[0] as DescriptionAttribute).Description;
            gbMain.Text = $@"{description} {(_updateObject !=null ? "Güncellemesi" : "Ekle")}";

            lblDescription.Text = $@"{description} Açıklaması";
            lblName.Text = $@"{description} Adı";
            Text = description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("İsim Alanı Doldurulmalıdır...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (_updateObject != null)
            {
                _updateObject.GetType().GetProperties().FirstOrDefault(q => q.Name.EndsWith("Name"))
                    ?.SetValue(_updateObject, txtName.Text);

                _updateObject.GetType().GetProperties().FirstOrDefault(q => q.Name.EndsWith("Description"))
                    ?.SetValue(_updateObject, txtDescription.Text);
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
