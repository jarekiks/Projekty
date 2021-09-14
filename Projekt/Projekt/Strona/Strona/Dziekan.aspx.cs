using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class Dziekan : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=KT-all1;Integrated Security=True");
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter sda = new SqlDataAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();

        if (Session["Dziekan"] != null)
        {
            btnLogin.Visible = false;
            btnRegister.Visible = false;
            btnLogout.Visible = true;
            btnUpdate.Visible = true;
            btnCancel.Visible = true;
            masterPageBody.Attributes.CssStyle.Add("background-image", "yell-bg.png");
        }
        else
        {
            btnLogin.Visible = true;
            btnRegister.Visible = true;
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
                GridViewRow row = Session["Row"] as GridViewRow;
                Session["id"] = Convert.ToInt32(row.Cells[3].Text);
                txtBoxTelefon.Text = row.Cells[6].Text;
                txtBoxMail.Text = row.Cells[7].Text;


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
                GridViewRow row = Session["Row"] as GridViewRow;
                Session["id"] = Convert.ToInt32(row.Cells[3].Text);
                txtBoxTelefon.Text = row.Cells[6].Text;
                txtBoxMail.Text = row.Cells[7].Text;

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
                GridViewRow row = Session["Row"] as GridViewRow;
                Session["id"] = Convert.ToInt32(row.Cells[3].Text);
                txtBoxTelefon.Text = row.Cells[6].Text;
                txtBoxMail.Text = row.Cells[7].Text;

                Session.Remove("wnz");
                Session["wnz1"] = 1;
            }
        }
        


    }

    

    void Clear()
    {
        
        txtBoxTelefon.Text = "";
        txtBoxMail.Text = "";

    }



    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int id = 0;
        GridViewRow row = Session["Row"] as GridViewRow;
        if (txtBoxTelefon.Text == "" || txtBoxMail.Text == "")
        {
            lblErrorMessage.Text = "Uzupełnij wszystkie pola.";
        }
        else if (txtBoxTelefon.Text.Length < 9)
        {
            lblErrorMessage.Text = "Numer telefonu jest za krótki";
        }
        else if (!this.txtBoxMail.Text.Contains('@') || !this.txtBoxMail.Text.Contains('.'))
        {
            lblErrorMessage.Text = "Email jest niepoprawny";
        }
        else
        {
            int index = Convert.ToInt32(Session["id"]) + id;
            cmd.CommandText = "Update ksiazka_telefoniczna set Telefon='" + txtBoxTelefon.Text.ToString() + "',Email='" + txtBoxMail.Text.ToString() + "'where id='" + index + "'";
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
        Session.Remove("Dziekan");
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