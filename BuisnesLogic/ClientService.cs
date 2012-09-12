using System;
using System.Collections.Generic;
using BusinessLogic.Error;
using DataAccessLayer;
using DataAccessLayer.Adapter;
using Model;

namespace BusinessLogic
{
    /// <summary>
    /// Srevice for client data model.
    /// </summary>
    /// <remarks>Base on ClientRepository</remarks>
    public static class ClientService
    {
        private static readonly ObjectContextAdapter Context = new ObjectContextAdapter();
        private static readonly ClientRepository Client = new ClientRepository(Context);

        #region Client CRUD
        /// <summary>
        /// Gets the clients.
        /// </summary>
        public static IEnumerable<Client> GetClients()
        {
            return Client.GetAll();
        }

        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <param name="id">The id.</param>
        public static Client GetClient(int id)
        {
            return id < 1 ? null : Client.GetFirstOrDefault(id);
        }

        /// <summary>
        /// Deletes the client.
        /// </summary>
        /// <param name="client">The client.</param>
        public static void DeleteClient(Client client)
        {
            if (client == null || client.Id == 0)
                throw new CustomException("Invalid user argument","Can`t remove user");

            Client.Delete(client);
            Context.SaveChanges();
        }

        /// <summary>
        /// Updates the client.
        /// </summary>
        /// <param name="client">The client.</param>
        public static void UpdateClient(Client client)
        {
            if (client == null || client.Id == 0)
                throw new CustomException("Invalid user argument","Can`t update user data");

            Client.Update(client);
            Context.SaveChanges();
        }

        /// <summary>
        /// Creates the client.
        /// </summary>
        /// <param name="client">The client.</param>
        public static void CreateClient(Client client)
        {
            if (client == null ||
                string.IsNullOrEmpty(client.Email) ||
                string.IsNullOrEmpty(client.FirstName) ||
                string.IsNullOrEmpty(client.Login) ||
                string.IsNullOrEmpty(client.Pass) ||
                string.IsNullOrEmpty(client.PhoneNumber) ||
                string.IsNullOrEmpty(client.SecondName))
                throw new CustomException("Invalid user argument","Can`t create user");

            Client.Add(client);
            Context.SaveChanges();
        }
        #endregion

        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <param name="login">The login.</param>
        public static Client GetClient(string login)
        {
            if (string.IsNullOrEmpty(login))
                throw new CustomException("Invalid user argument","Can`t return user data");

            return Client.GetClient(login);
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        public static int Count()
        {
            return Client.Count();
        }

        /// <summary>
        /// Gets the clients.
        /// </summary>
        /// <param name="sortExpression">The sort expression.</param>
        /// <param name="sortDirection">The sort direction.</param>
        public static List<Client> GetClients(string sortExpression, string sortDirection)
        {
            return Client.GetClients(sortExpression, sortDirection);
        }

        /// <summary>
        /// Determines whether the specified login is valid.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <param name="pass">The pass.</param>
        /// <returns><c>true</c> if the specified login is valid; otherwise, <c>false</c>.</returns>
        public static bool IsValid(string login, string pass)
        {
            if (string.IsNullOrEmpty(login) ||
                string.IsNullOrEmpty(pass))
                throw new CustomException("Invalid validaton argument","The login or password not valid");

            return Client.IsValid(login, pass);
        }

        /// <summary>
        /// Determines whether the specified login is exist.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <param name="email">The email.</param>
        /// <returns><c>true</c> if the specified login is exist; otherwise, <c>false</c>.</returns>
        /// <remarks></remarks>
        public static bool IsExist(string login, string email = " ")
        {
            if (string.IsNullOrEmpty(login))
                throw new CustomException("Invalid check user argument","Can`t find user by this parametrs");
            
            return Client.IsExist(login, email);
        }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetPassword(string login)
        {
            if (string.IsNullOrEmpty(login))
                throw new CustomException("Invalid password return argument","Can`t return password");

            return Client.GetPassword(login);
        }

        /// <summary>
        /// Gets the age.
        /// </summary>
        /// <param name="birthDay">The birth day.</param>
        public static string GetAge(DateTime birthDay)
        {
            var age = DateTime.Now.Year - birthDay.Year;
            string str;
            switch (age % 10)
            {
                case 1: str = "год";
                    break;
                case 2:
                case 3:
                case 4: str = "года";
                    break;
                default: str = "лет";
                    break;
            }

            return age + " " + str;
        }
    }
}
