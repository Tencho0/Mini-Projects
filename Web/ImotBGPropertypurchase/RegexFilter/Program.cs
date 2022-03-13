using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //find out all properties in the locations and their prices in the web site and find out their average price per rooms and per location;
            //Current website have only 25 webpages, then we loop allOfThem;
            //CHANGE THE LINK TO SEE ALL PROPERTIES - curr selection is only for locations: "Бояна, Гео Милев, Витоша";

            Dictionary<string, List<int>> priceByLocation = new Dictionary<string, List<int>>();
            Dictionary<string, List<int>> priceByRooms = new Dictionary<string, List<int>>();

            for (int i = 0; i < 25; i++)
            {
                string htmlCode = string.Empty;
                WebClient client = new WebClient { Encoding = Encoding.UTF8 };
                byte[] reply = client.DownloadData($"https://www.imot.bg/pcgi/imot.cgi?act=3&slink=7s8bwi&f1={i + 1}");

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding encoding1251 = Encoding.GetEncoding("windows-1251");
                var convertedBytes = Encoding.Convert(encoding1251, Encoding.UTF8, reply);
                htmlCode = Encoding.UTF8.GetString(convertedBytes);

                Regex regex = new Regex(@"<div class=""price""><im.*?>(.*?)<a.*?<a.*?>(.*?)<.*?<a.*?>(.*?)<|<div class=""price"">(.*?)<a.*?<a.*?>(.*?)<.*?<a.*?>(.*?)<", RegexOptions.Singleline);
                var matches = regex.Matches(htmlCode);
                foreach (Match match in matches)
                {
                    try
                    {
                        string room = string.Empty;
                        string location = string.Empty;
                        int price = 0;

                        if (string.IsNullOrEmpty(match.Groups[1].Value))
                        {
                            var priceTruncated = Regex.Match(match.Groups[4].Value, @"[0-9]+ ?[0-9]*").Value;
                            priceTruncated = Regex.Replace(priceTruncated, @" ", "");

                            price = int.Parse(priceTruncated);
                            room = match.Groups[5].Value;
                            location = match.Groups[6].Value;

                            //Printing the properties
                            // Console.WriteLine(match.Groups[4]);
                            // Console.WriteLine(match.Groups[5]);
                            // Console.WriteLine(match.Groups[6]);
                        }
                        else
                        {
                            var priceTruncated = Regex.Match(match.Groups[1].Value, @"[0-9]+ ?[0-9]*").Value;
                            priceTruncated = Regex.Replace(priceTruncated, @" ", "");

                            price = int.Parse(priceTruncated);
                            room = match.Groups[2].Value;
                            location = match.Groups[3].Value;

                            //Printing the properties
                            // Console.WriteLine(match.Groups[1]);
                            // Console.WriteLine(match.Groups[2]);
                            // Console.WriteLine(match.Groups[3]);
                        }
                        AddAverageValues(priceByLocation, priceByRooms, room, location, price);
                        // Console.WriteLine();
                    }
                    catch (Exception x)
                    {
                        //if price != int, continue
                    }
                }
            }

            PrintAveragePrices(priceByLocation, priceByRooms);
        }
        private static void PrintAveragePrices(Dictionary<string, List<int>> priceByLocation, Dictionary<string, List<int>> priceByRooms)
        {
            foreach (var location in priceByLocation)
            {
                Console.WriteLine($"Average price in: {location.Key} is: {location.Value.Average():F2} EURO");
            }
            Console.WriteLine();
            foreach (var room in priceByRooms)
            {
                Console.WriteLine($"{room.Key} -> {room.Value.Average():F2} EURO");
            }
        }
        private static void AddAverageValues(Dictionary<string, List<int>> priceByLocation, Dictionary<string, List<int>> priceByRooms, string room, string location, int price)
        {
            if (!priceByRooms.ContainsKey(room))
            {
                priceByRooms[room] = new List<int>();
            }
            priceByRooms[room].Add(price);

            if (!priceByLocation.ContainsKey(location))
            {
                priceByLocation[location] = new List<int>();
            }
            priceByLocation[location].Add(price);

        }
    }
}
