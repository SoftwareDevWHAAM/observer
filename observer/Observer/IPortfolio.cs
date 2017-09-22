using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Group 7
namespace Observer
{
    //Interface so StockSubject does not have to change if we add classes that implement the interface.
    interface IPortfolioObserver
    {
        void Update();
    }
}
