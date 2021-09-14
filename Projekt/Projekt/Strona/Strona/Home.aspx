<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

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
    <header>
            <div class="logo">
                <img src="zdjRej.png" />
            </div>
        <div class="main">
        <form id="form1" runat="server">
            <ul id="nav" runat="server">
                <li id="btnHome" runat="server"><a href="Home.aspx">Strona główna</a></li>
                <li id="btnLog" runat="server"><a href="Login.aspx">Logowanie</a></li>
                
            </ul>
        </div>
    </header>
        <div class="background">
            <div class="homepage">
                <br />
                <p><h1>Witamy na stronie rejestru kontaktów Studentów</h1></p>
                <br />
                <div class="tableee">
                <table>
                <tr><td>
                <h2>Zaloguj się jako administrator danych</h2>
                <asp:Button class="btnAdminLogin" ID="btnAdminLogin" runat="server" Text="Zaloguj się jako administrator danych" onclick="btnAdminLogin_Click"/>
                </td></tr>
                <tr><td>
                <h2>Zaloguj się jako koordynator danych</h2>
                <asp:Button class="btnDziekanLogin" ID="btnDziekanLogin" runat="server" Text="Zaloguj się jako koordynator danych" onclick="btnDziekanLogin_Click"/>
                </td></tr>
                <tr><td>
                <h2>Zaloguj się jako użytkownik</h2>
                <asp:Button class="btnUserLogin" ID="btnUserLogin" runat="server" Text="Zaloguj się jako użytkownik" onclick="btnUserLogin_Click"/>
                </td></tr>
                </table>
                </div>
            <//div>
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
