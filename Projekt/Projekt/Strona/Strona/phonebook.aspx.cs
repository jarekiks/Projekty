using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.HtmlControls;

public partial class phonebook : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        GetPhoneBookRecords();
        if (Session["ULogin"] != null)
        {
            btnLogin.Visible = false;
            btnRegister.Visible = false;
            adminvis.Visible = false;
            btnLogout.Visible = true;
            Session.Remove("wnhi1");
            Session.Remove("wns1");
            Session.Remove("wnz1");
        }
        else if (Session["Admin"] != null)
        {
            if ((int)Session["Admin"] == 1)
            {
                adminvis.Visible = true;
                btnLogin.Visible = false;
                btnRegister.Visible = true;
                btnLogout.Visible = true;
                masterPageBody.Attributes.CssStyle.Add("background-image", "red-bg.png");
                Session.Remove("wnhi1");
                Session.Remove("wns1");
                Session.Remove("wnz1");
            }
            
        }
        else if(Session["Dziekan"] != null)
        {
            if ((int)Session["Dziekan"] == 1)
            {

                dziekanvis.Visible = false;
                btnLogin.Visible = false;
                btnRegister.Visible = false;
                btnLogout.Visible = true;
                masterPageBody.Attributes.CssStyle.Add("background-image", "yell-bg.png");
                Session.Remove("wnhi1");
                Session.Remove("wns1");
                Session.Remove("wnz1");
            }
        }
        else
        {
            adminvis.Visible = false;
            btnLogin.Visible = true;
            btnRegister.Visible = true;
            btnLogout.Visible = false;
            Session.Remove("wnhi1");
            Session.Remove("wns1");
            Session.Remove("wnz1");
        }
    }

    private void GetPhoneBookRecords()
    {
        SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=KT-all1;Integrated Security=True");
        SqlCommand cmd = new SqlCommand("Select * from ksiazka_telefoniczna", con);
        DataTable dt = new DataTable();

        con.Open();

        SqlDataReader sdr = cmd.ExecuteReader();
        dt.Load(sdr);
        con.Close();
        
    }


    protected void gvKsiazkaTelefoniczna_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Remove("Dziekan");
        Session.Remove("Admin");
        Session.Remove("ULogin");
        btnLogout.Visible = false;
        Response.Redirect("Home.aspx");
    }
}