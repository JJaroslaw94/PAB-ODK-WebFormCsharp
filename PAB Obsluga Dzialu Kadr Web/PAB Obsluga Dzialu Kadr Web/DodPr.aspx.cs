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
    public partial class DodPr : System.Web.UI.Page
    {
        String indexDzialu = "0";
        String indexStanowiska = "0";
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\workspace\PAB-ODK-WebFormCsharp\PAB Obsluga Dzialu Kadr Web\PAB Obsluga Dzialu Kadr Web\App_Data\BazaDanch.mdf;Integrated Security=True");
        SqlCommand Sq;
        DataTable Dzialy;
        DataTable Stanowisko;

        protected void Page_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter("select NAZWA_DZIALU, ID_DZIALU from DZIAL", conn);
            Dzialy = new DataTable();
            sda.Fill(Dzialy);

            sda = new SqlDataAdapter("select NAZWA_STANOWISKA, ID_STANOWISKA from STANOWISKA", conn);
            Stanowisko = new DataTable();
            sda.Fill(Stanowisko);

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

        protected void ButtonDodPrW_Click(object sender, EventArgs e)
        {
            Session["StanPaneluAdministratora"] = "0";
            Response.Redirect("~/Admin1.aspx");
        }

        protected void ButtonPopUp_Click1(object sender, EventArgs e)
        {
            Session["StanPaneluAdministratora"] = "0";
            Response.Redirect("~/Admin1.aspx");
        }

        protected void ButtonDodPrD_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("INSERT INTO PRACOWNICY (ID_STANOWISKA, ID_DZIALU, IMIE_PRACOWNIKA, NAZWISKO_PRACOWNIKA, E_MAIL_PRACOWNIKA, HASLO_PRACOWNIKA) VALUES ('" + indexStanowiska + "','" + indexDzialu + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();


            ButtonDodPrD.Enabled = false;
            ButtonDodPrW.Enabled = false;

            lblmessage.Text = "Pomyślnie Dodano!";
            divThankYou.Visible = true;
        }
    }
}