<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dziekan.aspx.cs" Inherits="Dziekan" %>

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
                <li><a href="phonebook.aspx">Książka</a></li>
                <li id="btnLogin" runat="server"><a href="Home.aspx">Logowanie</a></li>
                <li id="btnRegister" runat="server"><a href='registration.aspx'>Rejestracja</a></li>
                <li class="active" id="btnDziekan" runat="server" visible="true"><a href="Dziekan.aspx">Panel koordynatora</a></li>
                <asp:Button CssClass="btnLogout" ID="btnLogout" runat="server" Text="Wyloguj" onclick="btnLogout_Click" UseSubmitBehavior="False"/>
            </ul>
        </div>
    </header>
    
        <div class="background">
        <div class="tableA">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblTelefon" runat="server" Text="Telefon:"></asp:Label>
                        <asp:TextBox ID="txtBoxTelefon" runat="server" MaxLength="9"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMail" runat="server" Text="Email:"></asp:Label>
                        <asp:TextBox ID="txtBoxMail" runat="server" CausesValidation="True" TextMode="Email"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                         <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                         <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <td class="button" style="height: 27px">
                        <asp:Button class="btn1" ID="btnUpdate" runat="server" Text="Zmień" OnClick="btnUpdate_Click" />
                        <asp:Button class="btn2" ID="btnCancel" runat="server" Text="Wróć" OnClick="btnCancel_Click" visible="false"/>
                </td>
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
