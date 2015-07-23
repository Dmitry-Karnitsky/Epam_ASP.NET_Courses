using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHelper
{
    public class LinqToXmlExporter : IXmlExporter
    {
        public void Export(IEnumerable<Book> books, string fileName)
        {
            XElement booksNode = new XElement("books");
            foreach(Book book in books)
            {
                XElement bookNode = new XElement("book");
                bookNode.Add(new XElement("title", book.Title));
                bookNode.Add(new XElement("author", book.Author));
                bookNode.Add(new XElement("publisher", book.Publisher));
                bookNode.Add(new XElement("year", book.Year.ToString()));
                bookNode.Add(new XElement("edition", book.Edition.ToString()));
                bookNode.Add(new XElement("pages", book.Pages.ToString()));
                booksNode.Add(bookNode);
            }
            XDocument xDoc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"), booksNode);
            xDoc.Save(fileName);
        }
    }
}
