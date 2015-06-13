<%@ Page Language="C#" Title="Registrazione" MasterPageFile="~/NoSidebar.Master" AutoEventWireup="true" CodeBehind="InserisciAnnuncio.aspx.cs" Inherits="Swimmy.Account.InserisciAnnuncio" %>





<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="HeaderArticleContent">



    <!-- Main -->   
    <section>
        <form id="form" runat="server" class="form">
            <h2><a href="#">Inserisci annuncio</a></h2>


            <label>Titolo</label>
            <asp:TextBox ID="txtTitolo" Text="" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtTitolo"
                runat="server" />
            <asp:RegularExpressionValidator ID="txtTitoloExprValidator" runat="server"
                ControlToValidate="txtTitolo" ErrorMessage="Titolo non valido. È vietato inserire caratteri speciali."
                ValidationExpression="^([a-zA-Z\xE0\xE8\xE9\xF9\xF2\xEC\x27]\s?)+$" ForeColor="Red" />


            <label>Descrizione</label>
            <asp:TextBox ID="txtDescrizione" Text="" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtDescrizione"
                runat="server" />
            <asp:RegularExpressionValidator ID="txtDescrizioneExprValidator" runat="server"
                ControlToValidate="txtDescrizione" ErrorMessage="Descrizione non valida. È vietato inserire caratteri speciali."
                ValidationExpression="^([a-zA-Z\xE0\xE8\xE9\xF9\xF2\xEC\x27]\s?)+$" ForeColor="Red" />
          
            <label>Città</label>
            <asp:TextBox ID="txtCitta" Text="" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtCitta"
                runat="server" />
              <asp:RegularExpressionValidator ID="txtCittaExprValidator" runat="server"
                ControlToValidate="txtCitta" ErrorMessage="Città non valida. È vietato inserire caratteri speciali."
                ValidationExpression="^([a-zA-Z\xE0\xE8\xE9\xF9\xF2\xEC\x27]\s?)+$" ForeColor="Red" />
          <br />
            <label>Indirizzo</label>
            <asp:TextBox ID="txtIndirizzo" Text="" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtIndirizzo"
                runat="server" />
              <asp:RegularExpressionValidator ID="txtIndirizzoExprValidator" runat="server"
                ControlToValidate="txtIndirizzo" ErrorMessage="Indirizzo non valido. È vietato inserire caratteri speciali."
                ValidationExpression="^([0-9a-zA-Z\xE0\xE8\xE9\xF9\xF2\xEC\x27]\s?)+$" ForeColor="Red" />
          <br />
            
            <label>Numero di telefono</label>
            <asp:TextBox ID="txtTelefono" Text="" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtTelefono"
                runat="server" />
              <asp:RegularExpressionValidator ID="txtTelefonoExprValidator" runat="server"
                ControlToValidate="txtTelefono" ErrorMessage="Numero di telefono non valido."
                ValidationExpression="^([0-9]\s?)+$" ForeColor="Red" />
          <br />
            <br />
            <br />

            <asp:Button ID="submitButton" Text="Inserisci annuncio" CssClass="button" runat="server" OnClick="submitButton_Click" />
        </form>


    </section>

</asp:Content>
