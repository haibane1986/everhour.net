using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public abstract class EverhourResponse<T>: IResponse<T>
    {
        public string Raw { get; set; }
        public int StatusCode { get; set; }
        public abstract T FromJson(string json);
    }
}