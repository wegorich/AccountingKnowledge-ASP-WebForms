using System;
using System.Linq;
using System.Linq.Expressions;
using DataAccessLayer.Adapter;
using DataAccessLayer.Entity;
using DataAccessLayer.Generic;
using Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Role data model repository
    /// </summary>
    public class PrivilegyRepository : BaseRepository<Privilegy,EntityPrivilegy>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrivilegyRepository"/> class.
        /// </summary>
        /// <param name="objectContext">The object context.</param>
        public PrivilegyRepository(IObjectContext objectContext)
            : base(objectContext)
        {
        }

        /// <summary>
        /// Gets the converter.
        /// </summary>
        protected override Expression<Func<EntityPrivilegy,Privilegy>> GetConverter()
        {
            return c => new Privilegy
                            {
                                 Id = c.PrivilegyID,
                                 Title = c.Title
                            };
        }

        /// <summary>
        /// Updates the entry.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="isNew">if set to <c>true</c> [is new].</param>
        protected override EntityPrivilegy UpdateEntry(Privilegy entity, bool isNew)
        {
            var dbEntity = (isNew) ? new EntityPrivilegy() :
                                                           ObjectSet.Single(x => x.PrivilegyID == entity.Id);
            dbEntity.Title = entity.Title;
            return dbEntity;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void Delete(Privilegy entity)
        {
            ObjectSet.DeleteObject(ObjectSet.Single(x => x.PrivilegyID == entity.Id));
            base.Delete(entity);
        }

        /// <summary>
        /// Gets the id by title.
        /// </summary>
        /// <param name="title">The title.</param>
        public short GetIdByTitle(string title)
        {
            return GetQuery().Single(x => x.Title == title).Id;
        }

        /// <summary>
        /// Determines whether the specified title is exist.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns><c>true</c> if the specified title is exist; otherwise, <c>false</c>.</returns>
        public bool IsExist(string title)
        {
            return GetQuery().Count(x => x.Title == title) > 0;
        }

        /// <summary>
        /// Gets the first or default.
        /// </summary>
        /// <param name="title">The title.</param>
        public Privilegy GetFirstOrDefault(string title)
        {
            return GetQuery().FirstOrDefault(x => x.Title == title);
        }
    }
}