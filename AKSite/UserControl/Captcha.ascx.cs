using System;
using System.Web;

namespace AKSite.UserControl
{
    /// <summary>
    /// Generate captcha image
    /// </summary>
    public partial class Captcha : System.Web.UI.UserControl
    {
        /// <summary>
        /// Gets the previous captcha.
        /// </summary>
        protected string PreviousCaptcha { get; private set; }
        private const string Symbols = "0123456789ABCDIFGHabicawflgiwnq";

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get { return txtBox.Title; }
            set { txtBox.Title = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is correct.
        /// </summary>
        public bool IsCorrect
        {
            get
            {
                return (PreviousCaptcha == txtBox.Text);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="T:System.EventArgs"/> object that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            if (HttpContext.Current.Session["Captcha"] != null)
                PreviousCaptcha = HttpContext.Current.Session["Captcha"].ToString();

            var newStr = new char[3];
            var rand = new Random();

            for (var i = 0; i < 3; i++)
                newStr[i] = Symbols[rand.Next(0, Symbols.Length)];

            HttpContext.Current.Session.Add("Captcha", new String(newStr));
        }

        /// <summary>
        /// Custs the validator server validate.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="args">
        /// The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> 
        /// instance containing the event data.</param>
        protected void CustValidatorServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = IsCorrect;
        }

    }
}