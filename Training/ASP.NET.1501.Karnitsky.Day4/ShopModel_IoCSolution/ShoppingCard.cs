using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopModel.Interfaces;

namespace ShopModel
{
    public class ShoppingCard : IShoppingCard
    {
        private readonly IValueCalculator valueCalc;
        private readonly IDiscount discount;

        public IEnumerable<IProduct> Products { get; set; }

        public ShoppingCard(IValueCalculator valueCalc, IDiscount discount)
        {
            if (valueCalc == null || discount == null)
            {
                throw new ArgumentNullException("Not all of arguments were set.");
            }

            this.valueCalc = valueCalc;
            this.discount = discount;
        }

        public decimal CalculateProductTotal()
        {
            return valueCalc.ValueProducts(Products, discount);
        }
    }
}
