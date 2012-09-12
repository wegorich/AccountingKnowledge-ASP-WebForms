using System;

namespace BusinessLogic.Error
{
    /// <summary>
    /// Default class for this app exception
    /// </summary>
    /// <remarks>Need to control known exception situations</remarks>
    public class CustomException : Exception
    {
        private readonly string _description;
       
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public CustomException()
        {
        }
       
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public CustomException(string message)
            : base(message)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="description">The description.</param>
        public CustomException(string message, string description)
            : base(message)
        {
            _description = description;
        }
        
        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description
        {
            get
            {
                return String.IsNullOrEmpty(_description) ?
                                                                base.StackTrace :
                                                                _description;
            }
        }
    }
}
