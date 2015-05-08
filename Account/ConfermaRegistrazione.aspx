<%@ Page Title="Registrazione avvenuta correttamente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfermaRegistrazione.aspx.cs" Inherits="Swimmy.Account.ConfermaRegistrazione" %>



<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">

    <!-- Main -->
    <div class="wrapper style1">

        <div class="container">
            <form id="form1" runat="server">
                <h2><a href="#">Registrazione avvenuta correttamente</a></h2>

                <div>
                    <p>Registrazione effettuata con successo, appena tutti i servizi saranno disponibili sarai avvisato tramite email.</p>
                    <br />
                    <asp:Button ID="redirectToIndex" Text="OK" runat="server" OnClick="redirectToIndex_Click" />

                </div>
            </form>
        </div>

    </div>


</asp:Content>


