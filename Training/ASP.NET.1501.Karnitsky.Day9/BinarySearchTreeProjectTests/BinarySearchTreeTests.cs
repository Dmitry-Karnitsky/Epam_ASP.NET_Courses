using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTreeProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookHelper;
using Point;

namespace BinarySearchTreeProject.Tests
{
    [TestClass()]
    public class BinarySearchTreeTests
    {
        BinarySearchTree<int> _default = new BinarySearchTree<int>(6, 4, 13, 3, 1, 2, 5, 8, 7, 10, 12, 11, 15);

        [TestMethod()]
        public void BinarySearchTreeOnBooksTest()
        {
            #region Books
            Book book1 = new Book("CLR via C#", "Jeffrey Richter", "Microsoft Press", 4, 2013, 860);
            Book book2 = new Book(".Net Performance", "Sasha Goldstein", "APress", 1, 2012, 361);
            Book book3 = new Book("C# in a Nutshell", "Joseph Albahari", "O'Reilly", 5, 2012, 1062);
            Book book4 = new Book("C# 4.0 Unleashed", "Bart de Smet", "SAMS", 1, 2011, 1635);
            Book book5 = new Book("C# 4.0 Unleashed", "Bart de Smet", "SAMS", 1, 2011, 1635);
            Book book6 = new Book("AnotherBook", "SomeAuthor", "Unknown", 1, 1, 1);
            Book book7 = new Book("Book", "AnotherAuthor", "Publisher", 2, 2, 2);
            Book book8 = new Book("Really Interesting Book", "Unknown", "AnotherPublisher", 1, 2011, 1635);
            #endregion

            #region With default comparer
            BinarySearchTree<Book> booksSearchTree = new BinarySearchTree<Book>(book1, book2, book3, book4, book5, book6, book7, book8);
            
            var actualCollection = new List<Book>();
            foreach (Book i in booksSearchTree.PreOrderTraversal())
            {
                actualCollection.Add(i);
            }
            var expectedCollection = new Book[7] { book1, book2, book3, book4, book6, book7, book8  };

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
            #endregion 

            #region With author increasing comparer
            booksSearchTree = new BinarySearchTree<Book>(new AuthorIncreasing(), book1, book2, book3, book4, book5, book6, book7, book8);

            actualCollection = new List<Book>();

            foreach (Book i in booksSearchTree.PreOrderTraversal())
            {
                actualCollection.Add(i);
            }

            expectedCollection = new Book[7] { book1, book4, book7, book2, book3, book6, book8 };

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
            #endregion
        }

        #region Book Comparator
        private class AuthorIncreasing : IComparer<Book>
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
        #endregion

        [TestMethod()]
        public void BinarySearchTreeOnNumbersTest()
        {
            BinarySearchTree<int> numbersSearchTree = new BinarySearchTree<int>(6, 4, 13, 3, 1, 2, 5, 8, 7, 10, 12, 11, 15);

            var actual = new List<int>();
            foreach (int i in numbersSearchTree.PreOrderTraversal())
            {
                actual.Add(i);
            }

            var expected = new int[13] { 6, 4, 3, 1, 2, 5, 13, 8, 7, 10, 12, 11, 15 };
            CollectionAssert.AreEqual(expected, actual);

            numbersSearchTree = new BinarySearchTree<int>((int x, int y) => { return -x.CompareTo(y); }, 6, 4, 13, 3, 1, 2, 5, 8, 7, 10, 12, 11, 15);

            actual = new List<int>();
            foreach (int i in numbersSearchTree.PreOrderTraversal())
            {
                actual.Add(i);
            }

            expected = new int[13] { 6, 13, 15, 8, 10, 12, 11, 7, 4, 5, 3, 1, 2 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BinarySearchTreeOnStringsTest()
        {
            BinarySearchTree<string> numbersSearchTree = new BinarySearchTree<string>("k", "s", "c", "a", "z", "r", "f", "b", "v", "e", "q", "i", "n");

            var actual = new List<string>();
            foreach (string i in numbersSearchTree.PreOrderTraversal())
            {
                actual.Add(i);
            }

            var expected = new string[13] { "k", "c", "a", "b", "f", "e", "i", "s", "r", "q", "n", "z", "v" };
            CollectionAssert.AreEqual(expected, actual);

            numbersSearchTree = new BinarySearchTree<string>((string x, string y) => { return -x.CompareTo(y); }, "k", "s", "c", "a", "z", "r", "f", "b", "v", "e", "q", "i", "n");

            actual = new List<string>();
            foreach (string i in numbersSearchTree.PreOrderTraversal())
            {
                actual.Add(i);
            }

            expected = new string[13] { "k", "s", "z", "v", "r", "q", "n", "c", "f", "i", "e", "a", "b" };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void BinarySearchTreeOnPoint2DTest()
        {
            BinarySearchTree<Point2D> booksSearchTree = new BinarySearchTree<Point2D>(new Point2D(1,1));
        }        

        [TestMethod()]
        public void InsertTest()
        {
            BinarySearchTree<int> forInsert = new BinarySearchTree<int>(5, 3, 7, 1, 4, 6, 8);
            var actual = forInsert.Insert(2);
            var expected = true;
            Assert.AreEqual(expected, actual);

            actual = forInsert.Insert(2);
            expected = false;
            Assert.AreEqual(expected, actual);

            var actualCollection = new List<int>();
            foreach (int i in forInsert.PreOrderTraversal())
            {
                actualCollection.Add(i);
            }
            var expectedCollection = new int[8] { 5, 3, 1, 2, 4, 7, 6, 8 };
            CollectionAssert.AreEqual(expectedCollection, actualCollection);

        }

        [TestMethod()]
        public void RemoveTest()
        {
            BinarySearchTree<int> forRemove = new BinarySearchTree<int>(5, 3, 7, 1, 4, 6, 8);
            var actual = forRemove.Remove(7);
            var expected = true;
            Assert.AreEqual(expected, actual);

            actual = forRemove.Remove(7);
            expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FindTest()
        {
            var expected = _default.Find(12);
            Assert.AreEqual(expected, true);
            expected = _default.Find(9);
            Assert.AreEqual(expected, false);
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            var actual = new List<int>();
            foreach (int i in _default)
            {
                actual.Add(i);
            }
            var expected = new int[13] { 1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13, 15 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PreOrderTraversalTest()
        {
            var actual = new List<int>();
            foreach (int i in _default.PreOrderTraversal())
            {
                actual.Add(i);
            }
            var expected = new int[13] { 6, 4, 3, 1, 2, 5, 13, 8, 7, 10, 12, 11, 15 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void InOrderTraversalTest()
        {
            var actual = new List<int>();
            foreach (int i in _default.InOrderTraversal())
            {
                actual.Add(i);
            }
            var expected = new int[13] { 1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13, 15 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PostOrderTraversalTest()
        {
            var actual = new List<int>();
            foreach (int i in _default.PostOrderTraversal())
            {
                actual.Add(i);
            }
            var expected = new int[13] { 2, 1, 3, 5, 4, 7, 11, 12, 10, 8, 15, 13, 6 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCountTest()
        {
            var actual = _default.Count;
            var expected = 13;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetMaxTest()
        {
            var actual = _default.Max;
            var expected = 15;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetMinTest()
        {
            var actual = _default.Min;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }
    }
}
