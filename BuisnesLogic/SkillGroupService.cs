using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Error;
using DataAccessLayer;
using DataAccessLayer.Adapter;
using Model;

namespace BusinessLogic
{
    /// <summary>
    /// Service of skill group data.
    /// </summary>
    /// <remarks>Base on SkillGroupRepository.</remarks>
   public static class SkillGroupService
    {
        private static readonly ObjectContextAdapter Context = new ObjectContextAdapter();
        private static readonly SkillGroupRepository SkillGroup = new SkillGroupRepository(Context);
       
        #region Skill Group CRUD
        /// <summary>
        /// Gets the skill groups.
        /// </summary>
        public static IEnumerable<SkillGroup> GetSkillGroups()
        {
            return SkillGroup.GetAll();
        }

        /// <summary>
        /// Gets the skill group titles.
        /// </summary>
        public static string[] GetSkillGroupTitles()
        {
            return SkillGroup.GetAll().Select(x=>x.Title).ToArray();
        }

        /// <summary>
        /// Gets the skill group.
        /// </summary>
        /// <param name="id">The id.</param>
        public static SkillGroup GetSkillGroup(int id)
        {
            return id < 1 ? null : SkillGroup.GetFirstOrDefault(id);
        }

        /// <summary>
        /// Deletes the skill group.
        /// </summary>
        /// <param name="group">The group.</param>
        public static void DeleteSkillGroup(SkillGroup group)
        {
            if (group==null||String.IsNullOrEmpty(group.Title))
                throw new CustomException("Invalid skill group argument","Can`t delete this argument");
            
            SkillGroup.Delete(group);
            Context.SaveChanges();
        }

        /// <summary>
        /// Adds the skill group.
        /// </summary>
        /// <param name="group">The group.</param>
        public static void AddSkillGroup(SkillGroup group)
        {
            if (group==null||String.IsNullOrEmpty(group.Title))
                throw new CustomException("Invalid skill group argument","Can`t add this argument");

            SkillGroup.Add(group);
            Context.SaveChanges();
        }

        /// <summary>
        /// Updates the skill group.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <remarks></remarks>
        public static void UpdateSkillGroup(SkillGroup group)
        {
            if (group==null||
                String.IsNullOrEmpty(group.Title)||
                group.Id <1)
                throw new CustomException("Invalid skill group argument","Can`t update this value");

            SkillGroup.Update(group);
            Context.SaveChanges();
        }
        #endregion

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <param name="title">The title.</param>
        public static int GetIndex(object title)
       {
            if(string.IsNullOrEmpty(title.ToString()))
                throw new CustomException("Invalid title argument","Can`t get this index");

           return SkillGroup.GetIndexOf(title);
       }
    }
}
