using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopModel;

namespace ShopModel.Interfaces
{
    public interface IValueCalculator
    {
        decimal ValueProducts(IEnumerable<IProduct> products, IDiscount discount);
    }
}
