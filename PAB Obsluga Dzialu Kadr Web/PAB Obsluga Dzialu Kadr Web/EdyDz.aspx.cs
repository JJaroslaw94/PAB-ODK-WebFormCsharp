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
    public partial class EdyDz : System.Web.UI.Page
    {
        String IDdz;

        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\workspace\PAB-ODK-WebFormCsharp\PAB Obsluga Dzialu Kadr Web\PAB Obsluga Dzialu Kadr Web\App_Data\BazaDanch.mdf;Integrated Security=True");
        SqlCommand Sq;
        DataTable Dtt;

        protected void Page_Load(object sender, EventArgs e)
        {
            IDdz = Convert.ToString(Session["IDwybrane"]);
            if (!IsPostBack)
            {
                divThankYou1.Visible = false;
                divThankYou2.Visible = false;

                IDdz = Convert.ToString(Session["IDwybrane"]);

                sda = new SqlDataAdapter("select NAZWA_DZIALU from DZIAL where ID_DZIALU='"+ IDdz + "'", conn);
                Dtt = new DataTable();
                sda.Fill(Dtt);

                TextBox1.Text = Convert.ToString(Dtt.Rows[0][0]);
            }
        }

        protected void ButtonDodawanieDz1_Click(object sender, EventArgs e)
        {
            Session["StanPaneluAdministratora"] = "4";
            Response.Redirect("~/Admin1.aspx");
        }

        protected void ButtonUsuwanieDz1_Click(object sender, EventArgs e)
        {
            Boolean mozna = true;
            String trescBledu = "Nie mozna usunac dzialu " + TextBox1.Text + " ponieważ: ";

            sda = new SqlDataAdapter("select count(*) from PRACOWNICY where ID_DZIALU='" + IDdz + "'", conn);
            DataTable check1 = new DataTable();
            sda.Fill(check1);

            if (Convert.ToString(check1.Rows[0][0]) != "0")
            {
                mozna = false;
                trescBledu = trescBledu + "\nIstnieją jeszcze pracownicy w tym dziale";
            }

            sda = new SqlDataAdapter("select count(*) from STANOWISKA where ID_DZIALU='" + IDdz + "'", conn);
            DataTable check2 = new DataTable();
            sda.Fill(check2);

            if (Convert.ToString(check2.Rows[0][0]) != "0")
            {
                mozna = false;
                trescBledu = trescBledu + "\nIstnieją jeszcze stanowiska w tym dziale";
            }

            if (mozna)
            {
                Sq = new SqlCommand("DELETE FROM DZIAL WHERE ID_DZIALU='" + IDdz + "'", conn);
                conn.Open();
                SqlDataReader SDR = Sq.ExecuteReader();
                conn.Close();

                lblmessage2.Text = "Pomyślnie usunięto Dział!";
                divThankYou2.Visible = true;

                ButtonDodawanieDz1.Enabled = false;
                ButtonUsuwanieDz1.Enabled = false;
                ButtonDodawanieDz2.Enabled = false;
            }
            else
            {
                lblmessage2.Text = trescBledu;
                divThankYou2.Visible = true;

                ButtonDodawanieDz1.Enabled = false;
                ButtonUsuwanieDz1.Enabled = false;
                ButtonDodawanieDz2.Enabled = false;
            }

            


        }

        protected void ButtonDodawanieDz2_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("UPDATE DZIAL set NAZWA_DZIALU='" + TextBox1.Text + "' where ID_DZIALU='" + IDdz + "'", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            lblmessage1.Text = "Pomyślnie edytowano Dział!";
            divThankYou1.Visible = true;

            ButtonDodawanieDz1.Enabled = false;
            ButtonUsuwanieDz1.Enabled = false;
            ButtonDodawanieDz2.Enabled = false;
        }

        protected void ButtonPopUp_Click1(object sender, EventArgs e)
        {
            Session["StanPaneluAdministratora"] = "4";
            Response.Redirect("~/Admin1.aspx");
        }
    }
}