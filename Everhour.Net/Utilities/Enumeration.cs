using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Everhour.Net
{
    public abstract class Enumeration : IComparable
    {
        public string Name { get; private set; }
 
        public int Id { get; private set; }
 
        protected Enumeration()
        {
        }
 
        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }
 
        public override string ToString()
        {
            return Name;
        }
 
        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            return (from field in fields let instance = (T)Activator.CreateInstance(typeof(T), true) 
					select field.GetValue(instance)).OfType<T>();
        }
 
        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;
 
            if (otherValue == null)
            {
                return false;
            }
 
            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);
 
            return typeMatches && valueMatches;
        }
 
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
 
        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue.Id - secondValue.Id);
            return absoluteDifference;
        }
 
        public static T FromValue<T>(int value) where T : Enumeration, new()
        {
            var matchingItem = Parse<T, int>(value, "value", item => item.Id == value);
            return matchingItem;
        }
 
        public static T FromDisplayName<T>(string displayName) where T : Enumeration
        {
            var matchingItem = Parse<T, string>(displayName, "display name", item => item.Name?.ToLower() == displayName?.ToLower());
            return matchingItem;
        }
 
        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);
 
            if (matchingItem == null)
            {
                var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
 
                throw new InvalidOperationException(message);
            }
 
            return matchingItem;
        }
 
        public int CompareTo(object other)
        {
            return Id.CompareTo(((Enumeration)other).Id);
        }
    }
}