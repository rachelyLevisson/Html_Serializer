using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Html_Serializer
{
    public class HtmlHelper
    {
        private readonly static HtmlHelper _Singleton =new HtmlHelper();

        public static HtmlHelper Singleton => _Singleton;

        public string[] Tags { get; set; }
        public string[] CloseTag { get; set; }
        private HtmlHelper()
        {
            Tags = JsonSerializer.Deserialize<string[]>(File.ReadAllText("JSON Files/HtmlTags.json"));
            CloseTag = JsonSerializer.Deserialize<string[]>(File.ReadAllText("JSON Files/HtmlVoidTags.json"));
        }
    }
}
