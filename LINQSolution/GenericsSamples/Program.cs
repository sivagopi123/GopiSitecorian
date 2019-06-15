using System;
using System.Collections.Generic;

namespace GenericsSamples
{
    class Program
    {
        public static string VendorId { get; private set; }

        static void Main(string[] args)
        {
            /***
             * Array is strongly typed: Generic is also strongly typed
             * Array is fixed length
             * Generic list is expandable
             * No abilitiy to add / remove element in array but can in generic list
             * Array is multi dimensional.. Generic is always single dimensional
             * */

            //Generic List
            //List<T>
            /**
             * System: Array
             *  Use array only if you need multiple dimension. 
             *  Small performance benifit with large fixed number of elements.
             * System.Collection(.NET 1): ArrayList
             *  Do not use this
             * System.Collection.Generic(.NET 2+): List<T>, LinkedList<T>,Queue<T>,Stack<T>
             *  LinkedList<T>: This is doubly linked list, which is that the element is linked to the element before and the element after.
             *  Use this when you want to access the list in a sequence or if we want to insert or remove the elemtn in the middle of the list. 
             *  Queue<T>: First IN First OUT list of elements. Discard element after retrieval, Access elements in the same order as they were added. 
             *  Stack<T>: First IN Last OUT list of elements.Discard element after retrieval.
             *  
             *  System.Collection.ObjectModel
             *  ReadOnlyCollection: can be sorted and iterated but cannot be removed.
             *  ObservableCollection: can be used for binding
             *  System.Collection.Specialized: For speciality collection, such as string collection
             *  System.Collection.Concurrent (.NET 4): Thread safe list classes - to access the list form multiple threads concurrently. 
             * */
            var colorOptions = new List<string>
                                    { "Red", "Espresso", "White", "Navy" };
            colorOptions.Insert(4, "Blue");
            colorOptions.Remove("White");

            //foreach (var elem in colorOptions)
            //    Console.WriteLine($"{elem}");

            /**
             * Generic Dictionary: Key value pair of strongly typed collection
             * Key must be unique
             * lists allow duplicate element, but dictionary allow duplicate value but key must be unique
             * Lists: Marginally faster iteration
             * Dictionary: Marginally faster lookups
             * Dictionary<TKey,TValue>
             * 
             * 
             * */
            //Dictionary<string, string> states = new Dictionary<string, string>();

            //var states = new Dictionary<string, string>();

            //states.Add("IND", "India");
            //states.Add("PAK", "Pakistan");
            //states.Add("SRI", "Srilanka");
            //states.Add("CHN", "China");
            //states.Add("CHN", "Greater china");

            var states = new Dictionary<string, string>
            {
                { "IND", "India" },
                { "PAK", "Pakistan" },
                { "SRI", "Srilanka" },
                { "CHN", "China" }
            };

            //Console.WriteLine(states);
            //foreach (var s in states)
            //    Console.WriteLine(s);

            var action = new Vendor();
            var result = action.DictionaryCollectionSample();
            if(result.TryGetValue("ABC", out action))
            {
                Console.WriteLine(action.CompanyName);
            }

            /**
             * Dictionary<TKey,TValue> : Used most often | Not Sorted 
             * SortedList<TKey,TValue>: Sorted on the key, faster when populating the collectoin
             * SortedDictionary<TKey,TValue>: SortedbyKey, faster when populating from unsorted data
             * 
             * System.Collections.ObjectModel
             * ReadOnlyDictionary: 
             * KeyedCollection
             * */
            
        }

        
    }
}

