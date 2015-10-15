﻿<%@ Page Title="Login" Language="C#" MasterPageFile="~/NoSidebar.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Swimmy.Account.Login" %>

<asp:Content runat="server" ID="HeaderArticleContent" ContentPlaceHolderID="HeaderArticleContent">
     <!--Facebook script-->
    <script>
        // This is called with the results from from FB.getLoginStatus().
        function statusChangeCallback(response) {
            console.log('statusChangeCallback');
            console.log(response);
            // The response object is returned with a status field that lets the
            // app know the current login status of the person.
            // Full docs on the response object can be found in the documentation
            // for FB.getLoginStatus().
            if (response.status === 'connected') {
                // Logged into your app and Facebook.
                testAPI();
            } else if (response.status === 'not_authorized') {
                // The person is logged into Facebook, but not your app.
                document.getElementById('status').innerHTML = 'Please log ' +
                  'into this app.';
                FB.login(function (response) {
                    // handle the response
                }, {
                    scope: 'publish_actions,email',
                    return_scopes: true
                });
            } else {
                // The person is not logged into Facebook, so we're not sure if
                // they are logged into this app or not.
                document.getElementById('status').innerHTML = 'Please log ' +
                  'into Facebook.';
                FB.login(function (response) {
                    // handle the response
                }, {
                    scope: 'publish_actions,email',
                    return_scopes: true
                });
            }
        }

        // This function is called when someone finishes with the Login
        // Button.  See the onlogin handler attached to it in the sample
        // code below.
        function checkLoginState() {
            FB.getLoginStatus(function (response) {
                statusChangeCallback(response);
            });
        }

        window.fbAsyncInit = function () {
            FB.init({
                appId: '1625471347674242',
                cookie: true,  // enable cookies to allow the server to access 
                // the session
                xfbml: true,  // parse social plugins on this page
                version: 'v2.4' // use version 2.4
            });

            // Now that we've initialized the JavaScript SDK, we call 
            // FB.getLoginStatus().  This function gets the state of the
            // person visiting this page and can return one of three states to
            // the callback you provide.  They can be:
            //
            // 1. Logged into your app ('connected')
            // 2. Logged into Facebook, but not your app ('not_authorized')
            // 3. Not logged into Facebook and can't tell if they are logged into
            //    your app or not.
            //
            // These three cases are handled in the callback function.

            FB.getLoginStatus(function (response) {
                statusChangeCallback(response);
            });

            FB.login(function (response) {
                // handle the response
            }, {
                scope: 'publish_actions,email',
                return_scopes: true
            });
        };

        // Load the SDK asynchronously
        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/it_IT/sdk.js";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));

        // Here we run a very simple test of the Graph API after login is
        // successful.  See statusChangeCallback() for when this call is made.
        function testAPI() {
            console.log('Welcome!  Fetching your information.... ');
            FB.api('/me?fields=name,email', function (response) {
                console.log('Successful login for: ' + response.name);
                document.getElementById('status').innerHTML =
                  'Thanks for logging in, ' + response.email + '!';
            });
            //qua devo chiamare loginFacebook() e passargli i dati
        }
    </script>


    <!-- Main -->
    <div class="wrapper style1">
        <div class="container">
            <div class="containerMini">
                <form id="form1" runat="server" class="formMini">
                    <h2>Login</h2>

                    <asp:CustomValidator runat="server" ControlToValidate="txtUsername" ErrorMessage="Email o password errati."
                        OnServerValidate="controllaAccesso" ForeColor="Red" />
                    <asp:TextBox ID="txtUsername" Text="" runat="server" CssClass="textArea" />
                    <asp:RequiredFieldValidator ErrorMessage="Campo obbligatorio" ForeColor="Red" ControlToValidate="txtUsername"
                        runat="server" />

                    <asp:TextBox ID="txtPassword" Text="" TextMode="Password" runat="server" CssClass="textArea" />
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

                    <!--<div id="status"></div>-->
                </form>
            </div>
        </div>
    </div>

</asp:Content>
