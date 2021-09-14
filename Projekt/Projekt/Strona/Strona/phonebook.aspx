<%@ Page Language="C#" AutoEventWireup="true" CodeFile="phonebook.aspx.cs" Inherits="phonebook" %>

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
            <ul id="nav" runat="server">
                <li class="active"><a href="phonebook.aspx">Książka</a></li>
                <li id="btnLogin" runat="server"><a href="Home.aspx">Logowanie</a></li>
                <li id="btnRegister" runat="server"><a href='registration.aspx'>Rejestracja</a></li>
                <li id="adminvis" runat="server" visible="false"><a href="Admin.aspx">Panel administratora</a></li>
                <li id="dziekanvis" runat="server" visible="false"><a href="Dziekan.aspx">Panel koordynatora</a></li>
                <asp:Button CssClass="btnLogout" ID="btnLogout" runat="server" Text="Wyloguj" onclick="btnLogout_Click"/>
            </ul>
        </div>
     </header>
        <div class="departments">
            <ul1>
                <li><a href="WNS.aspx" class="dep">Wydział Nauk Społecznych</a></li>
                <li><a href="WNHI.aspx" class="dep">Wydział Nauk Humanistycznych i Informatyki</a></li>
                <li><a href='WNZ.aspx' class="dep">Wydział Nauk o Zdrowiu</a></li>
            </ul1>
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