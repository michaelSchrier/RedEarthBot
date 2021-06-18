using System;

namespace RedEarthBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot bot = new Bot();
            bot.RunAync().GetAwaiter().GetResult();
        }
    }
}
