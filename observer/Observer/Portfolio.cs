using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Portfolio : IPortfolio
    {
        private float totalStockValue;
        private Dictionary<ConcreteStock, float> stockDict;
        IDisplay display;

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
                //Console.WriteLine(">>" + stockValPair.Value);
                totalStockValue += 
                    stockValPair.Value * stockValPair.Key.StockValue;
            }
        }

        public void Update()
        {
            //recalculating total value
            CalculateTotalValue();

            DisplayStocks();
        }

        public void DisplayStocks()
        {
            var stockDictCopy = stockDict.ToDictionary(entry => entry.Key,
                                       entry => entry.Value);

            display.Display(totalStockValue, stockDictCopy);
        }

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
                CalculateTotalValue();

            }
        }
    }
}
