using System;
using System.Collections.Generic;
using System.Linq;

namespace Everhour.Net.Models
{
    public class EstimateType : Enumeration
    {
        public static EstimateType OVERALL = new EstimateType(1, nameof(OVERALL).ToLowerInvariant());
        public static EstimateType USERS = new EstimateType(2, nameof(USERS).ToLowerInvariant());
 
        protected EstimateType()
        {
        }
 
        public EstimateType(int id, string name)
            : base(id, name)
        {
        }
 
        public static IEnumerable<EstimateType> List() => new[] { OVERALL, USERS };
 
        public static EstimateType FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for EstimateType: {String.Join(",", List().Select(s => s.Name))}. argument={name}.");
            }
 
            return state;
        }
 
        public static EstimateType From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for EstimateType: {String.Join(",", List().Select(s => s.Name))}. argument={id}.");
            }
 
            return state;
        }
    }
}