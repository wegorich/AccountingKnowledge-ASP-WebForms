using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.Adapter;
using Model;

namespace BusinessLogic.Search
{

    /// <summary>
    /// Search strategy for resume theme entity.
    /// </summary>
    public class ThemeSearchStrategy:ISearchStrategy
    {
        private static ResumeThemeRepository _resumeTheme;

        /// <summary>
        /// Searches the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public List<Resume> Search(string value)
        {
            var resumesId = _resumeTheme.Search(value);
            return resumesId.Select(ResumeService.GetResume)
                                            .ToList();
        }

        /// <summary>
        /// Sets the set context.
        /// </summary>
        /// <value>The set context.</value>
        public ObjectContextAdapter SetContext
        {
            set { _resumeTheme = new ResumeThemeRepository(value); }
        }
    }
}
