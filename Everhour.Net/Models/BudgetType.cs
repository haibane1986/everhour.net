using System;
using System.Collections.Generic;
using System.Linq;

namespace Everhour.Net.Models
{
    /// <summary>
    /// Budget Type.
    /// </summary>
    public class BudgetType : Enumeration
    {
        /// <summary>
        /// FMoney budget.
        /// </summary>
        public static BudgetType MONEY = new BudgetType(1, nameof(MONEY).ToLowerInvariant());
        /// <summary>
        /// Time budget.
        /// </summary>
        public static BudgetType TIME = new BudgetType(2, nameof(TIME).ToLowerInvariant());
 
        protected BudgetType()
        {
        }
 
        public BudgetType(int id, string name)
            : base(id, name)
        {
        }
 
        public static IEnumerable<BudgetType> List() => new[] { MONEY, TIME };
 
        public static BudgetType FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for BudgetType: {String.Join(",", List().Select(s => s.Name))}. argument={name}.");
            }
 
            return state;
        }
 
        public static BudgetType From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);
 
            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Possible values for BudgetType: {String.Join(",", List().Select(s => s.Name))}. argument={id}.");
            }
 
            return state;
        }
    }
}