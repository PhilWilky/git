using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net.Http;

namespace EbayScraperConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GetHtmlAsync();
            Console.ReadLine();
        }

        private static async void GetHtmlAsync()
        {
            var url = "https://www.ebay.co.uk/sch/i.html?_nkw=ps4&_in_kw=1&_ex_kw=&_sacat=0&LH_Complete=1&_udlo=&_udhi=&_samilow=&_samihi=&_sadis=15&_stpos=&_sargn=-1%26saslc%3D1&_salic=3&_sop=12&_dmd=1&_ipg=50&_fosrp=1";
            var httpClient1 = new HttpClient();
            var html = await httpClient1.GetStringAsync(url);


            // Parsing

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var productsHtml = htmlDocument.DocumentNode.Descendants("ul")
                .Where(node => node.GetAttributeValue("id", "")
                .Equals("ListViewInner")).ToList();

            var productListItem = productsHtml[0].Descendants("li")
                .Where(node => node.GetAttributeValue("id", "")
                .Contains("item")).ToList();

            //var productList = productsHtml[0].Descendants()

            Console.WriteLine();

        }
    }
}
