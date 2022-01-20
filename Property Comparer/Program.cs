
using Google.Apis.Drive.v3.Data;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

string htmlCode = "";
WebClient client = new() { Encoding = Encoding.UTF8 };
byte[] reply = client.DownloadData($"https://www.imot.bg/pcgi/imot.cgi?act=3&slink=7krpiy&f1=1");

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
Encoding encoding1251 = Encoding.GetEncoding("windows-1251");
var convertedBytes = Encoding.Convert(encoding1251, Encoding.UTF8, reply);
htmlCode = Encoding.UTF8.GetString(convertedBytes);

Regex regex = new Regex(@"<div class=""price""><im.*?>(.*?)<a.*?<a.*?>(.*?)<.*?<a.*?>(.*?)<|<div class=""price"">(.*?)<a.*?<a.*?>(.*?)<.*?<a.*?>(.*?)<", RegexOptions.Singleline);

