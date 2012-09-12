namespace Model
{
    /// <summary>
    /// Model of data base.
    /// </summary>
    public class AKBase
    {
        /// <summary>
        /// Gets or sets the clients.
        /// </summary>
        /// <value>The clients.</value>
        public Client[] Clients { get; set; }

        /// <summary>
        /// Gets or sets the privilegies.
        /// </summary>
        /// <value>The privilegies.</value>
        public Privilegy[] Privilegies { get; set; }
        
        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        /// <value>The fields.</value>
        public Field[] Fields { get; set; }
        
        /// <summary>
        /// Gets or sets the themes.
        /// </summary>
        /// <value>The themes.</value>
        public Theme[] Themes { get; set; }
        
        /// <summary>
        /// Gets or sets the skills.
        /// </summary>
        /// <value>The skills.</value>
        public Skill[] Skills { get; set; }
        
        /// <summary>
        /// Gets or sets the skill groups.
        /// </summary>
        /// <value>The skill groups.</value>
        public SkillGroup[] SkillGroups { get; set; }
        
        /// <summary>
        /// Gets or sets the resumes.
        /// </summary>
        /// <value>The resumes.</value>
        public Resume[] Resumes { get; set; }
    }
}
