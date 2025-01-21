using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html_Serializer
{
    public class HtmlElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Attributes { get; set; }
        public string[] Classes { get; set; }
        public string InnerHtml { get; set; }
    }
}
