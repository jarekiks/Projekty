<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WNS.aspx.cs" Inherits="WNEI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="shortcut icon" type="image/x-icon" href="iconn.png" />
    <title>PhoneBook</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
    </head>
<body runat="server" id="masterPageBody">
    <form id="form1" runat="server">
    <header>
            <div class="logo">
                <img src="zdjRej.png" />
            </div>
        <div class="main">
            <ul>
                <li class="active"><a href="phonebook.aspx">Książka</a></li>
                <li id="btnLogin" runat="server"><a href="Home.aspx">Logowanie</a></li>
                <li id="btnRegister" runat="server"><a href='registration.aspx'>Rejestracja</a></li>
                <li ID="adminvis" runat="server" visible="false"><a href="Admin.aspx">Panel administratora</a></li>
                <li id="dziekanvis" runat="server" visible="false"><a href="Dziekan.aspx">Panel koordynatora</a></li>
                <asp:Button CssClass="btnLogout" ID="btnLogout" runat="server" Text="Wyloguj" onclick="btnLogout_Click" UseSubmitBehavior="False"/>
            </ul>
        </div>
    </header>
        <div class="name">
            <asp:Label ID="lblWNEI" runat="server" Text="Wydział Nauk Społecznych"></asp:Label>
        </div>
        <div class="content">
            <asp:GridView ID="gvKsiazkaTelefoniczna" runat="server" CssClass="gridView" AllowPaging="True" OnPageIndexChanging="gvKsiazkaTelefoniczna_PageIndexChanging" showfooter="True" >
                <rowstyle Height="40px" />
                <alternatingrowstyle  Height="40px"/>
                <Columns>
                
                <asp:TemplateField HeaderText="OutlookID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="id" runat="server">Existing Control</asp:Label>        
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" CssClass="EditButton" Text="Zmień" OnClick="btnEdit_Click" UseSubmitBehavior="False" />
                        
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" Text="Usuń" OnClick="btnDelete_Click" UseSubmitBehavior="False" />
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#f5ead0" Height="100%"/>
                <HeaderStyle Height="80px" />

            </asp:GridView>
        </div>
        <div class ="search">
            <asp:TextBox ID="txtBoxSearch" runat="server" Width="274px" ToolTip="Search by last name" placeholder="Szukaj po nazwisku"></asp:TextBox>
                        <asp:Button class="btnsearch" ID="btnSearch" runat="server" Text="Szukaj" Height="29px" OnClick="btnSearch_Click" Width="79px" />
        </div>
        <footer>
            <ul>
                <li><a href="#">Copyright 2020 ©</a></li>
                <li><a href="#">Kontakt:</a></li>
            </ul>
        </footer>
    </form>
</body>
</html>
