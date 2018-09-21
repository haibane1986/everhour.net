using System;
using System.Collections.Generic;
using System.Linq;

namespace Everhour.Net.Models
{
    public class RoleType : Enumeration
    {
        public static RoleType ADMIN = new RoleType(1, nameof(ADMIN).ToLowerInvariant());
        public static RoleType SUPERVISOR = new RoleType(2, nameof(SUPERVISOR).ToLowerInvariant());
        public static RoleType MEMBER = new RoleType(3, nameof(MEMBER).ToLowerInvariant());
 
        protected RoleType()
        {
        }
 
        public RoleType(int id, string name)
            : base(id, name)
        {
        }
 
        public static IEnumerable<RoleType> List() => new[] { ADMIN, SUPERVISOR, MEMBER };
 
        public static RoleType FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for RoleType: {String.Join(",", List().Select(s => s.Name))}. argument={name}.");
            }
 
            return state;
        }
 
        public static RoleType From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for RoleType: {String.Join(",", List().Select(s => s.Name))}. argument={id}.");
            }
 
            return state;
        }
    }
}