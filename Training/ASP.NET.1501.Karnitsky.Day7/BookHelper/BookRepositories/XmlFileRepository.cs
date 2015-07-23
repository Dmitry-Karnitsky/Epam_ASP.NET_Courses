using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BookHelper
{
    public class XmlFileRepository : IBookRepository
    {
        public static string FileName { get; private set; }

        public XmlFileRepository(string fileName)
        {
            FileName = fileName;
        }

        public IEnumerable<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();
            try
            {
                using (FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    object obj = bf.Deserialize(fs);
                    foreach (Book b in (IEnumerable<Book>)obj)
                    {
                        books.Add(b);
                    }
                }
            }
            catch (Exception e)
            {
                books.Clear();
                books.TrimExcess();
                throw new IOException("Error while loading books from xml file.", e);
            }
            return books;
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            if (books == null)
                throw new ArgumentNullException("SaveBooks") { Source = "List of books to save." };

            long position = 0;
            FileStream fs = null;
            try
            {
                using (fs = new FileStream(FileName, FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, books);
                }
            }
            catch (Exception)
            {
                if (fs != null)
                    fs.Position = position;
                throw;
            }
        }
    }
}
