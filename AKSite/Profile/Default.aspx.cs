using System.Web;

namespace AKSite.Profile
{
    /// <summary>
    /// Profile start page
    /// </summary>
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// Resumes the data selecting.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The  <see cref="System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs"/> 
        /// instance containing the event data.
        /// </param>
        protected void ResumeDataSelecting(object sender, System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["login"] = HttpContext.Current.User.Identity.Name;
        }
    }
}