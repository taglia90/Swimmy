<%@ Page Language="C#" Title="Annuncio" MasterPageFile="~/NoSidebar.Master" AutoEventWireup="true" CodeBehind="Annuncio.aspx.cs" Inherits="Swimmy.Annuncio.Annuncio" %>


<asp:Content runat="server" ID="Script" ContentPlaceHolderID="ScriptPlaceHolder">
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <link rel="stylesheet" href="../ImageSlider/css/responsiveslides.css">
    <link rel="stylesheet" href="../ImageSlider/css/themes.css">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="../ImageSlider/js/responsiveslides.min.js"></script>
    <script>
        // You can also use "$(window).load(function() {"
        $(function () {

            // Slideshow 1
            $("#slider1").responsiveSlides({
                auto: false,
                pager: true,
                nav: true,
                speed: 500,
                maxwidth: 800,
                namespace: "centered-btns"
            });

            // Slideshow 2
            $("#slider2").responsiveSlides({
                auto: true,
                pager: true,
                nav: true,
                speed: 500,
                maxwidth: 800,
                namespace: "transparent-btns"
            });

            // Slideshow 3
            $("#slider3").responsiveSlides({
                auto: false,
                pager: false,
                nav: true,
                speed: 500,
                maxwidth: 800,
                namespace: "large-btns"
            });

        });
    </script>

</asp:Content>


<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="HeaderArticleContent">


    <header>
        <!--<label>Titolo</label>-->
        <h2>
            <asp:Label ID="titoloLabel" Text="" runat="server" />
        </h2>

    </header>


    <div class="rslides_container">

        <ul class="rslides" id="slider2">

            <asp:Repeater ID="foto" runat="server">
                <ItemTemplate>
                    <li>
                        <a href="#" class="image featured">
                            <img src="<%# "http://www.swimmy.it/" + Container.DataItem %>" alt="" /></a>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
            <!-- <li>
                        <img src="../images/pic07.jpg" alt=""></li>
                    <li>
                        <img src="../images/pic08.jpg" alt=""></li>
                    <li>
                        <img src="../images/pic09.jpg" alt=""></li>-->
        </ul>
    </div>

    <section>
        <header>
            <h3>Descrizione</h3>
        </header>
        <p>
            <asp:Label ID="descrizioneLabel" Text="" runat="server" />
        </p>
    </section>
    <section>
        <header>
            <h3>Email</h3>
        </header>
        <p>
            <asp:Label ID="emailLabel" Text="" runat="server" />
        </p>
    </section>
    <section>
        <header>
            <h3>Città</h3>
        </header>
        <p>
            <asp:Label ID="cittaLabel" Text="" runat="server" />

        </p>
    </section>
    <section>
        <header>
            <h3>Indirizzo</h3>
        </header>
        <p>
            <asp:Label ID="indirizzoLabel" Text="" runat="server" />

        </p>
    </section>
    <section>
        <header>
            <h3>Descrizione</h3>
        </header>
        <p>
            <asp:Label ID="telefonoLabel" Text="" runat="server" />

        </p>
    </section>
    <section>

        <%if (isLoggato)
          { %>
        <asp:Button ID="submitButton" Text="Torna al tuo profilo" CssClass="button" runat="server" OnClick="submitButton_Click" />
        <%}
          else
          { %>
        <a id="registerLink" runat="server" class="button" href="~/Registrazione.aspx">Esegui registrazione</a>
        <br />
        <br />
        <a id="loginLink" runat="server" class="button" href="~/Account/Login.aspx">Accedi</a>

        <%} %>
    </section>

</asp:Content>
