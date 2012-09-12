using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccessLayer.Adapter;
using DataAccessLayer.Entity;
using DataAccessLayer.Generic;
using DataAccessLayer.Sort;
using Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Repository for Client Model.
    /// </summary>
    public class ClientRepository : BaseRepository<Client, EntityClient>
    {
        private readonly PrivilegyRepository _role;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientRepository"/> class.
        /// </summary>
        /// <param name="objectContext">The object context.</param>
        public ClientRepository(IObjectContext objectContext)
            : base(objectContext)
        {
            _role = new PrivilegyRepository(objectContext);
        }

        #region Base override
        /// <summary>
        /// Gets the converter.
        /// </summary>
        /// <returns>Convert expression.</returns>
        protected override Expression<Func<EntityClient, Client>> GetConverter()
        {
            return c => new Client
                            {
                                Id = c.ClientID,
                                Email = c.Email,
                                FirstName = c.FirstName,
                                SecondName = c.SecondName,
                                PhoneNumber=c.PhoneNumber,
                                BirthDay=c.BirthDay,
                                Privilegy = c.Privilegy.Title,
                                Login = c.Login,
                                Pass = c.Pass
                            };
        }

        /// <summary>
        /// Updates the entry.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="isNew">if set to <c>true</c> [is new].</param>
        /// <returns>Entity object.</returns>
         protected override EntityClient UpdateEntry(Client entity, bool isNew)
        {
            var dbEntity = (isNew) ? new EntityClient() :
                                                           ObjectSet.Single(x => x.ClientID == entity.Id);
            dbEntity.Email = entity.Email;
            dbEntity.FirstName = entity.FirstName;
            dbEntity.SecondName = entity.SecondName;
            dbEntity.Login = entity.Login;
            dbEntity.Pass = entity.Pass;
            dbEntity.BirthDay = entity.BirthDay;
            dbEntity.PhoneNumber = entity.PhoneNumber;
            dbEntity.PrivilegyID = _role.GetIdByTitle(entity.Privilegy);
            return dbEntity;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void Delete(Client entity)
        {
            ObjectSet.DeleteObject(ObjectSet.Single(x => x.ClientID == entity.Id));
            base.Delete(entity);
        }
        #endregion

        /// <summary>
        /// Gets the clients.
        /// </summary>
        /// <param name="sortExpression">The sort expression.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <returns>List of objects.</returns>
        public List<Client> GetClients(string sortExpression, string sortDirection)
        {
            var clinetsList = GetQuery().ToList();

            if (!string.IsNullOrEmpty(sortExpression))
            {
                clinetsList.Sort(new ListSorter<Client>(sortExpression));
            }

            if (sortDirection != null && sortDirection == "Desc")
            {
                clinetsList.Reverse();
            }

            return clinetsList;
        }

        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>Client.</returns>
        public Client GetClient(string login)
        {
            return GetQuery().Single(x => x.Login == login);
        }

        /// <summary>
        /// Gets all in role.
        /// </summary>
        /// <param name="role">The role.</param>
        public IEnumerable<Client> GetAllInRole(string role)
        {
            return GetQuery().Where(x => x.Privilegy == role);
        }

        /// <summary>
        /// Finds the users in role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <param name="loginToMatch">The login to match.</param>
        public IEnumerable<Client> FindUsersInRole(string role, string loginToMatch)
        {
            return GetQuery().Where(x => x.Privilegy == role&&x.Login.Contains(loginToMatch));
        }

        /// <summary>
        /// Gets the first or default.
        /// </summary>
        /// <param name="id">The id.</param>
        public Client GetFirstOrDefault(int id)
        {
            return GetQuery().FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Gets the privilegy.
        /// </summary>
        /// <param name="login">The login.</param>
        public string GetPrivilegy(string login)
        {
            return GetQuery().Where(x => x.Login == login)
                                               .Select(x => x.Privilegy)
                                               .Single();
        }

        /// <summary>
        /// Determines whether the specified login is valid.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <param name="pass">The pass.</param>
        /// <returns><c>true</c> if the specified login is valid; otherwise, <c>false</c>.</returns>
        public bool IsValid(string login, string pass)
        {
            return GetQuery().Where(x => x.Login == login && x.Pass == pass)
                       .Count() > 0;
        }

        /// <summary>
        /// Determines whether the specified login is exist.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <param name="email">The email.</param>
        /// <returns><c>true</c> if the specified login is exist; otherwise, <c>false</c>.</returns>
        public bool IsExist(string login, string email)
        {
            return GetQuery().Where(x => x.Login == login ||
                                                                       x.Email == email)
                                               .Count() > 0;
        }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <param name="login">The login.</param>
        public string GetPassword(string login)
        {
            return GetQuery().Where(x => x.Login == login)
                                               .Select(x => x.Pass)
                                               .Single();
        }
    }
}