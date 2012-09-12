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
    /// Field data model reposytory
    /// </summary>
    public class FieldRepository : BaseRepository<Field,EntityField>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldRepository"/> class.
        /// </summary>
        /// <param name="objectContext">The object context.</param>
        public FieldRepository(IObjectContext objectContext)
            : base(objectContext)
        {
        }

        #region Base override
        /// <summary>
        /// Gets the converter.
        /// </summary>
        protected override Expression<Func<EntityField,Field>> GetConverter()
        {
            return c => new Field
                            {
                                 Id = c.FieldID,
                                 Title = c.Title
                            };
        }

        /// <summary>
        /// Updates the entry.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="isNew">if set to <c>true</c> [is new].</param>
        protected override EntityField UpdateEntry(Field entity, bool isNew)
        {
            var dbEntity = (isNew) ? new EntityField() :
                                                           ObjectSet.Single(x => x.FieldID == entity.Id);
            dbEntity.Title = entity.Title;
            return dbEntity;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void Delete(Field entity)
        {
            ObjectSet.DeleteObject(ObjectSet.Single(x => x.FieldID == entity.Id));
            base.Delete(entity);
        }
        #endregion

        /// <summary>
        /// Gets the first or default.
        /// </summary>
        /// <param name="id">The id.</param>
        public Field GetFirstOrDefault(int id)
        {
            return GetQuery().FirstOrDefault(x => x.Id == id);
        }
    }
}