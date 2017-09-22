using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Group 7
namespace Observer
{
    //Standard Subject class (as part of Observer pattern)
    abstract class StockSubject
    {
        //List of all observers
        private List<IPortfolioObserver> portfolioList;

        public StockSubject()
        {
            portfolioList = new List<IPortfolioObserver>();
        }

        public void Attach(IPortfolioObserver ip)
        {
            if (!(portfolioList.Contains(ip)))
            {
                portfolioList.Add(ip);
            }
        }
        public void Detach(IPortfolioObserver ip)
        {
            if (portfolioList.Contains(ip))
            {
                portfolioList.Remove(ip);
            }
        }
        public void Notify()
        {
            foreach(var portfolio in portfolioList)
            {
                portfolio.Update();
            }

        }



    }
}
