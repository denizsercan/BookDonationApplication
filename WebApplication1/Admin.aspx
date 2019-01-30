<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication1.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color:#84DBFF">
             <asp:Button ID="btnClick" Text="Çıkış" runat="server" OnClick="btnClick_Click"/>
            <table>
                <tr>
                    <th style="padding:100px">For the given book name, find the number of books donated.</th>
                    <th style="padding:100px">
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="BookName" DataValueField="BookName" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                         </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BookConnectionString %>" SelectCommand="SELECT DISTINCT [BookName] FROM [Book]"></asp:SqlDataSource>
                    </th>
                    <th style="padding:100px">
                        <asp:Label ID="lblKitap" runat="server"></asp:Label>
                    </th>
                </tr>

                <tr>
                    <th style="padding:100px">Find the number of donated books of the given author.</th>
                    <th style="padding:100px">
                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource4" DataTextField="Author" DataValueField="Author" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged1">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:BookConnectionString %>" SelectCommand="SELECT DISTINCT [Author] FROM [Book]"></asp:SqlDataSource>
                    </th>
                    <th style="padding:100px">
                        <asp:Label ID="lblKitap2" runat="server"></asp:Label>
                    </th>
                </tr>

                 <tr>
                    <th style="padding:100px">For the given delivery service time, find the number of deliveries.</th>
                    <th style="padding:100px">
                        <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource6" DataTextField="DeliveryTime" DataValueField="DeliveryTime" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                         </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:BookConnectionString %>" SelectCommand="SELECT DISTINCT [DeliveryTime] FROM [Book]"></asp:SqlDataSource>
                    </th>
                    <th style="padding:100px">
                        <asp:Label ID="lblKitap3" runat="server"></asp:Label>
                    </th>
                </tr>

                <tr>
                    <th style="padding:100px">Find the total number of different books donated.</th>
                    <th style="padding:100px">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
                            <Columns>
                                <asp:BoundField DataField="SAYI" HeaderText="SAYI" ReadOnly="True" SortExpression="SAYI" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BookConnectionString %>" SelectCommand="SELECT COUNT(BookName) AS SAYI FROM Book"></asp:SqlDataSource>
                    </th>
                    <th></th>
                </tr>

                 <tr>
                    <th style="padding:100px">Find the book name that is donated the most.</th>
                    <th style="padding:100px">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3">
                            <Columns>
                                <asp:BoundField DataField="BookName" HeaderText="BookName" SortExpression="BookName" />
                                <asp:BoundField DataField="SAYI" HeaderText="SAYI" ReadOnly="True" SortExpression="SAYI" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:BookConnectionString %>" SelectCommand="SELECT TOP 1 BookName, COUNT(BookName) AS SAYI FROM Book GROUP BY BookName ORDER BY COUNT(BookName) DESC;"></asp:SqlDataSource>
                     </th>
                    <th></th>
                </tr>

                 <tr>
                    <th style="padding:100px">Find the number of donated books published on the given publication date.</th>
                    <th style="padding:100px">
                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:BookConnectionString %>" SelectCommand="SELECT COUNT(BookName) AS SAYI, PublicationDate FROM Book GROUP BY PublicationDate;"></asp:SqlDataSource>
                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource5">
                            <Columns>
                                <asp:BoundField DataField="SAYI" HeaderText="SAYI" SortExpression="SAYI" ReadOnly="True" />
                                <asp:BoundField DataField="PublicationDate" HeaderText="PublicationDate" SortExpression="PublicationDate" />
                            </Columns>
                        </asp:GridView>                        
                     </th>
                    <th></th>
                </tr>
                
            </table>
        </div>
    </form>
</body>
</html>
