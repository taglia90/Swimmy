<%@ Page Title="Registrazione avvenuta correttamente" Language="C#" MasterPageFile="~/NoSidebar.Master" AutoEventWireup="true" CodeBehind="ConfermaRegistrazione.aspx.cs" Inherits="Swimmy.ConfermaRegistrazione" %>



<asp:Content runat="server" ID="HeaderArticleContent" ContentPlaceHolderID="HeaderArticleContent">

    <!-- Main -->
    <section>
        <form id="form" runat="server">
            <h2><a href="#">Registrazione avvenuta correttamente</a></h2>

            <div>
                <p>Registrazione effettuata con successo, appena tutti i servizi saranno disponibili sarai avvisato tramite email.</p>
                <br />
                <asp:Button ID="redirectToIndex" Text="OK" runat="server" OnClick="redirectToIndex_Click" />

            </div>
        </form>
    </section>

</asp:Content>


