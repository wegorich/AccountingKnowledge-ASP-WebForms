using System;
using System.Web.UI;

namespace AKSite.UserControl
{
    /// <summary>
    /// Login input control.
    /// </summary>
    [ValidationProperty("UserPass")]
    public partial class Login : System.Web.UI.UserControl
    {
        /// <summary>
        /// Gets or sets the login description.
        /// </summary>
        /// <value>The login description.</value>
        public string LoginDescription
        {
            get { return loginBlock.Description; }
            set { loginBlock.Description = value; }
        }

        /// <summary>
        /// Gets or sets the login title.
        /// </summary>
        /// <value>The login title.</value>
        public string LoginTitle
        {
            get { return loginBlock.Title; }
            set { loginBlock.Title = value; }
        }

        /// <summary>
        /// Gets or sets the pass description.
        /// </summary>
        /// <value>The pass description.</value>
        public string PassDescription
        {
            get { return passBlock.Description; }
            set { passBlock.Description = value; }
        }

        /// <summary>
        /// Gets or sets the pass title.
        /// </summary>
        /// <value>The pass title.</value>
        public string PassTitle
        {
            get { return passBlock.Title; }
            set { passBlock.Title = value; }
        }

        /// <summary>
        /// Gets or sets the user login.
        /// </summary>
        /// <value>The user login.</value>
        public string UserLogin
        {
            get { return loginBlock.Text; }
            set { loginBlock.Text = value; }
        }

        /// <summary>
        /// Gets or sets the user pass.
        /// </summary>
        /// <value>The user pass.</value>
        public string UserPass
        {
            get { return passBlock.Text; }
            set { passBlock.Text = value; }
        }
    }
}