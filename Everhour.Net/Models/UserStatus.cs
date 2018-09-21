using System;
using System.Collections.Generic;
using System.Linq;

namespace Everhour.Net.Models
{
    public class UserStatus : Enumeration
    {
        public static UserStatus ACTIVE = new UserStatus(1, nameof(ACTIVE).ToLowerInvariant());
        public static UserStatus INVITED = new UserStatus(2, nameof(INVITED).ToLowerInvariant());
        public static UserStatus PENDING = new UserStatus(3, nameof(PENDING).ToLowerInvariant());
        public static UserStatus REMOVED = new UserStatus(4, nameof(REMOVED).ToLowerInvariant());
 
        protected UserStatus()
        {
        }
 
        public UserStatus(int id, string name)
            : base(id, name)
        {
        }
 
        public static IEnumerable<UserStatus> List() => new[] { ACTIVE, INVITED, PENDING, REMOVED };
 
        public static UserStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for UserStatus: {String.Join(",", List().Select(s => s.Name))}. argument={name}.");
            }
 
            return state;
        }
 
        public static UserStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for UserStatus: {String.Join(",", List().Select(s => s.Name))}. argument={id}.");
            }
 
            return state;
        }
    }
}