using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopModel.Interfaces;

namespace ShopModel
{
    public class Discount_10 : IDiscount
    {
        double IDiscount.Discount
        {
            get { return 0.1; }
        }

    }
}
