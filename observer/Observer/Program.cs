using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;


//Group 7
namespace Observer
{
    class Program
    {
        static Dictionary<string, ConcreteStock> stockNamesDict;

        private static System.Timers.Timer aTimer;

        //Function that is called periodically(every 2 seconds) to update all stock values
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

        //Helper function for input from user
        public static void ParseLine(string input, out string stockName, out float stockValue)
        {
            string[] elems = input.Split();
            stockName = elems[0];
            stockValue = float.Parse(elems[1]);
            
        }

        //A function that updates stock value
        public static void UpdateStock(string name, float value)
        {

            if ((stockNamesDict.ContainsKey(name)))
            {
                Console.WriteLine("updating stock " + name + " value: " + value);
                stockNamesDict[name].UpdateStockValue(value);
            }

        }

        //A function that adds a new stock to our dictionary(and the portfolio)
        public static void AddStock(string name, float value, Portfolio p, int amount)
        {
            if (!(stockNamesDict.ContainsKey(name)))
            {
                Console.WriteLine("creating stock " + name + " value: " + value);

                ConcreteStock stock = new ConcreteStock(name.ToUpper(), value);
                stockNamesDict.Add(name, stock);
                p.AddStock(stock, amount);
            }
            //When user's input is repeating a company, only update the value. Don't add again to dictionary nor portfolio
            else
            {
                UpdateStock(name, value);
            }

        }


        static void Main(string[] args)
        {

            //Just a dummy amount for testing, will always be the same when new stock added.
            int startingAmount = 1;

            //Dictionary that keeps accounting of all created stocks.
            stockNamesDict = new Dictionary<string, ConcreteStock>();
            //Dummy portofolio for testing.
            Portfolio p = new Portfolio();

            Console.WriteLine("use notation company_name stock_value (no colons)");

            //Loop for getting user's input to create stocks.
            bool stop = false;
            do
            {
                Console.WriteLine("Hit 'x' to stop inserting stocks\n and other key to insert a new stock\n");
                var key = Console.ReadKey(true);
                if(key.KeyChar == 'x')
                {
                    stop = true;
                }
                else
                {
                    Console.WriteLine("type a new stock");
                    string line = Console.ReadLine();
                    ParseLine(line, out string name, out float value);
                    //For testing all created stocks will be added to the portfolio.
                    AddStock(name, value, p, startingAmount);
            
                }
            } while (!stop);

            aTimer = new System.Timers.Timer(10000);

            //Making UpdateStocksValue being called each interval.
            //Hook up the Elapsed event for the timer.
            aTimer.Elapsed += new ElapsedEventHandler(UpdateStocksValues);

            // Set the Interval to 2 seconds (2000 milliseconds).
            aTimer.Interval = 2000;
            aTimer.Enabled = true;

            Console.ReadKey();
        }
    }
}
