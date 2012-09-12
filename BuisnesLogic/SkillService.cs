using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Error;
using DataAccessLayer;
using DataAccessLayer.Adapter;
using Model;

namespace BusinessLogic
{
    /// <summary>
    /// Service of skill data
    /// </summary>
    /// <remarks>Base on SkillRepository</remarks>
    public static class SkillService
    {
        private static readonly ObjectContextAdapter Context = new ObjectContextAdapter();
        private static readonly SkillRepository Skill = new SkillRepository(Context);

        #region Skill CRUD
        /// <summary>
        /// Gets the skills.
        /// </summary>
        public static IEnumerable<Skill> GetSkills()
        {
            return Skill.GetAll();
        }

        /// <summary>
        /// Gets the skills with none.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="none">The none.</param>
        public static List<Skill> GetSkillsWithNone(string groupName, string none)
        {
            if (string.IsNullOrEmpty(groupName) || none == null)
                throw new CustomException("Invalid skill group argument","Invalid skill group name");

            var result = GetSkills(groupName).ToList();
            result.Insert(0, new Skill { GroupName = none, Title = none });

            return result;
        }

        /// <summary>
        /// Gets the skills.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        public static IEnumerable<Skill> GetSkills(string groupName)
        {
            if (string.IsNullOrEmpty(groupName))
                throw new CustomException("Invalid skill group argument","Invalid skill group name");

            return Skill.GetAll(groupName);
        }

        /// <summary>
        /// Gets the skill.
        /// </summary>
        /// <param name="id">The id.</param>
        public static Skill GetSkill(int id)
        {
            return id < 1 ? null : Skill.GetFirstOrDefault(id);
        }

        /// <summary>
        /// Adds the skill.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="groupName">Name of the group.</param>
        public static void AddSkill(string title, string groupName)
        {
            AddSkill(new Skill
            {
                GroupName = groupName,
                Title = title
            });
        }

        /// <summary>
        /// Deletes the skill.
        /// </summary>
        /// <param name="skill">The skill.</param>
        public static void DeleteSkill(Skill skill)
        {
            if (skill == null || skill.Id < 1)
                throw new CustomException("Invalid skill argument","Can`t delete this value");

            Skill.Delete(skill);
            Context.SaveChanges();
        }
        /// <summary>
        /// Deletes the skill.
        /// </summary>
        /// <param name="id">The id.</param>
        public static void DeleteSkill(int id)
        {
            DeleteSkill(new Skill { Id = id });
        }
        /// <summary>
        /// Adds the skill.
        /// </summary>
        /// <param name="skill">The skill.</param>
        public static void AddSkill(Skill skill)
        {
            if (skill == null ||
                string.IsNullOrEmpty(skill.Title) ||
                string.IsNullOrEmpty(skill.GroupName))
                throw new CustomException("Invalid skill argument","Can`t add this value");

            Skill.Add(skill);
            Context.SaveChanges();
        }

        /// <summary>
        /// Updates the skill.
        /// </summary>
        /// <param name="skill">The skill.</param>
        public static void UpdateSkill(Skill skill)
        {
            if (skill == null ||
                skill.Id < 1 ||
                string.IsNullOrEmpty(skill.Title) ||
                string.IsNullOrEmpty(skill.GroupName))
                throw new CustomException("Invalid skill argument","Can`t update this argument");

            Skill.Update(skill);
            Context.SaveChanges();
        }

        /// <summary>
        /// Updates the skill.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="title">The title.</param>
        public static void UpdateSkill(int id, string groupName, string title)
        {
            UpdateSkill(new Skill
            {
                Id = id,
                GroupName = groupName,
                Title = title
            });
        }
        #endregion
    }
}
