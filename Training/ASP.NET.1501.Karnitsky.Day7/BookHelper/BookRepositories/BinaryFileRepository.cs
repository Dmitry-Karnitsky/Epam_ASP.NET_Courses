using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NLog;

namespace BookHelper
{
    public class BinaryFileRepository : IBookRepository
    {    
        public static string FileName { get; private set; }

        public BinaryFileRepository(string fileName)
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
                    using (BinaryReader bw = new BinaryReader(fs))
                    {
                        long position = bw.BaseStream.Position;
                        while (position < bw.BaseStream.Length)
                        {
                            Book book = new Book(bw.ReadString(), bw.ReadString(), bw.ReadString(), bw.ReadInt32(), bw.ReadInt32(), bw.ReadInt32());
                            books.Add(book);
                            position = bw.BaseStream.Position;
                        }
                    }
                }
            }
            catch (Exception e)
            {                
                books.Clear();
                books.TrimExcess();
                throw new IOException("Error while loading books from file.", e);                
            }

            return books;
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            if (books == null)
                throw new ArgumentNullException("SaveBooks") { Source = "List of books to save."};
            long position = 0;
            FileStream fs = null;
            BinaryWriter bw = null;
            try
            {
                fs = new FileStream(FileName, FileMode.OpenOrCreate | FileMode.Truncate, FileAccess.Write);
                using (bw = new BinaryWriter(fs))
                {
                    position = bw.BaseStream.Position;
                    foreach (Book book in books)
                    {
                        bw.Write(book.Title);
                        bw.Write(book.Author);
                        bw.Write(book.Publisher);
                        bw.Write(book.Edition);
                        bw.Write(book.Year);
                        bw.Write(book.Pages);
                        position = bw.BaseStream.Position;
                    }
                    bw.Flush();
                }

            }
            catch (Exception e)
            {
                if (bw != null)
                    bw.BaseStream.Position = position;
                throw new IOException("Error while saving books to file.", e);   
            }
        }
    }
}
