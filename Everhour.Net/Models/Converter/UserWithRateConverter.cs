using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
namespace Everhour.Net.Models
{
    public class UserWithRateConverter : BaseJsonConverter<List<UserWithRate>>
    {
        protected override List<UserWithRate> ReadInternal(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartObject) return null;

            JObject jObject = JObject.Load(reader);
            var users = new List<UserWithRate>();
            foreach (var j in jObject)
            {
                var id = int.TryParse(j.Key, out var tempId) ? tempId : default(int);
                var rate = j.Value.ToObject<int>();
                users.Add(new UserWithRate() { Id = id, Rate = rate });
            }
            return users;
        }

        protected override void WriteInternal(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = JToken.FromObject(value);
            if (t.Type != JTokenType.Array) return;
            if (!(value is List<UserWithRate>)) return;
            
            var users = (List<UserWithRate>)value;
            var o = new JObject();
            foreach (var user in users)
            {
                o.Add(new JProperty(user.Id.ToString(), new JValue(user.Rate)));
            }
            o.WriteTo(writer);
        }
    }
}