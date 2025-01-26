using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html_Serializer
{
    public class HtmlElement
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<string> Classes { get; set; }
        public List<string> Attributes { get; set; }
        public string InnerHtml { get; set; }

        public  HtmlElement Parenst { get; set; }
        public List<HtmlElement> Children{ get; set; }

        public IEnumerable<HtmlElement> Descendants(HtmlElement root)
        {
            Queue<HtmlElement> q = new Queue<HtmlElement>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                yield return q.Dequeue();
                
                //run to children  == not good....
                while(this.Children.Count > 0)
                {
                    q.Enqueue(this.Children.First());//?
                }
            }
        }

        public List<HtmlElement> Ancestors()
        {
            return new List<HtmlElement>();
        }
    }
}
