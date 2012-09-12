using System;
using System.Runtime.Serialization;
using System.Security.Principal;
using DataAccessLayer;
using DataAccessLayer.Adapter;

namespace BusinessLogic.Security
{
    /// <summary>
    /// Simple identity class.
    /// </summary>
    /// <remarks>Serializable.</remarks>
    [Serializable]
    public class Identity : IIdentity, ISerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Identity"/> class.
        /// </summary>
        /// <param name="login">The login.</param>
        public Identity(string login)
        {
            Name = login;
            using (var adapter = new ObjectContextAdapter())
            {
                var result = new ClientRepository(adapter).GetPrivilegy(Name);

                IsAuthenticated = result != null;
                if (IsAuthenticated)
                {
                    Role = result;
                }
            }
        }
        /// <summary>
        /// Gets the role.
        /// </summary>
        public string Role { get; private set; }

        /// <summary>
        /// Gets the name of the current user.
        /// </summary>
        /// <returns>The name of the user on whose behalf the code is running.</returns>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the type of authentication used.
        /// </summary>
        /// <returns>The type of authentication used to identify the user.</returns>
        public string AuthenticationType
        {
            get { return "Account knowledge Authentication"; }
        }

        /// <summary>
        /// Gets a value that indicates whether the user has been authenticated.
        /// </summary>
        /// <returns>true if the user was authenticated; otherwise, false.</returns>
        public bool IsAuthenticated { get; private set; }

        /// <summary>
        /// Populates a 
        /// <see cref="T:System.Runtime.Serialization.SerializationInfo"/> 
        /// with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">
        /// The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> 
        /// to populate with data.</param>
        /// <param name="context">
        /// The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"/>) 
        /// for this serialization.
        /// </param>
        /// <exception cref="T:System.Security.SecurityException">
        /// The caller does not have the required permission. 
        /// </exception>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (context.State != StreamingContextStates.CrossAppDomain)
            {
                throw new InvalidOperationException("Serialization not supported");
            }

            var gIdent = new GenericIdentity(Name, AuthenticationType);
            info.SetType(gIdent.GetType());

            var serializableMembers = FormatterServices.GetSerializableMembers(gIdent.GetType());
            var serializableValues = FormatterServices.GetObjectData(gIdent, serializableMembers);

            for (int i = 0; i < serializableMembers.Length; i++)
            {
                info.AddValue(serializableMembers[i].Name, serializableValues[i]);
            }

        }
    }
}
