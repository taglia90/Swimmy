<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Swimmy.Default" %>



<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">


    <!-- Features -->

    <header>
        <h2>Stiamo arrivando!</h2>
        <p>Glu glu glu! Rimani in contatto con noi!</p>
        <p>
            Registrati per essere informato non appena il servizio sarà operativo e per poter essere tra i primi
                     ad usufruire della nostra piattaforma!
        </p>

        <section id="login">
            <asp:LoginView runat="server" ViewStateMode="Disabled">
                <AnonymousTemplate>
                    <ul>
                        <li><a id="registerLink" runat="server" class="button" href="~/Registrazione.aspx">Esegui registrazione</a></li>
                        <br />
                       <!-- <li><a id="loginLink" runat="server" class="button" href="~/Login.aspx">Accedi</a></li>-->
                    </ul>
                </AnonymousTemplate>
                <LoggedInTemplate>
                    <p>
                        Hello, <a runat="server" class="username" href="~/Account/Manage" title="Manage your account">
                            <asp:LoginName runat="server" CssClass="username" />
                        </a>!
                                <asp:LoginStatus runat="server" LogoutAction="Redirect" LogoutText="Disconnetti" LogoutPageUrl="~/" />
                    </p>
                </LoggedInTemplate>
            </asp:LoginView>
        </section>


    </header>
    <div class="row">
        <article class="4u special">
            <a href="#" class="image featured">
                <img src="./Images/pic07.jpg" alt="" /></a>
            <header>
                <h3><a href="#">Guadagna con la tua piscina</a></h3>
            </header>
            <p>
                Swimmy ti aiuta a trovare piccoli gruppi di bagnanti, amici o famiglie, interessati a trascorrere
                         qualche ora di relax nel tuo piccolo paradiso.
            </p>
        </article>
        <article class="4u special">
            <a href="#" class="image featured">
                <img src="./Images/pic08.jpg" alt="" /></a>
            <header>
                <h3><a href="#">Scegli quando ospitare i nuovi swimmer!</a></h3>
            </header>
            <p>
                Grazie all’agenda di Swimmy, gli swimmer potranno prenotare solo nei giorni in cui deciderai di rendere  
                accessibile la tua piscina… e dopo sarai tu a scegliere se accettare le proposte che riceverai!       

            </p>
        </article>
        <article class="4u special">
            <a href="#" class="image featured">
                <img src="./Images/pic09.jpg" alt="" /></a>
            <header>
                <h3><a href="#">E tu dove ti vuoi tuffare?</a></h3>
            </header>
            <p>
                Splash! Vivi con noi questa nuova esperienza… Swimmy ti porta nel mondo delle #HomeSwimmingPool! Prepara  
           infradito e asciugamano, ti stiamo aspettando!

            </p>
        </article>
    </div>


</asp:Content>
