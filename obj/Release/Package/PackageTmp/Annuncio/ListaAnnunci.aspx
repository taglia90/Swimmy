<%@ Page Language="C#" Title="Lista annunci" MasterPageFile="~/NoSidebar.Master" AutoEventWireup="true" CodeBehind="ListaAnnunci.aspx.cs" Inherits="Swimmy.Annuncio.ListaAnnunci" %>


<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="HeaderArticleContent">

    <!-- Main -->
    <section>
        <form id="form" runat="server" class="form">
            <h2><a href="#">Lista annunci</a></h2>

            <asp:ListView ID="listaAnnunciView" runat="server">


                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>Nessun annuncio trovato.</td>
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
                                    <a href="./Annuncio.aspx?idAnnuncio=<%#Eval("IdAnnuncio")%>">
                                        <img src="<%#Eval("UrlFotoPrincipale")%>"
                                            width="100" height="75" style="border: solid" /></a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="./Annuncio.aspx?idAnnuncio=<%#Eval("IdAnnuncio")%>">
                                        <span>
                                            <%#Eval("Titolo")%>
                                        </span>
                                    </a>
                                    <br />
                                    <span>
                                        <!-- <b>Price: </b><#:String.Format("{0:c}", Item.UnitPrice)%>-->
                                    </span>
                                    <br />
                                </td>
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


            <br />
            <br />

            <asp:Button ID="submitButton" Text="Torna al tuo profilo" CssClass="button" runat="server" OnClick="submitButton_Click" />
        </form>
    </section>

</asp:Content>
