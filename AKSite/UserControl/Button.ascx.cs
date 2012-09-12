using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AKSite.UserControl
{
    /// <summary>
    /// The main app button.
    /// </summary>
    [Themeable(true)]
    public partial class Button : System.Web.UI.UserControl
    {
        /// <summary>
        /// Gets the BTN attributes.
        /// </summary>
        public AttributeCollection BtnAttributes
        {
            get { return btn.Attributes; }
        }

        /// <summary>
        /// Gets or sets the on client click.
        /// </summary>
        /// <value>The on client click.</value>
        public string OnClientClick
        {
            get { return btn.OnClientClick; }
            set { btn.OnClientClick = value; }
        }

        /// <summary>
        /// Gets or sets the name of the command.
        /// </summary>
        /// <value>The name of the command.</value>
        public string CommandName
        {
            get { return btn.CommandName; }
            set { btn.CommandName = value; }
        }

        /// <summary>
        /// Gets or sets the validation group.
        /// </summary>
        /// <value>The validation group.</value>
        public string ValidationGroup
        {
            get { return btn.ValidationGroup; }
            set { btn.ValidationGroup = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [causes validation].
        /// </summary>
        /// <value><c>true</c> if [causes validation]; otherwise, <c>false</c>.</value>
        public bool CausesValidation
        {
            get { return btn.CausesValidation; }
            set { btn.CausesValidation = value; }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get { return btn.Text; }
            set { btn.Text = value; }
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public Unit Width
        {
            get { return btn.Width; }
            set { btn.Width = value; }
        }

        /// <summary>
        /// Occurs when [click].
        /// </summary>
        public event EventHandler Click;

        /// <summary>
        /// Called when [click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void OnClick(object sender, EventArgs e)
        {
            if (Click != null)
                Click(this, e);
        }

    }
}