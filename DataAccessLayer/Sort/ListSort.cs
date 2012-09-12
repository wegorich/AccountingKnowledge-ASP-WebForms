using System;
using System.Collections.Generic;
using System.Collections;

namespace DataAccessLayer.Sort
{
    public class ListSorter<T> : IComparer<T>
    {
        #region Constructor
        public ListSorter(string pPropertyName)
        {
            PropertyName = pPropertyName;
        }
        #endregion

        #region Property

        public string PropertyName { get; set; }

        #endregion

        #region IComparer<T> Members

        /// <summary>
        /// This comparer is used to sort the generic comparer
        /// The constructor sets the PropertyName that is used
        /// by reflection to access that property in the object to 
        /// object compare.
        /// </summary>
        public int Compare(T x, T y)
        {
            var t = x.GetType();
            var val = t.GetProperty(PropertyName);
            if (val != null)
            {
                return Comparer.DefaultInvariant.Compare(val.GetValue(x, null), val.GetValue(y, null));
            }
            throw new Exception(PropertyName + " is not a valid property to sort on.  It doesn't exist in the Class.");
        }

        #endregion
    }
}