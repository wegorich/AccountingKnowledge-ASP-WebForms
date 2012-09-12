using System;
using System.Diagnostics;
using System.Web;
using BusinessLogic.Security;
using Microsoft.Win32;

namespace AKSite
{
    /// <summary>
    /// Global event file
    /// </summary>
    public class Global : HttpApplication
    {

        /// <summary>
        /// Handles the Start event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Start event of the Session control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the BeginRequest event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the AuthenticateRequest event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated) return;

            var loggedUser = HttpContext.Current.User.Identity.Name;
            var principal = new Principal(loggedUser);

            HttpContext.Current.User = principal;
        }

        /// <summary>
        /// Handles the Error event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            var objErr = Server.GetLastError();
            if (objErr == null) return;
            var err = String.Format("\nError Caught in Application_Error event\n" +
                                                         "Error in: {0}\n" +
                                                         "Error Message: {1}\n" +
                                                         "Stack Trace: {2}",
                                                         Request.Url, objErr.Message, objErr.StackTrace);


            LogTheError(err);
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="err">The err.</param>
        private static void LogTheError(string err)
        {
            const string eventLogName = "AKSite";
            const string sourceName = "SiteErrors";
            
            var eventLog = new EventLog {Log = eventLogName, 
                                                                         Source = sourceName};

            const string keyName = @"SYSTEM\CurrentControlSet\Services\EventLog\" + eventLogName + 
                                   @"\" + sourceName;
            var rkEventSource = Registry.LocalMachine.OpenSubKey(keyName);
            
            if (rkEventSource == null)
            {
                var proc = new Process();
                var procStartInfo = new ProcessStartInfo("Reg.exe")
                                        {Arguments = @"add HKLM\" + keyName, 
                                          UseShellExecute = true, Verb = "runas"};
                proc.StartInfo = procStartInfo;
                proc.Start();
            }
            try
            {
                eventLog.WriteEntry(err,EventLogEntryType.Error);
            }
            catch
            {
                Debug.Print("failed to write key");
            }
            finally
            {
                eventLog.Dispose();
            }
        }

        /// <summary>
        /// Handles the End event of the Session control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Session_End(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the End event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}