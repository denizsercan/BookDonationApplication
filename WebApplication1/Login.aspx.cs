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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text != "" && txtUserName.Text != "")
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);

                String sorgu = "Select * From Users Where UserName = @UserName AND UserPassword = @UserPassword";

                SqlCommand cmd = new SqlCommand(sorgu, cnn);


                cnn.Open();

                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@UserPassword", txtPassword.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    User u = new User();
                    u.UserId = Convert.ToInt32(dr["UserId"]);
                    u.Name = dr["Name"] != DBNull.Value ? dr["Name"].ToString() : string.Empty;
                    u.Surname = dr["Surname"] != DBNull.Value ? dr["Surname"].ToString() : string.Empty;
                    u.UserName = dr["UserName"] != DBNull.Value ? dr["UserName"].ToString() : string.Empty;
                    u.Email = dr["Email"] != DBNull.Value ? dr["Email"].ToString() : string.Empty;

                    u.isAdmin = Convert.ToInt32(dr["Admin"]) == 1 ? true : false;
                    Session["User"] = u;

                    if(u.isAdmin)
                        Response.Redirect("~/Admin.aspx");
                    else
                        Response.Redirect("~/Home.aspx");
                }
                else {

                    lblSonuc.Text = "Kullanıcı Girişi Sağlanamadı.";

                }
                cnn.Close();

            }
            else { lblSonuc.Text = "Boş Alanları Doldurunuz."; }
        }
    }
}