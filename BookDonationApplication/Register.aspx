<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="form_settings">
            <p>&nbsp;<h2>Registration Form </h2></p>
            
            <p><span>Name</span><asp:TextBox ID="txtName" class="contact" runat="server"/></p>
            <p><span>Surname</span><asp:TextBox ID="txtSurname" class="contact" runat="server"/></p>
            <p><span>TC</span><asp:TextBox ID="txtTC" class="contact" runat="server"/></p>
            <p><span>Phone number</span><asp:TextBox ID="txtPhone" class="contact" runat="server"/></p>
            <p><span>E-mail</span><asp:TextBox ID="txtEmail" class="contact" runat="server" TextMode="Email"/></p>
            <p><span>Address</span><asp:TextBox ID="txtAddress" class="contact" runat="server" Rows="4" TextMode="MultiLine"/></p>
            <p><span>Username</span><asp:TextBox ID="txtUserName" class="contact" runat="server"/></p>
            <p><span>Password</span><asp:TextBox ID="txtPassword" class="contact" runat="server" TextMode="Password"/></p>

            <p style="padding-top: 25px"><asp:Button Text="Register" runat="server" OnClick="BtnRegister_Click"/></p>
            <p>
                <asp:Label ID="lblSonuc" Text="" runat="server" />
            </p>
        </div>
</asp:Content>
