using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication1
{
    public partial class Donate : System.Web.UI.Page
    {
        internal User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            CalendarExtender2.StartDate = DateTime.Today;

            string teslimSaatSorgu = "select DeliveryTime, COUNT(DeliveryTime) as Sayi from Book group by DeliveryTime";
            SqlConnection cnnTeslim = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            SqlCommand cmdTeslim = new SqlCommand(teslimSaatSorgu, cnnTeslim);

            cnnTeslim.Open();
            try
            {
                using(SqlDataReader dr = cmdTeslim.ExecuteReader())
                {
                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            string teslimSaat = dr["DeliveryTime"].ToString().Substring(0, 2);
                            int kitapSayi = Convert.ToInt32(dr["Sayi"]);
                            switch(teslimSaat)
                            {
                                case "10":
                                    if(kitapSayi >= 20)
                                        DropDownListDeliveryTime.Items.FindByValue("10").Enabled = false;
                                    else
                                        DropDownListDeliveryTime.Items.FindByValue("10").Enabled = true;
                                    break;
                                case "12":
                                    if(kitapSayi >= 20)
                                        DropDownListDeliveryTime.Items.FindByValue("12").Enabled = false;
                                    else
                                        DropDownListDeliveryTime.Items.FindByValue("12").Enabled = true;
                                    break;
                                case "14":
                                    if(kitapSayi >= 20)
                                        DropDownListDeliveryTime.Items.FindByValue("14").Enabled = false;
                                    else
                                        DropDownListDeliveryTime.Items.FindByValue("14").Enabled = true;
                                    break;
                                case "16":
                                    if(kitapSayi >= 20)
                                        DropDownListDeliveryTime.Items.FindByValue("16").Enabled = false;
                                    else
                                        DropDownListDeliveryTime.Items.FindByValue("16").Enabled = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }         
            }

            catch (Exception ex)
            {

            }
            cnnTeslim.Close();

            User kullanici = (User)Session["User"];
            if(Session["User"] != null)
            {
                user = Session["User"] as User;
                string sorgu = @"Select  Users.UserName, COUNT(Book.BookName) AS Sayi
                                 FROM Users
                                 LEFT JOIN Book ON Users.UserId = Book.UserId  
                                 WHERE Users.UserName = @UserName
                                 GROUP BY UserName";

                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);
                SqlCommand cmd = new SqlCommand(sorgu, cnn);

                cnn.Open();
                try
                {
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        int kitapSayi = Convert.ToInt32(dr["Sayi"]);
                        if(kitapSayi >= 5)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                        "alert('5 Taneden fazla kitap bağışı yapamazsınız');window.location ='Home.aspx';", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                        String.Format("alert('{0} tane daha kitap bağışlayabilirsiniz!');", 5 - kitapSayi), true);
                        }
                    }
                    cnn.Close();
                }
                catch(Exception ex)
                {

                }                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    "alert('Bağış yapmak için giriş yapmalısınız!');window.location ='Home.aspx';", true);
            }
        }

        protected void BtnDonate_Click(object sender, EventArgs e)
        {
            if(txtBookName.Text != "" && txtAuthor.Text != "" && txtPublicationDate.Text != "" && txtCategory.Text != "" && txtDeliveryAddress.Text != "" && txtDeliveryDate.Text != "" && DropDownListDeliveryTime.SelectedValue != "")
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);

                String sorgu = "Insert into Book (BookName, Author, PublicationDate, Catagories, DeliveryAddress, DeliveryDate, DeliveryTime, UserId) Values (@BookName, @Author, @PublicationDate, @Catagories, @DeliveryAddress, @DeliveryDate, @DeliveryTime, (Select UserId From Users Where UserId = @UserId))";


                SqlCommand cmd = new SqlCommand(sorgu, cnn);

                cnn.Open();
                try
                {

                    cmd.Parameters.AddWithValue("@BookName", txtBookName.Text);
                    cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
                    cmd.Parameters.AddWithValue("@PublicationDate", txtPublicationDate.Text);
                    cmd.Parameters.AddWithValue("@Catagories", txtCategory.Text);
                    cmd.Parameters.AddWithValue("@DeliveryAddress", txtDeliveryAddress.Text);
                    cmd.Parameters.AddWithValue("@DeliveryDate", txtDeliveryDate.Text);
                    cmd.Parameters.AddWithValue("@DeliveryTime", DropDownListDeliveryTime.Text);
                    cmd.Parameters.AddWithValue("@UserId", user.UserId);

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
                lblSonuc.Text = "Boş Alanları Doldurunuz.";
            }
        }
    }
}
