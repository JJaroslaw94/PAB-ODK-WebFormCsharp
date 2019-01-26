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
    public partial class OfertyDlaGoscia : System.Web.UI.Page
    {
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\workspace\PAB-ODK-WebFormCsharp\PAB Obsluga Dzialu Kadr Web\PAB Obsluga Dzialu Kadr Web\App_Data\BazaDanch.mdf;Integrated Security=True");

        List<String> StanowiskaL = new List<String>();
        List<String> OpisL = new List<String>();
        List<String> WymaganiaL = new List<String>();
        List<String> WynagrodzenieL = new List<String>();
        List<String> MiejscaL = new List<String>();

        int indexL;
        int maxIndex;

        protected void Page_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter("select NAZWA_STANOWISKA, OPIS, WYMOGI, WYNAGRODZENIE, DOSTEPNE_MIEJSCA from OFERTY", conn);
            DataTable Oferty = new DataTable();
            sda.Fill(Oferty);

            if (Session["INDEXL"]== null)
            {
                indexL = 0;
            }else
            if (Session["INDEXL"] != null)
            {
                Int32.TryParse((Session["INDEXL"] ?? 0).ToString(), out indexL);
            }
            
            

            int xTabeliO = Oferty.Rows.Count;

            for (int i = 0; i < xTabeliO; i++)
            {
                int yTabeli = Oferty.Columns.Count;
                for (int ii = 0; ii < yTabeli + 1; ii++)
                {
                    if(ii == 0)
                    {
                        StanowiskaL.Add(Convert.ToString(Oferty.Rows[i][ii]));
                    }else
                    if(ii == 1)
                    {
                        OpisL.Add(Convert.ToString(Oferty.Rows[i][ii]));
                    }else
                    if(ii == 2)
                    {
                        WymaganiaL.Add(Convert.ToString(Oferty.Rows[i][ii]));
                    }else
                    if (ii == 3)
                    {
                        WynagrodzenieL.Add(Convert.ToString(Oferty.Rows[i][ii]));
                    }
                    if (ii == 4)
                    {
                        MiejscaL.Add(Convert.ToString(Oferty.Rows[i][ii]));
                    }
                }

            }

            maxIndex = StanowiskaL.Count();

            TextBox1.Text = StanowiskaL[indexL];
            TextBox2.Text = OpisL[indexL];
            TextBox3.Text = WymaganiaL[indexL];
            TextBox4.Text = WynagrodzenieL[indexL];
            TextBox5.Text = MiejscaL[indexL];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (indexL == 0)
            {
                indexL = maxIndex-1;
            }else
            {
                indexL--;
            }

            Session["INDEXL"] = indexL;

            TextBox1.Text = StanowiskaL[indexL];
            TextBox2.Text = OpisL[indexL];
            TextBox3.Text = WymaganiaL[indexL];
            TextBox4.Text = WynagrodzenieL[indexL];
            TextBox5.Text = MiejscaL[indexL];
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (indexL >= maxIndex-1)
            {
                indexL = 0;
            }
            else
            {
                indexL++;
            }

            Session["INDEXL"] = indexL;

            TextBox1.Text = StanowiskaL[indexL];
            TextBox2.Text = OpisL[indexL];
            TextBox3.Text = WymaganiaL[indexL];
            TextBox4.Text = WynagrodzenieL[indexL];
            TextBox5.Text = MiejscaL[indexL];
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["INDEXL"] = null;
            Response.Redirect("~/PisaniePodaniaGoscia.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session["INDEXL"] = null;
            Response.Redirect("~/MainMenu.aspx");
        }
    }
}