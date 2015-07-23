using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopModel.Interfaces;
using ShopModel;

namespace ShopModel.ValueCalculators
{
    public class HalfValueCalculator : IValueCalculator
    {
        public decimal ValueProducts(IEnumerable<IProduct> products, IDiscount discount)
        {
            if (products == null || discount == null)
            {
                throw new ArgumentNullException();
            }
            
            decimal sumOfProduct = 0;
            foreach (var product in products)
            {
                sumOfProduct += product.Price / 2;
            }
            Decimal.Multiply(sumOfProduct, (decimal)discount.Discount);
            return sumOfProduct - Decimal.Multiply(sumOfProduct, (decimal)discount.Discount);
        }
    }
}
