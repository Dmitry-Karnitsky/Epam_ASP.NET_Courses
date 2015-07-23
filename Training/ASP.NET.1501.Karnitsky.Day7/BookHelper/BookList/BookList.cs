using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookHelper
{
    public class BookList : IBookList
    {
        IBookListService bls;

        public BookList(IBookListService bls)
        {
            this.bls = bls; 
        }
        
        public bool AddBook(Book bookToAdd)
        {
            return bls.AddBook(bookToAdd);
        }

        public Book BookAt(int index)
        {
            return bls.BookAt(index);
        }

        public bool Clear()
        {
            return bls.Clear();
        }

        public bool DeleteBook(Book bookForDeletion)
        {
            return bls.DeleteBook(bookForDeletion);
        }

        public int IndexOfBook(Book book)
        {
            return bls.IndexOfBook(book);
        }

        public bool Export(string fileName)
        {
            return bls.Export(fileName);
        }

        public bool Filter(Predicate<Book> predicate, IBookList bookList)
        {
            return bls.Filter(predicate, bookList);
        }

        public bool SortBooks(IComparer<Book> comparer)
        {
            return bls.SortBooks(comparer);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return bls.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)bls).GetEnumerator();
        }
    }
}
