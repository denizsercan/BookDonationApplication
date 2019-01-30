using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication1
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "" && txtSurname.Text != "" && txtTC.Text != "" && txtPhone.Text != "" && txtEmail.Text != "" && txtAddress.Text != "" && txtUserName.Text != "" && txtPassword.Text != "")
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);

                String sorgu = "Insert into Users (Name, Surname, TC, Email, Phone, UserAddress, UserName, UserPassword) Values (@Name, @Surname, @TC, @Email, @Phone, @UserAddress, @UserName, @UserPassword)";


                SqlCommand cmd = new SqlCommand(sorgu, cnn);

                cnn.Open();
                try
                {

                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Surname", txtSurname.Text);
                    cmd.Parameters.AddWithValue("@TC", txtTC.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@UserAddress", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@UserPassword", txtPassword.Text);

                    cmd.ExecuteNonQuery();

                    cnn.Close();

                    lblSonuc.Text = "Kayıt yapıldı.";
                }
                catch(Exception)
                {
                    lblSonuc.Text = "Kayıt yapılmadı.";
                }
            }
            else {
                lblSonuc.Text = "Boş Alanları Doldurunuz."; }
        }
    }
}