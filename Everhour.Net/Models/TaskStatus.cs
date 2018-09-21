using System;
using System.Collections.Generic;
using System.Linq;

namespace Everhour.Net.Models
{
    public class TaskStatus : Enumeration
    {
        public static TaskStatus OPEN = new TaskStatus(1, nameof(OPEN).ToLowerInvariant());
        public static TaskStatus CLOSED = new TaskStatus(2, nameof(CLOSED).ToLowerInvariant());
 
        protected TaskStatus()
        {
        }
 
        public TaskStatus(int id, string name)
            : base(id, name)
        {
        }
 
        public static IEnumerable<TaskStatus> List() => new[] { OPEN, CLOSED };
 
        public static TaskStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for TaskStatus: {String.Join(",", List().Select(s => s.Name))}. argument={name}.");
            }
 
            return state;
        }
 
        public static TaskStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for TaskStatus: {String.Join(",", List().Select(s => s.Name))}. argument={id}.");
            }
 
            return state;
        }
    }
}