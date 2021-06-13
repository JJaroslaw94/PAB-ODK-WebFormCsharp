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
    public partial class PisaniePodaniaGoscia : System.Web.UI.Page
    {

        String indexStanowiska;
        String indexDzialu;
        int wybraneStanowisko;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\BazaDanch.mdf;Integrated Security=True");
        SqlCommand Sq;
        DataTable Stanowiska;

        protected void Page_Load(object sender, EventArgs e)
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

                    if    (DropDownListPodania1.Items.FindByText(Convert.ToString(Stanowiska.Rows[i][0])) == null)
                    {
                        DropDownListPodania1.Items.Add(Convert.ToString(Stanowiska.Rows[i][0]));
                    }else
                    {
                        Boolean check = true;
                        String zmiana = " I";
                        while (check)
                        {
                            if (DropDownListPodania1.Items.FindByText(Convert.ToString(Stanowiska.Rows[i][0]) + zmiana) == null)
                            {
                                DropDownListPodania1.Items.Add(Convert.ToString(Stanowiska.Rows[i][0] + zmiana));
                                check = false;
                            }else
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

        protected void Button11_Click(object sender, EventArgs e)
        {
            Session["INDEXS"] = null;
            Session["INDEXD"] = null;
            Session["indexListy"] = null;

            Response.Redirect("~/OfertyDlaGoscia.aspx");
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            Session["INDEXS"] = null;
            Session["INDEXD"] = null;
            Session["indexListy"] = null;

            //Zapis do SQL

            DateTime czas = DateTime.Now;
            String czasPoConv = czas.Month + "." + czas.Day + "." + czas.Year;

            Sq = new SqlCommand("INSERT INTO PODANIA (ID_STANOWISKA, IMIE_PRACOWNIKA, NAZWISKO_PRACOWNIKA, WIEK, RODZAJ_WYKSZTALCENIA, MIEJSCE_ZAMIESZKANIA, DLUGOSC_STAZU, DATA_OTRZYMANIA, STAN, TELEFON) VALUES ('" + Convert.ToString(indexStanowiska) + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + czasPoConv + "','0','" + TextBox8.Text + "')", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            divThankYou.Visible = true;
            lblmessage.Text = " Podanie wysłano, Dziękujemy! ";
            Button11.Enabled = false;
            Button12.Enabled = false;
        }

        protected void DropDownListPodania1_SelectedIndexChanged(object sender, EventArgs e)
        {
            wybraneStanowisko = DropDownListPodania1.SelectedIndex;

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

        protected void ButtonExit_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenu.aspx");
        }
    }
}
