using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Crawler.Logic;
using Crawler.Service;

namespace Crawler
{
    public class Crawler
    {
        private static IScraperLogic _scraper = new ScraperLogic();
        private static IClientService _client = new ClientService();

        public int PagesToCrawl { get; set; }
        public string BaseUrl { get; set; }
        public List<string> UrlsFound { get; set; }

        public Crawler()
        {
            Console.WriteLine("Configuring Crawler . . .");

            Console.WriteLine("please input a base url to crawl from: ");
            BaseUrl = Console.ReadLine();

            Console.WriteLine("Please input the number of pages you wish to crawl: ");
            PagesToCrawl = int.Parse(Console.ReadLine());

            UrlsFound = new List<string>();

            Console.WriteLine("Configuration completed!");
        }

        public async Task CrawlPage(string url)
        {
            var content = await _client.Get(url);

            var result = _scraper.FindHrefs(content);

            foreach (var item in result)
            {
                try
                {
                    await CrawlPage(item);
                    UrlsFound.Add(item);
                    Console.WriteLine(item);
                }
                catch
                {
                }
            }
        }
    }
}
