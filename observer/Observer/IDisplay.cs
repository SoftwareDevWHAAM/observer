using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    interface IDisplay
    {
        void Display(float totalStockValue, Dictionary<ConcreteStock, float> stockDict);
            
    }
}
