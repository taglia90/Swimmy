<%@ Page Title="Ricerca" Language="C#" MasterPageFile="~/NoSidebar.Master" AutoEventWireup="true" CodeBehind="Ricerca.aspx.cs" Inherits="Swimmy.Account.Ricerca" %>

<asp:Content runat="server" ID="HeaderArticleContent" ContentPlaceHolderID="HeaderArticleContent">


    <form id="form" runat="server" class="form">
        <h2><a href="#">Ricerca</a></h2>


        <!-- Main -->


        <div class="row">
            <article class="4u special">

                <!--<label>Regione</label>-->
                <asp:DropDownList ID="regioneDDL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="popolaProvinciaDDL">
                    <asp:ListItem Text="--Inserisci la regione--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Abruzzo" Value="Abruzzo"></asp:ListItem>
                    <asp:ListItem Text="Basilicata" Value="Basilicata"></asp:ListItem>
                    <asp:ListItem Text="Calabria" Value="Calabria"></asp:ListItem>
                    <asp:ListItem Text="Campania" Value="Campania"></asp:ListItem>
                    <asp:ListItem Text="Emilia-Romagna" Value="Emilia-Romagna"></asp:ListItem>
                    <asp:ListItem Text="Friuli-Venezia Giulia" Value="Friuli-Venezia Giulia"></asp:ListItem>
                    <asp:ListItem Text="Lazio" Value="Lazio"></asp:ListItem>
                    <asp:ListItem Text="Liguria" Value="Liguria"></asp:ListItem>
                    <asp:ListItem Text="Lombardia" Value="Lombardia"></asp:ListItem>
                    <asp:ListItem Text="Marche" Value="Marche"></asp:ListItem>
                    <asp:ListItem Text="Molise" Value="Molise"></asp:ListItem>
                    <asp:ListItem Text="Piemonte" Value="Piemonte"></asp:ListItem>
                    <asp:ListItem Text="Puglia" Value="Puglia"></asp:ListItem>
                    <asp:ListItem Text="Sardegna" Value="Sardegna"></asp:ListItem>
                    <asp:ListItem Text="Sicilia" Value="Sicilia"></asp:ListItem>
                    <asp:ListItem Text="Toscana" Value="Toscana"></asp:ListItem>
                    <asp:ListItem Text="Trentino-Alto Adige" Value="Trentino-Alto Adige"></asp:ListItem>
                    <asp:ListItem Text="Umbria" Value="Umbria"></asp:ListItem>
                    <asp:ListItem Text="Valle d'Aosta" Value="Valle d'Aosta"></asp:ListItem>
                    <asp:ListItem Text="Veneto" Value="Veneto"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="regioneDDL"
                    runat="server" />
            </article>
            <article class="4u special">
                <!--<label>Provincia</label>-->
                <asp:DropDownList ID="provinciaDDL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="submitButton_Click">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="provinciaDDL"
                    runat="server" />
            </article>
            <article class="4u special">
                <!--<label>Inserisci una città:</label>-->
                <asp:TextBox ID="txtCitta" Text="" runat="server" />
                <asp:RegularExpressionValidator ID="txtCittaExprValidator" runat="server"
                    ControlToValidate="txtCitta" ErrorMessage="Città non valida. È vietato inserire caratteri speciali."
                    ValidationExpression="^([a-zA-Z\xE0\xE8\xE9\xF9\xF2\xEC\x27]\s?)+$" ForeColor="Red" />

            </article>
        </div>


        <asp:Button ID="submitButton" Text="Cerca" CssClass="button" runat="server" OnClick="submitButton_Click" />
    </form>
    <br />
    <!--Lista risultati-->
    <asp:Label Visible="false" ID="lblRisultato" Text="Ecco tutte le piscine disponibili nella zona selezionata:" runat="server"></asp:Label>
    <br />

    <asp:ListView ID="listaAnnunciView" runat="server" GroupItemCount="3">
        <EmptyDataTemplate>
            <article class="4u special">
                <header>
                    <h3>Nessun risultato trovato</h3>
                </header>
            </article>
        </EmptyDataTemplate>
        <EmptyItemTemplate>
            <div></div>
        </EmptyItemTemplate>

        <LayoutTemplate>
            <div class="row" id="groupPlaceholderContainer" runat="server">
                <div id="groupPlaceholder" runat="server"></div>
            </div>

        </LayoutTemplate>
        <GroupTemplate>
            <div id="itemPlaceholderContainer" runat="server">
                <div id="itemPlaceholder" runat="server"></div>
            </div>
        </GroupTemplate>
        <ItemTemplate>
            <div runat="server">
                <article class="4u special">
                    <a href="../Annuncio/Annuncio.aspx?idAnnuncio=<%#Eval("IdAnnuncio")%>" class="image featured">
                        <img src="<%#"http://www.swimmy.it/"+Eval("UrlFotoPrincipale")%>" alt="" /></a>
                    <header>
                        <h3><a href="../Annuncio/Annuncio.aspx?idAnnuncio=<%#Eval("IdAnnuncio")%>"><%#Eval("Titolo")%></a></h3>
                    </header>
                    <p>
                        <a href="../Annuncio/Annuncio.aspx?idAnnuncio=<%#Eval("IdAnnuncio")%>">
                            <span>
                                <%#Eval("Descrizione")%>
                            </span>
                        </a>
                    </p>
                </article>

            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
