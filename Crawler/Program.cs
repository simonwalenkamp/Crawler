using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Crawler.Logic;
using Crawler.Service;

namespace Crawler
{
    class Program
    {
        
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var crawler = new Crawler();
            await crawler.CrawlPage(crawler.BaseUrl);
        }

    }
}
