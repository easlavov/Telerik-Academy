using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.VisitorsCounter
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Application["visitors"] == null)
            {
                this.Application["visitors"] = 1;
            }
            else
            {
                int count = int.Parse(this.Application["visitors"].ToString());
                count++;
                this.Application["visitors"] = count;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            string count = this.Application["visitors"].ToString();
            PrintImage(count, Context);
        }

        private void PrintImage(string text, HttpContext context)
        {
            var path = context.Server.MapPath("img/image.jpg");
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
            bitmap.Save(context.Response.OutputStream, ImageFormat.Jpeg);
        }
    }
}