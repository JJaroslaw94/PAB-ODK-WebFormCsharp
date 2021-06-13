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
    public partial class EdyPod : System.Web.UI.Page
    {
        String IDdz;

        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\BazaDanch.mdf;Integrated Security=True");
        SqlCommand Sq;
        DataTable Dtt;

        protected void Page_Load(object sender, EventArgs e)
        {
            IDdz = Convert.ToString(Session["IDwybrane"]);
            if (!IsPostBack)
            {
                divThankYou.Visible = false;

                sda = new SqlDataAdapter("select ID_PODANIA, ID_STANOWISKA, IMIE_PRACOWNIKA, NAZWISKO_PRACOWNIKA, WIEK, RODZAJ_WYKSZTALCENIA, MIEJSCE_ZAMIESZKANIA, DLUGOSC_STAZU, DATA_OTRZYMANIA, STAN, TELEFON from PODANIA where ID_PODANIA='" + IDdz + "'", conn);
                DataTable Podania = new DataTable();
                sda.Fill(Podania);

                sda = new SqlDataAdapter("select NAZWA_STANOWISKA, ID_DZIALU from STANOWISKA where ID_STANOWISKA ='" + Convert.ToString(Podania.Rows[0][1]) + "'", conn);
                DataTable stan = new DataTable();
                sda.Fill(stan);

                

                

                TextBox1.Text = Convert.ToString(stan.Rows[0][0]);

                TextBox2.Text = Convert.ToString(Podania.Rows[0][2]);
                TextBox3.Text = Convert.ToString(Podania.Rows[0][3]);
                TextBox4.Text = Convert.ToString(Podania.Rows[0][4]);
                TextBox5.Text = Convert.ToString(Podania.Rows[0][5]);
                TextBox6.Text = Convert.ToString(Podania.Rows[0][6]);
                TextBox7.Text = Convert.ToString(Podania.Rows[0][7]);
                TextBox8.Text = Convert.ToString(Podania.Rows[0][8]);

                if (Convert.ToString(Podania.Rows[0][9]).Equals("0"))
                {
                    TextBox9.Text = "Nie sprawdzone";
                }
                if (Convert.ToString(Podania.Rows[0][9]).Equals("1"))
                {
                    TextBox9.Text = "Odłożone";
                }
                if (Convert.ToString(Podania.Rows[0][9]).Equals("2"))
                {
                    TextBox9.Text = "Zaakceptowane";
                }

                TextBox10.Text = Convert.ToString(Podania.Rows[0][10]);

                TextBox1.Enabled = false;
                TextBox1.CssClass = "CentrowanePrawe";
                TextBox2.Enabled = false;
                TextBox2.CssClass = "CentrowanePrawe";
                TextBox3.Enabled = false;
                TextBox3.CssClass = "CentrowanePrawe";
                TextBox4.Enabled = false;
                TextBox4.CssClass = "CentrowanePrawe";
                TextBox5.Enabled = false;
                TextBox5.CssClass = "CentrowanePrawe";
                TextBox6.Enabled = false;
                TextBox6.CssClass = "CentrowanePrawe";
                TextBox7.Enabled = false;
                TextBox7.CssClass = "CentrowanePrawe";
                TextBox8.Enabled = false;
                TextBox8.CssClass = "CentrowanePrawe";
                TextBox9.Enabled = false;
                TextBox9.CssClass = "CentrowanePrawe";
                TextBox10.Enabled = false;
                TextBox10.CssClass = "CentrowanePrawe";


            }
        }

        protected void ButtonPodWroc_Click(object sender, EventArgs e)
        {
            Session["StanPaneluAdministratora"] = "2";
            Response.Redirect("~/Admin1.aspx");
        }

        protected void ButtonPodOcz_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("UPDATE PODANIA set STAN='1' where ID_PODANIA='" + IDdz + "'", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            lblmessage.Text = "Odłożono podanie!";
            divThankYou.Visible = true;
        }

        protected void ButtonPodAkc_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("UPDATE PODANIA set STAN='2' where ID_PODANIA='" + IDdz + "'", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            lblmessage.Text = "Zaakceptowano podanie!";
            divThankYou.Visible = true;
        }

        protected void ButtonPodUsu_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("DELETE FROM PODANIA WHERE ID_PODANIA='" + IDdz + "'", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            lblmessage.Text = "Usunięto podanie!";
            divThankYou.Visible = true;
        }

        protected void ButtonPopUp_Click1(object sender, EventArgs e)
        {
            Session["StanPaneluAdministratora"] = "2";
            Response.Redirect("~/Admin1.aspx");
        }
    }
}
