using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CuncurrentCollections
{
    class Program
    {
        public static readonly List<string> AllShirtNames =
            new List<string>
            { "technologyhour", "Code School", "jDays", "buddhistgeeks", "iGeek" };

        static void Main(string[] args)
        {
            //Queue Collection not being thread safe
            //ConcurrentIntroduction();
            //NormalDictionaryExample();
            //ConcurrentDictionarySample();
            //ConcurrentDictionaryConcreteDemo();
            //NormalQueueExample();
            //ConcurrentQueueSample();
            //ConcurrentStackSample();
            //ConcurrentBagSample();
            //SampleUsingProducerConsumerCollectionInterface();

        }

        private static void SampleUsingProducerConsumerCollectionInterface()
        {
            IProducerConsumerCollection<string> shirts = new ConcurrentQueue<string>();

            shirts.TryAdd("Pluralsight");
            shirts.TryAdd("WordPress");
            shirts.TryAdd("Code School");

            Console.WriteLine($"After pushing count = {shirts.Count.ToString()}");

            bool success = shirts.TryTake(out string item1);
            if (success)
                Console.WriteLine($"\r\nRemoving\t:{item1}");
            else
                Console.WriteLine($"\r\nBag is Empty");

            foreach (var item in shirts)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"\nAfter enumerating count = {shirts.Count.ToString()}");
        }

        private static void ConcurrentBagSample()
        {
            var shirts = new ConcurrentBag<string>();

            shirts.Add("Pluralsight");
            shirts.Add("WordPress");
            shirts.Add("Code School");

            Console.WriteLine($"After pushing count = {shirts.Count.ToString()}");

            bool success = shirts.TryTake(out string item1);
            if (success)
                Console.WriteLine($"\r\nRemoving\t:{item1}");
            else
                Console.WriteLine($"\r\nBag is Empty");
            success = shirts.TryPeek(out string item2);
            if (success)
                Console.WriteLine($"Peeking\t\t:{item2}");
            else
                Console.WriteLine($"\r\nBag is Empty");
            foreach (var item in shirts)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"\nAfter enumerating count = {shirts.Count.ToString()}");
        }

        private static void ConcurrentStackSample()
        {
            var shirts = new ConcurrentStack<string>();

            shirts.Push("Pluralsight");
            shirts.Push("WordPress");
            shirts.Push("Code School");

            Console.WriteLine($"After pushing count = {shirts.Count.ToString()}");

            bool success = shirts.TryPop(out string item1);
            if (success)
                Console.WriteLine($"\r\nRemoving\t:{item1}");
            else
                Console.WriteLine($"\r\nStack is Empty");
            success = shirts.TryPeek(out string item2);
            if (success)
                Console.WriteLine($"Peeking\t\t:{item2}");
            else
                Console.WriteLine($"\r\nStack is Empty");
            foreach (var item in shirts)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"\nAfter enumerating count = {shirts.Count.ToString()}");
        }

        private static void ConcurrentQueueSample()
        {
            var shirts = new ConcurrentQueue<string>();

            shirts.Enqueue("Pluralsight");
            shirts.Enqueue("WordPress");
            shirts.Enqueue("Code School");

            Console.WriteLine($"After enqueing count = {shirts.Count.ToString()}");

            bool success = shirts.TryDequeue(out string item1);
            if (success)
                Console.WriteLine($"\r\nRemoving\t:{item1}");
            else
                Console.WriteLine($"\r\nQueue is Empty");
            success = shirts.TryPeek(out string item2);
            if (success)
                Console.WriteLine($"Peeking\t\t:{item2}");
            else
                Console.WriteLine($"\r\nQueue is Empty");
            foreach (var item in shirts)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"\nAfter enumerating count = {shirts.Count.ToString()}");
        }

        private static void NormalQueueExample()
        {
            var shirts = new Queue<string>();

            shirts.Enqueue("Pluralsight");
            shirts.Enqueue("WordPress");
            shirts.Enqueue("Code School");

            Console.WriteLine($"After enqueing count = {shirts.Count.ToString()}");

            var item1 = shirts.Dequeue();
            Console.WriteLine($"\r\nRemoving\t:{item1}");
            var item2 = shirts.Peek();
            Console.WriteLine($"Peeking\t\t:{item2}");

            foreach (var item in shirts)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"\nAfter enumerating count = {shirts.Count.ToString()}");
        }

        private static void ConcurrentDictionaryConcreteDemo()
        {
            //StackController controller = new StackController();
            //TimeSpan workDay = new TimeSpan(0, 0, 2);
            //Task t1 = Task.Run(() => new SalesPerson("Sahil").Work(controller, workDay));
            //Task t2 = Task.Run(() => new SalesPerson("Peter").Work(controller, workDay));
            //Task t3 = Task.Run(() => new SalesPerson("Juliette").Work(controller, workDay));
            //Task t4 = Task.Run(() => new SalesPerson("Xavier").Work(controller, workDay));

            //Task.WaitAll(t1, t2, t3, t4);
            //controller.DisplayStatus();
        }

        private static void ConcurrentDictionarySample()
        {
            var stock = new ConcurrentDictionary<string, int>() { };

            bool success = stock.TryAdd("jDays", 4);
            Console.WriteLine($"Added Successfully? : {success}");
            success = stock.TryAdd("technologyHours", 3);
            Console.WriteLine($"Added Successfully? : {success}");
            success = stock.TryAdd("technologyHours", 3);
            Console.WriteLine($"Added Successfully? : {success}");

            Console.WriteLine($"No. of t-shirts in stock {stock.Count}");
            stock.TryAdd("pluralsight", 6);
            stock["buddhistgeeks"] = 5;
            stock["pluralsight"] = 7;

            success = stock.TryUpdate("pluralsight", 8, 7);
            Console.WriteLine($"\r\n Pluralsight = {stock["pluralsight"]}, did update worked? {success}");
            //This tryupdate wont update, as the existing value is not matching correctly
            success = stock.TryUpdate("pluralsight", 9, 7);
            Console.WriteLine($"\r\n Pluralsight = {stock["pluralsight"]}, did update worked? {success}");

            //success = stock.TryRemove("pluralsight", out int removingPluralsightItem);
            //Console.WriteLine($"\r\nItem removed: {removingPluralsightItem}, Is remove succeeded? {success}");
            ////AddorUpdateExample
            Console.WriteLine
                ($"\r\n Pluralsight (added through addorupdate method) = " +
                $"{stock.AddOrUpdate("pluralsight", 1, (key, OldValue) => OldValue + 1)}"
                );

            success = stock.TryRemove("pluralsight", out int removingPluralsightItem1);
            Console.WriteLine($"\r\nItem removed: {removingPluralsightItem1}, Is remove succeeded? {success}");

            //Printing using Indexer //This code will fail if the key is removed through some other thread
            //Console.WriteLine($"\r\n stock[pluralsight] = {stock["pluralsight"]}");
            success = stock.TryRemove("pluralsight", out int removingPluralsightItem2);
            Console.WriteLine($"\r\nItem removed: {removingPluralsightItem2}, Is remove succeeded? {success}");

            Console.WriteLine($"\r\n stock[pluralsight] through getoradd = {stock.GetOrAdd("pluralsight", 1)}");


            //Printing using TryGetValue
            success = stock.TryGetValue("buddhistgeeks", out int psStock);
            Console.WriteLine($"\r\n stock.TryGetValue(buddhistgeeks) = {psStock}, result = {success}");
            success = stock.TryRemove("jDays", out int removingItem);
            Console.WriteLine($"\r\nRemoving Item : {removingItem}, result = {success}");
            Console.WriteLine("\r\nEnumerating");
            foreach (var keyValPair in stock)
            {
                Console.WriteLine($"{keyValPair.Key} : {keyValPair.Value}");
            }
            Console.WriteLine($"No. of t-shirts in stock {stock.Count}");
        }

        private static void NormalDictionaryExample()
        {
            var stock = new Dictionary<string, int>()
            {
                { "jDays", 4},
                { "technologyHours", 3}
            };

            Console.WriteLine($"No. of t-shirts in stock {stock.Count}");
            stock.Add("pluralsight", 6);
            stock["buddhistgeeks"] = 5;
            stock["pluralsight"] = 7;
            Console.WriteLine($"\r\nstock[pluralsight] = {stock["pluralsight"]}");
            stock.Remove("jDays");
            Console.WriteLine("\r\nEnumerating");
            foreach (var keyValPair in stock)
            {
                Console.WriteLine($"{keyValPair.Key} : {keyValPair.Value}");
            }
            Console.WriteLine($"No. of t-shirts in stock {stock.Count}");
        }

        private static void ConcurrentIntroduction()
        {
            ConcurrentQueue<string> orders = new ConcurrentQueue<string>();//ThreadSafetyInQueue();

            Task task1 = Task.Run(() => PlaceOrderOnList(orders, "Mark"));
            Task task2 = Task.Run(() => PlaceOrderOnList(orders, "Ramdevi"));
            Task.WaitAll(task1, task2);

            foreach (var order in orders)
                Console.WriteLine($"Order: {order}");
        }

        private static void PlaceOrderOnList(ConcurrentQueue<string> orders, string customerName)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1);
                string orderName = $"{customerName} wants t-shirt {i + 1}";
                orders.Enqueue(orderName);
            }
        }

        private static Queue<string> ThreadSafetyInQueue()
        {
            var orders = new Queue<string>();
            //PlaceOrders(orders, "Mark");
            //PlaceOrders(orders, "Ramdevi");

            Task task1 = Task.Run(() => PlaceOrdersOnQueue(orders, "Mark"));
            Task task2 = Task.Run(() => PlaceOrdersOnQueue(orders, "Ramdevi"));
            Task.WaitAll(task1, task2);
            return orders;
        }

        static void PlaceOrdersOnQueue(Queue<string> orders, string customerName)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1);
                string orderName = $"{customerName} wants t-shirt {i + 1}";
                orders.Enqueue(orderName);
            }
        }
    }

}
