<%@ Page Title="Profilo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profilo.aspx.cs" Inherits="Swimmy.Account.Profilo" %>
<%@ Page Title="Profilo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profilo.aspx.cs" Inherits="Swimmy.Account.Profilo" %>



<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">

    <!-- Main -->
    <div class="wrapper style1">

        <div class="container">
            <form id="form1" runat="server">
                <h2><a href="#">Profilo</a></h2>

                <div>
                    <p>Ciao!</p>
                    <asp:Label ID="userLabel" Text="No User" runat="server" />
                    <p>Grazie per esserti registrato. Il sito è ancora in costruzione, ti invieremo una mail non appena sarà tutto pronto!</p>
                    <br />
                    <asp:Button ID="logoutButton" Text="LogOut" runat="server" OnClick="logoutButton_Click" />

                </div>
            </form>
        </div>

    </div>


</asp:Content>


