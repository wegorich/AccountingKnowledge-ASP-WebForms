using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using BusinessLogic.Render;

namespace AKSite.Search
{
    /// <summary>
    /// Resume manager show.
    /// </summary>
    public partial class Resume : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var resume = ResumeService.GetResume(Convert.ToInt32(Request.QueryString["resume"]));
            if (resume == null)
                Response.Redirect("~/Search/Default.aspx");
            
            var otherResume = ResumeService.GetResumes(resume.Client.Login);
            
            someResume.ResumeDataSource=new List<Model.Resume>{resume};
            resumes.DataSource= otherResume.Where(x => x.Id != resume.Id);

            someResume.DataBind();
            resumes.DataBind();
        }

        /// <summary>
        /// Resumes the result pre render.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void ResumeResultPreRender(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["CallBack"])) return;

            someResume.DataBind();
            var html = RenderToString.RenderControl(resumePlaceHolder);
            Response.Clear();
            Response.Write(html);
            Response.End();

        }
    }
}