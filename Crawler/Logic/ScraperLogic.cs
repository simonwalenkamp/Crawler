using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Crawler.Logic
{
    public interface IScraperLogic
	{
        public List<string> FindUrls(string html);
        public List<string> FindHrefs(string html);
    }
    public class ScraperLogic : IScraperLogic
	{
		public ScraperLogic()
		{
		}

        public List<string> FindUrls(string html)
        {
            string URLPattern = @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$";
            return FindMatches(html, URLPattern);
        }

        public List<string> FindHrefs(string html)
        {
            string HRefPattern = @"href\s*=\s*(?:[""'](?<1>[^""']*)[""']|(?<1>\S+))";
            return FindMatches(html, HRefPattern);
        }

        private List<string> FindMatches(string content, string pattern)
		{
            var matches = new List<string>();
            try
            {
                var m = Regex.Match(content, pattern,
                                RegexOptions.IgnoreCase | RegexOptions.Compiled,
                                TimeSpan.FromSeconds(1));
                while (m.Success)
                {
                    matches.Add(m.Groups[1].ToString());
                    m = m.NextMatch();
                }
            }
            catch (RegexMatchTimeoutException)
            {
                Console.WriteLine("The matching operation timed out.");
            }

            return matches;
        }
    }
}
