using System;
using System.Web;

namespace BusinessLogic.Error
{
    /// <summary>
    /// Http module it check custom exception on page for show user full information.
    /// </summary>
    /// <remarks>transfer user for error page.</remarks>
    public class CustomExceptionHttpModule : IHttpModule
    {
        /// <summary>
        /// Inits the specified app.
        /// </summary>
        /// <param name="app">The app.</param>
        public void Init(HttpApplication app)
        {
            app.Error += AppError;
        }

        /// <summary>
        /// Apps the error.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        static void AppError(object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            
            var exception = context.Server.GetLastError().InnerException as CustomException;
            if (exception == null) return; 

            context.Server.ClearError();
            context.Session["LastError"] = exception; 
            context.Server.Transfer("~/Error/CustomError.aspx", true);
        }

        /// <summary>
        /// Disposes of the resources (other than memory) used by 
        /// the module that implements <see cref="T:System.Web.IHttpModule"/>.
        /// </summary>
        public void Dispose()
        {
            //Do nothing!
        }

    }
}
