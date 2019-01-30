<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Donate.aspx.cs" Inherits="WebApplication1.Donate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlgiris" runat="server">
        <div class="form_settings">
            <p><h2>Donation Form </h2>
                <p>
                </p>
                <p>
                    <span>Book Name</span><asp:TextBox ID="txtBookName" runat="server" class="contact" />
                </p>
                <p>
                    <span>Author</span><asp:TextBox ID="txtAuthor" runat="server" class="contact" />
                </p>
                <p>
                    <span>Publication Date</span><asp:TextBox ID="txtPublicationDate" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="true" TargetControlID="txtPublicationDate" />
                </p>
                <p>
                    <span>Category</span><asp:TextBox ID="txtCategory" runat="server" class="contact" />
                </p>
                 <p>
                    <span>Address</span><asp:TextBox ID="txtDeliveryAddress" runat="server" class="contact" Rows="4" TextMode="MultiLine" />
                </p>                
                <p>
                    <span>Delivery Date</span>                    
                    <asp:TextBox ID="txtDeliveryDate" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="true" TargetControlID="txtDeliveryDate"/>
                </p>
                <p>
                    <span>Delivery Time</span><asp:DropDownList ID="DropDownListDeliveryTime" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="10">10:00</asp:ListItem>
                        <asp:ListItem Value="12">12:00</asp:ListItem>
                        <asp:ListItem Value="14">14:00</asp:ListItem>
                        <asp:ListItem Value="16">16:00</asp:ListItem>
                    </asp:DropDownList>
                </p>               
                <p style="padding-top: 15px">
                    <span>&nbsp;</span><asp:Button runat="server" ID="btnDonate" class="submit" OnClick="BtnDonate_Click" Text="Donate" />
                </p>
                <p>
                    <asp:Label ID="lblSonuc" runat="server" Text="" />
                </p>
                <p>
                </p>
                <p>
                </p>
            </p>
            
        </div>
        </asp:Panel>
</asp:Content>
