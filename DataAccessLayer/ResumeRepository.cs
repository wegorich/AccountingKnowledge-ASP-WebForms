using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using DataAccessLayer.Adapter;
using DataAccessLayer.Entity;
using DataAccessLayer.Filters;
using DataAccessLayer.Generic;
using Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Resume data model repository.
    /// </summary>
    /// <remarks></remarks>
    public class ResumeRepository : BaseRepository<Resume, EntityResume>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResumeRepository"/> class.
        /// </summary>
        /// <param name="objectContext">The object context.</param>
        public ResumeRepository(IObjectContext objectContext)
            : base(objectContext)
        {
        }

        /// <summary>
        /// Gets the converter.
        /// </summary>
        protected override Expression<Func<EntityResume, Resume>> GetConverter()
        {
            return c => new Resume
                            {
                                Id = c.ResumeID,
                                Title = c.Title,
                                Client = new Client
                                             {
                                                 BirthDay = c.Client.BirthDay,
                                                 Email = c.Client.Email,
                                                 FirstName = c.Client.FirstName,
                                                 Login = c.Client.Login,
                                                 Pass = c.Client.Pass,
                                                 PhoneNumber = c.Client.PhoneNumber,
                                                 Privilegy = c.Client.Privilegy.Title,
                                                 SecondName = c.Client.SecondName,
                                                 Id = c.Client.ClientID
                                             },
                                Date = c.Date,
                                Description = c.Description,
                            };
        }

        /// <summary>
        /// Updates the entry.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="isNew">if set to <c>true</c> [is new].</param>
        protected override EntityResume UpdateEntry(Resume entity, bool isNew)
        {
            var dbEntity = (isNew) ? new EntityResume() :
                                                           ObjectSet.Single(x => x.ClientID == entity.Id);
            dbEntity.ClientID = entity.Client.Id;
            dbEntity.Title = entity.Title;
            dbEntity.Date = DateTime.Now;
            dbEntity.Description = entity.Description;
            return dbEntity;
        }

        /// <summary>
        /// Gets the last.
        /// </summary>
        /// <param name="login">The login.</param>
        public int GetLast(string login)
        {
            var some = GetQuery().Where(x => x.Client.Login == login).ToArray();
            return some[some.Length - 1].Id;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void Delete(Resume entity)
        {
            ObjectSet.DeleteObject(ObjectSet.Single(x => x.ResumeID == entity.Id));
            base.Delete(entity);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="login">The login.</param>
        public Resume[] GetAll(string login)
        {
            return GetQuery().Where(x => x.Client.Login == login).ToArray();
        }

        /// <summary>
        /// Gets the first or default.
        /// </summary>
        /// <param name="id">The id.</param>
        public Resume GetFirstOrDefault(int id)
        {
            return GetQuery().FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Searches the client.
        /// </summary>
        /// <param name="value">The value.</param>
        public List<Resume> SearchClient(string value)
        {
            var wordStrings = Regex.Matches(value, @"(?<word>\w+)");
            var result = GetQuery();
            result = wordStrings.Cast<object>()
                                                  .Aggregate(result,
                                                                          (current, str) => current.FindClients(str.ToString()));
            return result.ToList();

        }

        /// <summary>
        /// Searches the other.
        /// </summary>
        /// <param name="value">The value.</param>
        public List<Resume> SearchOther(string value)
        {
            var wordStrings = Regex.Matches(value, @"(?<word>\w+)");
            var result = GetQuery();
            result = wordStrings.Cast<object>()
                                                  .Aggregate(result,
                                                                          (current, str) => current.FindOther(str.ToString()));
            return result.ToList();
        }
    }
}