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
    /// Resume theme data model repository.
    /// </summary>
    public class ResumeThemeRepository : BaseRepository<ResumeTheme, EntityResumeTheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResumeThemeRepository"/> class.
        /// </summary>
        /// <param name="objectContext">The object context.</param>
        public ResumeThemeRepository(IObjectContext objectContext)
            : base(objectContext)
        {
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="resumeId">The resume id.</param>
        public IEnumerable<ResumeTheme> GetAll(int resumeId)
        {
            return GetQuery().Where(x => x.ResumeId == resumeId);
        }

        /// <summary>
        /// Gets the converter.
        /// </summary>
        protected override Expression<Func<EntityResumeTheme, ResumeTheme>> GetConverter()
        {
            return c => new ResumeTheme
                            {
                                Id = c.ResumeThemeID,
                                ThemeId = c.ThemeID,
                                ResumeId = c.ResumeID,
                                SkillId = c.SkillID,
                                ThemeName = c.Theme.Title,
                                SkillName = c.Theme.SkillGroup.Skill
                                                                                          .Where(x => x.SkillID == c.SkillID)
                                                                                          .Select(x => x.Title)
                                                                                          .FirstOrDefault(),
                                FieldName = c.Theme.FieldOfKnowledge.Title
                            };
        }

        /// <summary>
        /// Updates the entry.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="isNew">if set to <c>true</c> [is new].</param>
        protected override EntityResumeTheme UpdateEntry(ResumeTheme entity, bool isNew)
        {
            var dbEntity = (isNew) ? new EntityResumeTheme() :
                                                           ObjectSet.Single(x => x.ResumeThemeID == entity.Id);
            dbEntity.ResumeID = entity.ResumeId;
            dbEntity.ThemeID = entity.ThemeId;
            dbEntity.SkillID = entity.SkillId;
            return dbEntity;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void Delete(ResumeTheme entity)
        {
            ObjectSet.DeleteObject(ObjectSet.Single(x => x.ResumeThemeID == entity.Id));
            base.Delete(entity);
        }

        /// <summary>
        /// Gets the first or default.
        /// </summary>
        /// <param name="id">The id.</param>
        public ResumeTheme GetFirstOrDefault(int id)
        {
            return GetQuery().FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Searches the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public IEnumerable<int> Search(string value)
        {
            var wordStrings = Regex.Matches(value, @"(?<word>\w+)");
            var result = GetQuery();
            result = wordStrings.Cast<object>().Aggregate(result, (current, str) => current.FindTheme(value));
            return result.Select(x => x.ResumeId)
                                   .Distinct();
        }
    }
}