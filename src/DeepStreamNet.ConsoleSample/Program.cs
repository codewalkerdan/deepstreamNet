﻿using System;
using System.Threading.Tasks;

namespace DeepStreamNet.Core.ConsoleSample
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();

            Console.Read();
        }

        static Task MainAsync(string[] args)
        {
            return Exec();
        }

        async static Task Exec()
        {
            var client = new DeepStreamClient("localhost", 6020);

            if (await client.LoginAsync())
            {
                var disp = await client.Events.SubscribeAsync("test", Console.WriteLine);

                await Task.Delay(2000);

                client.Events.Publish("test", "Hello World");

                await Task.Delay(30000);

                Console.ReadKey();

                await disp.DisposeAsync();
            }

            client.Dispose();
        }
    }
}
