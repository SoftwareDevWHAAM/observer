using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Observer
{
    class Program
    {
        static Dictionary<string, ConcreteStock> stockNamesDict;

        private static System.Timers.Timer aTimer;

        private static void UpdateStocksValues(object sender, EventArgs e)
        {
            foreach(var stock in stockNamesDict)
            {
                Random r = new Random();
                //double nextPercentage = r.NextDouble();
                int nextInt = r.Next(-5,5);
                float percentage = (float)nextInt / 100;
                float nextPercentage = 1 + percentage;

                stock.Value.UpdateStockValue(stock.Value.StockValue * nextPercentage);
            }
        }


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

            aTimer = new System.Timers.Timer(10000);

            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += new ElapsedEventHandler(UpdateStocksValues);

            // Set the Interval to 2 seconds (2000 milliseconds).
            aTimer.Interval = 2000;
            aTimer.Enabled = true;

            Console.ReadKey();
        }
    }
}
