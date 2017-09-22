using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Group 7
namespace Observer
{
    //The class containing the values for the stock(observable thing)
    class ConcreteStock : StockSubject
    {
        public string StockName { get; }
        public float StockValue { private set;  get; }

        public ConcreteStock(string name, float startValue)
        {
            StockName = name;
            StockValue = startValue;
        }

        //Sets new value for stock and calls Notify so all observers can be notified
        public void UpdateStockValue(float newValue)
        {
            StockValue = newValue;
            Notify();
        }

    }
}
