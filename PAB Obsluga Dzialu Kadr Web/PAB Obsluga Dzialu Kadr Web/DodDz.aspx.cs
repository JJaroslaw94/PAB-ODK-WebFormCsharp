using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAB_Obsluga_Dzialu_Kadr_Web
{
    public partial class DodDz : System.Web.UI.Page
    {

        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\BazaDanch.mdf;Integrated Security=True");
        SqlCommand Sq;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divThankYou.Visible = false;
            }
                
        }

        protected void ButtonDodawanieDz1_Click(object sender, EventArgs e)
        {
            Session["StanPaneluAdministratora"] = "4";
            Response.Redirect("~/Admin1.aspx");
        }

        protected void ButtonDodawanieDz2_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("INSERT INTO DZIAL (NAZWA_DZIALU) VALUES ('" + TextBox1.Text + "')", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            lblmessage.Text = "Pomyślnie dodano Dział!";
            divThankYou.Visible = true;

            ButtonDodawanieDz1.Enabled = false;
            ButtonDodawanieDz2.Enabled = false;
            
        }

        protected void ButtonPopUp_Click1(object sender, EventArgs e)
        {
            Session["StanPaneluAdministratora"] = "4";
            Response.Redirect("~/Admin1.aspx");
        }
    }
}
