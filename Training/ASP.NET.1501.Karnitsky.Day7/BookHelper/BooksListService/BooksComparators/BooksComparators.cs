using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHelper.Comparators
{
    public class TitleIncreasing : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return 1;
            if (a == null && b != null) return -1;
            if (a.Title.Length == 0 && b.Title.Length == 0) return 0;
            if (a.Title.Length != 0 && b.Title.Length == 0) return 1;
            if (a.Title.Length == 0 && b.Title.Length != 0) return -1;

            return String.Compare(a.Title, b.Title, StringComparison.InvariantCulture);
        }
    }

    public class TitleDecreasing : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return -1;
            if (a == null && b != null) return 1;
            if (a.Title.Length == 0 && b.Title.Length == 0) return 0;
            if (a.Title.Length != 0 && b.Title.Length == 0) return -1;
            if (a.Title.Length == 0 && b.Title.Length != 0) return 1;

            return String.Compare(b.Title, a.Title, StringComparison.InvariantCulture);
        }
    }

    public class AuthorIncreasing : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return 1;
            if (a == null && b != null) return -1;
            if (a.Author.Length == 0 && b.Author.Length == 0) return 0;
            if (a.Author.Length != 0 && b.Author.Length == 0) return 1;
            if (a.Author.Length == 0 && b.Author.Length != 0) return -1;

            return String.Compare(a.Author, b.Author, StringComparison.InvariantCulture);
        }
    }

    public class AuthorDecreasing : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return -1;
            if (a == null && b != null) return 1;
            if (a.Author.Length == 0 && b.Author.Length == 0) return 0;
            if (a.Author.Length != 0 && b.Author.Length == 0) return -1;
            if (a.Author.Length == 0 && b.Author.Length != 0) return 1;

            return String.Compare(b.Author, a.Author, StringComparison.InvariantCulture);
        }
    }

    public class PublisherIncreasing : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return 1;
            if (a == null && b != null) return -1;
            if (a.Publisher.Length == 0 && b.Publisher.Length == 0) return 0;
            if (a.Publisher.Length != 0 && b.Publisher.Length == 0) return 1;
            if (a.Publisher.Length == 0 && b.Publisher.Length != 0) return -1;

            return String.Compare(a.Publisher, b.Publisher, StringComparison.InvariantCulture);
        }
    }

    public class PublisherDecreasing : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return -1;
            if (a == null && b != null) return 1;
            if (a.Publisher.Length == 0 && b.Publisher.Length == 0) return 0;
            if (a.Publisher.Length != 0 && b.Publisher.Length == 0) return -1;
            if (a.Publisher.Length == 0 && b.Publisher.Length != 0) return 1;

            return String.Compare(b.Publisher, a.Publisher, StringComparison.InvariantCulture);
        }
    }

    public class YearIncreasing : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return 1;
            if (a == null && b != null) return -1;

            return a.Year.CompareTo(b.Year);
        }
    }

    public class YearDecreasing : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return -1;
            if (a == null && b != null) return 1;

            return b.Year.CompareTo(a.Year);
        }
    }

    public class EditionIncreasing : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return 1;
            if (a == null && b != null) return -1;

            return a.Edition.CompareTo(b.Edition);
        }
    }

    public class EditionDecreasing : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return -1;
            if (a == null && b != null) return 1;

            return b.Edition.CompareTo(a.Edition);
        }
    }

    public class PagesIncreasing : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return 1;
            if (a == null && b != null) return -1;

            return a.Pages.CompareTo(b.Pages);
        }
    }

    public class PagesDecreasing : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return -1;
            if (a == null && b != null) return 1;

            return b.Pages.CompareTo(a.Pages);
        }
    }
}
