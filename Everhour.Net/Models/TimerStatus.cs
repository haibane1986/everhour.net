using System;
using System.Collections.Generic;
using System.Linq;

namespace Everhour.Net.Models
{
    public class TimerStatus : Enumeration
    {
        public static TimerStatus ACTIVE = new TimerStatus(1, nameof(ACTIVE).ToLowerInvariant());
        public static TimerStatus STOPPED = new TimerStatus(2, nameof(STOPPED).ToLowerInvariant());
 
        protected TimerStatus()
        {
        }
 
        public TimerStatus(int id, string name)
            : base(id, name)
        {
        }
 
        public static IEnumerable<TimerStatus> List() => new[] { ACTIVE, STOPPED };
 
        public static TimerStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for TimerStatus: {String.Join(",", List().Select(s => s.Name))}. argument={name}.");
            }
 
            return state;
        }
 
        public static TimerStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for TimerStatus: {String.Join(",", List().Select(s => s.Name))}. argument={id}.");
            }
 
            return state;
        }
    }
}