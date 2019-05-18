using System;
using System.IO;
class Program{
static void Main(String [] args)
{
 Webclient client = new WebClient();
 string reply = client.DownloadString("https://msdn.microsoft.com");
 Console.WriteLine(reply);
 File.WriteAllText(@ "Sitescrap\Sitescrap.txt",reply);
 Console.ReadLine();
}
}