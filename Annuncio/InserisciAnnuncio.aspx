<%@ Page Language="C#" Title="Registrazione" MasterPageFile="~/NoSidebar.Master" AutoEventWireup="true" CodeBehind="InserisciAnnuncio.aspx.cs" Inherits="Swimmy.Account.InserisciAnnuncio" %>





<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="HeaderArticleContent">



    <!-- Main -->
    <section>
        <form id="form" runat="server" class="form">
            <h2><a href="#">Inserisci annuncio</a></h2>


            <label>Titolo</label>
            <asp:TextBox ID="txtTitolo" Text="" runat="server" Width="500px" />
            <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtTitolo"
                runat="server" />
            <asp:RegularExpressionValidator ID="txtTitoloExprValidator" runat="server"
                ControlToValidate="txtTitolo" ErrorMessage="Titolo non valido. È vietato inserire caratteri speciali."
                ValidationExpression="^([a-zA-Z\xE0\xE8\xE9\xF9\xF2\xEC\x27\x2C\x2E]\s?)+$" ForeColor="Red" />


            <label>Descrizione</label>
            <asp:TextBox ID="txtDescrizione" Text="" runat="server" Height="300" TextMode="MultiLine"/>
            <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtDescrizione"
                runat="server" />
            <asp:RegularExpressionValidator ID="txtDescrizioneExprValidator" runat="server"
                ControlToValidate="txtDescrizione" ErrorMessage="Descrizione non valida. È vietato inserire caratteri speciali."
                ValidationExpression="^([0-9a-zA-Z\xE0\xE8\xE9\xF9\xF2\xEC\x27]\r?\n?\s?)+$" ForeColor="Red" />

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
            <br />

            <label>Provincia</label>
            <asp:DropDownList ID="provinciaDDL" runat="server" Width="200px">
            </asp:DropDownList>
            <br />

            <label>Città</label>
            <asp:TextBox ID="txtCitta" Text="" runat="server" Width="500" />
            <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtCitta"
                runat="server" />
            <asp:RegularExpressionValidator ID="txtCittaExprValidator" runat="server"
                ControlToValidate="txtCitta" ErrorMessage="Città non valida. È vietato inserire caratteri speciali."
                ValidationExpression="^([a-zA-Z\xE0\xE8\xE9\xF9\xF2\xEC\x27]\s?)+$" ForeColor="Red" />
            <br />
            <label>Indirizzo</label>
            <asp:TextBox ID="txtIndirizzo" Text="" runat="server" Width="700" />
            <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtIndirizzo"
                runat="server" />
            <asp:RegularExpressionValidator ID="txtIndirizzoExprValidator" runat="server"
                ControlToValidate="txtIndirizzo" ErrorMessage="Indirizzo non valido. È vietato inserire caratteri speciali."
                ValidationExpression="^([0-9a-zA-Z\xE0\xE8\xE9\xF9\xF2\xEC\x27\x2C]\s?)+$" ForeColor="Red" />
            <br />

            <label>Numero di telefono</label>
            <asp:TextBox ID="txtTelefono" Text="" runat="server" Width="200" />
            <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtTelefono"
                runat="server" />
            <asp:RegularExpressionValidator ID="txtTelefonoExprValidator" runat="server"
                ControlToValidate="txtTelefono" ErrorMessage="Numero di telefono non valido."
                ValidationExpression="^([0-9]\s?)+$" ForeColor="Red" />
            <br />

            <label>Inserisci foto</label>
            <asp:FileUpload ID="fuUpload" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="btnUpload_Click" /><br />
            <br />
            <asp:Label ID="lblStatus" Style="color: Red;" Text="&nbsp;" runat="server" />

            <asp:Button ID="btnDelete" Text="Elimina foto" runat="server" OnClick="btnDelete_Click" /><br />
            <br />
            <asp:Repeater ID="rptrUserPhotos" runat="server">
                <ItemTemplate>
                    <span class="saucer" style="float: left; padding: 15px;">
                        <asp:ImageButton OnCommand="imgUserPhoto_Command" CommandArgument="<%# Container.DataItem %>" ImageUrl="<%# Container.DataItem %>" ID="imgUserPhoto" Style="width: 100px; height: 100px;" runat="server" alt="" /><br />
                        <asp:CheckBox special="<%# Container.DataItem %>" ID="cbDelete" Text="Elimina" runat="server" /><br />
                    </span>
                </ItemTemplate>
            </asp:Repeater>
            <br />
            <br />
            <br />

            <asp:Button ID="submitButton" Text="Inserisci annuncio" CssClass="button" runat="server" OnClick="submitButton_Click" />
        </form>


    </section>

</asp:Content>
