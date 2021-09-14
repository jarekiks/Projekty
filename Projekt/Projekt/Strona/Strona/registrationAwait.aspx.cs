using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;
using System.Net.Mail;
using System.IO;

public partial class registrationAwait : System.Web.UI.Page
{

    string connectionString = @"Data Source=(local);Initial Catalog=KT-all1;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {

        /*using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("UserAdd", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Nr_rej", Session["RegNum"]);
            sqlCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            sqlCmd.Parameters.AddWithValue("@ULogin", Session["LoginReg"]);
            sqlCmd.Parameters.AddWithValue("UHaslo", Session["Password"]);
            sqlCmd.Parameters.AddWithValue("@Imie", Session["FirstName"]);
            sqlCmd.Parameters.AddWithValue("@Nazwisko", Session["LastName"]);
            sqlCmd.Parameters.AddWithValue("@CzyAdmin", Session["IsAdmin"]);
            sqlCmd.Parameters.AddWithValue("@UTelefon", Session["PhoneNUmber"]);
            sqlCmd.Parameters.AddWithValue("@UEmail", Session["EmailReg"]);
            sqlCmd.Parameters.AddWithValue("@Wydzial", Session["Department"]);
            sqlCmd.ExecuteNonQuery();*/
            labelRegistrationAwait.Text = "Dziękujemy za pomyślną rejestrację. Możesz się teraz zalogować na nowoutworzone konto.";
        /*

            Session.Remove("RegNum");
            Session.Remove("UserID");
            Session.Remove("LoginReg");
            Session.Remove("Password");
            Session.Remove("FirstName");
            Session.Remove("LastName");
            Session.Remove("IsAdmin");
            Session.Remove("PhoneNUmber");
            Session.Remove("EmailReg");
            Session.Remove("Department");
        }
        */
    }
        
    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");
    }
}