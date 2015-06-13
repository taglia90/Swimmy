<%@ Page Title="Login" Language="C#" MasterPageFile="~/NoSidebar.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Swimmy.Account.Login" %>



<asp:Content runat="server" ID="HeaderArticleContent" ContentPlaceHolderID="HeaderArticleContent">



    <!-- Main -->
    <div class="wrapper style1">

        <div class="container">
             <form id="form1" runat="server">
                  <asp:CustomValidator runat="server" ControlToValidate="txtUsername" ErrorMessage="Email o password errati."
                OnServerValidate="controllaAccesso" ForeColor="Red" />

                <h2><a href="#">Login</a></h2>
                <p>Email</p>
                <asp:TextBox ID="txtUsername" Text="" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtUsername"
                    runat="server" />

                <p>Password</p>
                <asp:TextBox ID="txtPassword" Text="" TextMode="Password" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtPassword"
                    runat="server" />

                <br />
                <br />
                <asp:Button ID="submitButton" Text="Accedi" runat="server" OnClick="submitButton_Click" />
            </form>



        </div>

    </div>


</asp:Content>
