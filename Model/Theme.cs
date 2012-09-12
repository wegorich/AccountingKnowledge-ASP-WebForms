namespace Model
{
    /// <summary>
    /// Theme data model.
    /// </summary>
    public class Theme
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id{get; set; }
        
        /// <summary>
        /// Gets or sets the field id.
        /// </summary>
        /// <value>The field id.</value>
        public int FieldId { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        /// <value>The name of the group.</value>
        public string GroupName { get; set; }
        
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
    }
}
