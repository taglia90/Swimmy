﻿<%@ Page Title="Registrazione" Language="C#" MasterPageFile="~/NoSidebar.Master" AutoEventWireup="true" CodeBehind="Registrazione.aspx.cs" Inherits="Swimmy.Registrazione" %>



<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="HeaderArticleContent">

    <!-- Main -->
    <div class="wrapper style1">
        <div class="container">
            <div class="containerMini">
                <form id="form" runat="server" class="formMini">
                    <h2><a href="#">Registrazione</a></h2>
                    <p>
                        Registrandoti potrai inserire annunci, ricercare le piscine e godere di tutte le funzionalità del nostro sito.
                    </p>

                    <asp:TextBox ID="txtNome" Text="" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtNome"
                        runat="server" />
                    <asp:RegularExpressionValidator ID="txtNomeExprValidator" runat="server"
                        ControlToValidate="txtNome" ErrorMessage="Nome non valido. È vietato inserire caratteri speciali."
                        ValidationExpression="^([a-zA-Z\xE0\xE8\xE9\xF9\xF2\xEC\x27]\s?)+$" ForeColor="Red" />

                    <asp:TextBox ID="txtCognome" Text="" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtCognome"
                        runat="server" />
                    <asp:RegularExpressionValidator ID="txtCognomeExprValidator" runat="server"
                        ControlToValidate="txtCognome" ErrorMessage="Cognome non valido. È vietato inserire caratteri speciali."
                        ValidationExpression="^([a-zA-Z\xE0\xE8\xE9\xF9\xF2\xEC\x27]\s?)+$" ForeColor="Red" />
                    <!--
                <label>Username</label>
                <asp:TextBox ID="txtUsername" Text="" runat="server" />
                <asp:RequiredFieldValidator ID="txtUsernameFieldValidator" ErrorMessage="Campo obbligatorio" ForeColor="Red"
                    ControlToValidate="txtUsername" runat="server" />
                <asp:RegularExpressionValidator ID="txtUsernameExprValidator" runat="server"
                    ControlToValidate="txtUsername" ErrorMessage="Il nome utente può essere composto solo da lettere o numeri."
                    ValidationExpression="^([a-zA-Z0-9])+$" ForeColor="Red" />
                <asp:CustomValidator runat="server" ControlToValidate="txtUsername" ErrorMessage="L'username è già utilizzato."
                    OnServerValidate="controllaUsername" ForeColor="Red" />
                -->

                    <asp:TextBox ID="txtPassword1" Text="Password" TextMode="Password" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtPassword1"
                        runat="server" />
                    <asp:RegularExpressionValidator ID="txtPasswordExprValidator" runat="server"
                        ControlToValidate="txtPassword1" ErrorMessage="Devi inserire min 6, max 40 caratteri, numeri, _ * – + ! ? , : ; . e lettere accentate."
                        ValidationExpression="^[a-zA-Z0-9_\*\-\+\!\?\,\:\;\.\xE0\xE8\xE9\xF9\xF2\xEC\x27]{6,40}" ForeColor="Red" />

                    <asp:TextBox ID="txtPassword2" Text="Password" TextMode="Password" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtPassword2"
                        runat="server" />
                    <asp:CompareValidator runat="server" ControlToValidate="txtPassword2" ControlToCompare="txtPassword1"
                        ErrorMessage="Le password inserite non sono uguali!" ForeColor="Red" />

                    <asp:TextBox ID="txtEmail" Text="" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtEmail"
                        runat="server" />
                    <asp:RegularExpressionValidator ID="txtEmailExprValidator" runat="server"
                        ControlToValidate="txtEmail" ErrorMessage="Indirizzo email non valido."
                        ValidationExpression="^[a-zA-Z0-9\._\%\-]+\@[a-zA-Z0-9\.\-]+\.[a-zA-Z]{2,4}$" ForeColor="Red" />
                    <asp:CustomValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="L'email risulta già registrata, utilizzarne un'altra."
                        OnServerValidate="controllaEmail" ForeColor="Red" />
                    <br />

                    <asp:RadioButton ID="RadioButton1" runat="server" Text="Sono un proprietario di una piscina." GroupName="Radio"
                        AutoPostBack="true" Checked="true" />
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="Mi piacerebbe affittare una piscina." GroupName="Radio"
                        AutoPostBack="true" />

                    <br />
                    <br />

                    <asp:Button ID="submitButton" Text="Registrati" CssClass="button" runat="server" OnClick="submitButton_Click" />
                </form>


            </div>
        </div>
    </div>

</asp:Content>
