using System;
using Newtonsoft.Json;
using Everhour.Net.Models;

namespace Everhour.Net
{
    public class EverhourException : Exception
    {
        public EverhourException(string response)
        {
            Response = response;

            try
            {
                Error = JsonConvert.DeserializeObject<ErrorResponse>(response, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            }
            catch {}
        }

        public EverhourException(ErrorResponse error)
        {
            Error = error;

            try
            {
                Response = JsonConvert.SerializeObject(error);
            }
            catch {}
        }

        public string Response { get; private set; }

        public ErrorResponse Error { get; private set; }

        public override string Message
        {
            get
            {
                if (Error != null) return Error.Message;
                return "An error occurred, but could not deserialize the error response.";
            }
        }
    }
}
