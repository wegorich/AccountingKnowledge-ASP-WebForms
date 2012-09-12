using System.Collections.Generic;
using DataAccessLayer.Adapter;
using Model;

namespace BusinessLogic.Search
{
    /// <summary>
    /// Base interfase for search strategy.
    /// </summary>
    public interface ISearchStrategy
    {
        /// <summary>
        /// Searches the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        List<Resume> Search(string value);
       
        /// <summary>
        /// Sets the set context.
        /// </summary>
        /// <value>The set context.</value>
        ObjectContextAdapter SetContext { set; }
    }
}
