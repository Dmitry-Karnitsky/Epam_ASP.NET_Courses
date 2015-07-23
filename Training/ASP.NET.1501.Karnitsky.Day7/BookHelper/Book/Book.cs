using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHelper
{
    [Serializable]
    public class Book : IEquatable<Book>, IComparable<Book>   
    {       
        public string Author { get; private set; }
        public string Title { get; private set; }
        public string Publisher { get; private set; }
        public int Edition { get; private set; }
        public int Year { get; private set; }
        public int Pages { get; private set; }

        private Book() { } 
        
        public Book(string title, string author, string publisher, int edition, int year, int pages)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            Edition = edition;
            Year = year;
            Pages = pages;
        }   
       
        public bool Equals(Book other)
        {
            if (Object.Equals(this, null) && Object.Equals(other, null))
                return true;

            if (Object.Equals(this, null) || Object.Equals(other, null))
                return false;

            if (Object.ReferenceEquals(this, other) == true)
                return true;

            if (String.Equals(this.Author, other.Author, StringComparison.CurrentCultureIgnoreCase) &&
                Int32.Equals(this.Edition, other.Edition) &&
                Int32.Equals(this.Pages, other.Pages) && 
                String.Equals(this.Publisher, other.Publisher, StringComparison.CurrentCultureIgnoreCase) &&
                String.Equals(this.Title, other.Title, StringComparison.CurrentCultureIgnoreCase) &&
                Int32.Equals(this.Pages, other.Pages))
            {
                return true;
            }
            else return false;
        }

        public override bool Equals(object obj)
        {
            if (Object.Equals(this, null) && Object.Equals(obj, null))
                return true;

            if (Object.Equals(this, null) || Object.Equals(obj, null))
                return false;

            if (Object.ReferenceEquals(this, obj) == true)
                return true;

            Book other = obj as Book;
            if (other == null)
                return false;
            else return ((IEquatable<Book>)this).Equals(other);            
        }

        public int CompareTo(Book other)
        {
            if (this.Equals(other)) return 0;
            return String.Compare(this.Title, other.Title, true, System.Globalization.CultureInfo.CurrentCulture);
        }

        public override int GetHashCode()
        {
            int hash = 0;
            unchecked
            {                
                for(int i = 0; i < Title.Length; i++)
                {
                    hash += (int)Title[i]<<i;
                }
                for (int i = 0; i < Author.Length; i++)
                {
                    hash = hash & (int)Author[i]<<i;
                }
                for (int i = 0; i < Publisher.Length; i++)
                {
                    hash = hash ^ (int)Publisher[i]<<i;
                }
                hash = hash & Year << 4;
                hash = hash << Edition;
                hash = hash | Pages << 4;
            }            
            return hash;
        }

        public override string ToString()
        {
            return String.Format("Title: {0}, Author: {1}, Publisher: {2}, Edition: {3}, Year: {4}, Pages: {5}", Title, Author, Publisher, Edition, Year, Pages);
        }

        public static bool operator ==(Book b1, Book b2)
        {
            if (Object.Equals(b1, null) && Object.Equals(b2, null))
                return true;

            if (Object.Equals(b1, null) || Object.Equals(b2, null))
                return false;

            if (Object.ReferenceEquals(b1, b2) == true)
                return true;

            return b1.Equals(b2);
        }

        public static bool operator !=(Book b1, Book b2)
        {
            return !(b1 == b2);
        }
    }  
}

