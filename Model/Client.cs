using System;

namespace Model
{
    /// <summary>
    /// Client data model.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id{get;set;}
    
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get;set; }
        
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get;set; }
        
        /// <summary>
        /// Gets or sets the name of the second.
        /// </summary>
        /// <value>The name of the second.</value>
        public string SecondName { get;set; }
        
        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        /// <value>The login.</value>
        public string Login { get;set; }
        
        /// <summary>
        /// Gets or sets the pass.
        /// </summary>
        /// <value>The pass.</value>
        public string Pass { get;set; }
        
        /// <summary>
        /// Gets or sets the birth day.
        /// </summary>
        /// <value>The birth day.</value>
        /// <remarks></remarks>
        public DateTime BirthDay { get; set; }
        
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// Gets or sets the privilegy.
        /// </summary>
        /// <value>The privilegy.</value>
        public string Privilegy { get;set; }
    }
}
