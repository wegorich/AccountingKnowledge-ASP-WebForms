using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AKSite.Search
{
    /// <summary>
    /// Search master page
    /// </summary>
    public partial class Search : MasterPage
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            search.Text = Request.QueryString["search"];
            if (IsPostBack)
                Response.Redirect(
                    string.Format("Default.aspx?selection={0}&" +
                                                                "search={1}&" +
                                                                "page={2}&" +
                                                                "min={3}&" +
                                                                "max={4}&" +
                                                                "exp={5}&" +
                                                                "dir={6}",
                                                                selectSearch.SelectedValue,
                                                                 search.Text,
                                                                 Request.QueryString["page"],
                                                                 yearsStart.SelectedValue,
                                                                 yearsEnd.SelectedValue,
                                                                 sortExpression.SelectedValue,
                                                                  sortDirection.SelectedValue), true);
        
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event to initialize the page.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/>
        /// that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                yearsStart.Items.Add(new ListItem
                {
                    Text = "От",
                    Value = "0",
                });
                yearsEnd.Items.Add(new ListItem
                {
                    Text = "До",
                    Value = "70",
                });
                for (var i = 18; i < 66; i++)
                {
                    yearsStart.Items.Add(new ListItem
                    {
                        Text = "От " + i,
                        Value = i.ToString(),
                    });
                    yearsEnd.Items.Add(new ListItem
                    {
                        Text = "До " + i,
                        Value = i.ToString(),
                    });
                }
            }
            base.OnInit(e);
        }
        
        #region OnPreRender sent QueryString value to the controls
        /// <summary>
        /// Selects the search pre render.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void SelectSearchPreRender(object sender, EventArgs e)
        {
            var selection = Request.QueryString["selection"];
            if (string.IsNullOrEmpty(selection))
            {
                selectSearch.Items[0].Selected = true;
                return;
            }
            foreach (var item in selectSearch.Items.Cast<MenuItem>()
                                                                             .Where(item => item.Value == selection))
            {
                item.Selected = true;
                return;
            }
            selectSearch.Items[0].Selected = true;
        }

        /// <summary>
        /// Ages the start pre render.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void AgeStartPreRender(object sender, EventArgs e)
        {
            var min = Request.QueryString["min"];
            SelectDropDownItem(sender, min);
        }

        /// <summary>
        /// Ages the end pre render.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void AgeEndPreRender(object sender, EventArgs e)
        {
            var max = Request.QueryString["max"];
            SelectDropDownItem(sender, max);
        }

        /// <summary>
        /// Sorts the exp pre render.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void SortExpPreRender(object sender, EventArgs e)
        {
            var exp = Request.QueryString["exp"];
            SelectDropDownItem(sender, exp);
        }

        /// <summary>
        /// Sorts the dec pre render.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void SortDecPreRender(object sender, EventArgs e)
        {
            var dir = Request.QueryString["dir"];
            SelectDropDownItem(sender, dir);
        }

        /// <summary>
        /// Selects the drop down item.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="value">The min.</param>
        private static void SelectDropDownItem(object sender, string value)
        {
            if (string.IsNullOrEmpty(value)) return;

            foreach (var item in ((DropDownList)sender).Items.Cast<ListItem>().Where(item => item.Value == value))
            {
                item.Selected = true;
                return;
            }
        }
        #endregion

    }
}