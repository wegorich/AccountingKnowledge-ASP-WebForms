using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Error;
using DataAccessLayer;
using DataAccessLayer.Adapter;
using Model;

namespace BusinessLogic
{
    /// <summary>
    /// Service of resume theme data.
    /// </summary>
    /// <remarks>It base on ResumeThemeRepository.</remarks>
    public class ResumeThemeService
    {
        private static readonly ObjectContextAdapter Context = new ObjectContextAdapter();
        private static readonly ResumeThemeRepository ResumeTheme = new ResumeThemeRepository(Context);

        #region Resume theme CRUD
        /// <summary>
        /// Gets the resume themes.
        /// </summary>
        public static IEnumerable<ResumeTheme> GetResumeThemes()
        {
            return ResumeTheme.GetAll();
        }

        /// <summary>
        /// Gets the resume theme.
        /// </summary>
        /// <param name="id">The id.</param>
        public static ResumeTheme GetResumeTheme(int id)
        {
            return id < 1 ? null : ResumeTheme.GetFirstOrDefault(id);
        }

        /// <summary>
        /// Deletes the resume theme.
        /// </summary>
        /// <param name="resumeTheme">The resume theme.</param>
        public static void DeleteResumeTheme(ResumeTheme resumeTheme)
        {
            if (resumeTheme == null ||
                resumeTheme.Id < 1)
                throw new CustomException("Invalid part of resume","Can`t delete this value");

            ResumeTheme.Delete(resumeTheme);
            Context.SaveChanges();
        }

        /// <summary>
        /// Adds the resume theme.
        /// </summary>
        /// <param name="resumeTheme">The resume theme.</param>
        public static void AddResumeTheme(ResumeTheme resumeTheme)
        {
            if (resumeTheme == null ||
                resumeTheme.ResumeId < 1 ||
                resumeTheme.ThemeId < 1 ||
                resumeTheme.SkillId < 1)
                throw new CustomException("Invalid part of resume","Can`t add this value");

            ResumeTheme.Add(resumeTheme);
            Context.SaveChanges();
        }

        /// <summary>
        /// Updates the resume theme.
        /// </summary>
        /// <param name="resumeTheme">The resume theme.</param>
        public static void UpdateResumeTheme(ResumeTheme resumeTheme)
        {
            if (resumeTheme == null ||
                resumeTheme.ResumeId < 1 ||
                resumeTheme.ThemeId < 1 ||
                resumeTheme.SkillId < 1)
                throw new CustomException("Invalid part of resume","Can`t update this value");

            ResumeTheme.Update(resumeTheme);
            Context.SaveChanges();
        }
        #endregion

        /// <summary>
        /// Adds the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        public static void Add(List<ResumeField> list)
        {
            foreach (var item in list.SelectMany(item => item.Theme))
            {
                if (item == null ||
                    item.ResumeId < 1 ||
                    item.ThemeId < 1 ||
                    item.SkillId < 1)
                    throw new CustomException("Invalid part of resume","Add operation was broken by invalid argument");

                ResumeTheme.Add(item);
            }
            Context.SaveChanges();
        }

        /// <summary>
        /// Gets the resume fields.
        /// </summary>
        /// <param name="resumeId">The resume id.</param>
        public static List<ResumeField> GetResumeFields(int resumeId)
        {
            if (resumeId < 1)
                return null;

            var themes = ResumeTheme.GetAll(resumeId).OrderBy(x => x.FieldName);

            var result = new List<ResumeField>();
            ResumeField field = null;

            foreach (var theme in themes)
            {
                if (field == null || field.FieldName != theme.FieldName)
                {
                    field = new ResumeField
                                {
                                    FieldName = theme.FieldName,
                                    Theme = new List<ResumeTheme>()
                                };
                    result.Add(field);
                }
                field.Theme.Add(theme);
            }
            return result;
        }

    }
}
