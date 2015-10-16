using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using System;


namespace Swimmy
{

    public class BasePage : System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {
            if (!string.IsNullOrEmpty(Request["lang"]))
            {

                Session["lang"] = Request["lang"];
            }
            string lang = Convert.ToString(Session["lang"]);
            string culture = string.Empty;
             // L'italiano è di default
            if(lang.ToLower().CompareTo("it") == 0 ||string.IsNullOrEmpty(culture))
            {               
				culture = "it-IT";
            }

            if (lang.ToLower().CompareTo("en") == 0 )
            {
                culture = "en-US";
            }
           
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            base.InitializeCulture();
        }
    }
}


