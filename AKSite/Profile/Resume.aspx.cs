using System.Web.UI;
using System.Web.UI.WebControls;

namespace AKSite.Profile
{
    /// <summary>
    /// Resume show page.
    /// </summary>
    public partial class Resume : Page
    {
        /// <summary>
        /// Resumes the data selected.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs"/> 
        /// instance containing the event data.
        /// </param>
        protected void ResumeDataSelected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            var x = (Model.Resume) e.ReturnValue;
            if (x==null||x.Client.Login != User.Identity.Name)
                Response.Redirect("~/Profile/Default.aspx");
        }
    }
}