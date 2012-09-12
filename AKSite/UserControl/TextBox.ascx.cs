using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AKSite.UserControl
{
    /// <summary>
    /// Main app text box.
    /// </summary>
    [Themeable(true)][ValidationProperty("Text")]
    public partial class TextBox : System.Web.UI.UserControl
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get { return blockTitle.InnerText; }
            set { blockTitle.InnerText = value; }
        }
        
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get { return blockDescription.InnerText; }
            set { blockDescription.InnerText = value; }
        }

        #region Text Box свойства
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get { return blockInput.Text; }
            set { blockInput.Text = value; }
        }
        
        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public Unit Width
        {
            get { return blockInput.Width; }
            set { blockInput.Width = value; }
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public Unit Height
        {
            get { return blockInput.Height; }
            set { blockInput.Height = value; }
        }


        /// <summary>
        /// Gets or sets the length of the max.
        /// </summary>
        /// <value>The length of the max.</value>
        public int MaxLength
        {
            get { return blockInput.MaxLength; }
            set { blockInput.MaxLength = value; }
        }

        /// <summary>
        /// Gets or sets the text mode.
        /// </summary>
        /// <value>The text mode.</value>
        public TextBoxMode TextMode
        {
            get { return blockInput.TextMode; }
            set { blockInput.TextMode = value; }
        }
        #endregion

        #region Свойства валидатора
        /// <summary>
        /// Gets or sets the validator text.
        /// </summary>
        /// <value>The validator text.</value>
        public string ValidatorText
        {
            get { return reqValidator.Text; }
            set { reqValidator.Text =value; }
        }

        /// <summary>
        /// Gets or sets the validation group.
        /// </summary>
        /// <value>The validation group.</value>
        public string ValidationGroup
        {
            get { return reqValidator.ValidationGroup; }
            set { reqValidator.ValidationGroup = value; }
        }
        #endregion

        /// <summary>
        /// Gets or sets the color of the validator fore.
        /// </summary>
        /// <value>The color of the validator fore.</value>
        public Color ValidatorForeColor
        {
            get { return reqValidator.ForeColor; }
            set { reqValidator.ForeColor = value; }
        }

        /// <summary>
        /// Gets or sets the size of the text box font.
        /// </summary>
        /// <value>The size of the text box font.</value>
        public FontUnit TextBoxFontSize
        {
            get { return blockInput.Font.Size; }
            set { blockInput.Font.Size = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [text box font bold].
        /// </summary>
        /// <value><c>true</c> if [text box font bold]; otherwise, <c>false</c>.</value>
        public bool TextBoxFontBold
        {
            get { return blockInput.Font.Bold; }
            set { blockInput.Font.Bold = value; }
        }

        /// <summary>
        /// Gets or sets the onkeydown.
        /// </summary>
        /// <value>The onkeydown.</value>
        public string onkeydown
        {
            get { return blockInput.Attributes["onkeydown"]; }
            set { blockInput.Attributes.Add("onkeydown", value); }
        }
    }
}