using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Group 7 
namespace Observer
{
    //Interface so different classes can be made in the future for displaying.
    interface IDisplay
    {
        void Display(float totalStockValue, Dictionary<ConcreteStock, float> stockDict);
            
    }
}
