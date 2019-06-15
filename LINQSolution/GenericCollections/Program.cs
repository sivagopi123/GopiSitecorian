using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace GenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<T>
            //ReadonlyCollection<T>
            //Collection<T>
            //ObservableCollection<T>
            //Lists
            #region List
            //AddElementsinLists();

            //RemovingElementsInLists();

            //ReadOnlyCollection();

            //Collection();
            //ObservableCollectionSample();
            #endregion

            #region LinkedList, Stack and Queue
            //LinkedList
            //OtherLists();
            #endregion

            #region Dictionary
            //SortedList
            //SortedDictionary
            //Dictionary

            //Equality Comparer
            //var primeMinisters = new Dictionary<string, PrimeMinisters>(StringComparer.InvariantCultureIgnoreCase)
            //DictionaryMethod();
            #endregion

            #region Sets
            /*
             * Hashset<T>
             * Elements have no order
             * Its not a Dictionary, stores just elements and values
             * Basic usage is, it provides Uniqueness
             * */
            //SortedListClass();
            //HashSetClassExplained();
            //HashSetCustomComparerToFindUniqueness();
            /*
             * Intersect method modifies the array inline
             * */
            //IntersectionandUnionOnSets();
            //IntersetctionandUniononSetsUsingLinq();
            //SymmetricDifference();

            #endregion

            #region EnumeratorSamples
            EnumeratorSamples();
            #endregion

            #region MultiDimensionalArray
            float[,] tempGrid = new float[4, 3]; //Only Arrays 
            float[][] jaggdArray = new float[4][]; //Any Collection
                                                   //Rank is the total number of indexes in a multidimensional array

            #endregion

            #region ArraySamples
            //ArrayBasics();
            //ArrayEquals();
            //ArrayWithMultipleObjects();
            //ArrayCovariance();
            //ArrayCopyTo();
            //OrderOfItem
            //ComparerSortofArray();
            //ArraySearch();
            #endregion
        }

        private static void EnumeratorSamples()
        {
            string[] daysOfWeek =
                        {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            //DisplayItems("Hello World!");
            //DisplayItems(daysOfWeek);
            //Covariance for collections
            var strList = new List<string> { "Monday", "Tuesday" };
            //This cast is not possible
            //List<object> objList = strList;
            //This is also not possible
            //List<object> objList = (List<object>)strList;
            string[] strArray = { "Monday", "Tuesday" };
            object[] objList = strArray;
            //Console.WriteLine(objList[1] = 3);
            //This is possible
            IEnumerable<object> enumrableList = strList;
            DisplayItems(enumrableList);
        }

        public static void DisplayItems<T>(IEnumerable<T> collection)
        {
            using (IEnumerator<T> enumerator = collection.GetEnumerator())
            {
                bool moreItems = enumerator.MoveNext();
                while (moreItems)
                {
                    T item = enumerator.Current;
                    Console.WriteLine(item);
                    moreItems = enumerator.MoveNext();
                }
            }
        }

        private static void SymmetricDifference()
        {
            var bigCities = new HashSet<string>
            {
                "Chennai",
                "Bangalore",
                "Mumbai",
                "Pune"
            };

            string[] citiesinUK = { "Sheffeild", "Ripon", "Truro", "Manchester", "Chennai", "Mumbai" };
            //bigCities.SymmetricExceptWith(citiesinUK);
            bigCities.ExceptWith(citiesinUK);
            foreach (var item in bigCities)
            {
                Console.WriteLine(item);
            }
        }

        private static void IntersetctionandUniononSetsUsingLinq()
        {
            var bigCities = new HashSet<string>
            {
                "Chennai",
                "Bangalore",
                "Mumbai",
                "Pune"
            };

            string[] citiesinUK = { "Sheffeild", "Ripon", "Truro", "Manchester", "Chennai", "Mumbai" };
            var newCities = bigCities.Intersect(citiesinUK);
            var allCities = bigCities.Union(citiesinUK);
            foreach (var item in newCities)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("***************************");
            foreach (var item in allCities)
            {
                Console.WriteLine(item);
            }
        }

        private static void IntersectionandUnionOnSets()
        {
            var bigCities = new HashSet<string>
            {
                "Chennai",
                "Bangalore",
                "Mumbai",
                "Pune"
            };

            string[] citiesinUK = { "Sheffeild", "Ripon", "Truro", "Manchester", "Chennai", "Mumbai" };
            //bigCities.IntersectWith(citiesinUK);
            bigCities.UnionWith(citiesinUK);
            foreach (var item in bigCities)
            {
                Console.WriteLine(item);
            }
        }

        private static void HashSetCustomComparerToFindUniqueness()
        {
            var bigCities = new HashSet<string>
                        //(StringComparer.InvariantCultureIgnoreCase)
                        (new UncasedStringEqualityComparer())
            {
                "Chennai",
                "Bangalore",
                "Mumbai",
                "Pune"
            };

            bigCities.Add("CHENNAI");
            bigCities.Add("Trivandrum");

            foreach (var item in bigCities)
            {
                Console.WriteLine($"{item}");
            }
        }

        private static void HashSetClassExplained()
        {
            var bigCities = new HashSet<string>
            {
                "Chennai",
                "Bangalore",
                "Mumbai",
                "Pune"
            };

            bigCities.Add("Chennai");
            bigCities.Add("Trivandrum");

            foreach (var item in bigCities)
            {
                Console.WriteLine($"{item}");
            }
        }

        private static void SortedListClass()
        {
            var bigCities = new SortedList<int, string>
            {
                {1, "Chennai" },
                {2, "Bangalore" },
                {3, "Mumbai" },
                {4, "Pune" }
            };

            foreach (var item in bigCities)
            {
                Console.WriteLine($"{item}");
            }
        }

        private static void DictionaryMethod()
        {
            var primeMinisters = new Dictionary<string, PrimeMinisters>
                            (new UncasedStringEqualityComparer())
            {
                {"JC", new PrimeMinisters("James Callaghen", 1976) },
                {"MT", new PrimeMinisters("Margret thatcher", 1979) },
                {"TB", new PrimeMinisters("Tony Blair", 1997) }
            };

            Console.WriteLine($"{primeMinisters["tb"]}");

            //KeyedCollection
            var primeMinistersKeyedCollection = new PrimeMinistersByYearDictionary()
            {
                new PrimeMinisters("James Callaghen", 1976),
                new PrimeMinisters("Margret thatcher", 1979),
                 new PrimeMinisters("Tony Blair", 1997)
            };

            Console.WriteLine($"{primeMinistersKeyedCollection[1997]}");
            foreach (var item in primeMinistersKeyedCollection)
            {
                Console.WriteLine($"{item}");
            }
        }

        private static void OtherLists()
        {
            var newLinkedList = new LinkedList<string>();
            newLinkedList.AddLast("Gopi");
            newLinkedList.AddLast("Dinesh");
            newLinkedList.AddLast("Venkatesh");
            newLinkedList.AddLast("Deetchith");
            newLinkedList.AddLast("Vivek");
            newLinkedList.AddLast("Devika");

            var previousNode = newLinkedList.Find("Vivek");

            newLinkedList.AddAfter(previousNode, "Prarthana");

            foreach (var name in newLinkedList)
            {
                Console.WriteLine($"Name:\t{name}\n");
            }

            //Stack
            var stackList = new Stack<string>();
            stackList.Push("Gopi");
            stackList.Push("Dinesh");
            stackList.Push("Devika");
            stackList.Push("Prarthana");

            foreach (var name in stackList)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine(stackList.Peek());

            //Queue
            var queueList = new Queue<string>();

            queueList.Enqueue("1");
            queueList.Enqueue("2");
            queueList.Enqueue("3");
            queueList.Enqueue("4");
            queueList.Enqueue("5");

            foreach (var name in queueList)
            {
                Console.WriteLine(name);
            }
            queueList.Dequeue();
            foreach (var name in queueList)
            {
                Console.WriteLine(name);
            }
        }

        private static void ObservableCollectionSample()
        {
            //ObservableCollection
            ObservableCollection<string> presidents = new ObservableCollection<string>
            {
                "Jimmy Carter",
                "Ronald Reagan",
                "Gearge HW Bush",
                "Bill Clinton",
                "Gearge W Bush"
            };

            presidents.CollectionChanged += OnCollectionChanged;

            presidents.Add("Donald Trump");
            presidents.Remove("Jimmy Carter");

            foreach (var pr in presidents)
                Console.WriteLine(pr.ToString());
        }

        static void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine($"Action:\t{e}\n" +
                                $"New Items:\t{e.NewItems}");
        }

        private static void Collection()
        {
            NonBlankStringList lst = new NonBlankStringList();
            lst.Add("Item added at INdex 0");
            lst[0] = "  ";
            lst.Add("Item added at index 1");
            lst.Insert(2, "Item inserted at index 2");

            foreach (string item in lst)
                Console.WriteLine(item);
        }

        private static void ReadOnlyCollection()
        {
            var presidents = new List<string>(12)
            {
                "Jimmy Carter",
                "Ronald Reagan",
                "Gearge HW Bush",
                "Bill Clinton",
                "Gearge W Bush"
            };

            Console.WriteLine($"First President: {presidents[0]}");

            foreach (var pre in presidents)
                Console.WriteLine($"{pre}");

            var copy = new ReadOnlyCollection<string>(presidents);

            foreach (var pre in copy)
                Console.WriteLine($"{pre}");
        }

        private static void RemovingElementsInLists()
        {
            var presidents = new List<string>(12)
            {
                "Jimmy Carter",
                "Ronald Reagan",
                "Gearge HW Bush",
                "Bill Clinton",
                "Gearge W Bush"
            };

            presidents.RemoveAt(3);

            Console.WriteLine($"Count:\t\t{presidents.Count}");
            Console.WriteLine($"Capacity:\t{presidents.Capacity}");

            foreach (var pre in presidents)
                Console.WriteLine($"{pre}");
        }

        private static void AddElementsinLists()
        {
            var presidents = new List<string>(12)
            {
                "Jimmy Carter",
                "Ronald Reagan",
                "Gearge HW Bush",
                "Bill Clinton",
                "Gearge W Bush"
            };
            Console.WriteLine($"Count:\t\t{presidents.Count}");
            Console.WriteLine($"Capacity:\t{presidents.Capacity}");
            presidents.Add("Barack Obama");
            Console.WriteLine("Barack Obama");
            Console.WriteLine($"Count:\t\t{presidents.Count}");
            Console.WriteLine($"Capacity:\t{presidents.Capacity}");
            presidents.Add("Donald Trump");
            Console.WriteLine("Donald Trump");

            presidents.Add("Steven Spilburg");
            Console.WriteLine("Steven Spilburg");
            presidents.Add("Pluralsight");
            Console.WriteLine("Pluralsight");
            Console.WriteLine($"Count:\t\t{presidents.Count}");
            Console.WriteLine($"Capacity:\t{presidents.Capacity}");

            presidents.Add("Pluralsight");
            Console.WriteLine("Pluralsight");
            Console.WriteLine($"Count:\t\t{presidents.Count}");
            Console.WriteLine($"Capacity:\t{presidents.Capacity}");
            presidents.Add("Pluralsight");
            Console.WriteLine("Pluralsight");
            Console.WriteLine($"Count:\t\t{presidents.Count}");
            Console.WriteLine($"Capacity:\t{presidents.Capacity}");
            presidents.Add("Pluralsight");
            Console.WriteLine("Pluralsight");
            Console.WriteLine($"Count:\t\t{presidents.Count}");
            Console.WriteLine($"Capacity:\t{presidents.Capacity}");
            presidents.Add("Pluralsight");
            Console.WriteLine("Pluralsight");
            Console.WriteLine($"Count:\t\t{presidents.Count}");
            Console.WriteLine($"Capacity:\t{presidents.Capacity}");
            presidents.Add("Pluralsight");
            Console.WriteLine("Pluralsight");
            Console.WriteLine($"Count:\t\t{presidents.Count}");
            Console.WriteLine($"Capacity:\t{presidents.Capacity}");
            presidents.Add("Pluralsight");
            Console.WriteLine("Pluralsight");
            Console.WriteLine($"Count:\t\t{presidents.Count}");
            Console.WriteLine($"Capacity:\t{presidents.Capacity}");
            presidents.Add("Pluralsight");
            Console.WriteLine("Pluralsight");
            Console.WriteLine($"Count:\t\t{presidents.Count}");
            Console.WriteLine($"Capacity:\t{presidents.Capacity}");
            presidents.Add("Pluralsight");
            Console.WriteLine("Pluralsight");
            Console.WriteLine($"Count:\t\t{presidents.Count}");
            Console.WriteLine($"Capacity:\t{presidents.Capacity}");
            presidents.Add("Pluralsight");
            Console.WriteLine("Pluralsight");
            Console.WriteLine($"Count:\t\t{presidents.Count}");
            Console.WriteLine($"Capacity:\t{presidents.Capacity}");
            presidents.Add("Pluralsight");
            Console.WriteLine("Pluralsight");
            Console.WriteLine($"Count:\t\t{presidents.Count}");
            Console.WriteLine($"Capacity:\t{presidents.Capacity}");
            presidents.Add("Pluralsight");
            Console.WriteLine("Pluralsight");
            Console.WriteLine($"Count:\t\t{presidents.Count}");
            Console.WriteLine($"Capacity:\t{presidents.Capacity}");
            presidents.Add("Pluralsight");
            Console.WriteLine("Pluralsight");
            Console.WriteLine($"Count:\t\t{presidents.Count}");
            Console.WriteLine($"Capacity:\t{presidents.Capacity}");
        }

        private static void ArraySearch()
        {
            string[] daysOfWeek = {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Staturday",
                "Sunday"
            };

            Array.IndexOf(daysOfWeek, "Monday");
            Array.FindIndex(daysOfWeek, x => x[0] == 'W');
            Array.BinarySearch(daysOfWeek, "Monday");
        }

        private static void ComparerSortofArray()
        {
            string[] daysOfWeek = {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Staturday",
                "Sunday"
            };

            //Array.Reverse(daysOfWeek);
            //LINQ Method
            var reversed = daysOfWeek.Reverse();
            StringComparer comparer = new StringComparer();
            Array.Sort(daysOfWeek, comparer);

            foreach (var day in daysOfWeek)
                Console.WriteLine($"daysofWeek:{day}");
        }

        private static void ArrayCopyTo()
        {
            //ArrayCopyToMethod
            int[] squares = { 1, 43, 5, 6 };
            int[] anotherSquare = new int[4];
            squares.CopyTo(anotherSquare, 0);
            Array.Copy(squares, anotherSquare, 4);
            foreach (var el in anotherSquare)
                Console.WriteLine(el.ToString());
        }

        private static void ArrayCovariance()
        {
            //ArrayCovariance
            object[] objArr = new object[3];
            string[] dayOfWeek =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            objArr[0] = 3;
            Console.WriteLine($"ObjArr[0]:{objArr[0]}");

            object[] anotherObjArray = dayOfWeek;
            anotherObjArray[2] = 4;

            foreach (var obj in anotherObjArray)
                Console.WriteLine(obj.ToString());
        }

        private static void ArrayWithMultipleObjects()
        {
            object[] objArray = new object[3]
                        {
                "Hello World",
                5,
                new Button { Text = "test"}
                        };

            foreach (Object obj in objArray)
                Console.WriteLine(obj);
        }

        private static void ArrayEquals()
        {
            int[] x1 = { 1, 4, 9, 16 };
            var x2 = x1;

            int[] x3 = { 1, 4, 9, 16 };


            Console.WriteLine($"RefEquals(x1,x2): {ReferenceEquals(x1, x2)}");
            Console.WriteLine($"RefEquals(x1,x3): {ReferenceEquals(x1, x3)}");
            Console.WriteLine($"x1=x2 is: {x1 == x2}");
            Console.WriteLine($"x1=x3 is: {x1 == x3}");
        }

        private static void ArrayBasics()
        {
            string monday = "Monday";
            string[] daysOfWeek = {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Staturday",
                "Sunday"
            };


            string tuesday = daysOfWeek[2];
            Console.WriteLine(tuesday);
            int x1;
            int[] x2;
        }
    }

    class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return x.Length.CompareTo(y.Length);
        }
    }
}
