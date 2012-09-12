using System.Collections.Generic;
using BusinessLogic.Error;
using DataAccessLayer.Adapter;
using DataAccessLayer;
using Model;

namespace BusinessLogic
{
    /// <summary>
    /// Service of theme data
    /// </summary>
    /// <remarks>Base on ThemeRepository</remarks>
    public static class ThemeService
    {
        private static readonly ObjectContextAdapter Context = new ObjectContextAdapter();
        private static readonly ThemeRepository Theme = new ThemeRepository(Context);

        #region Theme CRUD
        /// <summary>
        /// Gets the themes.
        /// </summary>
        public static IEnumerable<Theme> GetThemes()
        {
            return Theme.GetAll();
        }

        /// <summary>
        /// Gets the themes.
        /// </summary>
        /// <param name="fieldId">The field id.</param>
        public static IEnumerable<Theme> GetThemes(int fieldId)
        {
            return fieldId < 1 ? null : Theme.GetAll(fieldId);
        }

        /// <summary>
        /// Gets the theme.
        /// </summary>
        /// <param name="id">The id.</param>
        public static Theme GetTheme(int id)
        {
            return id < 1 ? null : Theme.GetFirstOrDefault(id);
        }

        /// <summary>
        /// Deletes the theme.
        /// </summary>
        /// <param name="theme">The theme.</param>
        public static void DeleteTheme(Theme theme)
        {
            if (theme==null||theme.Id< 1)
                throw new CustomException("Invalid theme argument","Can`t delete this argument");

            Theme.Delete(theme);
            Context.SaveChanges();
        }
        /// <summary>
        /// Adds the theme.
        /// </summary>
        /// <param name="theme">The theme.</param>
        public static void AddTheme(Theme theme)
        {
            if (theme==null||
                 string.IsNullOrEmpty(theme.Title) || 
                 string.IsNullOrEmpty(theme.GroupName) || 
                 theme.FieldId == 0)
               throw new CustomException("Invalid theme argument","Can`t add this value");

            Theme.Add(theme);
            Context.SaveChanges();
        }
        /// <summary>
        /// Updates the theme.
        /// </summary>
        /// <param name="theme">The theme.</param>
        public static void UpdateTheme(Theme theme)
        {
            if (theme==null||
                 string.IsNullOrEmpty(theme.Title)||
                 string.IsNullOrEmpty(theme.GroupName)|| 
                 theme.FieldId == 0||
                 theme.Id==0)
                throw new CustomException("Invalid theme argument","Can`t update this argument");

            Theme.Update(theme);
            Context.SaveChanges();
        }

        #endregion
    }
}
