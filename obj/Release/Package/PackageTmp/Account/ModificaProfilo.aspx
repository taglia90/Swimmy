<%@ Page Title="Modifica Profilo" Language="C#" MasterPageFile="~/NoSidebar.Master" AutoEventWireup="true" CodeBehind="ModificaProfilo.aspx.cs" Inherits="Swimmy.Account.ModificaProfilo" %>



<asp:Content runat="server" ID="HeaderArticleContent" ContentPlaceHolderID="HeaderArticleContent">

    <section>
        <form id="form" runat="server" class="form">
            <h2><a href="#">Modifica Profilo</a></h2>

            <label>Profilo di: </label>
            <asp:Label ID="userLabel" Text="No User" runat="server" />
            <br />
            <br />

            <label>Email:</label>
            <asp:Label ID="emailLabel" Text="No Email" runat="server" />
            <br />
            <br />

           <!-- <asp:RadioButton ID="RadioButtonMaschio" runat="server" Text="Maschio" GroupName="Radio"
                AutoPostBack="true" Checked="true" />
            <asp:RadioButton ID="RadioButtonFemmina" runat="server" Text="Femmina" GroupName="Radio"
                AutoPostBack="true" />-->

            <br />
            <label>Città</label>
            <asp:TextBox ID="txtCitta" Text="" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtCitta"
                runat="server" />
            <asp:RegularExpressionValidator ID="txtCittaExprValidator" runat="server"
                ControlToValidate="txtCitta" ErrorMessage="Città non valida. È vietato inserire caratteri speciali."
                ValidationExpression="^([a-zA-Z\xE0\xE8\xE9\xF9\xF2\xEC\x27]\s?)+$" ForeColor="Red" />
            <br />
            <label>CAP</label>
            <asp:TextBox ID="txtCap" Text="" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtCap"
                runat="server" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                ControlToValidate="txtCap" ErrorMessage="Cap non valido. È vietato inserire caratteri speciali."
                ValidationExpression="^([0-9]\s?)+$" ForeColor="Red" />

            <br />
            <label>Numero di Telefono</label>
            <asp:TextBox ID="txtNumeroTelefono" Text="" runat="server" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                ControlToValidate="txtNumeroTelefono" ErrorMessage="Cognome non valido. È vietato inserire caratteri speciali."
                ValidationExpression="^([0-9]\s?)+$" ForeColor="Red" />


            <br />
            <br />

            <asp:Button ID="submitButton" Text="Salva" CssClass="button" runat="server" OnClick="submitButton_Click" />
        </form>


    </section>



</asp:Content>


