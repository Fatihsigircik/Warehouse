using DatabaseServer.Models;
using Extension;
using System;
using System.IO;
using System.Linq;

namespace DatabaseServer
{
    public static class ImageManager
    {
        private const string ImageFolder = @"D:\SimpleWarehouseImages";

        //internal static ProductImage ToProductImage(WebImage webImage)
        //{
        //    return new ProductImage
        //    {
        //        ProductImageId = webImage.ProductImageId,
        //        ProductId = webImage.ProductId,
        //        LineNumber = webImage.LineNumber,
        //        IsDefault = webImage.IsDefault
        //    };
        //}

        internal static string GetImage(string path)
        {
            //path = @"D:\SimpleWarehouseImages\code3\code3_1.jpg";
            try
            {
                return Convert.ToBase64String(File.ReadAllBytes(path));
            }
            catch
            {
                return null;
            }
        }

        internal static string GetImageFileName(WebImage webImage)
        {
            var lastNumber = 0;
            var path = Path.Combine(ImageFolder, webImage.ProductCode);
            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    var number = Path.GetFileName(file).Split('_').Last().Split('.')[0].ToInt();
                    if (number > lastNumber)
                        lastNumber = number;
                }
            }
            else
                Directory.CreateDirectory(path);
            return $"{webImage.ProductCode}_{++lastNumber}.jpg";
        }

        internal static string CreateImage(WebImage webImage)
        {
            try
            {
                var path = Path.Combine(ImageFolder, webImage.ProductCode, GetImageFileName(webImage));
                File.WriteAllBytes(path, Convert.FromBase64String(webImage.Base64String));
                return path;
            }
            catch
            {
                return null;
            }
        }
    }
}