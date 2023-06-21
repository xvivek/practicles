using System;
using System.Net;

namespace Torify
{
    internal class Tor
    {
        private static async Task Main(string[] argv)
        {
            if (argv is null)
            {
                throw new ArgumentNullException(nameof(argv));
            }

            Uri url = new("https://duckduckgogg42xjoc72x3sjasowoarfbgcmvfimaftt6twagswzczad.onion");

            HttpClient client = new(new HttpClientHandler
            {
                // Magic happens with socks scheme used below
                Proxy = new WebProxy("socks5://127.0.0.1:9050")
            });
            Console.WriteLine(await client.GetStringAsync(url));
        }
    }

}
