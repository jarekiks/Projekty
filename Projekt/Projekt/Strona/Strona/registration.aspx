<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="registration" %>

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

    <script type="text/javascript">
      function ValidNumeric()
      {
         var charCode = (event.which) ? event.which : event.keyCode;
         if (charCode >= 48 && charCode <= 57)
            return true;
         else
            return false;
      }
    </script>
    <script type="text/javascript">
        function ValidString()
      {
         var charCode = (event.which) ? event.which : event.keyCode;
            if ((charCode <= 93 && charCode >= 65) || (charCode <= 122 && charCode >= 97) || (charCode == 261 && e.Alt) || (charCode == 260 && e.Alt) || (charCode == 262 && e.Alt) || (charCode == 263 && e.Alt) || (charCode == 280 && e.Alt) || (charCode == 281 && e.Alt) || (charCode == 321 && e.Alt) || (charCode == 322 && e.Alt) || (charCode == 323 && e.Alt) || (charCode == 324 && e.Alt) || (charCode == 211 && e.Alt) || (charCode == 243 && e.Alt) || (charCode == 346 && e.Alt) || (charCode == 347 && e.Alt) || (charCode == 377 && e.Alt) || (charCode == 378 && e.Alt) || (charCode == 379 && e.Alt) || (charCode == 380 && e.Alt))
            return true;
         else
            return false;
      }
    </script>
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
                <li id="btnRegister" runat="server" class="active"><a href='registration.aspx'>Rejestracja</a></li>
                <li ><a href="Admin.aspx">Panel administratora</a></li>
                <asp:Button CssClass="btnLogout" ID="btnLogout" runat="server" Text="Wyloguj" onclick="btnLogout_Click" UseSubmitBehavior="False"/>
            </ul>
        </div>
    </header>
   
        <div class="table2">
            <table>
                <tr>
                    <asp:HiddenField ID="hfUserID" runat="server" />
                    <asp:HiddenField ID="hfCzyAdmin" runat="server" />
                    <td>
                        <asp:Label ID="labelRegistrationNumber" runat="server" Text="Numer rejestracji:"></asp:Label>
                        <asp:TextBox ID="txtBoxRegistrationNumber" runat="server" MaxLength="3" onkeypress="return ValidNumeric()" Width="30px"></asp:TextBox>
                        <asp:Label ID="labelDate" runat="server" OnInit="labelDate_Init" Text="Label"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label></br></br>
                    </td>
                    
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="labelLoginRegistration" runat="server" Text="Numer albumu:"></asp:Label>
                        <asp:TextBox ID="txtBoxLoginRegistration" runat="server" MaxLength="5" onkeypress="return ValidNumeric()"></asp:TextBox>
                        <asp:Label ID="star1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                </tr>              
                <tr>
                    <td>
                        <asp:Label ID="lblFirstNameRegistration" runat="server" Text="Imie:"></asp:Label>
                        <asp:TextBox ID="txtBoxFirstNameRegistration" runat="server" MaxLength="20" onkeypress="return ValidString()"></asp:TextBox>
                        <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLastNameRegistration" runat="server" Text="Nazwisko:"></asp:Label>
                        <asp:TextBox ID="txtBoxLastNameRegistration" runat="server" MaxLength="20" onkeypress="return ValidString()"></asp:TextBox>
                        <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblPhoneNumberRegistration" runat="server" Text="Numer telefonu: "></asp:Label>
                        <asp:TextBox ID="txtBoxPhoneNumberRegistration" runat="server" MaxLength="9"  onkeypress="return ValidNumeric()" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmailRegistration" runat="server" Text="Email:"></asp:Label>
                        <asp:TextBox ID="txtBoxEmailRegistration" runat="server" AutoCompleteType="Email" TextMode="Email" CausesValidation="True" OnDataBinding="txtBoxEmailRegistration_DataBinding" ValidateRequestMode="Enabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="DDL">
                        <asp:Label ID="lblDepartment" runat="server" Text="Wydział:"></asp:Label>
                        <br />
                        <asp:DropDownList ID="DDLDepartment" runat="server" Width="345px">
                            <asp:ListItem>Wydział Nauk Społecznych</asp:ListItem>
                            <asp:ListItem>Wydział Nauk Humanistycznych i Informatyki</asp:ListItem>
                            <asp:ListItem>Wydział Nauk o Zdrowiu</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="star4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                        <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="button" style="margin-top: 155px">
                        <asp:Button class="btnn" ID="btnRegistration" runat="server" Text="Zarejestruj" OnClick="btnRegistration_Click" />
                    </td>
                </tr>
            </table>
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
