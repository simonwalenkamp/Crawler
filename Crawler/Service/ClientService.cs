using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Crawler.Service
{
    public interface IClientService
    {
        public Task<string> Get(string URL);
    }

    public class ClientService : IClientService
    {
        public ClientService()
        {
        }

        public async Task<string> Get(string URL)
        {
            try
            {
                using var client = new HttpClient();
                var content = await client.GetStringAsync(URL);
                return content;
            }
            catch (Exception e)
            {
            }
            return "";
        }
    }
}
