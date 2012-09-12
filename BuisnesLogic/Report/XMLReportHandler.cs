using System;
using System.IO;
using System.Linq;
using System.Web;
using DataAccessLayer;
using DataAccessLayer.Adapter;
using Model;

namespace BusinessLogic.Report
{
    /// <summary>
    /// XML report generator handler
    /// </summary>
    public class XMLReportHandler : IHttpHandler
    {
        /// <summary>
        /// Enables processing of HTTP Web requests by a custom 
        /// HttpHandler that implements the <see cref="T:System.Web.IHttpHandler"/> interface.
        /// </summary>
        /// <param name="context">
        /// An <see cref="T:System.Web.HttpContext"/> 
        /// object that provides references to the intrinsic server objects 
        /// (for example, Request, Response, Session, and Server) 
        /// used to service HTTP requests.
        /// </param>
        public void ProcessRequest(HttpContext context)
        {
            var file = context.Request.FilePath.ToLower();
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;

            var name = Path.GetFileNameWithoutExtension(file);
            var obj = GetDataObject(name);
            
            file= "/temp/" + name+".xml";
            File.WriteAllText(baseDir + file,
                              XMLSerialize.SerializeAnObject(obj));
            
            
            var xsltFile = "/temp/" + name + ".xslt";
            var htmlFile = "/temp/" + name + ".html";
            
            if(File.Exists(baseDir+xsltFile))
            {
                XMLSerialize.XMLTransform(baseDir + file, baseDir+xsltFile, baseDir + htmlFile);
                context.Response.Redirect("~" + htmlFile, true);
            }

            context.Response.Redirect("~"+file,true);
        }

        /// <summary>
        /// Gets the data object.
        /// </summary>
        /// <param name="name">The name.</param>
        private static object GetDataObject(string name)
        {
            object obj;
            switch (name)
            {
                case "client":
                case "clients":
                    obj = ClientService.GetClients();
                    break;
                case "resume":
                case "resumes":
                    obj = ResumeService.GetResumes();
                    break;
                case "skill":
                case "skills":
                    obj = SkillService.GetSkills();
                    break;
                case "skillgroup":
                case "skillgroups":
                    obj = SkillGroupService.GetSkillGroups();
                    break;
                case "field":
                case "fields":
                    obj = FieldService.GetFeilds();
                    break;
                case "theme":
                case "themes":
                    obj = ThemeService.GetThemes();
                    break;
                case "resumetheme":
                case "resumethemes":
                    obj = ResumeThemeService.GetResumeThemes();
                    break;
                default:
                    obj = new AKBase
                              {
                                  Clients = ClientService.GetClients().ToArray(),
                                  Fields = FieldService.GetFeilds().ToArray(),
                                  Resumes = ResumeService.GetResumes().ToArray(),
                                  SkillGroups = SkillGroupService.GetSkillGroups().ToArray(),
                                  Skills = SkillService.GetSkills().ToArray(),
                                  Themes = ThemeService.GetThemes().ToArray(),
                                  Privilegies =
                                      new PrivilegyRepository(new ObjectContextAdapter()).GetAll().ToArray()
                              };
                    break;
            }
            return obj;
        }

        /// <summary>
        /// Gets a value indicating whether 
        /// another request can use the 
        /// <see cref="T:System.Web.IHttpHandler"/> instance.
        /// </summary>
        /// <returns>
        /// true if 
        /// the <see cref="T:System.Web.IHttpHandler"/> instance 
        /// is reusable; otherwise, false.</returns>
        public bool IsReusable
        {
            get { return true; }
        }
    }
}