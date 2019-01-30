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
    public partial class EdySt : System.Web.UI.Page
    {
        String indexDzialu;
        int wybraneStanowisko;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\workspace\PAB-ODK-WebFormCsharp\PAB Obsluga Dzialu Kadr Web\PAB Obsluga Dzialu Kadr Web\App_Data\BazaDanch.mdf;Integrated Security=True");
        SqlCommand Sq;
        DataTable Dzialy;
        DataTable Stanowisko;

        String IDSt;

        protected void Page_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter("select NAZWA_DZIALU, ID_DZIALU from DZIAL", conn);
            Dzialy = new DataTable();
            sda.Fill(Dzialy);

            IDSt = Convert.ToString(Session["IDwybrane"]);

            sda = new SqlDataAdapter("select ID_DZIALU, NAZWA_STANOWISKA, MIEJSCA, UPRAWNIENIA from STANOWISKA where ID_STANOWISKA='" + IDSt + "'", conn);
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

                

                int ileDzialow = Dzialy.Rows.Count;

                for (int i = 0; i < ileDzialow; i++)
                {
                    if (Convert.ToString(Dzialy.Rows[i][1]).Equals(Convert.ToString(Stanowisko.Rows[0][0])))
                    {
                        indexDzialu = Convert.ToString(Dzialy.Rows[i][1]);
                        DropDownListPodania2.SelectedIndex = i;
                    }
                }

                TextBox1.Text = Convert.ToString(Stanowisko.Rows[0][1]);
                TextBox2.Text = Convert.ToString(Stanowisko.Rows[0][2]);
                TextBox3.Text = Convert.ToString(Stanowisko.Rows[0][3]);

            }
            SprawdzanieSesji();
        }

        protected void SprawdzanieSesji()
        {

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
            wybraneStanowisko = DropDownListPodania2.SelectedIndex;
            indexDzialu = Convert.ToString(Dzialy.Rows[wybraneStanowisko][1]);
            Session["INDEXD"] = indexDzialu;
        }

        protected void ButtonDodStW_Click(object sender, EventArgs e)
        {
            Session["StanPaneluAdministratora"] = "1";
            Response.Redirect("~/Admin1.aspx");
        }

        protected void ButtonPopUp_Click1(object sender, EventArgs e)
        {
            Session["StanPaneluAdministratora"] = "1";
            Response.Redirect("~/Admin1.aspx");
        }

        protected void ButtonDodStU_Click(object sender, EventArgs e)
        {
            Boolean mozna = true;
            String trescBledu = "Nie mozna usunac stanowiska " + Stanowisko.Rows[0][1] + " ponieważ: ";

            sda = new SqlDataAdapter("select count(*) from PRACOWNICY where ID_STANOWISKA='" + IDSt + "'", conn);
            DataTable check1 = new DataTable();
            sda.Fill(check1);

            if (Convert.ToString(check1.Rows[0][0]) != "0")
            {
                mozna = false;
                trescBledu = trescBledu + "\nIstnieją jeszcze pracownicy na tym stanowisku";
            }

            sda = new SqlDataAdapter("select count(*) from OFERTY where ID_STANOWISKA='" + IDSt + "'", conn);
            DataTable check2 = new DataTable();
            sda.Fill(check2);

            if (Convert.ToString(check2.Rows[0][0]) != "0")
            {
                mozna = false;
                trescBledu = trescBledu + "\nIstnieją jeszcze oferty na to stanowisko";
            }

            sda = new SqlDataAdapter("select count(*) from Podania where ID_STANOWISKA='" + IDSt + "'", conn);
            DataTable check3 = new DataTable();
            sda.Fill(check3);

            if (Convert.ToString(check3.Rows[0][0]) != "0")
            {
                mozna = false;
                trescBledu = trescBledu + "\nIstnieją jeszcze podania na to stanowisko";
            }

            if (mozna)
            {
                Sq = new SqlCommand("DELETE FROM STANOWISKA WHERE ID_STANOWISKA='" + IDSt + "'", conn);
                conn.Open();
                SqlDataReader SDR = Sq.ExecuteReader();
                conn.Close();

                lblmessage.Text = "Pomyślnie usunięto!";
                divThankYou.Visible = true;


            }
            else
            {
                lblmessage.Text = trescBledu;
                divThankYou.Visible = true;
            }     
        }

        protected void ButtonDodStE_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("UPDATE STANOWISKA set ID_DZIALU='" + indexDzialu + "' , NAZWA_STANOWISKA='" + TextBox1.Text + "', MIEJSCA='" + TextBox2.Text + "', UPRAWNIENIA='" + TextBox3.Text + "' where ID_STANOWISKA='" + IDSt + "'", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            lblmessage.Text = "Pomyślnie wyedytowano!";
            divThankYou.Visible = true;
        }
    }
}