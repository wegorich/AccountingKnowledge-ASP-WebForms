using System.Web.UI;

namespace AKSite.Admin
{
    /// <summary>
    /// Show skill contructor.
    /// </summary>
    public partial class Skill : Page
    {
        /// <summary>
        /// Skils the view item inserting.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.Web.UI.WebControls.ListViewInsertEventArgs"/>
        /// instance containing the event data.</param>
        protected void SkilViewItemInserting(object sender, System.Web.UI.WebControls.ListViewInsertEventArgs e)
        {
            if (SkillGroupView.SelectedValue == null||e.Values["Title"]==null)
                e.Cancel = true;
            else
                e.Values.Add("GroupName", SkillGroupView.SelectedValue);
        }

        /// <summary>
        /// Skills the group view item inserting.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.Web.UI.WebControls.ListViewInsertEventArgs"/>
        ///  instance containing the event data.
        /// </param>
        protected void SkillGroupViewItemInserting(object sender, System.Web.UI.WebControls.ListViewInsertEventArgs e)
        {
            if (e.Values["Title"] == null)
                e.Cancel = true;
        }
    }
}