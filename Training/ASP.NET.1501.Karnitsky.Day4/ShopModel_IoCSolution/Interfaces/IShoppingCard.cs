using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopModel;

namespace ShopModel.Interfaces
{
    public interface IShoppingCard
    {
        IEnumerable<IProduct> Products { get; set; }
        decimal CalculateProductTotal();
    }
}
