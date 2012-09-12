using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace AKSite.Account
{
    /// <summary>
    /// Remind the user password
    /// </summary>
    public partial class Reminder : Page
    {
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

            var pass = ClientService.GetPassword(loginBlock.Text);
            accessRemind.InnerHtml = "Дорогой пользователь"+
                                                                "мы с радостью помогаем тебе в этот раз, " +
                                                                "но будь внимателен и не забывай свой:<br/>" +
                                                                "<b>пароль:</b> " + pass;
            MultiView.ActiveViewIndex = 1;
        }

        /// <summary>
        /// Custs the validator server validate.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="args">
        /// The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> 
        /// instance containing the event data.</param>
        protected void CustValidatorServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid =ClientService.IsExist(loginBlock.Text) ;
        }
    }
}