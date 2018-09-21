using System;
using System.Collections.Generic;
using System.Linq;

namespace Everhour.Net.Models
{
    public class SectionStatus : Enumeration
    {
        public static SectionStatus OPEN = new SectionStatus(1, nameof(OPEN).ToLowerInvariant());
        public static SectionStatus ARCHIVED = new SectionStatus(2, nameof(ARCHIVED).ToLowerInvariant());
 
        protected SectionStatus()
        {
        }
 
        public SectionStatus(int id, string name)
            : base(id, name)
        {
        }
 
        public static IEnumerable<SectionStatus> List() => new[] { OPEN, ARCHIVED };
 
        public static SectionStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for SectionStatus: {String.Join(",", List().Select(s => s.Name))}. argument={name}.");
            }
 
            return state;
        }
 
        public static SectionStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for SectionStatus: {String.Join(",", List().Select(s => s.Name))}. argument={id}.");
            }
 
            return state;
        }
    }
}