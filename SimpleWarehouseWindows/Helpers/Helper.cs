using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouseWindows.FormHelper;

namespace SimpleWarehouseWindows.Helpers
{
    internal class Helper
    {
        internal void CenterForm(BaseForm frm)
        {
            if (frm.Parent == null)
                throw new Exception("Form Bir Nesne İçinde Değil..");

            var prnt = frm.Parent;

            frm.Top = (prnt.Height / 2) - (frm.Height / 2);
            frm.Left = (prnt.Width / 2) - (frm.Width / 2);
        }

        internal static Image Base64ToImage(string base64)
        {
            var imageByteArray = Convert.FromBase64String(base64);
            Image picture;
            using (MemoryStream stream = new MemoryStream(imageByteArray))
            {
                picture = Image.FromStream(stream);
            }

            return picture;
        }

        internal static string FileToBase64(string filePath)
        {
            var retVal = Convert.ToBase64String(File.ReadAllBytes(filePath));
            
            return retVal;
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
