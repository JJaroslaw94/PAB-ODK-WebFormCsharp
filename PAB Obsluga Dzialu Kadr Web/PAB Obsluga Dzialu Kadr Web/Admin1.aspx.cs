using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAB_Obsluga_Dzialu_Kadr_Web
{
    public partial class Admin1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                Response.Cache.SetNoStore();

                String wybranaKarta = Convert.ToString(Session["StanPaneluAdministratora"]);
                
                DivAdminPracownika.Visible = false;
                DivAdminStanowiska.Visible = false;
                DivAdminPodania.Visible = false;
                DivAdminOferty.Visible = false;
                DivAdminDzialu.Visible = false;

                if (wybranaKarta.Equals("0"))
                {
                    DivAdminPracownika.Visible = true;                   
                }
                else
                if (wybranaKarta.Equals("1"))
                {                    
                    DivAdminStanowiska.Visible = true;                   
                }
                else
                if (wybranaKarta.Equals("2"))
                {                    
                    DivAdminPodania.Visible = true;                    
                }
                else
                if (wybranaKarta.Equals("3"))
                {
                    DivAdminOferty.Visible = true;    
                }
                else
                if (wybranaKarta.Equals("4"))
                {                   
                    DivAdminDzialu.Visible = true;
                }



            }
        }

        protected void ButtonAdmin1Nawigacja1_Click(object sender, EventArgs e)
        {
            DivAdminPracownika.Visible = true;
            DivAdminStanowiska.Visible = false;
            DivAdminPodania.Visible = false;
            DivAdminOferty.Visible = false;
            DivAdminDzialu.Visible = false;
        }

        protected void ButtonAdmin1Nawigacja2_Click(object sender, EventArgs e)
        {
            DivAdminPracownika.Visible = false;
            DivAdminStanowiska.Visible = true;
            DivAdminPodania.Visible = false;
            DivAdminOferty.Visible = false;
            DivAdminDzialu.Visible = false;
        }

        protected void ButtonAdmin1Nawigacja3_Click(object sender, EventArgs e)
        {
            DivAdminPracownika.Visible = false;
            DivAdminStanowiska.Visible = false;
            DivAdminPodania.Visible = true;
            DivAdminOferty.Visible = false;
            DivAdminDzialu.Visible = false;
        }

        protected void ButtonAdmin1Nawigacja4_Click(object sender, EventArgs e)
        {
            DivAdminPracownika.Visible = false;
            DivAdminStanowiska.Visible = false;
            DivAdminPodania.Visible = false;
            DivAdminOferty.Visible = true;
            DivAdminDzialu.Visible = false;
        }

        protected void ButtonAdmin1Nawigacja5_Click(object sender, EventArgs e)
        {
            DivAdminPracownika.Visible = false;
            DivAdminStanowiska.Visible = false;
            DivAdminPodania.Visible = false;
            DivAdminOferty.Visible = false;
            DivAdminDzialu.Visible = true;
        }
    }
}