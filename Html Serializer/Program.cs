using Html_Serializer;
using System.Text.RegularExpressions;

async Task<string> Load(string url)
{
    HttpClient client = new HttpClient();
    var response = await client.GetAsync(url);
    var html = await response.Content.ReadAsStringAsync();
    return html;
}

var http = await Load("https://learn.malkabruk.co.il/practicode/projects/pract-2");

 var noSpase=new Regex("\\s").Replace(http,"");

var tab = new Regex("<(.*?)>").Split(noSpase).Where(s=>s.Length>0);

Console.ReadLine();
//Console.WriteLine(http);
