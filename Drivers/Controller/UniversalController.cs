using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Drivers.Controller
{
    public class UniversalController
    {
        private readonly string webPath = "http://localhost:16261/api/";

        public async Task<T> Get<T>(string path, string localPath, string any)
        {
            var client = new HttpClient();
            var stringTask = await client.GetStringAsync(webPath + path + localPath + any);
            var result = JsonSerializer.Deserialize<T>(stringTask);

            client.Dispose();

            return result;
        }
    }
}
