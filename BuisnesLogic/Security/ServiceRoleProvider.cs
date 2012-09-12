using System;
using System.Linq;
using System.Web.Hosting;
using System.Web.Security;
using DataAccessLayer;
using DataAccessLayer.Adapter;
using Model;

namespace BusinessLogic.Security
{
    /// <summary>
    /// Role provider uses privilegy data model
    /// </summary>
    public class ServiceRoleProvider : RoleProvider
    {
        private static readonly ObjectContextAdapter Adapter = new ObjectContextAdapter();
        private static readonly ClientRepository Client = new ClientRepository(Adapter);
        private static readonly PrivilegyRepository Roles = new PrivilegyRepository(Adapter);

        /// <summary>
        /// Gets a value indicating whether the specified user is in 
        /// the specified role for the configured applicationName.
        /// </summary>
        /// <param name="username">The user name to search for.</param>
        /// <param name="roleName">The role to search in.</param>
        /// <returns>
        /// true if the specified user is in the specified role for 
        /// the configured applicationName; otherwise, false.
        /// </returns>
        public override bool IsUserInRole(string username, string roleName)
        {
            return Client.GetPrivilegy(username) == roleName;
        }

        /// <summary>
        /// Roles the index.
        /// </summary>
        /// <param name="index">The index.</param>
        public int RoleIndex(object index)
        {
            return Array.IndexOf(GetAllRoles().ToArray(), index);
        }

        /// <summary>
        /// Gets a list of the roles that a specified user is in for the configured applicationName.
        /// </summary>
        /// <param name="username">The user to return a list of roles for.</param>
        /// <returns>
        /// A string array containing the names of all the roles 
        /// that the specified user is in for the configured applicationName.
        /// </returns>
        public override string[] GetRolesForUser(string username)
        {
            string[] result = { "" };
            result[0] = Client.GetPrivilegy(username);
            return result;
        }

        /// <summary>
        /// Adds a new role to the data source for the configured applicationName.
        /// </summary>
        /// <param name="roleName">The name of the role to create.</param>
        public override void CreateRole(string roleName)
        {
            if (!Roles.IsExist(roleName))
                Roles.Add(new Privilegy { Title = roleName });
            Adapter.SaveChanges();
        }

        /// <summary>
        /// Removes a role from the data source for the configured applicationName.
        /// </summary>
        /// <param name="roleName">The name of the role to delete.</param>
        /// <param name="throwOnPopulatedRole">
        /// If true, throw an exception if <paramref name="roleName"/> has 
        /// one or more members and do not delete <paramref name="roleName"/>.
        /// </param>
        /// <returns>true if the role was successfully deleted; otherwise, false.</returns>
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            var role = Roles.GetFirstOrDefault(roleName);
            if (role != null)
            {
                Roles.Delete(role);
                Adapter.SaveChanges();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets a value indicating whether the specified role name 
        /// already exists in the role data source for 
        /// the configured applicationName.
        /// </summary>
        /// <param name="roleName">
        /// The name of the role to search for in the data source.
        /// </param>
        /// <returns>
        /// true if the role name already exists in the 
        /// data source for the configured applicationName; otherwise, false.
        /// </returns>
        public override bool RoleExists(string roleName)
        {
            return Roles.IsExist(roleName);
        }

        /// <summary>
        /// Adds the specified user names to the specified 
        /// roles for the configured applicationName.
        /// </summary>
        /// <param name="usernames">
        /// A string array of user names to 
        /// be added to the specified roles.
        /// </param>
        /// <param name="roleNames">
        /// A string array of the role names to add 
        /// the specified user names to.
        /// </param>
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            if (usernames.Length != roleNames.Length) return;
            //Do nothing!
        }

        /// <summary>
        /// Removes the specified user names from the 
        /// specified roles for the configured applicationName.
        /// </summary>
        /// <param name="usernames">
        /// A string array of user names to be removed from the specified roles.
        /// </param>
        /// <param name="roleNames">
        /// A string array of role names to remove the specified user names from.</param>
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            if (usernames.Length != roleNames.Length) return;
            // Do nothing!
        }

        /// <summary>
        /// Gets a list of users in the specified role for the configured applicationName.
        /// </summary>
        /// <param name="roleName">
        /// The name of the role to get the list of users for.
        /// </param>
        /// <returns>
        /// A string array containing the names of all the users who 
        /// are members of the specified role for the configured applicationName.
        /// </returns>
        public override string[] GetUsersInRole(string roleName)
        {
            var result = Client.GetAllInRole(roleName)
                                                     .Select(x => x.Login)
                                                     .ToArray();
            return result;
        }

        /// <summary>
        /// Gets a list of all the roles for the configured applicationName.
        /// </summary>
        /// <returns>
        /// A string array containing the names of all the roles stored
        ///  in the data source for the configured applicationName.
        /// </returns>
        public override string[] GetAllRoles()
        {
            return Roles.GetAll().Select(x => x.Title)
                                                   .ToArray();
        }

        /// <summary>
        /// Gets an array of user names in a role where the user 
        /// name contains the specified user name to match.
        /// </summary>
        /// <param name="roleName">The role to search in.</param>
        /// <param name="usernameToMatch">The user name to search for.</param>
        /// <returns>
        /// A string array containing the names of all the users 
        /// where the user name matches <paramref name="usernameToMatch"/> 
        /// and the user is a member of the specified role.
        /// </returns>
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            return Client.FindUsersInRole(roleName, usernameToMatch)
                                    .Select(x => x.Login)
                                    .ToArray();
        }

        /// <summary>
        /// Gets or sets the name of the application to store and retrieve role information for.
        /// </summary>
        /// <value>The name of the application.</value>
        /// <returns>The name of the application to store and retrieve role information for.</returns>
        public override string ApplicationName
        {
            get { return HostingEnvironment.ApplicationVirtualPath; }
            set { }
        }
    }
}
