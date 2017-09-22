using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class PortfolioDisplay : IDisplay
    {
        public void Display(float totalStockValue, Dictionary<ConcreteStock, float> stockDict)
        {
            string stocksString = "total stock value: " 
                + totalStockValue + "\n";

            foreach(var pair in stockDict)
            {
                stocksString += pair.Key.StockName + ": $" +
                    pair.Key.StockValue + 
                    " x" + pair.Value + "\n";
            }

            Console.WriteLine("Printing the portfolio");
            Console.WriteLine(stocksString);
        }
    }
}
