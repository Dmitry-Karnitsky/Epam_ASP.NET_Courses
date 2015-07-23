using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace BookHelper
{
    public class BookListService : IBookListService, IEnumerable<Book>
    {
        private readonly IBookRepository repository;
        private readonly ILogger logger;
        private readonly IXmlExporter xmlExporter;

        private IList<Book> books = new List<Book>();

        public BookListService(IBookRepository repository, ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
            LoadBooks();
        }

        public BookListService(IBookRepository repository, ILogger logger, IXmlExporter xmlExporter)
        {
            this.repository = repository;
            this.logger = logger;
            this.xmlExporter = xmlExporter;
            LoadBooks();
        }

        public bool AddBook(Book bookToAdd)
        {
            if (bookToAdd == null)
            {
                var e = new ArgumentNullException("Book to add was null.") { Source = "bookToAdd" };
                logger.WriteError(e.Message, e.Source, e.StackTrace);
                return false;
            }

            bool isExists = false;

            foreach (Book b in books)
            {
                if (bookToAdd.Equals(b))
                {
                    isExists = true;
                    break;
                }
            }

            if (isExists)
            {
                logger.WriteWarning("AddBook: book is already exist in collection.");
                return false;
            }
            else
            {
                books.Add(bookToAdd);
                return SaveBooks();
            }
        }

        public bool DeleteBook(Book bookForDeletion)
        {
            if (bookForDeletion == null)
            {
                var e = new ArgumentNullException("Book for deletion was null.") { Source = "bookForDeletion" };
                logger.WriteError(e.Message, e.Source, e.StackTrace);
                return false;
            }

            bool isExists = false;

            foreach (Book b in books)
            {
                if (bookForDeletion.Equals(b))
                {
                    isExists = true;
                    break;
                }
            }

            if (isExists)
            {
                if (books.Remove(bookForDeletion) == false)
                    logger.WriteWarning("DeleteBook: error while removing from collection.");
                return false;
            }
            else
            {
                logger.WriteWarning("DeleteBook: book not found in collection.");
                return SaveBooks();
            }
        }

        public bool Filter(Predicate<Book> predicate, IBookList bookList)
        {
            try
            {
                foreach (Book book in books)
                {
                    if (predicate(book))
                        bookList.AddBook(book);
                }
            }
            catch(Exception e)
            {
                logger.WriteError(e.Message, e.Source, e.StackTrace);
                while (e.InnerException != null)
                {
                    logger.WriteError(e.Message, e.Source, e.StackTrace);
                    e = e.InnerException;
                }
                return false;
            }
            return true;
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return books.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return books.GetEnumerator();
        }

        public bool SortBooks()
        {
            try
            {
                Book[] b = books.ToArray<Book>();
                QuickSort(b, 0, books.Count - 1, (Book b1, Book b2) => { return b1.CompareTo(b2); });
                books.Clear();
                books = b.ToList<Book>();
            }
            catch (Exception e)
            {
                logger.WriteError(e.Message, e.Source, e.StackTrace);
                while (e.InnerException != null)
                {
                    logger.WriteError(e.Message, e.Source, e.StackTrace);
                    e = e.InnerException;
                }
                return false;
            }

            return SaveBooks();
        }

        public bool SortBooks(IComparer<Book> comparer)
        {
            try
            {
                if (comparer == null)
                    comparer = new FuncToComparer<Book>((Book b1, Book b2) => { return b1.CompareTo(b2); });

                Book[] b = books.ToArray<Book>();
                QuickSort(b, 0, books.Count - 1, comparer);
                books.Clear();
                books = b.ToList<Book>();
            }
            catch (Exception e)
            {
                logger.WriteError(e.Message, e.Source, e.StackTrace);
                while (e.InnerException != null)
                {
                    logger.WriteError(e.Message, e.Source, e.StackTrace);
                    e = e.InnerException;
                }
                return false;
            }
            return SaveBooks();
        }

        public int IndexOfBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException("IndexOf");

            int i = 0;
            foreach (Book b in books)
            {
                if (book.Equals(b))
                {
                    return i;
                }
                i++;
            }

            return -1;
        }

        public Book BookAt(int index)
        {
            Book b = null;
            try
            {
                b = books.ElementAt(index);
            }
            catch (ArgumentException)
            {
                throw;
            }
            return b;
        }

        public bool Clear()
        {
            books = new List<Book>();
            return SaveBooks();
        }

        public bool Export(string fileName)
        {
            if (xmlExporter != null)
            {
                xmlExporter.Export(books, fileName);
                return true;
            }
            return false;
        }

        private void LoadBooks()
        {
            try
            {
                foreach (Book b in repository.LoadBooks())
                {
                    books.Add(b);
                }
            }
            catch (Exception e)
            {
                logger.WriteError(e.Message, e.Source, e.StackTrace);
                while (e.InnerException != null)
                {
                    logger.WriteError(e.Message, e.Source, e.StackTrace);
                    e = e.InnerException;
                }
                throw;
            }
        }

        private bool SaveBooks()
        {
            try
            {
                repository.SaveBooks(books);
            }
            catch (Exception e)
            {
                logger.WriteError(e.Message, e.Source, e.StackTrace);
                while (e.InnerException != null)
                {
                    logger.WriteError(e.Message, e.Source, e.StackTrace);
                    e = e.InnerException;
                }
                return false;
            }
            return true;
        }

        #region QuickSort

        private void QuickSort<T>(T[] array, int leftBorder, int rightBorder, Comparison<T> comparison)
        {
            QuickSort<T>(array, leftBorder, rightBorder, new FuncToComparer<T>(comparison));
        }

        private void QuickSort<T>(T[] array, int leftBorder, int rightBorder, IComparer<T> comparer)
        {
            while (leftBorder < rightBorder)
            {
                int m = Partition<T>(array, leftBorder, rightBorder, comparer);
                if (m - leftBorder <= rightBorder - m)
                {
                    QuickSort<T>(array, leftBorder, m - 1, comparer);
                    leftBorder = m + 1;
                }
                else
                {
                    QuickSort<T>(array, m + 1, rightBorder, comparer);
                    rightBorder = m - 1;
                }
            }
        }

        private int Partition<T>(T[] array, int leftBorder, int rightBorder, IComparer<T> comparator)
        {
            int pivotIndex = leftBorder + (rightBorder - leftBorder) / 2;
            T pivotValue = array[pivotIndex];
            array[pivotIndex] = array[leftBorder];


            int i = leftBorder + 1;
            int j = rightBorder;

            while (true)
            {
                while ((i < j) && (comparator.Compare(pivotValue, array[i]) > 0)) i++;
                while ((j >= i) && (comparator.Compare(array[j], pivotValue) > 0)) j--;
                if (i >= j) break;
                Swap(ref array[i], ref array[j]);
                j--;
                i++;
            }

            array[leftBorder] = array[j];
            array[j] = pivotValue;

            return j;
        }

        private void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private sealed class FuncToComparer<T> : IComparer<T>
        {
            Comparison<T> comparison;

            public FuncToComparer(Comparison<T> comparison)
            {
                this.comparison = comparison;
            }

            public int Compare(T x, T y)
            {
                return comparison(x, y);
            }
        }

        #endregion

    }

}
