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
    public partial class EdyPr : System.Web.UI.Page
    {
        String indexDzialu = "0";
        String indexStanowiska = "0";
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\BazaDanch.mdf;Integrated Security=True");
        SqlCommand Sq;
        DataTable Dzialy;
        DataTable Stanowisko;

        String IDPr;

        protected void Page_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter("select NAZWA_DZIALU, ID_DZIALU from DZIAL", conn);
            Dzialy = new DataTable();
            sda.Fill(Dzialy);

            sda = new SqlDataAdapter("select NAZWA_STANOWISKA, ID_STANOWISKA from STANOWISKA", conn);
            Stanowisko = new DataTable();
            sda.Fill(Stanowisko);

            IDPr = Convert.ToString(Session["IDwybrane"]);

            if (!IsPostBack)
            {
                divThankYou.Visible = false;
                int xTabeliO = Dzialy.Rows.Count;

                for (int i = 0; i < xTabeliO; i++)
                {

                    if (DropDownListPodania2.Items.FindByText(Convert.ToString(Dzialy.Rows[i][0])) == null)
                    {
                        DropDownListPodania2.Items.Add(Convert.ToString(Dzialy.Rows[i][0]));
                    }
                    else
                    {
                        Boolean check = true;
                        String zmiana = " I";
                        while (check)
                        {
                            if (DropDownListPodania2.Items.FindByText(Convert.ToString(Dzialy.Rows[i][0]) + zmiana) == null)
                            {
                                DropDownListPodania2.Items.Add(Convert.ToString(Dzialy.Rows[i][0] + zmiana));
                                check = false;
                            }
                            else
                            {
                                zmiana = zmiana + "I";
                            }
                        }
                    }
                }

                xTabeliO = Stanowisko.Rows.Count;

                for (int i = 0; i < xTabeliO; i++)
                {

                    if (DropDownList1.Items.FindByText(Convert.ToString(Stanowisko.Rows[i][0])) == null)
                    {
                        DropDownList1.Items.Add(Convert.ToString(Stanowisko.Rows[i][0]));
                    }
                    else
                    {
                        Boolean check = true;
                        String zmiana = " I";
                        while (check)
                        {
                            if (DropDownList1.Items.FindByText(Convert.ToString(Stanowisko.Rows[i][0]) + zmiana) == null)
                            {
                                DropDownList1.Items.Add(Convert.ToString(Stanowisko.Rows[i][0] + zmiana));
                                check = false;
                            }
                            else
                            {
                                zmiana = zmiana + "I";
                            }
                        }
                    }
                }

                sda = new SqlDataAdapter("select ID_PRACOWNIKA, ID_STANOWISKA, ID_DZIALU, IMIE_PRACOWNIKA, NAZWISKO_PRACOWNIKA, E_MAIL_PRACOWNIKA, HASLO_PRACOWNIKA from PRACOWNICY where ID_PRACOWNIKA ='" + IDPr + "'", conn);
                DataTable Pracownicy = new DataTable();
                sda.Fill(Pracownicy);


                for (int i = 0; i < Stanowisko.Rows.Count; i++)
                {
                    if (Convert.ToString(Stanowisko.Rows[i][1]).Equals(Convert.ToString(Pracownicy.Rows[0][1])))
                    {
                        DropDownListPodania2.SelectedIndex = i;
                        indexStanowiska = Convert.ToString(Stanowisko.Rows[i][1]);
                        Session["INDEXS"] = indexStanowiska;
                    }
                }


                for (int i = 0; i < Dzialy.Rows.Count; i++)
                {
                    if (Convert.ToString(Dzialy.Rows[i][1]).Equals(Convert.ToString(Pracownicy.Rows[0][2])))
                    {
                        indexDzialu = Convert.ToString(Dzialy.Rows[i][1]);
                        DropDownList1.SelectedIndex = i;
                        Session["INDEXD"] = indexDzialu;
                    }
                }

                TextBox1.Text = Convert.ToString(Pracownicy.Rows[0][3]);
                TextBox2.Text = Convert.ToString(Pracownicy.Rows[0][4]);
                TextBox3.Text = Convert.ToString(Pracownicy.Rows[0][5]);
                TextBox4.Text = Convert.ToString(Pracownicy.Rows[0][6]);

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
        }
        protected void ButtonDodPrW_Click(object sender, EventArgs e)
        {
            Session["StanPaneluAdministratora"] = "0";
            Response.Redirect("~/Admin1.aspx");
        }

        protected void ButtonDodPrU_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("DELETE FROM PRACOWNICY WHERE ID_PRACOWNIKA='" + IDPr + "'", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            ButtonEdy.Enabled = false;
            ButtonDodPrW.Enabled = false;
            ButtonDodPrU.Enabled = false;

            lblmessage.Text = "Pomyślnie usunięto!";
            divThankYou.Visible = true;
        }

        protected void ButtonEdy_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("UPDATE PRACOWNICY set ID_STANOWISKA='" + indexStanowiska + "', ID_DZIALU='" + indexDzialu + "', IMIE_PRACOWNIKA='" + TextBox1.Text + "', NAZWISKO_PRACOWNIKA='" + TextBox2.Text + "', E_MAIL_PRACOWNIKA='" + TextBox3.Text + "', HASLO_PRACOWNIKA='" + TextBox4.Text + "' where ID_PRACOWNIKA='" + IDPr + "'", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            ButtonEdy.Enabled = false;
            ButtonDodPrW.Enabled = false;
            ButtonDodPrU.Enabled = false;

            lblmessage.Text = "Pomyślnie edytowano!";
            divThankYou.Visible = true;
        }

        protected void ButtonPopUp_Click1(object sender, EventArgs e)
        {
            Session["StanPaneluAdministratora"] = "0";
            Response.Redirect("~/Admin1.aspx");
        }

        protected void DropDownListPodania2_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexDzialu = Convert.ToString(Dzialy.Rows[DropDownListPodania2.SelectedIndex][1]);
            Session["INDEXD"] = indexDzialu;
        }

        protected void DropDownListPodania3_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexStanowiska = Convert.ToString(Stanowisko.Rows[DropDownList1.SelectedIndex][1]);
            Session["INDEXS"] = indexStanowiska;
        }
    }
}
