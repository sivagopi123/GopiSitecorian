using System;

namespace CuncurrentCollections
{
    class SalesPerson
    {
        public string Name { get; private set; }

        public SalesPerson(string id)
        {
            this.Name = id;
        }

        public void Work(StackController stackController, TimeSpan workDay)
        {
            Random rand = new Random(Name.GetHashCode());
            DateTime start = DateTime.Now;

            while (DateTime.Now - start < workDay)
            {
                //Thread.Sleep(rand.Next(100));
                bool buy = (rand.Next(6) == 0);
                string itemName = Program.AllShirtNames[rand.Next(Program.AllShirtNames.Count)];
            }
            Console.WriteLine($"Salesperson {this.Name} signing off");
        }

        private void DisplaySaleAttempt(bool success, string itemName)
        {
            if (success)
                Console.WriteLine($"{this.Name} sold {itemName}");
            else
                Console.WriteLine($"{this.Name}: Out of Stock of {itemName}");
        }

        private void DisplayPurchage(string itemName, int quantity)
        {
            Console.WriteLine($"{this.Name} bought {quantity} of {itemName}");
        }
    }
}
