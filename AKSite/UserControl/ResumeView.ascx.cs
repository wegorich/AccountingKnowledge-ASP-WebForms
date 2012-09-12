using System.Collections.Generic;
using Model;

namespace AKSite.UserControl
{
    /// <summary>
    /// View all resume control.
    /// </summary>
    public partial class ResumeView : System.Web.UI.UserControl
    {
        /// <summary>
        /// Gets or sets the resume page.
        /// </summary>
        /// <value>The resume page.</value>
        public string ResumePage { get; set; }

        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>The data source.</value>
        public object DataSource
        {
            get { return resume.DataSource; }
            set
            {
                resume.DataSource = new List<Resume>{(Resume)value};
                resume.DataBind();
            }
        }
    }
}