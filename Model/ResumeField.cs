using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Resume field data model.
    /// </summary>
    public class ResumeField
    {
        /// <summary>
        /// Gets or sets the name of the field.
        /// </summary>
        /// <value>The name of the field.</value>
        public string FieldName { get; set; }
    
        /// <summary>
        /// Gets or sets the theme.
        /// </summary>
        /// <value>The theme.</value>
        public List<ResumeTheme> Theme { get; set; }
    }
}
