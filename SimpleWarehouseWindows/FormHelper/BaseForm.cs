using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace SimpleWarehouseWindows.FormHelper
{
    public class BaseForm : KryptonForm
    {
        public bool IsOnlyOne;
        private PictureBox pb;

        protected void OpenLoader()
        {
            if(pb!=null)
                return;
            pb = new PictureBox
            {
                Image = Properties.Resources.Spinner_1s_64px,
                Top = this.Height / 2 - 32,
                Left = this.Width / 2 - 32,
                Width = 64,
                Height = 64,

                BackColor = Color.Transparent
            };
            var controls = this.GetType().GetProperty("Controls").GetValue(this) as ControlCollection;
           
            controls.Add(pb);
            pb.BringToFront();

        }

        protected void CloseLoader()
        {
            if(pb==null)
                return;
            var controls = this.GetType().GetProperty("Controls").GetValue(this) as ControlCollection;

            controls.Remove(pb);
            pb?.Dispose();
            pb = null;
        }


    }
}
