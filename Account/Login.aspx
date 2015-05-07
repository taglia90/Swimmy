<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Swimmy.Account.Login" %>



<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">



    <!-- Main -->
    <div class="wrapper style1">

        <div class="container">
            <form id="form1" runat="server">
                <h2><a href="#">Login</a></h2>
                <p>Username</p>
                <asp:TextBox ID="txtUsername" Text="" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtUsername"
                    runat="server" />

                <p>Password</p>
                <asp:TextBox ID="txtPassword" Text="" TextMode="Password" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                    runat="server" />
                
                <br />
                <br />
                <asp:Button ID="submitButton" Text="Accedi" runat="server" OnClick="submitButton_Click" />
            </form>



        </div>

    </div>


</asp:Content>
