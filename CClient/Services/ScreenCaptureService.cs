using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace CClient.Services
{
    public static class ScreenCaptureService
    {
        public static byte[] CaptureScreen()
        {
            Rectangle bounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            using Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
            }

            using MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Jpeg);

            return ms.ToArray();
        }
    }
}
