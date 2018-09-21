using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Everhour.Net.Models
{
    public abstract class BaseJsonConverter<T> : JsonConverter
    {
        protected virtual T ReadInternal(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) => throw new NotImplementedException();
        protected virtual void WriteInternal(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, 
                                        Type objectType, 
                                        object existingValue, 
                                        JsonSerializer serializer)
        {
            return ReadInternal(reader, objectType, existingValue, serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            WriteInternal(writer, value, serializer);
        }
    }
}