using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Group 7
namespace Observer
{
    //Class that takes care of displaying all stocks of a portfolio
    class PortfolioDisplay : IDisplay
    {
        public void Display(float totalStockValue, Dictionary<ConcreteStock, float> stockDict)
        {
            //Formatting
            string stocksString = "total stock value: " 
                + totalStockValue + "\n";

            foreach(var pair in stockDict)
            {
                stocksString += pair.Key.StockName + ": $" +
                    pair.Key.StockValue + 
                    " x" + pair.Value + "\n";
            }

            //Displaying
            Console.WriteLine("Printing the portfolio");
            Console.WriteLine(stocksString);
        }
    }
}
