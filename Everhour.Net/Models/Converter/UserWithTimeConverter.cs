using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Everhour.Net.Models
{
    public class UserWithTimeConverter : BaseJsonConverter<List<UserWithTime>>
    {
        public override bool CanWrite
        {
            get { return false; }
        }

        protected override List<UserWithTime> ReadInternal(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartObject) return null;

            JObject jObject = JObject.Load(reader);
            var users = new List<UserWithTime>();
            foreach (var j in jObject)
            {
                var id = int.TryParse(j.Key, out var tempId) ? tempId : default(int);
                var time = j.Value.ToObject<int>();
                users.Add(new UserWithTime() { Id = id, Time = time });
            }
            return users;
        }
    }
}