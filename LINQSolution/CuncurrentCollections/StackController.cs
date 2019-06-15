using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;

namespace CuncurrentCollections
{
    class StackController
    {
        ConcurrentDictionary<string, int> _stock = new ConcurrentDictionary<string, int>();

        int _totalQuantityBought;
        int _totalQantitySold;
        ToDoQueue _todoQueue;

        public StackController(ToDoQueue bonusController)
        {
            this._todoQueue = bonusController;
        }

        public void BuyStock(SalesPerson person, string item, int quantity)
        {
            _stock.AddOrUpdate(item, quantity, (key, oldValue) => oldValue + quantity);
            Interlocked.Add(ref _totalQuantityBought, quantity);
            _todoQueue.AddTrade(new Trade(person, -quantity));
        }

        public bool TrySellItem(SalesPerson person, string item)
        {
            bool success = false;
            int newStockLevel = _stock.AddOrUpdate
                (item,
                (itemName) => { success = false; return 0; },
                (key, OldValue) =>
                {
                    if (OldValue == 0)
                    {
                        success = false;
                        return 0;
                    }
                    else
                    {
                        success = true;
                        return OldValue - 1;
                    }
                });
            if (success)
            {
                Interlocked.Increment(ref _totalQantitySold);
                _todoQueue.AddTrade(new Trade(person, 1));
            }
            return success;
        }

        public bool TrySellItem2(string item)
        {
            int newStockLevel = _stock.AddOrUpdate(item, -1, (key, oldValue) => oldValue - 1);
            if(newStockLevel < 0)
            {
                _stock.AddOrUpdate(item, 0, (key, oldValue) => oldValue + 1);
                return false;
            }
            else
            {
                Interlocked.Increment(ref _totalQantitySold);
                return true;
            }

        }

        public void DisplayStatus()
        {
            int totalStock = _stock.Values.Sum();
            Console.WriteLine("\r\nBought = " + _totalQuantityBought);
            Console.WriteLine("Sold = " + _totalQantitySold);
            Console.WriteLine("Stock = " + totalStock);

            int error = totalStock + _totalQantitySold - _totalQuantityBought;
            if (error == 0)
                Console.WriteLine("Stock Levels Match");
            else
                Console.WriteLine($"Error in Stock Level: {error}");

            Console.WriteLine();
            Console.WriteLine("Stock levels by item: ");
            foreach(string Name in Program.AllShirtNames)
            {
                //int stockLevel = _stock.GetOrAdd(Name, 0);
                bool success = _stock.TryGetValue(Name, out int stockLevel);
                if (!success)
                    stockLevel = 0;
                Console.WriteLine($"{Name}: {stockLevel}");
            }
        }
    }
}
