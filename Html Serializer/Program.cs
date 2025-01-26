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
var tab = new Regex("<(.*?)>").Split(http);

var cleanedLines = Array.ConvertAll(tab, tab => Regex.Replace(tab, @"!--.*?--", ""));
var res = Array.FindAll(cleanedLines, cleanedLines => !Regex.IsMatch(cleanedLines, @"^\s*$"));


HtmlElement root = new HtmlElement();

HtmlElement current = new HtmlElement();
var t = Regex.Match(res[0], @"^\\s+").ToString();
int i = 0;

while (t != "/html")
{

    if (t[0] == '/')
    {
        current = current.Parenst;
    }
    else
    {
        if ((HtmlHelper.Singleton.Tags).Contains(t))
        {
            current.Children.Add(new HtmlElement());
            current.Name = t;
            //פרוק ויצירת Attributes
            res[i] = res[i].Substring(t.Length).TrimStart();
            if (res[i].Contains("class"))
            {
                t = Regex.Match(res[i], @"class=""([^""]+)""").ToString();
                var allClass = t.Split();
                for (int j = 0; j < allClass.Length; j++)
                {
                    current.Classes.Add(allClass[j]);
                }
            }
            if (res[i].Contains("id"))
                current.Id = Regex.Match(res[i], @"id=""([^""]+)""").ToString();
            var allAttri = Regex.Matches(res[i], "\"([^\"]*)\"").ToString().Split();
            foreach (var item in allAttri)
            {
                current.Attributes.Add(item);
            }

            if (!(HtmlHelper.Singleton.CloseTag.Contains(t)) && (res[i][res[i].Length - 1] != '/'))
            {
                current = new HtmlElement();
            }

        }

        else
        {
            current.InnerHtml = t;
        }
    }
    i++;
    t = Regex.Match(res[i], @"^\\s+").ToString();
}
Console.ReadLine();

