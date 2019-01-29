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
    public partial class Admin1 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\workspace\PAB-ODK-WebFormCsharp\PAB Obsluga Dzialu Kadr Web\PAB Obsluga Dzialu Kadr Web\App_Data\BazaDanch.mdf;Integrated Security=True");
        SqlDataAdapter sda;
        DataTable dtt;


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

                //Pracownicy

                sda = new SqlDataAdapter("select * from PRACOWNICY", conn);
                dtt = new DataTable();
                sda.Fill(dtt);
                DataTable dttbuff;

                DataTable PracownicyT = dtt.Clone();
                PracownicyT.Columns[2].DataType = typeof(String);
                PracownicyT.Columns[1].DataType = typeof(String);

                int xTabeliO = dtt.Rows.Count;

                for (int i = 0; i < xTabeliO; i++)
                {
                    PracownicyT.ImportRow(dtt.Rows[i]);
                    int yTabeli = dtt.Columns.Count;
                    for (int ii = 0; ii < yTabeli; ii++)
                    {
                        if (ii == 1)
                        {
                            sda = new SqlDataAdapter("select NAZWA_STANOWISKA from STANOWISKA where ID_STANOWISKA='" + Convert.ToString(dtt.Rows[i][ii]) + "'", conn);
                            dttbuff = new DataTable();
                            sda.Fill(dttbuff);
                            PracownicyT.Rows[i][ii] = dttbuff.Rows[0][0];
                        }
                        else
                        if (ii == 2)
                        {
                            sda = new SqlDataAdapter("select NAZWA_DZIALU from DZIAL where ID_DZIALU='" + Convert.ToString(dtt.Rows[i][ii]) + "'", conn);
                            dttbuff = new DataTable();
                            sda.Fill(dttbuff);
                            PracownicyT.Rows[i][ii] = dttbuff.Rows[0][0];
                        }
                        else
                            PracownicyT.Rows[i][ii] = dtt.Rows[i][ii];
                    }

                }

                GridViewPrac.DataSource = PracownicyT;
                GridViewPrac.DataBind();

                //Stanowiska

                sda = new SqlDataAdapter("select * from STANOWISKA", conn);
                dtt = new DataTable();
                sda.Fill(dtt);
                

                DataTable StanowiskaT = dtt.Clone();
                
                StanowiskaT.Columns[1].DataType = typeof(String);

                xTabeliO = dtt.Rows.Count;

                for (int i = 0; i < xTabeliO; i++)
                {
                    StanowiskaT.ImportRow(dtt.Rows[i]);
                    int yTabeli = dtt.Columns.Count;
                    for (int ii = 0; ii < yTabeli; ii++)
                    {
                        if (ii == 1)
                        {
                            sda = new SqlDataAdapter("select NAZWA_DZIALU from DZIAL where ID_DZIALU='" + Convert.ToString(dtt.Rows[i][ii]) + "'", conn);
                            DataTable dzial = new DataTable();
                            sda.Fill(dzial);

                            StanowiskaT.Rows[i][ii] = dzial.Rows[0][0];
                        }
                        else { }
                    }

                }

                GridViewStan.DataSource = StanowiskaT;
                GridViewStan.DataBind();

                //Oferty

                sda = new SqlDataAdapter("select * from OFERTY", conn);
                dtt = new DataTable();
                sda.Fill(dtt);

                DataTable OfertyT = dtt.Clone();

                OfertyT.Columns[1].DataType = typeof(String);

                xTabeliO = dtt.Rows.Count;
                for (int i = 0; i < xTabeliO; i++)
                {
                    OfertyT.ImportRow(dtt.Rows[i]);
                    int yTabeli = dtt.Columns.Count;
                    for (int ii = 0; ii < yTabeli; ii++)
                    {
                        if (ii == 1)
                        {
                            sda = new SqlDataAdapter("select NAZWA_STANOWISKA from STANOWISKA where ID_STANOWISKA='" + Convert.ToString(dtt.Rows[i][ii]) + "'", conn);
                            dttbuff = new DataTable();
                            sda.Fill(dttbuff);
                            OfertyT.Rows[i][ii] = dttbuff.Rows[0][0];
                        }
                        else { }
                    }
                }

                GridViewOferty.DataSource = OfertyT;
                GridViewOferty.DataBind();

                //Dzialy

                sda = new SqlDataAdapter("select * from DZIAL", conn);
                dtt = new DataTable();
                sda.Fill(dtt);

                DataTable DzialyT = dtt.Clone();

                xTabeliO = dtt.Rows.Count;
                for (int i = 0; i < xTabeliO; i++)
                {
                    DzialyT.ImportRow(dtt.Rows[i]);
                }

                GridViewDz.DataSource = DzialyT;
                GridViewDz.DataBind();

                //Podania

                sda = new SqlDataAdapter("select * from PODANIA", conn);
                dtt = new DataTable();
                sda.Fill(dtt);


                DataTable PodaniaT = dtt.Clone();

                PodaniaT.Columns[1].DataType = typeof(String);

                PodaniaT.Columns[9].DataType = typeof(String);

                xTabeliO = dtt.Rows.Count;
                for (int i = 0; i < xTabeliO; i++)
                {
                    PodaniaT.ImportRow(dtt.Rows[i]);
                    int yTabeli = dtt.Columns.Count;
                    for (int ii = 0; ii < yTabeli; ii++)
                    {
                        if(ii == 1)
                        {
                            sda = new SqlDataAdapter("select NAZWA_STANOWISKA from STANOWISKA where ID_STANOWISKA='" + Convert.ToString(dtt.Rows[i][ii]) + "'", conn);
                            dttbuff = new DataTable();
                            sda.Fill(dttbuff);
                            PodaniaT.Rows[i][ii] = dttbuff.Rows[0][0];
                        }
                        else
                        if (ii == 9)
                        {
                            if (Convert.ToString(dtt.Rows[i][ii]).Equals("0"))
                            {
                                PodaniaT.Rows[i][ii] = "Nie sprawdzone";
                            }
                            else
                            if (Convert.ToString(dtt.Rows[i][ii]).Equals("1"))
                            {
                                PodaniaT.Rows[i][ii] = "Oczekujące";
                            }
                            else
                            if (Convert.ToString(dtt.Rows[i][ii]).Equals("2"))
                            {
                                PodaniaT.Rows[i][ii] = "Zatwierdzone";
                            }
                        }
                    }
                }
                GridViewPod.DataSource = PodaniaT;
                GridViewPod.DataBind();

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

        protected void ButtonAdminBack1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenu.aspx");
        }

        protected void ButtonDodajPracownika_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DodPr.aspx");
        }

        protected void ButtonDodajStanowisko_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DodSt.aspx");
        }

        protected void ButtonDodajOferte_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DodOf.aspx");
        }

        protected void ButtonDodajDzial_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DodDz.aspx");
        }

        protected void WybranyPracownik_Click(object sender, EventArgs e)
        {
            Session["IDwybrane"] = Convert.ToString((sender as LinkButton).CommandArgument);
            Response.Redirect("~/EdyPr.aspx");
        }

        protected void WybraneStanowisko_Click(object sender, EventArgs e)
        {
            Session["IDwybrane"] = Convert.ToString((sender as LinkButton).CommandArgument);
            Response.Redirect("~/EdySt.aspx");
        }

        protected void WybranePodanie_Click(object sender, EventArgs e)
        {
            Session["IDwybrane"] = Convert.ToString((sender as LinkButton).CommandArgument);
            Response.Redirect("~/EdyPod.aspx");
        }

        protected void WybranaOferta_Click(object sender, EventArgs e)
        {
            Session["IDwybrane"] = Convert.ToString((sender as LinkButton).CommandArgument);
            Response.Redirect("~/EdyOf.aspx");
        }

        protected void WybranyDzial_Click(object sender, EventArgs e)
        {
            Session["IDwybrane"] = Convert.ToString((sender as LinkButton).CommandArgument);
            Response.Redirect("~/EdyDz.aspx");
        }
    }
}