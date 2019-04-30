using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GenerateTexture
{
    public static class ConvertTexture
    {
        public static BitmapSource GifToLongBmp(string LoadFilePath)
        {
            //
            GifBitmapDecoder gifDecoder = new GifBitmapDecoder(new Uri(LoadFilePath, UriKind.Relative), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            //MessageBox.Show(string.Format("{0}", gifDecoder.Frames.Count));
            //
            //берем размер кадра
            BitmapFrame frame0 = gifDecoder.Frames[0];
            int imageWidth = frame0.PixelWidth;
            int imageHeight = frame0.PixelHeight;
            int frameCount = gifDecoder.Frames.Count;
            // компонент для отрисовки всех кадров
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                for (int i = 0; i < gifDecoder.Frames.Count; i++)
                {
                    BitmapFrame frame1 = gifDecoder.Frames[i];
                    drawingContext.DrawImage(frame1, new Rect(i * imageWidth, 0, imageWidth, imageHeight));
                }
            }
            //конверт в BitmapSource
            RenderTargetBitmap bmp = new RenderTargetBitmap(imageWidth * frameCount, imageHeight, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);
            return bmp;
        }

        public static void SaveToPng(BitmapSource Bmp, string SaveFilePath)
        {
            using (var fileStream = new FileStream(SaveFilePath, FileMode.Create))
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(Bmp));
                encoder.Save(fileStream);
            }
        }
    }
}