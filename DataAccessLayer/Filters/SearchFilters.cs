using System.Linq;
using Model;

namespace DataAccessLayer.Filters
{
    /// <summary>
    /// The search filters class.
    /// </summary>
    internal static class SearchFilters
    {
        /// <summary>
        /// Finds the clients.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="value">The value.</param>
        /// <returns>Query of resume.</returns>
        public static IQueryable<Resume> FindClients(this IQueryable<Resume> item, string value)
        {
            return item.Where(x => x.Client.FirstName.Contains(value) ||
                                   x.Client.SecondName.Contains(value) ||
                                   x.Client.Email.Contains(value) ||
                                   x.Client.PhoneNumber.Contains(value)
                );
        }

        /// <summary>
        /// Finds the other.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="value">The value.</param>
        /// <returns>Query of resume.</returns>
        public static IQueryable<Resume> FindOther(this IQueryable<Resume> item, string value)
        {
            return item.Where(x => x.Title.Contains(value) ||
                                   x.Description.Contains(value));
        }

        /// <summary>
        /// Finds the theme.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="value">The value.</param>
        /// <returns>Query of resumes theme.</returns>
        public static IQueryable<ResumeTheme> FindTheme(this IQueryable<ResumeTheme> item, string value)
        {
            return item.Where(x => x.FieldName.Contains(value) ||
                                   x.SkillName.Contains(value) ||
                                   x.ThemeName.Contains(value));
        }
    }
}