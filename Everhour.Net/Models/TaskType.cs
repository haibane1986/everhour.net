using System;
using System.Collections.Generic;
using System.Linq;

namespace Everhour.Net.Models
{
    /// <summary>
    /// Task Type.
    /// </summary>
    public class TaskType : Enumeration
    {
        public static TaskType TASK = new TaskType(1, nameof(TASK).ToLowerInvariant());
 
        protected TaskType()
        {
        }
 
        public TaskType(int id, string name)
            : base(id, name)
        {
        }
 
        public static IEnumerable<TaskType> List() => new[] { TASK };
 
        public static TaskType FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for TaskType: {String.Join(",", List().Select(s => s.Name))}. argument={name}.");
            }
 
            return state;
        }
 
        public static TaskType From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for TaskType: {String.Join(",", List().Select(s => s.Name))}. argument={id}.");
            }
 
            return state;
        }
    }
}