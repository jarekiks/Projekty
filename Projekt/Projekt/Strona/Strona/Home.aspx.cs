using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnAdminLogin_Click(object sender, EventArgs e)
    {
        Session["adminlog"] = 0;
        Response.Redirect("Login.aspx");
    }

    protected void btnDziekanLogin_Click(object sender, EventArgs e)
    {
        Session["dziekanlog"] = 0;
        Response.Redirect("Login.aspx");
    }

    protected void btnUserLogin_Click(object sender, EventArgs e)
    {
        Session["uzytlog"] = 0;
        Response.Redirect("Login.aspx");
    }
}