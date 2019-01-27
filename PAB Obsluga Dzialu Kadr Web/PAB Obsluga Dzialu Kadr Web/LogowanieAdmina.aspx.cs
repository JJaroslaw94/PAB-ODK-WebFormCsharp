using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAB_Obsluga_Dzialu_Kadr_Web
{
    public partial class LogowanieAdmina : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["User"] = null;
                divThankYou.Visible = false;
                divFailAut1.Visible = false;
                divFailAut2.Visible = false;
            }

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
        }

        protected void ButtonLogowanieWstecz_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenu.aspx");
        }

        protected void ButtonLogowanieLogin_Click(object sender, EventArgs e)
        {
            ButtonLogowanieLogin.Enabled = false;
            ButtonLogowanieWstecz.Enabled = false;

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\workspace\PAB-ODK-WebFormCsharp\PAB Obsluga Dzialu Kadr Web\PAB Obsluga Dzialu Kadr Web\App_Data\BazaDanch.mdf;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from STANOWISKA INNER JOIN PRACOWNICY ON STANOWISKA.ID_STANOWISKA = PRACOWNICY.ID_STANOWISKA where CONVERT(VARCHAR, PRACOWNICY.E_MAIL_PRACOWNIKA)  ='" + TextBoxLogowanie1.Text + "' and CONVERT(VARCHAR, PRACOWNICY.HASLO_PRACOWNIKA)='" + TextBoxLogowanie2.Text + "' and CONVERT(VARCHAR, STANOWISKA.UPRAWNIENIA) ='Administrator'", conn);
            DataTable dtt = new DataTable();
            sda.Fill(dtt);
            
            if (dtt.Rows[0][0].ToString() == "1")
            {
                sda = new SqlDataAdapter("select IMIE_PRACOWNIKA, NAZWISKO_PRACOWNIKA from PRACOWNICY where CONVERT(VARCHAR, PRACOWNICY.E_MAIL_PRACOWNIKA)  ='" + TextBoxLogowanie1.Text + "' and CONVERT(VARCHAR, PRACOWNICY.HASLO_PRACOWNIKA)='" + TextBoxLogowanie2.Text+"'", conn);
                DataTable dttt = new DataTable();
                sda.Fill(dttt);

                lblmessage.Text = "Witamy " + dttt.Rows[0][0] + " " + dttt.Rows[0][1];
                Session["User"] = " " + TextBoxLogowanie1.Text + " " + TextBoxLogowanie2.Text + " ";
                Session["StanPaneluAdministratora"] = "0";
                divThankYou.Visible = true;
            }   
            else
            {
                sda = new SqlDataAdapter("select count(*) from STANOWISKA INNER JOIN PRACOWNICY ON STANOWISKA.ID_STANOWISKA = PRACOWNICY.ID_STANOWISKA where CONVERT(VARCHAR, PRACOWNICY.E_MAIL_PRACOWNIKA)  ='" + TextBoxLogowanie1.Text + "' and CONVERT(VARCHAR, PRACOWNICY.HASLO_PRACOWNIKA)='" + TextBoxLogowanie2.Text + "'", conn);
                dtt = new DataTable();
                sda.Fill(dtt);
                if (dtt.Rows[0][0].ToString() == "1")
                {
                    Labelfailaut1.Text = " Przepraszamy! Nie posiadasz uprawnień administratora ";
                    divFailAut1.Visible = true;                    
                }
                else
                {
                    Labelfailaut1.Text = " Przepraszamy! Błędne Hasło lub E-mail ";
                    divFailAut1.Visible = true;
                }
            }
        }

        protected void ButtonPopUp1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin1.aspx");
        }

        protected void ButtonPopUp2_Click1(object sender, EventArgs e)
        {
            ButtonLogowanieLogin.Enabled = true;
            ButtonLogowanieWstecz.Enabled = true;
            divFailAut1.Visible = false;
        }

        protected void ButtonPopUp3_Click1(object sender, EventArgs e)
        {
            ButtonLogowanieLogin.Enabled = true;
            ButtonLogowanieWstecz.Enabled = true;
            divFailAut2.Visible = false;
        }
    }
}