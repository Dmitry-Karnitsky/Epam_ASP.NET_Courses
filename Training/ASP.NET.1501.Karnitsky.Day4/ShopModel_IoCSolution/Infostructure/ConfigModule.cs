using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using ShopModel.Interfaces;
using ShopModel.ValueCalculators;
using ShopModel.Discounts;

namespace ShopModel.Infostructure
{
    public class ConfigModule : NinjectModule
    {   
        public override void Load()
        {
            this.Bind<IDiscount>().To<NoDiscount>();
            this.Bind<IValueCalculator>().To<HalfValueCalculator>();            
        }
    }
}
