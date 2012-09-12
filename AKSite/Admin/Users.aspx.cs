using System.Web.UI.WebControls;
using BusinessLogic;

namespace AKSite.Admin
{
    /// <summary>
    /// User control page.
    /// </summary>
    public partial class Users : System.Web.UI.Page
    {
        /// <summary>
        /// Protects the password.
        /// </summary>
        /// <param name="str">The STR.</param>
        protected string ProtectPassword(object str)
        {
            return new string('*', str.ToString().Length);
        }

        /// <summary>
        /// Userses the view item updating.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.Web.UI.WebControls.ListViewUpdateEventArgs"/> 
        /// instance containing the event data.</param>
        protected void UsersViewItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            var value = (DropDownList)usersView.EditItem.FindControl("Roles");
            e.NewValues.Add("Privilegy", value.Text);
            if (e.OldValues["Login"].ToString()!=e.NewValues["Login"].ToString()&&
                ClientService.IsExist(e.NewValues["Login"].ToString()))
                e.Cancel = true;
        }

        /// <summary>
        /// Userses the view sorting.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.Web.UI.WebControls.ListViewSortEventArgs"/> 
        /// instance containing the event data.</param>
        protected void UsersViewSorting(object sender, ListViewSortEventArgs e)
        {
            if (ClientsSource.SelectParameters[0].DefaultValue == null ||
                ClientsSource.SelectParameters[1].DefaultValue == null ||
                ClientsSource.SelectParameters[0].DefaultValue != e.SortExpression ||
                ClientsSource.SelectParameters[1].DefaultValue == "Desc")
            {
                ClientsSource.SelectParameters[1].DefaultValue = "Asce";
            }
            else if (ClientsSource.SelectParameters[1].DefaultValue == "Asce")
            {
                ClientsSource.SelectParameters[1].DefaultValue = "Desc";

            }

            ClientsSource.SelectParameters[0].DefaultValue = e.SortExpression;
            e.Cancel = true;
        }
    }
}
