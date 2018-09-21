using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Everhour.Net.Models
{
    public class UserWithTaskEstimateConverter : BaseJsonConverter<List<UserWithTaskEstimate>>
    {
        public override bool CanWrite
        {
            get { return false; }
        }

        protected override List<UserWithTaskEstimate> ReadInternal(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartObject) return null;

            JObject jObject = JObject.Load(reader);
            var users = new List<UserWithTaskEstimate>();
            foreach (var j in jObject)
            {
                var id = int.TryParse(j.Key, out var tempId) ? tempId : default(int);
                var taskEstimate = j.Value.ToObject<int>();
                users.Add(new UserWithTaskEstimate() { Id = id, TaskEstimate = taskEstimate });
            }
            return users;
        }
    }
}