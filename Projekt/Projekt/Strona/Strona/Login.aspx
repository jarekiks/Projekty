<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="shortcut icon" type="image/x-icon" href="iconn.png" />
    <title>PhoneBook</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
    <style type="text/css">
        .auto-style1 {
            width: 210px;
        }
    </style>

<body runat="server" id="masterPageBody">
    <form id="form1" runat="server">
    <header>
            <div class="logo">
                <img src="zdjRej.png" />
            </div>
        <div class="main">
            <ul id="nav" runat="server">
                <li id="btnHome" runat="server"><a href="Home.aspx">Strona główna</a></li>
                <li id="btnLog" runat="server"><a href="Login.aspx">Logowanie</a></li>
                <li id="adminvis" runat="server" visible="false"><a href="Admin.aspx">Panel administratora</a></li>
                <asp:Button CssClass="btnLogout" ID="btnLogout" runat="server" Text="Wyloguj" onclick="btnLogout_Click"/>
            </ul>
        </div>
    </header>
   
        <div class="background">
        <div class="tablee">
            <table>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="labelLogin" runat="server" Text="Login:"></asp:Label>
                        <asp:TextBox ID="txtBoxLogin" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Password" runat="server" Text="Hasło:"></asp:Label>
                        <asp:TextBox ID="txtBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                         <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                         <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                         <asp:Label ID="lblCzyadmin" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="button" style="height: 27px">
                        <asp:Button class="btn" ID="btnLogIn" runat="server" Text="Zaloguj" OnClick="btnLogIn_Click" />
                    </td>
                </tr>
            </table>
        </div>
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
