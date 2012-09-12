using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessLogic.Render;

namespace AKSite.Search
{
    /// <summary>
    /// Default search page
    /// </summary>
    public partial class Default : Page
    {
        /// <summary>
        /// Searches the result pre render.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void SearchResultPreRender(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["CallBack"])) return;
            
            var html = RenderToString.RenderControl(searchPlaceHolder);
            Response.Clear();
            Response.Write(html);
            Response.End();

        }

        /// <summary>
        /// Resumes the data selecting.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The
        /// <see cref="System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs"/>
        /// instance containing the event data.</param>
        protected void ResumeDataSelecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            var strategy = ResumeService.SearchStrategy(Request.QueryString["selection"]);
            int min;
            int max;
            int.TryParse(Request.QueryString["min"], out min);
            int.TryParse(Request.QueryString["max"], out max);
            e.InputParameters["value"] = Request.QueryString["search"];
            e.InputParameters["searchStrategy"] = strategy;
            e.InputParameters["startAge"] = min;
            e.InputParameters["endAge"] = max;
            e.InputParameters["sortExpression"] = Request.QueryString["exp"];
            e.InputParameters["sortDirection"] = Request.QueryString["dir"];
        }
    }
}
