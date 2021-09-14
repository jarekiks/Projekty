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

public partial class registration : System.Web.UI.Page
{
    string connectionString = @"Data Source=(local);Initial Catalog=KT-all1;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Clear();
        }

        if (Session["Admin"] != null)
        {
            btnLogin.Visible = false;
            btnRegister.Visible = true;
            btnLogout.Visible = true;
            masterPageBody.Attributes.CssStyle.Add("background-image", "red-bg.png");
        }
        else
        {
            btnLogin.Visible = true;
            btnRegister.Visible = false;
            btnLogout.Visible = false;
        }
        
    }

    protected void btnRegistration_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=KT-all1;Integrated Security=True");
        if (con.State == ConnectionState.Closed)
            con.Open();
        SqlCommand sqlDa = new SqlCommand("RegNumSearch", con);
        sqlDa.CommandType = CommandType.StoredProcedure;
        sqlDa.Parameters.AddWithValue("@nr_Rej", txtBoxRegistrationNumber.Text.Trim() + labelDate.Text.Trim());
        sqlDa.Parameters.AddWithValue("@UserID", Convert.ToInt32(hfUserID.Value == "" ? "0" : hfUserID.Value));
        sqlDa.Parameters.Add("@DBNr_Rej", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
        sqlDa.ExecuteNonQuery();
        con.Close();

        if (con.State == ConnectionState.Closed)
            con.Open();
        SqlCommand cmd = new SqlCommand("NumerAlbumuSearch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@AlbumNr", txtBoxLoginRegistration.Text.Trim());
        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(hfUserID.Value == "" ? "0" : hfUserID.Value));
        cmd.Parameters.Add("@DBAlbumNr", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
        cmd.ExecuteNonQuery();

        int ret = int.Parse(sqlDa.Parameters["@DBNr_Rej"].Value.ToString());
        int ret2 = int.Parse(cmd.Parameters["@DBAlbumNr"].Value.ToString());

        
        if (txtBoxLoginRegistration.Text == "" || DDLDepartment.Text == "" || txtBoxRegistrationNumber.Text == "" || txtBoxFirstNameRegistration.Text == "" || txtBoxLastNameRegistration.Text == "" || txtBoxEmailRegistration.Text == "" || txtBoxPhoneNumberRegistration.Text == "" )
            lblErrorMessage.Text = "Wypełnij wszystkie puste pola";
        else if (ret != 0)
            lblErrorMessage.Text = "Ten numer rejestracji jest już zajęty";
        else if (ret2 != 0)
            lblErrorMessage.Text = "Ten numer albumu jest już zajęty";
        else if (txtBoxPhoneNumberRegistration.Text.Length < 9)
            lblErrorMessage.Text = "Numer telefonu jest za krótki";
        else if (!this.txtBoxEmailRegistration.Text.Contains('@') || !this.txtBoxEmailRegistration.Text.Contains('.'))
            lblErrorMessage.Text = "Email jest niepoprawny";
        else
        {
            /*
            Session["RegNum"] = txtBoxRegistrationNumber.Text;
            Session["UserID"] = Convert.ToInt32(hfUserID.Value == "" ? "0" : hfUserID.Value);
            Session["LoginReg"] = txtBoxLoginRegistration.Text;
            Session["Password"] = txtBoxPasswordRegistration.Text;
            Session["FirstName"] = txtBoxFirstNameRegistration.Text;
            Session["LastName"] = txtBoxLastNameRegistration.Text;
            Session["IsAdmin"] = Convert.ToInt32(hfUserID.Value == "0");
            Session["PhoneNUmber"] =  txtBoxPhoneNumberRegistration.Text;
            Session["EmailReg"] = txtBoxEmailRegistration.Text;
            Session["Department"] = DDLDepartment.Text;*/

            Guid newUserID = new Guid();
            string urlBase = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;
            string verifyUrl = "/registrationAwait.aspx";
            string fullPath = urlBase + verifyUrl;
            string appPath = Request.PhysicalApplicationPath;
            StreamReader sr = new StreamReader(appPath + "Email/email.txt");
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress("ktmail@op.pl");
            message.To.Add(new MailAddress(txtBoxEmailRegistration.Text));
            message.Subject = "Weryfikacja";

            message.Body = sr.ReadToEnd();
            sr.Close();


            message.Body = message.Body.Replace("<%txtBoxFirstNameRegistration.Text%>", txtBoxFirstNameRegistration.Text);
            message.Body = message.Body.Replace("<%WeryfikacjaURL%>", fullPath);


            SmtpClient smtp = new SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("muprejestracja@gmail.com", "Haslo123");
                smtp.EnableSsl = true;
                
            }
            smtp.Send(message);

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("UserAdd", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Nr_rej", txtBoxRegistrationNumber.Text.Trim()+labelDate.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(hfUserID.Value == "" ? "0" : hfUserID.Value));
                sqlCmd.Parameters.AddWithValue("@ULogin", txtBoxLoginRegistration.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Imie", txtBoxFirstNameRegistration.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Nazwisko", txtBoxLastNameRegistration.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@CzyAdmin", Convert.ToInt32(hfUserID.Value == "0"));
                sqlCmd.Parameters.AddWithValue("@UTelefon", txtBoxPhoneNumberRegistration.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@UEmail", txtBoxEmailRegistration.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Wydzial", DDLDepartment.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                Clear();
                lblSuccessMessage.Text = "Success";
                Response.Redirect("registration.aspx");
            }

            
        }
    }
    void Clear()
    {
        txtBoxLoginRegistration.Text = txtBoxPhoneNumberRegistration.Text = txtBoxEmailRegistration.Text = DDLDepartment.Text = "";
        hfUserID.Value = "";
        lblSuccessMessage.Text = "";
        lblErrorMessage.Text = "";
    }

    protected void txtBoxEmailRegistration_DataBinding(object sender, EventArgs e)
    {

    }

    static bool checkPassword(string input)
    {
        bool hasNum = false;
        bool hasCap = false;
        bool hasLow = false;
        char currentCharacter;


        for (int i = 0; i < input.Length; i++)
        {
            currentCharacter = input[i];
            if (char.IsDigit(currentCharacter))
            {
                hasNum = true;
            }
            else if (char.IsUpper(currentCharacter))
            {
                hasCap = true;
            }
            else if (char.IsLower(currentCharacter))
            {
                hasLow = true;
            }

            if (hasNum && hasCap && hasLow)
            {
                return true;
            }
        }
        return false;
    }


    protected void labelDate_Init(object sender, EventArgs e)
    {
        string date = System.DateTime.Now.ToString("yyyy");
        labelDate.Text = "/" + date;
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Remove("Admin");
        Session.Remove("ULogin");
        btnLogout.Visible = false;
        Response.Redirect("Home.aspx");
    }
}