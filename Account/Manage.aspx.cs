using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNet.Membership.OpenAuth;

namespace Swimmy.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        protected bool CanRemoveExternalLogins
        {
            get;
            private set;
        }

        protected void Page_Load()
        {
            if (!IsPostBack)
            {
                // Determinare le sezioni di cui eseguire il rendering
                var hasLocalPassword = OpenAuth.HasLocalPassword(User.Identity.Name);
                setPassword.Visible = !hasLocalPassword;
                changePassword.Visible = hasLocalPassword;

                CanRemoveExternalLogins = hasLocalPassword;

                // Messaggio di completamento del rendering
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Rimuovere la stringa di query dall'azione
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Cambiamento password completato."
                        : message == "SetPwdSuccess" ? "Impostazione password completata."
                        : message == "RemoveLoginSuccess" ? "L'account di accesso esterno è stato rimosso."
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }

        }

        protected void setPassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var result = OpenAuth.AddLocalPassword(User.Identity.Name, password.Text);
                if (result.IsSuccessful)
                {
                    Response.Redirect("~/Account/Manage?m=SetPwdSuccess");
                }
                else
                {

                    ModelState.AddModelError("NewPassword", result.ErrorMessage);

                }
            }
        }


        public IEnumerable<OpenAuthAccountData> GetExternalLogins()
        {
            var accounts = OpenAuth.GetAccountsForUser(User.Identity.Name);
            CanRemoveExternalLogins = CanRemoveExternalLogins || accounts.Count() > 1;
            return accounts;
        }

        public void RemoveExternalLogin(string providerName, string providerUserId)
        {
            var m = OpenAuth.DeleteAccount(User.Identity.Name, providerName, providerUserId)
                ? "?m=RemoveLoginSuccess"
                : String.Empty;
            Response.Redirect("~/Account/Manage" + m);
        }


        protected static string ConvertToDisplayDateTime(DateTime? utcDateTime)
        {
            // È possibile modificare questo metodo per convertire la data e l'ora UTC in base all'offset e nel formato
            // di visualizzazione desiderati. In questo caso viene eseguita la conversione in base al fuso orario del server e nel formato
            // di data breve e ora estesa, secondo le impostazioni cultura del thread corrente.
            return utcDateTime.HasValue ? utcDateTime.Value.ToLocalTime().ToString("G") : "[mai]";
        }
    }
}