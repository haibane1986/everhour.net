using System;
using System.Linq;
using Task = System.Threading.Tasks.Task;
using Everhour.Net;
using Everhour.Net.Models;
using Newtonsoft.Json;

namespace Everhour.Net.Examples
{
    class Program
    {
        static EverhourClient _client;
        static async Task Main(string[] args)
        {
            _client = new EverhourClient("API_TOKEN_HERE");
            await MeAsync();
        }

        static async Task MeAsync() 
        {
            var res = await _client.MeAsync();
            Console.WriteLine(res.Me.Name);
            Console.WriteLine(res.Me.AvatarUrl);
            Console.WriteLine(res.Me.Headline);
            Console.WriteLine(res.Me.Id);
            Console.WriteLine(res.Me.Role.Name);
            Console.WriteLine(res.Me.Status.Name);
            Console.WriteLine(res.StatusCode);
        }
    }
}
