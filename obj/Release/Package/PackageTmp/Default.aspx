<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Swimmy.Default" %>



<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">


    <!-- Features -->

    <header>
        <h2>
            <asp:Literal ID="Literal7" runat="server" Text="<%$Resources:language, homeTitolo%>" /></h2>
        <p>
            <asp:Literal ID="Literal4" runat="server" Text="<%$Resources:language, homeSottotitolo1%>" /></p>
        <p>
            <asp:Literal ID="Literal5" runat="server" Text="<%$Resources:language, homeSottotitolo2%>" />
        </p>
    </header>
    <footer>

        <a id="registerLink" runat="server" class="button" href="~/Registrazione.aspx">
            <asp:Literal ID="Literal1" runat="server" Text="<%$Resources:language, mnuRegistrati%>" /></a>
        <a id="loginLink" runat="server" class="button" href="~/Account/Login.aspx">
            <asp:Literal ID="Literal2" runat="server" Text="<%$Resources:language, mnuAccedi%>" /></a>
        <a id="ricercaLink" runat="server" class="button" href="~/Account/Ricerca.aspx">
            <asp:Literal ID="Literal3" runat="server" Text="<%$Resources:language, mnuCerca%>" /></a>
    </footer>
    <br />
    <div class="row">
        <article class="4u special">
            <a href="#" class="image featured">
                <img src="./Images/pic07.jpg" alt="" /></a>
            <header>
                <h3><a href="#"><asp:Literal ID="Literal6" runat="server" Text="<%$Resources:language, homeDescrizione10%>" /></a></h3>
            </header>
            <p><asp:Literal ID="Literal8" runat="server" Text="<%$Resources:language, homeDescrizione11%>" />
               
            </p>
        </article>
        <article class="4u special">
            <a href="#" class="image featured">
                <img src="./Images/pic08.jpg" alt="" /></a>
            <header>
                <h3><a href="#"><asp:Literal ID="Literal9" runat="server" Text="<%$Resources:language, homeDescrizione20%>" /></a></h3>
            </header>
            <p><asp:Literal ID="Literal10" runat="server" Text="<%$Resources:language, homeDescrizione21%>" />
               
            </p>
        </article>
        <article class="4u special">
            <a href="#" class="image featured">
                <img src="./Images/pic09.jpg" alt="" /></a>
            <header>
                <h3><a href="#"><asp:Literal ID="Literal11" runat="server" Text="<%$Resources:language, homeDescrizione30%>" /></a></h3>
            </header>
            <p><asp:Literal ID="Literal12" runat="server" Text="<%$Resources:language, homeDescrizione31%>" />
                
            </p>
        </article>
    </div>


</asp:Content>
