using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    abstract class Stock
    {
        private List<IPortfolio> portfolioList;

        public Stock()
        {
            portfolioList = new List<IPortfolio>();
        }

        public void Attach(IPortfolio ip)
        {
            if (!(portfolioList.Contains(ip)))
            {
                portfolioList.Add(ip);
            }
        }
        public void Detach(IPortfolio ip)
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
