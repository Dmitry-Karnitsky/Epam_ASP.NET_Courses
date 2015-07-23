using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace BookHelper
{
    public class XmlWriterExporter : IXmlExporter
    {
        public void Export(IEnumerable<Book> books, string fileName)
        {
            XmlTextWriter writer = new XmlTextWriter(fileName, Encoding.UTF8)
            {
                Formatting = Formatting.Indented,
                Indentation = 2
            };

            writer.WriteStartDocument();

            writer.WriteStartElement("books");

            foreach (Book book in books)
            {
                writer.WriteStartElement("book");                
                writer.WriteElementString("title", book.Title);
                writer.WriteElementString("author", book.Author);
                writer.WriteElementString("publisher", book.Publisher);
                writer.WriteElementString("year", book.Year.ToString());
                writer.WriteElementString("edition", book.Edition.ToString());
                writer.WriteElementString("pages", book.Pages.ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.WriteEndDocument();

            writer.Flush();
        }
    }
}
