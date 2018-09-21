using System;
using System.Collections.Generic;
using System.Linq;

namespace Everhour.Net.Models
{
    public class ProjectType : Enumeration
    {
        /// <summary>
        /// Board project.
        /// </summary>
        public static ProjectType BOARD = new ProjectType(1, nameof(BOARD).ToLowerInvariant());
        /// <summary>
        /// To-do list project.
        /// </summary>
        public static ProjectType LIST = new ProjectType(2, nameof(LIST).ToLowerInvariant());
 
        protected ProjectType()
        {
        }
 
        public ProjectType(int id, string name)
            : base(id, name)
        {
        }
 
        public static IEnumerable<ProjectType> List() => new[] { BOARD, LIST };
 
        public static ProjectType FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for ProjectType: {String.Join(",", List().Select(s => s.Name))}. argument={name}.");
            }
 
            return state;
        }
 
        public static ProjectType From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for ProjectType: {String.Join(",", List().Select(s => s.Name))}. argument={id}.");
            }
 
            return state;
        }
    }
}