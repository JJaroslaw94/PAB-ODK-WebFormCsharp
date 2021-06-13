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
    public partial class DodSt : System.Web.UI.Page
    {
        
        String indexDzialu;
        int wybraneStanowisko;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\BazaDanch.mdf;Integrated Security=True");
        SqlCommand Sq;
        DataTable Dzialy;



        protected void Page_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter("select NAZWA_DZIALU from DZIAL", conn);
            Dzialy = new DataTable();
            sda.Fill(Dzialy);

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
            indexDzialu = Convert.ToString(Dzialy.Rows[wybraneStanowisko][0]);
            Session["INDEXD"] = indexDzialu;
        }

        protected void ButtonDodStD_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("INSERT INTO STANOWISKA (ID_DZIALU, NAZWA_STANOWISKA, MIEJSCA, UPRAWNIENIA) VALUES ('" + indexDzialu + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            ButtonDodStD.Enabled = false;
            ButtonDodStW.Enabled = false;

            lblmessage.Text = "Dodano Stanowisko!";
            divThankYou.Visible = true;
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
    }
}
