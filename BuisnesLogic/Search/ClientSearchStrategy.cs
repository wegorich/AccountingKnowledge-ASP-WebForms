using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Adapter;
using Model;

namespace BusinessLogic.Search
{
    /// <summary>
    /// Search strategy for client data.
    /// </summary>
    /// <remarks></remarks>
    public class ClientSearchStrategy:ISearchStrategy
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
            var result = _resume.SearchClient(value);
            ResumeService.AddFields(result);
            return result;
        }
    }
}
