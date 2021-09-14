using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class WNHS : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=KT-all1;Integrated Security=True");
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            GetPhoneBookRecords();
        if (Session["ULogin"] != null)
        {
            adminvis.Visible = false;
            btnLogin.Visible = false;
            btnRegister.Visible = false;
            btnLogout.Visible = true;
            gvKsiazkaTelefoniczna.Columns[1].Visible = false;
            gvKsiazkaTelefoniczna.Columns[2].Visible = false;
            Session["wnhi1"] = 0;
        }
        else if (Session["Admin"] != null)
        {
            if ((int)Session["Admin"] == 1)
            {
                adminvis.Visible = true;
                btnLogin.Visible = false;
                btnRegister.Visible = true;
                btnLogout.Visible = true;
                gvKsiazkaTelefoniczna.Columns[1].Visible = true;
                gvKsiazkaTelefoniczna.Columns[2].Visible = true;
                masterPageBody.Attributes.CssStyle.Add("background-image", "red-bg.png");
                Session["wnhi1"] = 0;
            }
        }
        else if (Session["Dziekan"] != null)
        {
            if ((int)Session["Dziekan"] == 1)
            {
                dziekanvis.Visible = false;
                btnLogin.Visible = false;
                btnRegister.Visible = false;
                btnLogout.Visible = true;
                gvKsiazkaTelefoniczna.Columns[1].Visible = true;
                gvKsiazkaTelefoniczna.Columns[2].Visible = false;
                masterPageBody.Attributes.CssStyle.Add("background-image", "yell-bg.png");
                Session["wnhi1"] = 0;
            }
        }
        else
        {
            adminvis.Visible = false;
            btnLogin.Visible = true;
            btnRegister.Visible = false;
            btnLogout.Visible = false;
            gvKsiazkaTelefoniczna.Columns[1].Visible = false;
            gvKsiazkaTelefoniczna.Columns[2].Visible = false;
            Session["wnhi1"] = 0;
        }
    }
    private void GetPhoneBookRecords()
    {
        SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=KT-all1;Integrated Security=True");
        SqlCommand cmd = new SqlCommand("Select * from ksiazka_telefoniczna WHERE Wydzial = 'Wydział Nauk Humanistycznych i Informatyki'", con);
        DataTable dt = new DataTable();

        con.Open();

        SqlDataReader sdr = cmd.ExecuteReader();
        dt.Load(sdr);
        con.Close();
        gvKsiazkaTelefoniczna.DataSource = dt;
        gvKsiazkaTelefoniczna.DataBind();
    }

    private void SearchPhoneBookRecords()
    {
        SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=KT-all1;Integrated Security=True");
        if (con.State == ConnectionState.Closed)
            con.Open();
        SqlDataAdapter sqlDa = new SqlDataAdapter("ViewOrSearchWNHI", con);
        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        sqlDa.SelectCommand.Parameters.AddWithValue("@Nazwisko", txtBoxSearch.Text.Trim());
        DataTable dt = new DataTable();
        sqlDa.Fill(dt);
        con.Close();
        gvKsiazkaTelefoniczna.DataSource = dt;
        gvKsiazkaTelefoniczna.DataBind();

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchPhoneBookRecords();
    }

    protected void gvKsiazkaTelefoniczna_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvKsiazkaTelefoniczna_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvKsiazkaTelefoniczna.PageIndex = e.NewPageIndex;
        GetPhoneBookRecords();
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Remove("Dziekan");
        Session.Remove("Admin");
        Session.Remove("ULogin");
        btnLogout.Visible = false;
        Response.Redirect("Home.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Button btnSend = sender as Button;
        GridViewRow row = btnSend.NamingContainer as GridViewRow;
        Session["Row"] = row;
        Session["wnhi"] = "WNHI.aspx";
        Session["wnhi1"] = 0;
        if (Session["Admin"] != null)
        {
            if ((int)Session["Admin"] == 1)
            {
                Response.Redirect("Admin.aspx");
                
            }
        }

        if (Session["Dziekan"] != null)
        {
            if ((int)Session["Dziekan"] == 1)
                Response.Redirect("Dziekan.aspx");
        }

    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {


        Button btnSend = sender as Button;
        GridViewRow row = btnSend.NamingContainer as GridViewRow;
        con.Open();
        cmd.CommandText = "Delete from ksiazka_telefoniczna where id='" + row.Cells[2].Text + "'";
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        con.Close();
        GetPhoneBookRecords();


    }
}