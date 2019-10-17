using System;
using System.Collections.Generic;
using System.Threading;

namespace DraftRandomizer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var teams = new List<string>
            {
                "Two Cups One Ball",
                "Daddy Daycare",
                "Junkball Junkie",
                "Kamikazweb",
                "Kawhi Me a River",
                "LaVar's Ballers",
                "LG",
                "Linh's Legit Team",
                "Mamba Mentality",
                "Mr. Luka's Hot Mom",
                "TheSystem",
                "Westbrick",
                "Tony's Tip-Top Team",
                "The White Walker"
            };
            teams.Shuffle();
            var rank = 1;
            teams.ForEach(x => Console.WriteLine($"{rank++}: {x}"));
            Console.ReadKey();
        }
    }

    public static class ThreadSafeRandom
    {
        [ThreadStatic] private static Random _local;

        public static Random ThisThreadsRandom => _local ??= new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId));
    }

    internal static class MyExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}