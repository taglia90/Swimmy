<%@ Page Title="Ricerca" Language="C#" MasterPageFile="~/NoSidebar.Master" AutoEventWireup="true" CodeBehind="Ricerca.aspx.cs" Inherits="Swimmy.Account.Ricerca" %>

<asp:Content runat="server" ID="HeaderArticleContent" ContentPlaceHolderID="HeaderArticleContent">



    <!-- Main -->
    <section>
        <form id="form" runat="server" class="form">
            <h2><a href="#">Ricerca</a></h2>


               <label>Scegli una regione</label>
            <asp:TextBox ID="TextBox1" Text="" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtProvincia"
                runat="server" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                ControlToValidate="txtProvincia" ErrorMessage="Provincia non valida. È vietato inserire caratteri speciali."
                ValidationExpression="^([a-zA-Z\xE0\xE8\xE9\xF9\xF2\xEC\x27]\s?)+$" ForeColor="Red" />


              <label>Scegli una provincia</label>
            <asp:TextBox ID="txtProvincia" Text="" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtProvincia"
                runat="server" />
            <asp:RegularExpressionValidator ID="txtProvinciaExprValidator" runat="server"
                ControlToValidate="txtProvincia" ErrorMessage="Provincia non valida. È vietato inserire caratteri speciali."
                ValidationExpression="^([a-zA-Z\xE0\xE8\xE9\xF9\xF2\xEC\x27]\s?)+$" ForeColor="Red" />


            <label>Inserisci una città:</label>
            <asp:TextBox ID="txtCitta" Text="" runat="server" />
            <asp:RegularExpressionValidator ID="txtCittaExprValidator" runat="server"
                ControlToValidate="txtCitta" ErrorMessage="Città non valida. È vietato inserire caratteri speciali."
                ValidationExpression="^([a-zA-Z\xE0\xE8\xE9\xF9\xF2\xEC\x27]\s?)+$" ForeColor="Red" />


          

           
            <br />
            <br />

            <asp:Button ID="submitButton" Text="Registrati" CssClass="button" runat="server" OnClick="submitButton_Click" />
        </form>


    </section>

</asp:Content>
