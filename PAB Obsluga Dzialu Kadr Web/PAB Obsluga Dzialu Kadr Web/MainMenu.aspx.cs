using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAB_Obsluga_Dzialu_Kadr_Web
{
    public partial class MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonMenu1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LogowanieAdmina.aspx");
        }

        protected void ButtonMenu2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/OfertyDlaGoscia.aspx");
        }
    }
}