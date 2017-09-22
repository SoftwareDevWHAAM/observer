using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Group 7
namespace Observer
{
    //Keeps track of owned stocks and their amount, as well as the total value of all stocks.
    class Portfolio : IPortfolioObserver
    {
        private float totalStockValue;
        private Dictionary<ConcreteStock, float> stockDict;
        private IDisplay display;

        public Portfolio()
        {
            totalStockValue = 0;
            stockDict = new Dictionary<ConcreteStock, float>();
            
            // PortfolioDisplay is a default choice
            display = new PortfolioDisplay();
        }

        private void CalculateTotalValue()
        {
            totalStockValue = 0;
            foreach(var stockValPair in stockDict)
            {
                totalStockValue += 
                    stockValPair.Value * stockValPair.Key.StockValue;
            }
        }

        //Called by Notify() of StockSubject when stock value changes.
        public void Update()
        {
            //recalculating total value
            CalculateTotalValue();
            //All values have to be re-displayed by requirements.
            DisplayStocks();
        }

        public void DisplayStocks()
        {
            //Making a copy of the stocks for security reasons.
            var stockDictCopy = stockDict.ToDictionary(entry => entry.Key,
                                       entry => entry.Value);
            //Passing the copy to class that displays owned stocks.
            display.Display(totalStockValue, stockDictCopy);
        }

        //When called it either adds a new stock or updates it's amount if it already existed in the portfolio and recalculates
        //the totalStockValue
        public void AddStock(ConcreteStock stock, int amount)
        {
            if (stockDict.ContainsKey(stock)) 
            {
                stockDict[stock] += amount;
            }
            else
            {
                stockDict.Add(stock, amount);
                stock.Attach(this);
            }
            CalculateTotalValue();
        }
    }
}
