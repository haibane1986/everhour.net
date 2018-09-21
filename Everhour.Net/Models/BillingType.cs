using System;
using System.Collections.Generic;
using System.Linq;

namespace Everhour.Net.Models
{
    /// <summary>
    /// Billing Type.
    /// </summary>
    public class BillingType : Enumeration
    {
        /// <summary>
        /// Flat-rate project (single rate for all team members).
        /// </summary>
        public static BillingType FLAT_RATE = new BillingType(1, nameof(FLAT_RATE).ToLowerInvariant());
        /// <summary>
        /// User-rate project (each team member has individual rate).
        /// </summary>
        public static BillingType USER_RATE = new BillingType(2, nameof(USER_RATE).ToLowerInvariant());
 
        protected BillingType()
        {
        }
 
        public BillingType(int id, string name)
            : base(id, name)
        {
        }
 
        public static IEnumerable<BillingType> List() => new[] { FLAT_RATE, USER_RATE };
 
        public static BillingType FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for BillingType: {String.Join(",", List().Select(s => s.Name))}. argument={name}.");
            }
 
            return state;
        }
 
        public static BillingType From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for BillingType: {String.Join(",", List().Select(s => s.Name))}. argument={id}.");
            }
 
            return state;
        }
    }
}