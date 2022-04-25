using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouseWindows.Models;

namespace SimpleWarehouseWindows.FormHelper
{
    public partial class frmSelectVariant : BaseForm
    {

        internal ProductVariant SelectedVariant =>
            (kclbVariant.CheckedItems.Count == 0
                ? (kclbVariant.Items.Count == 0 ? null : kclbVariant.Items[0])
                : kclbVariant.CheckedItems[0]) as ProductVariant;
        public frmSelectVariant(List<ProductVariant> variants)
        {
            InitializeComponent();
            kclbVariant.Items.AddRange(variants.ToArray());
            if (variants.Count != 0)
                kclbVariant.SetItemChecked(0, true);
        }

        private void kclbVariant_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < kclbVariant.Items.Count; ++ix)
                if (ix != e.Index) kclbVariant.SetItemChecked(ix, false);
        }

        private void kclbVariant_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
