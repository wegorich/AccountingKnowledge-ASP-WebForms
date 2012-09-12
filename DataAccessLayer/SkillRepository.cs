using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccessLayer.Adapter;
using DataAccessLayer.Entity;
using DataAccessLayer.Generic;
using Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Skill data model repository.
    /// </summary>
    public class SkillRepository : BaseRepository<Skill, EntitySkill>
    {
        private readonly SkillGroupRepository _group;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkillRepository"/> class.
        /// </summary>
        /// <param name="objectContext">The object context.</param>
        public SkillRepository(IObjectContext objectContext)
            : base(objectContext)
        {
            _group = new SkillGroupRepository(objectContext);
        }

        /// <summary>
        /// Gets the converter.
        /// </summary>
        protected override Expression<Func<EntitySkill, Skill>> GetConverter()
        {
            return c => new Skill
                            {
                                 Id = c.SkillID,
                                 Title = c.Title,
                                 GroupName=c.SkillGroup.Title
                            };
        }

        /// <summary>
        /// Updates the entry.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="isNew">if set to <c>true</c> [is new].</param>
        protected override EntitySkill UpdateEntry(Skill entity, bool isNew)
        {
            var dbEntity = (isNew) ? new EntitySkill() :
                                                           ObjectSet.Single(x => x.SkillID == entity.Id);
            dbEntity.Title = entity.Title;
            dbEntity.GroupID = _group.GetFirstOrDefault(entity.GroupName).Id;
            return dbEntity;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void Delete(Skill entity)
        {
            ObjectSet.DeleteObject(ObjectSet.Single(x => x.SkillID == entity.Id));
            base.Delete(entity);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        public IEnumerable<Skill> GetAll(string groupName)
        {
            return GetQuery().Where(x => x.GroupName == groupName).ToArray();
        }

        /// <summary>
        /// Gets the first or default.
        /// </summary>
        /// <param name="id">The id.</param>
        public Skill GetFirstOrDefault(int id)
        {
            return GetQuery().FirstOrDefault(x => x.Id == id);
        }
    }
}