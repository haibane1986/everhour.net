using Newtonsoft.Json.Converters;

namespace Everhour.Net.Models
{
    public class DateConverter : IsoDateTimeConverter
    {
        public DateConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }
}