using System.Security.Principal;

namespace BusinessLogic.Security
{
    /// <summary>
    /// Simple principal class.
    /// </summary>
    public class Principal:IPrincipal
    {
        private readonly Identity _identity;

        /// <summary>
        /// Initializes a new instance of the <see cref="Principal"/> class.
        /// </summary>
        /// <param name="login">The login.</param>
        public Principal(string login)
        {
            _identity = new Identity(login);
        }

        /// <summary>
        /// Determines whether the current principal belongs to the specified role.
        /// </summary>
        /// <param name="role">
        /// The name of the role for which to check membership.
        /// </param>
        /// <returns>
        /// true if the current principal is a member of the specified role; otherwise, false.
        /// </returns>
        public bool IsInRole(string role)
        {
            return _identity.Role == role;
        }

        /// <summary>
        /// Gets the identity of the current principal.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Security.Principal.IIdentity"/> object 
        /// associated with the current principal.
        /// </returns>
        public IIdentity Identity
        {
            get { return _identity; }
        }
    }
}
