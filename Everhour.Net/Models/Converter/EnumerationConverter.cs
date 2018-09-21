using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Everhour.Net.Models
{
    public class EnumerationConverter<T>: BaseJsonConverter<T> where T: Enumeration
    {
        protected override T ReadInternal(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String) return null;
            return Enumeration.FromDisplayName<T>((string)reader.Value);
        }

        protected override void WriteInternal(JsonWriter writer, object value, JsonSerializer serializer)
        {
            
            var t = JToken.FromObject(value);
            if (t.Type != JTokenType.Object) return;
            if (!(value is Enumeration)) return;

            var e = (Enumeration)value;
            new JValue(e.Name).WriteTo(writer);
        }
    }
}