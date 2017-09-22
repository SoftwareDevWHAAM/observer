using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static Dictionary<string, ConcreteStock> stockNamesDict;
        public static void ParseLine(string input, out string stockName, out float stockValue)
        {
            string[] elems = input.Split();
            stockName = elems[0];
            stockValue = float.Parse(elems[1]);
            
        }

        public static void UpdateStock(string name, float value, Portfolio p, int amount)
        {

            if (!(stockNamesDict.ContainsKey(name)))
            {
                Console.WriteLine("creating stock " + name + " value: "+ value);

                ConcreteStock stock = new ConcreteStock(name.ToUpper(), value);
                stockNamesDict.Add(name, stock);
                p.AddStock(stock, amount);
            }
            else
            {
                Console.WriteLine("updating stock " + name + " value: " + value);
                stockNamesDict[name].UpdateStockValue(value);

            }

        }


        static void Main(string[] args)
        {
            int startingAmount = 1;

            stockNamesDict= new Dictionary<string, ConcreteStock>();
            Portfolio p = new Portfolio();

            Console.WriteLine("use notation company_name stock_value (no colons)");

            bool stop = false;
            do
            {
                Console.WriteLine("type x to stop inserting stocks\n and n to insert a new stock\n");
                var key = Console.ReadKey();
                if(key.KeyChar == 'x')
                {
                    stop = true;
                }
                else
                {
                    Console.WriteLine("type a new stock");
                    string line = Console.ReadLine();
                    ParseLine(line, out string name, out float value);
                    UpdateStock(name, value, p, startingAmount);
            
                }
            } while (!stop);

            
     
            Console.ReadKey();
        }
    }
}
