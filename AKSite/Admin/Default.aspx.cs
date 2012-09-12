using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AKSite.Admin
{
    /// <summary>
    /// Default page for admin, show field constructor
    /// </summary>
    public partial class Default : Page
    {
        private string _selectedValue;
        private int _selectedId;

        /// <summary>
        /// Themes the view item updating.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.Web.UI.WebControls.ListViewUpdateEventArgs"/>
        /// instance containing the event data.</param>
        protected void ThemeViewItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            var value = (DropDownList)ThemeView.EditItem.FindControl("editGroup");
            e.NewValues.Add("GroupName", value.Text);
        }

        /// <summary>
        /// Themes the view item inserting.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.Web.UI.WebControls.ListViewInsertEventArgs"/> 
        /// instance containing the event data.
        /// </param>
        protected void ThemeViewItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (FieldView.SelectedValue == null||e.Values["Title"]==null) 
                e.Cancel = true;
            else
            {
                var groupValue = (DropDownList)ThemeView.InsertItem.FindControl("insertGroup");
        
                _selectedValue = groupValue.SelectedValue;
                _selectedId = groupValue.SelectedIndex;

                e.Values.Add("GroupName", _selectedValue);
                e.Values.Add("FieldId", FieldView.SelectedValue);
            }
        }

        /// <summary>
        /// Fields the view item inserting.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.Web.UI.WebControls.ListViewInsertEventArgs"/> 
        /// instance containing the event data.</param>
        protected void FieldViewItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (e.Values["Title"]==null)
                 e.Cancel = true;

        }

        /// <summary>
        /// Themes the view pre render.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void ThemeViewPreRender(object sender, EventArgs e)
        {
            if (_selectedValue == null) return;
            
            var groupValue = (DropDownList)ThemeView.InsertItem.FindControl("insertGroup");
            groupValue.SelectedIndex = _selectedId;
        }
    }
}