using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHelper
{
    public interface IBookListService : IEnumerable<Book>
    {
        bool AddBook(Book bookToAdd);
        Book BookAt(int index);
        bool Clear();
        bool DeleteBook(Book bookForDeletion);
        int IndexOfBook(Book book);
        bool Filter(Predicate<Book> predicate, IBookList bookList);
        bool SortBooks(IComparer<Book> comparer);        
        bool Export(string fileName);
    }
}
