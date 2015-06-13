<%@ Page Language="C#" Title="Annuncio" MasterPageFile="~/NoSidebar.Master" AutoEventWireup="true" CodeBehind="Annuncio.aspx.cs" Inherits="Swimmy.Annuncio.Annuncio" %>


<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="HeaderArticleContent">



    <!-- Main -->
    <section>
        <form id="form" runat="server" class="form">
            <h2><a href="#">Annuncio</a></h2>


            <label>Titolo</label>
            <asp:Label ID="titoloLabel" Text="" runat="server" />


            <label>Descrizione</label>
            <asp:Label ID="descrizioneLabel" Text="" runat="server" />



            <label>Email</label>
            <asp:Label ID="emailLabel" Text="" runat="server" />


            <label>Città</label>
            <asp:Label ID="cittaLabel" Text="" runat="server" />

            <label>Indirizzo</label>
            <asp:Label ID="indirizzoLabel" Text="" runat="server" />

            <label>Numero di telefono</label>
            <asp:Label ID="telefonoLabel" Text="" runat="server" />

            <br />

            <br />
            <br />

            <asp:Button ID="submitButton" Text="Torna al tuo profilo" CssClass="button" runat="server" OnClick="submitButton_Click" />
        </form>


    </section>

</asp:Content>
