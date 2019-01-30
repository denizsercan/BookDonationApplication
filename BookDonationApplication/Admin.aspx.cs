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
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            String sorgu = "SELECT COUNT(BookName) AS SAYI FROM Book WHERE BookName = @BookName GROUP BY BookName";

            SqlCommand cmd = new SqlCommand(sorgu, cnn);

            cnn.Open();

            cmd.Parameters.AddWithValue("@BookName", DropDownList1.SelectedItem.Text);

            SqlDataReader dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                lblKitap.Text = dr["SAYI"].ToString();
            }
        }

        protected void DropDownList2_SelectedIndexChanged1(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            String sorgu = "SELECT COUNT(Author) AS SAYI FROM Book WHERE Author = @Author GROUP BY BookName";

            SqlCommand cmd = new SqlCommand(sorgu, cnn);

            cnn.Open();

            cmd.Parameters.AddWithValue("@Author", DropDownList2.SelectedItem.Text);

            SqlDataReader dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                lblKitap2.Text = dr["SAYI"].ToString();
            }
        }      

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            String sorgu = "SELECT DeliveryTime, COUNT(DeliveryTime)AS SAYI FROM Book WHERE DeliveryTime = @DeliveryTime GROUP BY DeliveryTime";
           

            SqlCommand cmd = new SqlCommand(sorgu, cnn);

            cnn.Open();

            cmd.Parameters.AddWithValue("@DeliveryTime", DropDownList3.SelectedItem.Text);

            SqlDataReader dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                lblKitap3.Text = dr["SAYI"].ToString();
            }
        }

        protected void btnClick_Click(object sender, EventArgs e)
        {
            Session.Abandon();

            Session.Contents.RemoveAll();

            System.Web.Security.FormsAuthentication.SignOut();

            Response.Redirect("/home.aspx");
        }
    }
}