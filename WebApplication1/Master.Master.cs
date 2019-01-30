using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Master : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            User kullanici = (User)Session["User"];
            if(kullanici != null)
            {
                pnlgiris.Visible = false;
                pnlkullanici.Visible = true;
                lblKullaniciAdi.Text = String.Format("{0} {1}", kullanici.Name, kullanici.Surname);
            }
            else
            {
                pnlkullanici.Visible = false;
                pnlgiris.Visible = true;
            }
           
        }

       
        protected void btnCikisClick_Click(object sender, EventArgs e)
        {
            Session.Abandon();

            Session.Contents.RemoveAll();

            System.Web.Security.FormsAuthentication.SignOut();

            Response.Redirect("/Home.aspx");
        }
    }
}