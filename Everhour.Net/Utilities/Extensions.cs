using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Everhour.Net
{
    internal static class Extensions
    {
        internal async static Task ThrowIfBadRequest(this HttpResponseMessage response)
        {
            if ((int)response.StatusCode >= 400)
                throw new EverhourException(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        internal static bool IsSuccessfulDelete(this HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.NoContent:
                  return true;
                default:
                  return false;
            }
        }
    }
}