using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Adapter;
using Model;

namespace BusinessLogic.Search
{
    /// <summary>
    /// Search stategy for only resume data entity field .
    /// </summary>
      public class OtherSearchStrategy : ISearchStrategy
    {
        private ResumeRepository _resume;

        /// <summary>
        /// Sets the set context.
        /// </summary>
        /// <value>The set context.</value>
        public ObjectContextAdapter SetContext
        {
            set { _resume = new ResumeRepository(value); }
        }

        /// <summary>
        /// Searches the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public List<Resume> Search(string value)
        {
            var result = _resume.SearchOther(value);
            ResumeService.AddFields(result);
            return result;
        }
    }
}
