using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using BusinessLogic;
using Model;

namespace AKSite.Account
{
    /// <summary>
    /// Page for registration
    /// </summary>
    public partial class Register : System.Web.UI.Page
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
            args.IsValid = !ClientService.IsExist(login.UserLogin, emailBlock.Text);
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
            if (!IsPostBack || !IsValid) return;
            ClientService.CreateClient(new Client
            {
                Login = login.UserLogin,
                Pass = login.UserPass,
                Email = emailBlock.Text,
                FirstName = nameBlock.Text,
                SecondName = secondNameBlock.Text,
                PhoneNumber = phoneNumber.Text,
                BirthDay = birthDay.GetDate,
                Privilegy = "User"
            });

            FormsAuthentication.RedirectFromLoginPage(login.UserLogin, true);
        }
    }
}