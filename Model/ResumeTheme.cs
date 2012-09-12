namespace Model
{
    /// <summary>
    /// Resume theme repository
    /// </summary>
    public class ResumeTheme
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }
 
        /// <summary>
        /// Gets or sets the skill id.
        /// </summary>
        /// <value>The skill id.</value>
        public int SkillId { get; set; }
        
        /// <summary>
        /// Gets or sets the resume id.
        /// </summary>
        /// <value>The resume id.</value>
        public int ResumeId { get; set; }
        
        /// <summary>
        /// Gets or sets the theme id.
        /// </summary>
        /// <value>The theme id.</value>
        public int ThemeId { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the field.
        /// </summary>
        /// <value>The name of the field.</value>
        public string FieldName { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the skill.
        /// </summary>
        /// <value>The name of the skill.</value>
        public string SkillName { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the theme.
        /// </summary>
        /// <value>The name of the theme.</value>
        public string ThemeName { get; set; }
    }
}
