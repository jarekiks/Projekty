using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["adminlog"] != null)
        {
            masterPageBody.Attributes.CssStyle.Add("background-image", "red-bg.png");
            Session.Remove("adminlog");
        }
        else if(Session["dziekanlog"] != null)
        {
            masterPageBody.Attributes.CssStyle.Add("background-image", "yell-bg.png");
            Session.Remove("dziekanlog");
        }
        else if(Session["uzytlog"] != null)
        {
            masterPageBody.Attributes.CssStyle.Add("background-image", "bckgrnd.png");
            Session.Remove("uzytlog");
        }
        else
        {
            masterPageBody.Attributes.CssStyle.Add("background-image", "bckgrnd.png");
        }


        
        if (Session["ULogin"] != null)
        {
            adminvis.Visible = false;
            btnLog.Visible = false;
            btnLogout.Visible = true;
        }
        else if (Session["Admin"] != null)
        {
            if ((int)Session["Admin"] == 1)
            {
                adminvis.Visible = true;
                btnLog.Visible = false;
                btnLogout.Visible = true;
            }
        }
        else if (Session["Dziekan"] != null)
        {
            if ((int)Session["Dziekan"] == 1)
            {
                adminvis.Visible = true;
                btnLog.Visible = false;
                btnLogout.Visible = true;
            }
        }
        else
        {
            adminvis.Visible = false;
            btnLog.Visible = true;
            btnLogout.Visible = false;
        }

        

    }

    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(local);Initial Catalog=KT-all1;Integrated Security=True"))
        {

            SqlDataReader myReader;

            sqlCon.Open();
            string query = "SELECT * FROM Uzytkownicy WHERE Login=@ULogin AND Haslo = @UHaslo;";
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

            sqlCmd.Parameters.AddWithValue("@ULogin", txtBoxLogin.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@UHaslo", txtBoxPassword.Text.Trim());
            myReader = sqlCmd.ExecuteReader();
            string CzyAdmin = string.Empty;
            string CzyDziekan = string.Empty;

            int count = 0;
            while (myReader.Read())
            {
                count = count + 1;
                CzyAdmin = myReader["CzyAdmin"].ToString();
                CzyDziekan = myReader["CzyDziekan"].ToString();
            }
            if (count == 1)
            {

                if (CzyAdmin == "1")
                {

                    Session["Admin"] = 1;
                    Response.Redirect("phonebook.aspx");
                }
                else if(CzyDziekan == "1")
                {
                    Session["Dziekan"] = 1;
                    Response.Redirect("phonebook.aspx");
                }
                else
                {
                    Session["ULogin"] = txtBoxLogin.Text.Trim();
                    Response.Redirect("phonebook.aspx");
                }
            }
            else if (count > 1)
            {
                Session["ULogin"] = txtBoxLogin.Text.Trim();
                Response.Redirect("phonebook.aspx");
            }
            else { lblErrorMessage.Text = "Wprowadź poprawne dane logowania"; }
        }
    }
    public void Clear()
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