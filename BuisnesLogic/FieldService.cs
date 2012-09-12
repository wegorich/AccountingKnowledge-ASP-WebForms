using System.Collections.Generic;
using BusinessLogic.Error;
using DataAccessLayer;
using DataAccessLayer.Adapter;
using Model;

namespace BusinessLogic
{
    /// <summary>
    /// Service of field data.
    /// </summary>
    /// <remarks>Base on FieldRepository.</remarks>
    public static class FieldService
    {
        private static readonly ObjectContextAdapter Context = new ObjectContextAdapter();
        private static readonly FieldRepository Field = new FieldRepository(Context);
        
        #region Field GRUD
        /// <summary>
        /// Gets the feilds.
        /// </summary>
        public static IEnumerable<Field> GetFeilds()
        {
            return Field.GetAll();
        }

        /// <summary>
        /// Gets the field.
        /// </summary>
        /// <param name="id">The id.</param>
        public static Field GetField(int id)
        {
            return id < 1 ? null : Field.GetFirstOrDefault(id);
        }

        /// <summary>
        /// Deletes the field.
        /// </summary>
        /// <param name="field">The field.</param>
        public static void DeleteField(Field field)
        {
            if (field==null||field.Id < 1)
                throw new CustomException("Invalid field of knowledge argument","Can`t delete field");
            
            Field.Delete(field);
            Context.SaveChanges();
        }

        /// <summary>
        /// Adds the field.
        /// </summary>
        /// <param name="field">The field.</param>
        public static void AddField(Field field)
        {
            if (field==null||string.IsNullOrEmpty(field.Title))
                throw new CustomException("Invalid field of knowledge argument","Can`t add this value");

            Field.Add(field);
            Context.SaveChanges();
        }

        /// <summary>
        /// Updates the field.
        /// </summary>
        /// <param name="field">The field.</param>
        public static void UpdateField(Field field)
        {
            if (field == null || field.Id < 1)
                throw new CustomException("Invalid field of knowledge argument","Can`t update this value");

            Field.Update(field);
            Context.SaveChanges();
        }
        #endregion
    }
}
