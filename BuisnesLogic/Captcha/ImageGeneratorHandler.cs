using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;

namespace BusinessLogic.Captcha
{
    /// <summary>
    /// Handler for image generator
    /// </summary>
    public class ImageGeneratorHandler : IHttpHandler, IReadOnlySessionState
    {
        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler"/> interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext"/> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["Captcha"] == null) return;
                var captcha = context.Session["Captcha"].ToString();

            var response = context.Response;
            var img = new ImageGenerator(captcha);

            response.Clear();
            response.ContentType = "image/jpeg";

            img.GetImage.Save(response.OutputStream, ImageFormat.Jpeg);
            response.End();
        }

        /// <summary>
        /// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler"/> instance.
        /// </summary>
        /// <returns>true if the <see cref="T:System.Web.IHttpHandler"/> instance is reusable; otherwise, false.</returns>
        public bool IsReusable
        {
            get { return true; }
        }
    }
}