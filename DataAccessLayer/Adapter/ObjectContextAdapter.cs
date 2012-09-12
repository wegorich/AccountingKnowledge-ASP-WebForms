using System.Data.Objects;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Adapter
{
    /// <summary>
    /// Adapter for object context, use in all Repositories.
    /// </summary>
    public class ObjectContextAdapter : IObjectContext
    {
        readonly ObjectContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectContextAdapter"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ObjectContextAdapter(ObjectContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectContextAdapter"/> class.
        /// </summary>
        public ObjectContextAdapter()
            : this(new AkDbEntities())
        {}

        /// <summary>
        /// Performs application-defined tasks associated with freeing, 
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }

        /// <summary>
        /// Creates the object set.
        /// </summary>
        /// <typeparam name="T">Entity model.</typeparam>
        /// <returns>Object set of entity model.</returns>
        public IObjectSet<T> CreateObjectSet<T>() where T : class
        {
            return _context.CreateObjectSet<T>();
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
