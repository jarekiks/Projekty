using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class Admin : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=KT-all1;Integrated Security=True");
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter sda = new SqlDataAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();

        if (Session["Admin"] != null)
        {
            btnLogin.Visible = false;
            btnRegister.Visible = true;
            btnLogout.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            masterPageBody.Attributes.CssStyle.Add("background-image", "red-bg.png");
        }
        else
        {
            btnLogin.Visible = true;
            btnRegister.Visible = false;
            btnLogout.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
        }

        if (Session["wns"] != null)
        { 
            if (Session["Row"] != null)
            {
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
                btnAdd.Visible = false;
                GridViewRow row = Session["Row"] as GridViewRow;
                Session["id"] = Convert.ToInt32(row.Cells[3].Text);
                txtBoxImie.Text = row.Cells[4].Text;
                txtBoxNazwisko.Text = row.Cells[5].Text;
                txtBoxTelefon.Text = row.Cells[6].Text;
                txtBoxMail.Text = row.Cells[7].Text;
                DDLDepartmentAdmin.Text = row.Cells[8].Text;
                
                Session.Remove("wns");
                Session["wns1"] = 1;
            }
        }
        else if (Session["wnhi"] != null)
        {
            if (Session["Row"] != null)
            {
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
                btnAdd.Visible = false;
                GridViewRow row = Session["Row"] as GridViewRow;
                Session["id"] = Convert.ToInt32(row.Cells[3].Text);
                txtBoxImie.Text = row.Cells[4].Text;
                txtBoxNazwisko.Text = row.Cells[5].Text;
                txtBoxTelefon.Text = row.Cells[6].Text;
                txtBoxMail.Text = row.Cells[7].Text;
                DDLDepartmentAdmin.Text = row.Cells[8].Text;

                Session.Remove("wnhi");
                Session["wnhi1"] = 1;
            }
        }
        else if (Session["wnz"] != null)
        {
            if (Session["Row"] != null)
            {
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
                btnAdd.Visible = false;
                GridViewRow row = Session["Row"] as GridViewRow;
                Session["id"] = Convert.ToInt32(row.Cells[3].Text);
                txtBoxImie.Text = row.Cells[4].Text;
                txtBoxNazwisko.Text = row.Cells[5].Text;
                txtBoxTelefon.Text = row.Cells[6].Text;
                txtBoxMail.Text = row.Cells[7].Text;
                DDLDepartmentAdmin.Text = row.Cells[8].Text;

                Session.Remove("wnz");
                Session["wnz1"] = 1;
            }
        }
        else
        {
            if (Session["wns1"] != null)
            {
                if ((int)Session["wns1"] == 1)
                {
                    btnUpdate.Visible = true;
                    btnCancel.Visible = true;
                }
            }
            else if (Session["wnhi1"] != null)
            {
                if ((int)Session["wnhi1"] == 1)
                {
                    btnUpdate.Visible = true;
                    btnCancel.Visible = true;
                }
            }
            else if (Session["wnz1"] != null)
            {
                if ((int)Session["wnz1"] == 1)
                {
                    btnUpdate.Visible = true;
                    btnCancel.Visible = true;
                }
            }
            else
            {
                btnAdd.Visible = true;
            }
        }                            


    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtBoxImie.Text == "" || txtBoxNazwisko.Text == "" || txtBoxTelefon.Text == "" || txtBoxMail.Text == "")
            lblErrorMessage.Text = "Uzupełnij puste pola.";
        else if (txtBoxTelefon.Text.Length < 9)
            lblErrorMessage.Text = "Numer telefonu jest za krótki";
        else if (!this.txtBoxMail.Text.Contains('@') || !this.txtBoxMail.Text.Contains('.')) 
            lblErrorMessage.Text = "Email jest niepoprawny";
        else
        {
            cmd.CommandText = "Insert into ksiazka_telefoniczna (Imie, Nazwisko, Telefon, Email, Wydzial)values('" + txtBoxImie.Text.ToString() + "','" + txtBoxNazwisko.Text.ToString() + "','" + txtBoxTelefon.Text.ToString() + "' , '" + txtBoxMail.Text.ToString() + "' , '" + DDLDepartmentAdmin.Text.ToString() + "')";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            Clear();
            lblSuccessMessage.Text = "Successfully added data.";
        }
    }

    void Clear()
    {
        txtBoxImie.Text = "";
        txtBoxNazwisko.Text = "";
        txtBoxTelefon.Text = "";
        txtBoxMail.Text = "";
        
    }

    

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int id = 0;
        GridViewRow row = Session["Row"] as GridViewRow;
        if (txtBoxImie.Text == "" || txtBoxNazwisko.Text == "" || txtBoxTelefon.Text == "" || txtBoxMail.Text == "")
            lblErrorMessage.Text = "Uzupełnij puste pola.";
        else if (txtBoxTelefon.Text.Length < 9)
            lblErrorMessage.Text = "Numer telefonu jest za krótki";
        else if (!this.txtBoxMail.Text.Contains('@') || !this.txtBoxMail.Text.Contains('.')) 
            lblErrorMessage.Text = "Email jest niepoprawny";
        else
        {
            int index = Convert.ToInt32(Session["id"]) + id;
            cmd.CommandText = "Update ksiazka_telefoniczna set Telefon='" + txtBoxTelefon.Text.ToString() + "',Imie='" + txtBoxImie.Text.ToString() + "',Nazwisko='"+ txtBoxNazwisko.Text.ToString() + "',Email='" + txtBoxMail.Text.ToString() + "',Wydzial='" + DDLDepartmentAdmin.Text.ToString() + "'where id='" +index+"'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            Clear();
            Session.Remove("Row");
            lblSuccessMessage.Text = "Successfully updated data";
            if (Session["wns1"] != null)
            {
                if ((int)Session["wns1"] == 1)
                {
                    Response.Redirect("WNS.aspx");
                }
            }
            else if (Session["wnhi1"] != null)
            {
                if ((int)Session["wnhi1"] == 1)
                {
                    Response.Redirect("WNHI.aspx");
                }
            }
            else if (Session["wnz1"] != null)
            {
                if ((int)Session["wnz1"] == 1)
                {
                    Response.Redirect("WNZ.aspx");
                }
            }
        }
        
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Remove("Admin");
        Session.Remove("ULogin");
        btnLogout.Visible = false;
        Response.Redirect("Home.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Session["wns1"] != null)
        {
            if ((int)Session["wns1"] == 1)
            {
                Response.Redirect("WNS.aspx");
            }
        }
        else if (Session["wnhi1"] != null)
        {
            if ((int)Session["wnhi1"] == 1)
            {
                Response.Redirect("WNHI.aspx");
            }
        }
        else if (Session["wnz1"] != null)
        {
            if ((int)Session["wnz1"] == 1)
            {
                Response.Redirect("WNZ.aspx");
            }
        }
    }


}