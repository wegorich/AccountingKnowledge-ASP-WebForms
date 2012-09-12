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
    /// Skill group data model repository.
    /// </summary>
    public class SkillGroupRepository : BaseRepository<SkillGroup, EntitySkillGroup>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkillGroupRepository"/> class.
        /// </summary>
        /// <param name="objectContext">The object context.</param>
         public SkillGroupRepository(IObjectContext objectContext)
            : base(objectContext)
        {
        }

        /// <summary>
        /// Gets the converter.
        /// </summary>
        protected override Expression<Func<EntitySkillGroup, SkillGroup>> GetConverter()
        {
            return c => new SkillGroup
                            {
                                 Id = c.GroupID,
                                 Title = c.Title
                            };
        }

        /// <summary>
        /// Updates the entry.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="isNew">if set to <c>true</c> [is new].</param>
        protected override EntitySkillGroup UpdateEntry(SkillGroup entity, bool isNew)
        {
            var dbEntity = (isNew) ? new EntitySkillGroup() :
                                                           ObjectSet.Single(x => x.GroupID == entity.Id);
            dbEntity.Title = entity.Title;
            return dbEntity;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void Delete(SkillGroup entity)
        {
            ObjectSet.DeleteObject(ObjectSet.Single(x => x.Title == entity.Title));
        }

        /// <summary>
        /// Gets the index of.
        /// </summary>
        /// <param name="title">The title.</param>
        public int GetIndexOf(object title)
        {
            return Array.IndexOf(GetQuery().Select(x => x.Title).ToArray(), title);
        }

        /// <summary>
        /// Gets the first or default.
        /// </summary>
        /// <param name="id">The id.</param>
        public SkillGroup GetFirstOrDefault(int id)
        {
            return GetQuery().FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Gets the first or default.
        /// </summary>
        /// <param name="title">The title.</param>
        public SkillGroup GetFirstOrDefault(string title)
        {
            return GetQuery().FirstOrDefault(x => x.Title == title);
        }
    }
}