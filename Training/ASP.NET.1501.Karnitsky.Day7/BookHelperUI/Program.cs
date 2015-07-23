using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHelper;
using BookHelper.Comparators;
using Ninject;

namespace BookHelperUI
{
    class Program
    {
        static Book book1 = new Book("CLR via C#", "Jeffrey Richter", "Microsoft Press", 4, 2013, 860);
        static Book book2 = new Book(".Net Performance", "Sasha Goldstein", "APress", 1, 2012, 361);
        static Book book3 = new Book("C# in a Nutshell", "Joseph Albahari", "O'Reilly", 5, 2012, 1062);
        static Book book4 = new Book("C# 4.0 Unleashed", "Bart de Smet", "SAMS", 1, 2011, 1635);
        static Book book5 = new Book("C# 4.0 Unleashed", "Bart de Smet", "SAMS", 1, 2011, 1635);

        static void Main(string[] args)
        {           
            IKernel kernel = new StandardKernel();
            kernel.Bind<IBookRepository>().To<XmlFileRepository>().WithConstructorArgument(@"../../books.xml");
            kernel.Bind<ILogger>().To<Logger>();            
            kernel.Bind<IXmlExporter>().To<LinqToXmlExporter>();
            kernel.Bind<IBookListService>().To<BookListService>();
            IBookList list = kernel.Get<BookList>();

            Console.WriteLine("list.Export ended correctly? : " + list.Export(@"../../exported.xml")); 

            IKernel kernelForFilteredList = new StandardKernel();
            kernelForFilteredList.Bind<IBookRepository>().To<BinaryFileRepository>().WithConstructorArgument(@"../../filteredbooks.txt");
            kernelForFilteredList.Bind<ILogger>().To<Logger>();
            kernelForFilteredList.Bind<IXmlExporter>().To<XmlWriterExporter>();
            kernelForFilteredList.Bind<IBookListService>().To<BookListService>();
            IBookList filteredList = kernelForFilteredList.Get<BookList>();

            Console.WriteLine("list.Filter ended correctly? : " + list.Filter((Book b) =>
            {
                if (b.Edition == 1)
                    return true;
                else 
                    return false;
            },
            filteredList));

            Console.WriteLine("filteredlist.Export ended correctly? : " + filteredList.Export(@"../../filteredexported.xml"));
            Console.WriteLine();

            // Uncomment this procedure to check, that all methods from Day7 works correctly
            //DoSomeStuffToEnsureThatAllWorks(list); 

            Console.ReadLine();
        }

        static void Print(IEnumerable<Book> books)
        {
            foreach (Book b in books)
            {
                Console.WriteLine("--- " + b.ToString());
            }
        }

        static void DoSomeStuffToEnsureThatAllWorks(IBookList list)
        {
            Console.WriteLine("------ GetHashCode ------");
            Console.WriteLine("Book #1: " + book1.GetHashCode());
            Console.WriteLine("Book #2: " + book2.GetHashCode());
            Console.WriteLine("Book #3: " + book3.GetHashCode());
            Console.WriteLine("Book #4: " + book4.GetHashCode());
            Console.WriteLine("Book #5: " + book5.GetHashCode());
            Console.WriteLine("-------------------------");

            Console.WriteLine("--------- Equals --------");
            Console.WriteLine("book1 == book2: " + (book1 == book2));
            Console.WriteLine("book2 != book5: " + (book2 != book5));
            Console.WriteLine("book4.Equals(null): " + book4.Equals(null));
            Console.WriteLine("book4.Equals(book5): " + book4.Equals(book5));
            Console.WriteLine("-------------------------");

            Console.WriteLine("--------- AddBook -------");

            Console.WriteLine("AddBook #1: " + list.AddBook(book1));
            Console.WriteLine("AddBook #2: " + list.AddBook(book2));
            Console.WriteLine("AddBook #3: " + list.AddBook(book3));
            Console.WriteLine("AddBook #4: " + list.AddBook(book4));
            Console.WriteLine("AddBook #5: " + list.AddBook(book5));
            Console.WriteLine("-------------------------");

            Console.WriteLine("---------- Sort ---------");
            Console.WriteLine("Year Increasing: ");
            list.SortBooks(new YearIncreasing());
            Print(list);
            Console.WriteLine("---------");

            Console.WriteLine("Pages Decreasing: ");
            list.SortBooks(new PagesDecreasing());
            Print(list);
            Console.WriteLine("---------");

            Console.WriteLine("Title Increasing: ");
            list.SortBooks(new TitleIncreasing());
            Print(list);
            Console.WriteLine("---------");

            Console.WriteLine("Author Decreasing: ");
            list.SortBooks(new AuthorDecreasing());
            Print(list);
            Console.WriteLine("---------");
            Console.WriteLine("------------------------");

            Console.WriteLine("-------- IndexOf -------");
            Console.WriteLine("IndexOf Book #2: " + list.IndexOfBook(book2));
            Console.WriteLine("IndexOf Book #5: " + list.IndexOfBook(book5));
            Console.WriteLine("IndexOf Book #4: " + list.IndexOfBook(book4));
            Console.WriteLine("IndexOf Book #1: " + list.IndexOfBook(book1));
            Console.WriteLine("IndexOf Book #3: " + list.IndexOfBook(book3));
            Console.WriteLine("-----------------------");
        }
    }
}
