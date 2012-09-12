using System;
using System.Web.UI;
using BusinessLogic.Error;

namespace AKSite.Error
{
    /// <summary>
    /// Show custom Error page
    /// </summary>
    public partial class CustomError : Page
    {
        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event to initialize the page.
        /// </summary>
        /// <param name="e">
        /// An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Load += CustomErrorPageLoad;
        }
        /// <summary>
        /// Customs the error page load.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void CustomErrorPageLoad(object sender, EventArgs e)
        {
            var exception = (CustomException)Page.Session["LastError"];
            if (exception == null)
                return;
            titleErorr.Text = exception.Message;
            descriptionError.Text = exception.Description;
        }
    }
}