using System;

namespace AKSite.UserControl
{
    /// <summary>
    /// Data pager, don`t show when less then 2 page.
    /// </summary>
    public partial class DataPager : System.Web.UI.UserControl
    {
        /// <summary>
        /// Gets or sets the query string.
        /// </summary>
        /// <value>The query string.</value>
        public string QueryString
        {
            get { return dataPager.QueryStringField; }
            set { dataPager.QueryStringField = value; }
        }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        public int PageSize
        {
            get { return dataPager.PageSize; }
            set { dataPager.PageSize = value; }
        }

        /// <summary>
        /// Gets or sets the paged control id.
        /// </summary>
        /// <value>The paged control id.</value>
        public string PagedControlId
        {
            get { return dataPager.PagedControlID; }
            set { dataPager.PagedControlID = value; }
        }

        /// <summary>
        /// Gets the total row count.
        /// </summary>
        public int TotalRowCount
        {
            get { return dataPager.TotalRowCount; }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"/> event.
        /// </summary>
        /// <param name="e">
        /// An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
        protected override void OnPreRender(EventArgs e)
        {
            dataPager.Visible = dataPager.PageSize < dataPager.TotalRowCount;
            base.OnPreRender(e);
        }
    }
}