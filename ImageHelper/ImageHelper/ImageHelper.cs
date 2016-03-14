using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ImageHelper
{
    public class ImageUtilities
    {
        public static BitmapImage GetFullImage(Uri fileUri)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = fileUri;
            image.EndInit();
            return image;
        }

        public static BitmapImage GetScaledImage(Uri fileUri)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = fileUri;
            image.DecodePixelWidth = 150;
            image.EndInit();
            return image;
        }

        public static BitmapImage ScaleImageToSize(int newWidth, BitmapImage source)
        {
            // Calculate stride of source
            int stride = source.PixelWidth * (source.Format.BitsPerPixel / 8);

            // Create data array to hold source pixel data
            byte[] data = new byte[stride * source.PixelHeight];

            // Copy source image pixels to the data array
            source.CopyPixels(data, stride, 0);

            // Create WriteableBitmap to copy the pixel data to.      
            WriteableBitmap target = new WriteableBitmap(
              source.PixelWidth,
              source.PixelHeight,
              source.DpiX, source.DpiY,
              source.Format, null);

            // Write the pixel data to the WriteableBitmap.
            target.WritePixels(
              new Int32Rect(0, 0, source.PixelWidth, source.PixelHeight),
              data, stride, 0);

            return ConvertWriteableBitmapToBitmapImage(newWidth, target);
        }

        public static BitmapImage ConvertWriteableBitmapToBitmapImage(int newWidth, WriteableBitmap wbm)
        {
            BitmapImage bmImage = new BitmapImage();
            using (MemoryStream stream = new MemoryStream())
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(wbm));
                encoder.Save(stream);
                bmImage.BeginInit();
                bmImage.CacheOption = BitmapCacheOption.OnLoad;
                bmImage.DecodePixelWidth = newWidth;
                bmImage.StreamSource = stream;
                bmImage.EndInit();
                bmImage.Freeze();
            }
            return bmImage;
        }
    }
}
