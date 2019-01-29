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
    public partial class DodOf : System.Web.UI.Page
    {
        String indexStanowiska;
        String indexDzialu;
        int wybraneStanowisko;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\workspace\PAB-ODK-WebFormCsharp\PAB Obsluga Dzialu Kadr Web\PAB Obsluga Dzialu Kadr Web\App_Data\BazaDanch.mdf;Integrated Security=True");
        SqlCommand Sq;
        DataTable Stanowiska;

        protected void Page_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter("select NAZWA_STANOWISKA, ID_DZIALU, ID_STANOWISKA from STANOWISKA", conn);
            Stanowiska = new DataTable();
            sda.Fill(Stanowiska);
            if (!IsPostBack)
            {
                sda = new SqlDataAdapter("select NAZWA_STANOWISKA, ID_DZIALU, ID_STANOWISKA from STANOWISKA", conn);
                Stanowiska = new DataTable();
                sda.Fill(Stanowiska);

                if (!IsPostBack)
                {
                    divThankYou.Visible = false;
                    int xTabeliO = Stanowiska.Rows.Count;

                    for (int i = 0; i < xTabeliO; i++)
                    {

                        if (DropDownListPodania2.Items.FindByText(Convert.ToString(Stanowiska.Rows[i][0])) == null)
                        {
                            DropDownListPodania2.Items.Add(Convert.ToString(Stanowiska.Rows[i][0]));
                        }
                        else
                        {
                            Boolean check = true;
                            String zmiana = " I";
                            while (check)
                            {
                                if (DropDownListPodania2.Items.FindByText(Convert.ToString(Stanowiska.Rows[i][0]) + zmiana) == null)
                                {
                                    DropDownListPodania2.Items.Add(Convert.ToString(Stanowiska.Rows[i][0] + zmiana));
                                    check = false;
                                }
                                else
                                {
                                    zmiana = zmiana + "I";
                                }
                            }
                        }
                    }

                    sda = new SqlDataAdapter("select NAZWA_DZIALU from DZIAL where ID_DZIALU = '" + indexDzialu + "'", conn);
                    DataTable Dzialy = new DataTable();
                    sda.Fill(Dzialy);

                    TextBoxPodania1.Text = Convert.ToString(Dzialy.Rows[0][0]);
                }
                SprawdzanieSesji();
            }
        }

        protected void SprawdzanieSesji()
        {
            if (Session["INDEXS"] == null)
            {
                indexStanowiska = "0";
            }
            else
            if (Session["INDEXS"] != null)
            {
                indexStanowiska = Session["INDEXS"].ToString();
            }

            if (Session["INDEXD"] == null)
            {
                indexDzialu = "0";
            }
            else
            if (Session["INDEXD"] != null)
            {
                indexDzialu = Session["INDEXD"].ToString();
            }

            if (Session["indexListy"] == null)
            {
                wybraneStanowisko = 0;
            }
            else
            if (Session["indexListy"] != null)
            {

                Int32.TryParse((Session["indexListy"] ?? 0).ToString(), out wybraneStanowisko);
            }
        }

        protected void DropDownListPodania2_SelectedIndexChanged(object sender, EventArgs e)
        {
            wybraneStanowisko = DropDownListPodania2.SelectedIndex;

            sda = new SqlDataAdapter("select NAZWA_DZIALU from DZIAL where ID_DZIALU = '" + Convert.ToString(Stanowiska.Rows[wybraneStanowisko][1]) + "'", conn);
            DataTable Dzialy = new DataTable();
            sda.Fill(Dzialy);

            TextBoxPodania1.Text = Convert.ToString(Dzialy.Rows[0][0]);
            Session["indexListy"] = wybraneStanowisko;
            Session["INDEXS"] = Convert.ToString(Stanowiska.Rows[wybraneStanowisko][2]);
            indexStanowiska = Convert.ToString(Stanowiska.Rows[wybraneStanowisko][2]);
            Session["INDEXD"] = Convert.ToString(Stanowiska.Rows[wybraneStanowisko][1]);
            indexDzialu = Convert.ToString(Stanowiska.Rows[wybraneStanowisko][1]);
        }

        protected void ButtonDodOfW_Click(object sender, EventArgs e)
        {
            Session["StanPaneluAdministratora"] = "3";
            Response.Redirect("~/Admin1.aspx");
        }

        protected void ButtonDodOfD_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("INSERT INTO OFERTY (ID_STANOWISKA, NAZWA_STANOWISKA, OPIS, WYMOGI, WYNAGRODZENIE, DOSTEPNE_MIEJSCA) VALUES ('" + indexStanowiska + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "')", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            ButtonDodOfD.Enabled = false;
            ButtonDodOfW.Enabled = false;

            lblmessage.Text = "Pomyślnie dodano Oferte!";
            divThankYou.Visible = true;
        }

        protected void ButtonPopUp_Click1(object sender, EventArgs e)
        {
            Session["StanPaneluAdministratora"] = "3";
            Response.Redirect("~/Admin1.aspx");
        }
    }
}