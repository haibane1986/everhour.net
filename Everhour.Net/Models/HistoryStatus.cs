using System;
using System.Collections.Generic;
using System.Linq;

namespace Everhour.Net.Models
{
    public class HistoryStatus : Enumeration
    {
        public static HistoryStatus TIMER = new HistoryStatus(1, nameof(TIMER).ToLowerInvariant());
        public static HistoryStatus ADD = new HistoryStatus(2, nameof(ADD).ToLowerInvariant());
        public static HistoryStatus EDIT = new HistoryStatus(3, nameof(EDIT).ToLowerInvariant());
        public static HistoryStatus REMOVE = new HistoryStatus(4, nameof(REMOVE).ToLowerInvariant());
        public static HistoryStatus COMMENT = new HistoryStatus(5, nameof(COMMENT).ToLowerInvariant());
        public static HistoryStatus MOVE = new HistoryStatus(6, nameof(MOVE).ToLowerInvariant());
 
        protected HistoryStatus()
        {
        }
 
        public HistoryStatus(int id, string name)
            : base(id, name)
        {
        }
 
        public static IEnumerable<HistoryStatus> List() => new[] { TIMER, ADD, EDIT, REMOVE, COMMENT, MOVE };
 
        public static HistoryStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for HistoryStatus: {String.Join(",", List().Select(s => s.Name))}. argument={name}.");
            }
 
            return state;
        }
 
        public static HistoryStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for HistoryStatus: {String.Join(",", List().Select(s => s.Name))}. argument={id}.");
            }
 
            return state;
        }
    }
}