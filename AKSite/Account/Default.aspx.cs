using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace AKSite.Account
{
    /// <summary>
    /// Page for athentification.
    /// </summary>
    public partial class Default : Page
    {
        /// <summary>
        /// Custs the validator server validate.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="args">
        /// The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/>
        /// instance containing the event data.</param>
        protected void CustValidatorServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid =ClientService.IsValid(login.UserLogin, login.UserPass);
        }

        /// <summary>
        /// Sends the click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.
        /// </param>
        protected void SendClick(object sender, EventArgs e)
        {
            if (!Page.IsPostBack || !Page.IsValid) return;

            FormsAuthentication.RedirectFromLoginPage(login.UserLogin, true);
        }
 
    }
}