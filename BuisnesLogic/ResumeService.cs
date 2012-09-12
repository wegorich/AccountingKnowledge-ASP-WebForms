using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Error;
using BusinessLogic.Search;
using DataAccessLayer;
using DataAccessLayer.Adapter;
using DataAccessLayer.Sort;
using Model;

namespace BusinessLogic
{
    /// <summary>
    /// Service of resume data.
    /// </summary>
    /// <remarks>Base on ResumeRepository.</remarks>
    public static class ResumeService
    {
        private static readonly ObjectContextAdapter Context = new ObjectContextAdapter();
        private static readonly ResumeRepository Resume = new ResumeRepository(Context);

        /// <summary>
        /// Adds the fields.
        /// </summary>
        /// <param name="resumes">The resumes.</param>
        public static void AddFields(IEnumerable<Resume> resumes)
        {
            foreach (var resume in resumes)
            {
                resume.Fields = ResumeThemeService.GetResumeFields(resume.Id);
            }
        }

        /// <summary>
        /// Adds the fields.
        /// </summary>
        /// <param name="resume">The resume.</param>
        private static void AddFields(Resume resume)
        {
            resume.Fields = ResumeThemeService.GetResumeFields(resume.Id);
        }

        #region Resume CRUD
        /// <summary>
        /// Gets the resumes.
        /// </summary>
        public static IEnumerable<Resume> GetResumes()
        {
            var resumes = Resume.GetAll().ToArray();
            AddFields(resumes);
            return resumes;
        }

        /// <summary>
        /// Gets the resumes.
        /// </summary>
        /// <param name="login">The login.</param>
        public static Resume[] GetResumes(string login)
        {
            if (string.IsNullOrEmpty(login))
                throw new CustomException("Invalid user argument","Can`t select user");

            var resumes = Resume.GetAll(login);
            AddFields(resumes);
            return resumes;
        }

        /// <summary>
        /// Gets the resume.
        /// </summary>
        /// <param name="id">The id.</param>
        public static Resume GetResume(int id)
        {
            if (id < 1)
                return null;

            var resume = Resume.GetFirstOrDefault(id);
            AddFields(resume);
            return resume;
        }

        /// <summary>
        /// Deletes the resume.
        /// </summary>
        /// <param name="resume">The resume.</param>
        public static void DeleteResume(Resume resume)
        {
            if (resume==null||resume.Id<1)
                throw new CustomException("Invalid resume argument","Can`t delete resume");

            Resume.Delete(resume);
            Context.SaveChanges();
        }

        /// <summary>
        /// Adds the resume.
        /// </summary>
        /// <param name="resume">The resume.</param>
        public static int AddResume(Resume resume)
        {
            if (resume == null ||
                resume.Client == null ||
                resume.Client.Id < 1 ||
                string.IsNullOrEmpty(resume.Title) ||
                string.IsNullOrEmpty(resume.Description))
                throw new CustomException("Invalid resume argument","Can`t add resume, some important parametrs were lost");
                
            Resume.Add(resume);
            Context.SaveChanges();
            var resumeId = Resume.GetLast(resume.Client.Login);

            if (resume.Fields != null)
            {
                foreach (var x in resume.Fields.SelectMany(item => item.Theme))
                {
                    x.ResumeId = resumeId;
                }
                ResumeThemeService.Add(resume.Fields);
            }

            return resumeId;
        }

        /// <summary>
        /// Updates the resume.
        /// </summary>
        /// <param name="resume">The resume.</param>
        public static void UpdateResume(Resume resume)
        {
            if (resume == null ||
                string.IsNullOrEmpty(resume.Title) ||
                string.IsNullOrEmpty(resume.Description))
                throw new CustomException("Invalid resume argument","Can`t update resume");
            
            Resume.Update(resume);
            Context.SaveChanges();
        }
        #endregion

        /// <summary>
        /// Gets the fake resume.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        /// <param name="userLogin">The user login.</param>
        /// <param name="list">The list.</param>
        public static Resume GetFakeResume(string title,
                                                                                   string description,
                                                                                   string userLogin,
                                                                                   List<ResumeField> list)
        {
            var client = ClientService.GetClient(userLogin);

            return new Resume
            {
                Date = DateTime.Now,
                Description = description,
                Title = title,
                Client = client,
                Fields = list
            };
        }

        /// <summary>
        /// Searches the strategy.
        /// </summary>
        public static ISearchStrategy SearchStrategy(string selection)
        {
            ISearchStrategy strategy;
            switch (selection)
            {
                default:
                    strategy = new OtherSearchStrategy();
                    break;
                case "field":
                    strategy = new ThemeSearchStrategy();
                    break;
                case "client":
                    strategy = new ClientSearchStrategy();
                    break;
            }
            return strategy;
        }
        
        /// <summary>
        /// Searches the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="searchStrategy">The search strategy.</param>
        /// <param name="startAge">The start age.</param>
        /// <param name="endAge">The end age.</param>
        /// <param name="sortExpression">The sort expression.</param>
        /// <param name="sortDirection">The sort direction.</param>
        public static List<Resume> Search(string value,
                                                                           ISearchStrategy searchStrategy,
                                                                           int startAge,
                                                                           int endAge,
                                                                           string sortExpression,
                                                                           string sortDirection)
        {
            if (searchStrategy == null)
                throw new CustomException("Invalid search","Search arguments were lost");
            
            searchStrategy.SetContext = Context;
         
            var result = string.IsNullOrEmpty(value) ? GetResumes().ToList() : 
                                                                                           searchStrategy.Search(value);
            result=Sort(result,sortExpression, sortDirection);
            result = FindByAge(result, startAge, endAge);
            
            return result;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        public static int Count()
        {
            return Resume.Count();
        }

        /// <summary>
        /// Finds the by age.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="startAge">The start age.</param>
        /// <param name="endAge">The end age.</param>
        public static List<Resume> FindByAge(List<Resume> list, int startAge, int endAge)
        {
            if (endAge == 0) endAge = 99;
            if ((startAge < 1 && endAge > 65)||startAge>=endAge) return list; 

            var now = DateTime.Now.Year;
            return list.Where(x => startAge <= (now - x.Client.BirthDay.Year) &&
                                            (now - x.Client.BirthDay.Year) <= endAge)
                                             .ToList();
        }

        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="sortExpression">The sort expression.</param>
        /// <param name="sortDirection">The sort direction.</param>
        public static List<Resume> Sort(List<Resume> list, string sortExpression,
                                                                           string sortDirection)
        {
            if (!string.IsNullOrEmpty(sortExpression))
            {
                list.Sort(new ListSorter<Resume>(sortExpression));
            }

            if (sortDirection != null && sortDirection == "Desc")
            {
                list.Reverse();
            }

            return list;
        }
    }
}
