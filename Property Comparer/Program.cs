using System.Net;
using System.Text;
using System.Text.RegularExpressions;

Dictionary<string, List<int>> priceByLocation = new Dictionary<string, List<int>>();
Dictionary<string, List<int>> priceByRooms = new Dictionary<string, List<int>>();

for (int i = 0; i < 25; i++) // available 25 site pages
{
    string htmlCode = "";
    WebClient client = new() { Encoding = Encoding.UTF8 };
    byte[] reply = client.DownloadData($"https://www.imot.bg/pcgi/imot.cgi?act=3&slink=7krpiy&f1={i + 1}");

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
            string room = "";
            string location = "";
            int price = 0;
            if (string.IsNullOrEmpty(match.Groups[1].Value))
            {
                var priceTrim = Regex.Match(match.Groups[4].Value, @"[0-9]+ ?[0-9]*").Value;
                priceTrim = Regex.Replace(priceTrim, @" ", "");
                price = int.Parse(priceTrim);
                room = match.Groups[5].Value;
                location = match.Groups[6].Value;
                //Console.WriteLine(match.Groups[4]);
                //Console.WriteLine(match.Groups[5]);
                //Console.WriteLine(match.Groups[6]);
            }
            else
            {
                var priceTrim = Regex.Match(match.Groups[1].Value, @"[0-9]+ ?[0-9]*").Value;
                priceTrim = Regex.Replace(priceTrim, @" ", "");
                price = int.Parse(priceTrim);
                room = match.Groups[2].Value;
                location = match.Groups[3].Value;
                //Console.WriteLine(match.Groups[1]);
                //Console.WriteLine(match.Groups[2]);
                //Console.WriteLine(match.Groups[3]);
            }
            if (!priceByRooms.ContainsKey(room))
            {
                priceByRooms.Add(room, new List<int>());
            }
            if (!priceByLocation.ContainsKey(location))
            {
                //Console.WriteLine(location + " -> added");
                priceByLocation.Add(location, new List<int>());
            }

            priceByRooms[room].Add(price);
            priceByLocation[location].Add(price);
        }
        catch (Exception e)
        {


        }
    }
}
foreach (var location in priceByLocation)
{
    Console.WriteLine($"{location.Key} -> {(int)location.Value.Average()}");
}
foreach (var room in priceByRooms)
{
    Console.WriteLine($"{room.Key} -> {(int)room.Value.Average()}");
}
