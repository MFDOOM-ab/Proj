using System;
using System.Collections.Generic;
using System.Threading;
using System.Net.Http;

namespace goldDestroyer
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.Write("Webhook: ");
            string webhook = Console.ReadLine();

            Console.Write("Message: ");
            string message = Console.ReadLine();

            Console.Write("Threads: ");
            string threadsString = Console.ReadLine();

            int threads = Convert.ToInt32(threadsString);

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < threads; i++)
            {
                Webhook(webhook, message);
                Console.WriteLine("Message number [" + i + "] has been sent.");
                Thread.Sleep(500);
            }


        }

        public static void Webhook(string URL, string MSG)
        {
            HttpClient client = new HttpClient();
            Dictionary<string, string> contents = new Dictionary<string, string>
                {
                    { "content", MSG },
                    { "username", "WOONDU" },
                    { "avatar_url", "https://images-ext-2.discordapp.net/external/fewgyNJtbbjjECzyIYRNYWQpk9weJJJqFo7lRjraA5I/%3Fsize%3D256/https/cdn.discordapp.com/avatars/77210283558309888/8005c48c49ca8125938ce4f2d92f6baa.png" }
                };

            client.PostAsync(URL, new FormUrlEncodedContent(contents)).GetAwaiter().GetResult();
        }
    }
}
