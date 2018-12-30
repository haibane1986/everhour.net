using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Everhour.Net.Models
{
    public class UserWithTimeConverter : BaseJsonConverter<List<UserWithTime>>
    {
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

        protected override void WriteInternal(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = JToken.FromObject(value);
            if (t.Type != JTokenType.Array) return;
            if (!(value is List<UserWithTime>)) return;
            
            var users = (List<UserWithTime>)value;
            var o = new JObject();
            foreach (var user in users)
            {
                o.Add(new JProperty(user.Id.ToString(), new JValue(user.Time)));
            }
            o.WriteTo(writer);
        }
    }
}