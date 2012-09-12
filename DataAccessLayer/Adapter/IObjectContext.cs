using System;
using System.Data.Objects;

namespace DataAccessLayer.Adapter
{
    /// <summary>
    /// Interface of object context, fore make ObjectSet more custom
    /// </summary>
    public interface IObjectContext : IDisposable
    {
        /// <summary>
        /// Creates the object set.
        /// </summary>
        /// <typeparam name="T">Entity model.</typeparam>
        /// <returns>Object set of entity model.</returns>
        IObjectSet<T> CreateObjectSet<T>() where T : class;

        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();
    }
}
