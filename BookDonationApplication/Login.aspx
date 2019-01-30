<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="form_settings">
            <p><h2>Login</h2></p>
                     
            <p><span>UserName</span><asp:TextBox ID="txtUserName" class="contact" runat="server"/></p>
            <p><span>Password</span><asp:TextBox ID="txtPassword" class="contact" runat="server" TextMode="Password"/></p>
            <p style="padding-top: 25px ;padding-right:50px"><asp:Button class="submit" Text=" Login " runat="server" OnClick="BtnLogin_Click"/></p>
            <p>
                <asp:Label ID="lblSonuc" Text="" runat="server" />
            </p>
        </div>      
</asp:Content>
