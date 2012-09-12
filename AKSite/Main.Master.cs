using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AKSite
{
    /// <summary>
    /// Main app master page, show single page without the left collumn.
    /// </summary>
    public partial class Main : MasterPage
    {
        /// <summary>
        /// Mains the menu menu item data bound.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.Web.UI.WebControls.MenuEventArgs"/> 
        /// instance containing the event data.</param>
        protected void MainMenuMenuItemDataBound(object sender, MenuEventArgs e)
        {
            if (SiteMap.CurrentNode == null || SiteMap.CurrentNode.ParentNode == null) return;

            if (e.Item.Text == SiteMap.CurrentNode.ParentNode.Title)
            {
                e.Item.Selected = true;
            }
        }
    }
}