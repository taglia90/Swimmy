<%@ Page Title="Login" Language="C#" MasterPageFile="~/NoSidebar.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Swimmy.Account.Login" %>

<asp:Content runat="server" ID="HeaderArticleContent" ContentPlaceHolderID="HeaderArticleContent">





    <!-- Main -->
    <div class="wrapper style1">
        <div class="container">
            <div class="containerMini">
                <form id="form1" runat="server" class="formMini">
                    <h2>Login</h2>

                    <asp:CustomValidator runat="server" ControlToValidate="txtUsername" ErrorMessage="Email o password errati."
                        OnServerValidate="controllaAccesso" ForeColor="Red" />
                    <asp:TextBox ID="txtUsername" Text="" runat="server" CssClass="textArea"/>
                    <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtUsername"
                        runat="server" />

                    <asp:TextBox ID="txtPassword" Text="" TextMode="Password" runat="server" CssClass="textArea"/>
                    <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtPassword"
                        runat="server" />

                    <br />
                    <asp:Button ID="submitButton" Text="Accedi" runat="server" OnClick="submitButton_Click" />


                    <p>oppure Accedi con Facebook</p>
                    <!--<a href="#" onclick="fb_login();">
                        <img src="images/fb_login_awesome.jpg" border="0" alt=""></a>

                     <fb:login-button scope="public_profile,email" onlogin="checkLoginState();">
</fb:login-button>-->

                    <div class="fb-login-button" data-max-rows="1" data-size="xlarge" data-show-faces="false" data-auto-logout-link="false"></div>

                    <div id="status"></div>
                </form>
            </div>
        </div>
    </div>

</asp:Content>
