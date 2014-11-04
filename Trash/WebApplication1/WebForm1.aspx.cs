using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO.Compression;
using XMLSoccerCOM.DemoService;
using XMLSoccerCOM;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private const string API_KEY = "PWGWJJKBSTZMDKKYTCEGKKGCFVVVTZEJVWSHAFVXBWJLOOVBGA";

        protected void Page_Load(object sender, EventArgs e)
        {
            Requester req = new Requester(API_KEY, false);
            

            

            var fixtures = req.GetFixturesByLeagueAndSeason("Scottish Premier League", 2014);
            this.GridViewSoccer.DataSource = fixtures;
            this.GridViewSoccer.DataBind();
        }

        
    }
}