using Html_Serializer;
using System.Text.RegularExpressions;

async Task<string> LoadAsync(string url)
{
    HttpClient client = new HttpClient();
    var response = await client.GetAsync(url);
    var html = await response.Content.ReadAsStringAsync();
    return html;
}

var http = await LoadAsync("https://learn.malkabruk.co.il/practicode/projects/pract-2");
//var result = Regex.Replace(http, @"^\s*\n", "", RegexOptions.Multiline);
var tab = new Regex("<(.*?)>").Split(http);

var cleanedLines = Array.ConvertAll(tab, tab => Regex.Replace(tab, @"!--.*?--", ""));
var res = Array.FindAll(cleanedLines, cleanedLines => !Regex.IsMatch(cleanedLines, @"^\s*$"));

//var noSpase = new Regex("\\s").Replace(http, "");




#region build tree
//the cut thestring....
string t = "";

HtmlElement root = new HtmlElement();

HtmlElement current = new HtmlElement();
//string part
while (t != "/html")
{

    if (t == "/")
    {
        current = current.Parenst;
    }
    if ((HtmlHelper.Singleton.Tags).Contains(t))
    {
        current.Children.Add(new HtmlElement());
        current.Name = t;

        //  </br>...
        if (!(HtmlHelper.Singleton.CloseTag.Contains(t)))
        {
            
        }

    }
    //  if(Atribute)

    else // All... how...?
    {
        current.InnerHtml = t;
    }
    //agian part....
}

#endregion

Console.ReadLine();
//Console.WriteLine(http);
