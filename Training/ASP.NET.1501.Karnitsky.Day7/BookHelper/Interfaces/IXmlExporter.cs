using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHelper
{
    public interface IXmlExporter
    {
        void Export(IEnumerable<Book> books, string fileName);
    }
}
