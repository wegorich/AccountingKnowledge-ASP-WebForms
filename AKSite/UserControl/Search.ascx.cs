using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AKSite.UserControl
{
    /// <summary>
    /// Search input control.
    /// </summary>
    public partial class Search : System.Web.UI.UserControl
    {
        /// <summary>
        /// Gets the BTN attributes.
        /// </summary>
        public AttributeCollection BtnAttributes
        {
            get { return btn.BtnAttributes; }
        }

        /// <summary>
        /// Occurs when [on search click].
        /// </summary>
        public event EventHandler OnSearchClick;

        /// <summary>
        /// Gets or sets the width of the button.
        /// </summary>
        /// <value>The width of the button.</value>
        public Unit ButtonWidth
        {
            get { return btn.Width; }
            set { btn.Width = value; }
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
        /// Clicks the button.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void ClickButton(object sender, EventArgs e)
        {
            if (OnSearchClick != null)
                OnSearchClick(this, e);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Search"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled
        {
            get { return input.Enabled; }
            set
            {
                input.Enabled = value;
                btn.Visible = value;
            }
        }

        /// <summary>
        /// Gets or sets the button text.
        /// </summary>
        /// <value>The button text.</value>
        public string ButtonText
        {
            get { return btn.Text; }
            set { btn.Text = value; }
        }

        /// <summary>
        /// Gets or sets the length of the max.
        /// </summary>
        /// <value>The length of the max.</value>
        public int MaxLength
        {
            get { return input.MaxLength; }
            set { input.MaxLength = value; }

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
        /// Gets or sets the name of the command.
        /// </summary>
        /// <value>The name of the command.</value>
        public string CommandName
        {
            get { return btn.CommandName; }
            set { btn.CommandName = value; }
        }
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get { return input.Text; }
            set { input.Text = value; }
        }
    }
}