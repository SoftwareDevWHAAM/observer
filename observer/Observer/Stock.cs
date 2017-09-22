using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    abstract class StockSubject
    {
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
