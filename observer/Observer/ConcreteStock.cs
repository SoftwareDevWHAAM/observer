using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class ConcreteStock : StockSubject
    {
        public string StockName { get; }
        public float StockValue { private set;  get; }

        public ConcreteStock(string name, float startValue)
        {
            StockName = name;
            StockValue = startValue;
        }

        public void UpdateStockValue(float newValue)
        {
            StockValue = newValue;
            Notify();
        }

    }
}
