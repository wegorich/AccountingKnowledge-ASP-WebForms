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
    /// Theme data model repository.
    /// </summary>
    public class ThemeRepository : BaseRepository<Theme, EntityTheme>
    {
        private readonly SkillGroupRepository _group;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeRepository"/> class.
        /// </summary>
        /// <param name="objectContext">The object context.</param>
        public ThemeRepository(IObjectContext objectContext)
            : base(objectContext)
        {
            _group = new SkillGroupRepository(objectContext);
        }

        #region Base override
        /// <summary>
        /// Gets the converter.
        /// </summary>
        protected override Expression<Func<EntityTheme, Theme>> GetConverter()
        {
            return c => new Theme
                            {
                                 Id = c.ThemeID,
                                 Title = c.Title,
                                 FieldId=c.FieldID,
                                 GroupName=c.SkillGroup.Title
                            };
        }

        /// <summary>
        /// Updates the entry.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="isNew">if set to <c>true</c> [is new].</param>
        protected override EntityTheme UpdateEntry(Theme entity, bool isNew)
        {
            var dbEntity = (isNew) ? new EntityTheme() :
                                                           ObjectSet.Single(x => x.ThemeID == entity.Id);
            dbEntity.Title = entity.Title;
            dbEntity.FieldID = entity.FieldId;
            dbEntity.GroupID = _group.GetFirstOrDefault(entity.GroupName).Id; 
            return dbEntity;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void Delete(Theme entity)
        {
            ObjectSet.DeleteObject(ObjectSet.Single(x => x.ThemeID == entity.Id));
            base.Delete(entity);
        }
        #endregion

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="fieldId">The field id.</param>
        public IEnumerable<Theme> GetAll(int fieldId)
        {
            return GetQuery().Where(x => x.FieldId == fieldId).ToArray();
        }

        /// <summary>
        /// Gets the first or default.
        /// </summary>
        /// <param name="id">The id.</param>
        public Theme GetFirstOrDefault(int id)
        {
            return GetQuery().FirstOrDefault(x => x.Id == id);
        }
    }
}