namespace AKSite.UserControl
{
    /// <summary>
    /// Show resume control.
    /// </summary>
    public partial class ResumeShow : System.Web.UI.UserControl
    {
        /// <summary>
        /// Gets or sets the resume data source id.
        /// </summary>
        /// <value>The resume data source id.</value>
        public string ResumeDataSourceId
        {
            get { return resumeView.DataSourceID; }
            set { resumeView.DataSourceID = value; }
        }

        /// <summary>
        /// Gets or sets the resume data source.
        /// </summary>
        /// <value>The resume data source.</value>
        public object ResumeDataSource
        {
            get { return resumeView.DataSource; }
            set
            {
                resumeView.DataSource = value;
                resumeView.DataBind();
            }
        }
    }
}