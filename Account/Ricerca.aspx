<%@ Page Title="Ricerca" Language="C#" MasterPageFile="~/NoSidebar.Master" AutoEventWireup="true" CodeBehind="Ricerca.aspx.cs" Inherits="Swimmy.Account.Ricerca" %>

<asp:Content runat="server" ID="HeaderArticleContent" ContentPlaceHolderID="HeaderArticleContent">



    <!-- Main -->
    <section>
        <form id="form" runat="server" class="form">
            <h2><a href="#">Ricerca</a></h2>


            <label>Regione</label>
            <asp:DropDownList ID="regioneDDL" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="popolaProvinciaDDL">
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



            <label>Provincia</label>
            <asp:DropDownList ID="provinciaDDL" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="submitButton_Click">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="provinciaDDL"
                runat="server" />


            <label>Inserisci una città:</label>
            <asp:TextBox ID="txtCitta" Text="" runat="server" />
            <asp:RegularExpressionValidator ID="txtCittaExprValidator" runat="server"
                ControlToValidate="txtCitta" ErrorMessage="Città non valida. È vietato inserire caratteri speciali."
                ValidationExpression="^([a-zA-Z\xE0\xE8\xE9\xF9\xF2\xEC\x27]\s?)+$" ForeColor="Red" />


            <br />
            <br />

            <asp:Button ID="submitButton" Text="Cerca" CssClass="button" runat="server" OnClick="submitButton_Click" />
        </form>
        <br />
        <br />
        <asp:Label Visible="false" ID="lblRisultato" Text="Ecco tutte le piscine disponibili nella zona selezionata:" runat="server"></asp:Label>
        <br />
        <br />
        <asp:ListView ID="listaAnnunciView" runat="server">
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td>Nessun risultato trovato.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <EmptyItemTemplate>
                <td>
                <td />
            </EmptyItemTemplate>
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td runat="server">
                    <table>
                        <tr>
                            <td>
                                <a href="../Annuncio/Annuncio.aspx?idAnnuncio=<%#Eval("IdAnnuncio")%>">
                                    <img src="<%#"http://www.swimmy.it/"+Eval("UrlFotoPrincipale")%>"
                                        width="320" height="240" style="border: solid" /></a>
                            </td>

                        </tr>
                        <td>

                            <a href="../Annuncio/Annuncio.aspx?idAnnuncio=<%#Eval("IdAnnuncio")%>">
                                <span>
                                    <b>
                                        <%#Eval("Titolo")%>
                                    </b>
                                </span>
                            </a>
                            <br />
                            <a href="../Annuncio/Annuncio.aspx?idAnnuncio=<%#Eval("IdAnnuncio")%>">
                                <span>
                                    <%#Eval("Descrizione")%>
                                </span>
                            </a>

                        </td>
                        <tr>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    </p>
                </td>
            </ItemTemplate>
            <LayoutTemplate>
                <table style="width: 100%;">
                    <tbody>
                        <tr>
                            <td>
                                <table id="groupPlaceholderContainer" runat="server" style="width: 100%">
                                    <tr id="groupPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr></tr>
                    </tbody>
                </table>
            </LayoutTemplate>
        </asp:ListView>

    </section>

</asp:Content>
