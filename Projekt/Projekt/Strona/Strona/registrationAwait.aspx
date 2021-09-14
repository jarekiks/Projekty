<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registrationAwait.aspx.cs" Inherits="registrationAwait" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="shortcut icon" type="image/x-icon" href="iconn.png" />
    <title>PhoneBook</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
    <style type="text/css">
        .auto-style1 {
            height: 60px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <header>
        <div class="logo">
            <img src="zdjRej.png" />
        </div>
        </header>
        <asp:Label ID="labelRegistrationAwait" runat="server" Text=""></asp:Label>

        <asp:Button class="btn" ID="btnLogIn" runat="server" Text="Zaloguj" OnClick="btnLogIn_Click" />
        <footer>
            <ul>
                <li><a href="#">Copyright 2020 ©</a></li>
                <li><a href="#">Kontakt:</a></li>
            </ul>
        </footer>
    </form>
</body>
</html>