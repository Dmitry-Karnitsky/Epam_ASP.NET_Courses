using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using ShopModel.Interfaces;
using ShopModel.ValueCalculators;
using ShopModel.Discounts;

namespace ShopModel.Tests
{
    [TestClass()]
    public class ShopTests
    {
        [TestMethod()]
        public void FullValueCalculatorNoDiscountTest()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IDiscount>().To<NoDiscount>();
            kernel.Bind<IValueCalculator>().To<FullValueCalculator>();

            IShoppingCard shop = kernel.Get<ShoppingCard>();
            shop.Products = new List<Product>()
            {              
                new Product {Name = "Product 1", Category = "C1", Description = "no", ProductID = 1, Price = 800},
                new Product {Name = "Product 2", Category = "C2", Description = "no", ProductID = 2, Price = 200},
                new Product {Name = "Product 3", Category = "C3", Description = "no", ProductID = 3, Price = 500} 
            };

            var expected = shop.CalculateProductTotal();
            decimal actual = 1500;
            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod()]
        public void FullValueCalculatorDiscount20Test()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IDiscount>().To<Discount_20>();
            kernel.Bind<IValueCalculator>().To<FullValueCalculator>();

            IShoppingCard shop = kernel.Get<ShoppingCard>();
            shop.Products = new List<Product>()
            {              
                new Product {Name = "Product 1", Category = "C1", Description = "no", ProductID = 1, Price = 800},
                new Product {Name = "Product 2", Category = "C2", Description = "no", ProductID = 2, Price = 200},
                new Product {Name = "Product 3", Category = "C3", Description = "no", ProductID = 3, Price = 500} 
            };

            var expected = shop.CalculateProductTotal();
            decimal actual = (decimal)(1500 - (1500 * 0.2));
            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod()]
        public void FullValueCalculatorDiscount10Test()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IDiscount>().To<Discount_10>();
            kernel.Bind<IValueCalculator>().To<FullValueCalculator>();

            IShoppingCard shop = kernel.Get<ShoppingCard>();
            shop.Products = new List<Product>()
            {              
                new Product {Name = "Product 1", Category = "C1", Description = "no", ProductID = 1, Price = 800},
                new Product {Name = "Product 2", Category = "C2", Description = "no", ProductID = 2, Price = 200},
                new Product {Name = "Product 3", Category = "C3", Description = "no", ProductID = 3, Price = 500} 
            };

            var expected = shop.CalculateProductTotal();
            decimal actual = (decimal)(1500 - (1500 * 0.1));
            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod()]
        public void HalfValueCalculatorNoDiscountTest()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IDiscount>().To<NoDiscount>();
            kernel.Bind<IValueCalculator>().To<HalfValueCalculator>();

            IShoppingCard shop = kernel.Get<ShoppingCard>();
            shop.Products = new List<Product>()
            {              
                new Product {Name = "Product 1", Category = "C1", Description = "no", ProductID = 1, Price = 800},
                new Product {Name = "Product 2", Category = "C2", Description = "no", ProductID = 2, Price = 200},
                new Product {Name = "Product 3", Category = "C3", Description = "no", ProductID = 3, Price = 500} 
            };

            var expected = shop.CalculateProductTotal();
            decimal actual = 750;
            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod()]
        public void HalfValueCalculatorDiscount20Test()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IDiscount>().To<Discount_20>();
            kernel.Bind<IValueCalculator>().To<HalfValueCalculator>();

            IShoppingCard shop = kernel.Get<ShoppingCard>();
            shop.Products = new List<Product>()
            {              
                new Product {Name = "Product 1", Category = "C1", Description = "no", ProductID = 1, Price = 800},
                new Product {Name = "Product 2", Category = "C2", Description = "no", ProductID = 2, Price = 200},
                new Product {Name = "Product 3", Category = "C3", Description = "no", ProductID = 3, Price = 500} 
            };

            var expected = shop.CalculateProductTotal();
            decimal actual = (decimal)(750 - (750 * 0.2));
            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod()]
        public void HalfValueCalculatorDiscount10Test()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IDiscount>().To<Discount_10>();
            kernel.Bind<IValueCalculator>().To<HalfValueCalculator>();

            IShoppingCard shop = kernel.Get<ShoppingCard>();
            shop.Products = new List<Product>()
            {              
                new Product {Name = "Product 1", Category = "C1", Description = "no", ProductID = 1, Price = 800},
                new Product {Name = "Product 2", Category = "C2", Description = "no", ProductID = 2, Price = 200},
                new Product {Name = "Product 3", Category = "C3", Description = "no", ProductID = 3, Price = 500} 
            };

            var expected = shop.CalculateProductTotal();
            decimal actual = (decimal)(750 - (750 * 0.1));
            Assert.AreEqual<decimal>(expected, actual);
        }
    }
}
