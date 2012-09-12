using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using DataAccessLayer.Adapter;

namespace DataAccessLayer.Generic
{
    /// <summary>
    /// Base class for all Reposytories, empliment default method
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class BaseRepository<TModel, TEntity> : IRepository<TModel>
        where TModel : class
        where TEntity : class,new()
    {
        protected readonly IObjectSet<TEntity> ObjectSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository&lt;TModel, TEntity&gt;"/> class.
        /// </summary>
        /// <param name="objectContext">The object context.</param>
        protected BaseRepository(IObjectContext objectContext)
        {
            ObjectSet = objectContext.CreateObjectSet<TEntity>();
        }

        /// <summary>
        /// Gets the query.
        /// </summary>
        /// <returns>IQueryable for the Model</returns>
        protected IQueryable<TModel> GetQuery()
        {
            return ObjectSet.Select(GetConverter());
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        public int Count()
        {
            return ObjectSet.Count();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IEnumerable for the Model</returns>
        public IEnumerable<TModel> GetAll()
        {
            return GetQuery().ToArray();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Delete(TModel entity)
        {
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(TModel entity)
        {
            var dbEntity = UpdateEntry(entity, true);
            ObjectSet.AddObject(dbEntity);
        }

        /// <summary>
        /// Attaches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Attach(TModel entity)
        {
            var dbEntity = UpdateEntry(entity, true);
            ObjectSet.Attach(dbEntity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(TModel entity)
        {
            UpdateEntry(entity, false);
        }

        protected abstract Expression<Func<TEntity, TModel>> GetConverter();
        protected abstract TEntity UpdateEntry(TModel entity, bool isNew);

    }
}