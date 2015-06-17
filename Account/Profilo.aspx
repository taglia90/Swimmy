<%@ Page Title="Profilo" Language="C#" MasterPageFile="~/NoSidebar.Master" AutoEventWireup="true" CodeBehind="Profilo.aspx.cs" Inherits="Swimmy.Account.Profilo" %>



<asp:Content runat="server" ID="HeaderArticleContent" ContentPlaceHolderID="HeaderArticleContent">

    <!-- Main -->
    <section>
        <form id="form1" runat="server">
            <h2><a href="#">Profilo</a></h2>

            <div>
                <p>Ciao!</p>
                <asp:Label ID="userLabel" Text="No User" runat="server" />
                <p>Grazie per esserti registrato. Il sito è ancora in costruzione, ma puoi già iniziare a inserire i tuoi annunci!</p>
                <br />
                <asp:Button ID="modificaProfiloButton" Text="Modifica profilo" runat="server" OnClick="modificaProfiloButton_Click" />
                <asp:Button ID="inserisciAnnuncioButton" Text="Inserisci Annuncio" runat="server" OnClick="inserisciAnnuncioButton_Click" />
                <asp:Button ID="ricarcaButton" Text="Effettua una ricera" runat="server" OnClick="ricercaButton_Click" />
                <asp:Button ID="logoutButton" Text="LogOut" runat="server" OnClick="logoutButton_Click" />

            </div>
        </form>

    </section>

</asp:Content>


