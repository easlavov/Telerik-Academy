namespace _03.CustomHandler.App_Code
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Web;

    public class ImgHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {            
            string url = context.Request.Url.ToString();
            string text = GetText(url);
            PrintImage(text, context);
        }

        private void PrintImage(string text, HttpContext context)
        {
            var path = context.Server.MapPath("Images/image.png");
            var bitmap = new Bitmap(path);
            var graphics = Graphics.FromImage(bitmap);
            var brush = new SolidBrush(Color.LightSkyBlue);
            graphics.FillRectangle(brush, 0, 0, 5000, 600);
            graphics.DrawString(
                text,
                new Font("Verdana", 40),
                new SolidBrush(Color.OrangeRed),
                new PointF(25, 40));
            context.Response.ContentType = "image/png";
            bitmap.Save(context.Response.OutputStream, ImageFormat.Png);
        }

        private string GetText(string url)
        {
            int indexOfLastSlash = url.LastIndexOf('/');
            int indexOfLastDot = url.LastIndexOf('.');
            int length = indexOfLastDot - indexOfLastSlash - 1;
            string text = url.Substring(indexOfLastSlash + 1, length);
            return text;
        }
    }
}