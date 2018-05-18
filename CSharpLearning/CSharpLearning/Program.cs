using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpLearning
{
    class Program
    {

        static void Main(string[] args)
        {
            Program obj = new Program();
            //obj.getShiftedString();
            obj.getShiftedString();
            Console.ReadLine();
        }

        void getgopi()
        {
            int inputLengh = 3;
            int[] input = { 3, 4, 2, 5, 6, 7 };
            int maxLength;
            //if (input.Length > Math.Max())
            //    maxLength = 100;
            int[] temp = new int[input.Length];
            Array.Sort(input);
            List<int> listint = input.ToList();
            long Score = 0;
            while (listint.Count > 0)
            {
                listint.Sort();
                int maxValue = listint[listint.Count - 1];
                listint.Remove(maxValue);
                listint.Remove(maxValue - 1);
                listint.Remove(maxValue + 1);
                Score += Convert.ToInt64(maxValue);
            }
            Console.WriteLine(Score);
            Console.ReadLine();
        }

        void delete(int[] input)
        {
            delete(input, input.Length, 0);
        }
        void delete(int[] input, int i, int j)
        {
            int[] sorted = new int[input.Length];
            while (i > j)
            {
                for (int k = 0; k < input.Length - 1; k++)
                {
                    if (input[k] > input[k + 1])
                        sorted[k] = input[k];
                }
                i++;
            }
        }

        void getShiftedString()
        {
            string s = Console.ReadLine();
            string leftshiftstr = Console.ReadLine();
            string rightShiftstr = Console.ReadLine();
            if (!string.IsNullOrEmpty(s))
            {
                int leftShifts, rightShifts;
                if (string.IsNullOrEmpty(leftshiftstr))
                {
                    leftShifts = 0;
                }
                else
                {
                    try
                    {
                        leftShifts = Convert.ToInt32(leftshiftstr);
                        if (leftShifts < 0)
                            leftShifts = 0;
                    }
                    catch (Exception ex)
                    {
                        leftShifts = 0;
                    }
                }

                if (string.IsNullOrEmpty(rightShiftstr))
                {
                    rightShifts = 0;
                }
                else
                {
                    try
                    {
                        rightShifts = Convert.ToInt32(rightShiftstr);
                        if (rightShifts < 0)
                            rightShifts = 0;
                    }
                    catch (Exception ex)
                    {
                        rightShifts = 0;
                    }
                }
                // Write your code here.
                char[] inputchar = s.ToCharArray();
                char[] shiftedArray = new char[inputchar.Length];
                char[] rightShiftedArray = new char[inputchar.Length];

                Array.Copy(inputchar, leftShifts, shiftedArray, 0, inputchar.Length - leftShifts);
                Array.Copy(inputchar, 0, shiftedArray, inputchar.Length - leftShifts, leftShifts);
                string leftshiftedarray = new string(shiftedArray);
                Console.WriteLine(leftshiftedarray);

                Array.Copy(shiftedArray, 0, rightShiftedArray, shiftedArray.Length - rightShifts, rightShifts);
                Array.Copy(shiftedArray, rightShifts, rightShiftedArray, 0, shiftedArray.Length - rightShifts);

                string str = new string(rightShiftedArray);

                Console.WriteLine(str);
            }

        }


        #region Code Practice

        #region ListCollection
        private static void listCollection()
        {
            var names = new List<string> { "Gopi", "Ana", "Felipe" };
            names.Add("Dinesh");
            names.Add("Devika");
            names.Remove("Ana");
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }
            Console.WriteLine($"My name is {names[0]}");
            var searchedItem = Console.ReadLine();
            var index = names.IndexOf(searchedItem);
            if (index != -1)
                Console.WriteLine($"The searched item is {names[index]}");
            else
                Console.WriteLine($"The searched item not found!");
        }
        #endregion

        #region FibonacciNumbers
        private static void fibonacciNumbers()
        {
            var fibonacciCount = Convert.ToInt32(Console.ReadLine());
            var fibonacciNumbers = new List<int> { 1, 1 };
            while (fibonacciNumbers.Count < fibonacciCount)
            {
                var prev1 = fibonacciNumbers[fibonacciNumbers.Count - 1];
                var prev2 = fibonacciNumbers[fibonacciNumbers.Count - 2];
                fibonacciNumbers.Add(prev1 + prev2);
            }

            foreach (var num in fibonacciNumbers)
            {
                Console.WriteLine(num);
            }
        }
        #endregion
        //Array and ArrayList
        #region ArrayList
        private static void RotatingArray(string[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            int length = a.Length;
            int[] rotated = new int[length];
            //int[] rotated2 = new int[length];

            Array.Copy(a, k, rotated, 0, length - k);
            Array.Copy(a, 0, rotated, length - k, k);

            foreach (int val in rotated)
            {
                Console.Write(val);
                Console.Write(" ");
            }
            Console.WriteLine();

        }
        #endregion
        //String and StringBuilder
        #region Anagram
        private static void Anagram()
        {
            Console.WriteLine("Please enter the first String:");
            var firstString = Console.ReadLine();
            Console.WriteLine("Please enter the second String:");
            var secondString = Console.ReadLine();

            int[] firstCount = GetCharCount(firstString);
            int[] secondCount = GetCharCount(secondString);
            int delta = GetDifference(firstCount, secondCount);
            Console.WriteLine(delta);
        }

        private static int[] GetCharCount(string s)
        {
            int[] numberofChars = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                char schar = s[i];
                int Offset = (int)'a';
                int code = schar - Offset;
                numberofChars[code]++;
            }
            return numberofChars;
        }

        private static int GetDifference(int[] first, int[] second)
        {
            int delta = 0;
            for (int i = 0; i < first.Length; i++)
            {
                int difference = Math.Abs(first[i] - second[i]);
                delta += difference;
            }
            return delta;
        }
        #endregion

        #region Hash Table Samples
        private static Dictionary<string, int> GetStringFrequency(string[] str)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (string istr in str)
            {
                if (!dic.ContainsKey(istr))
                {
                    dic.Add(istr, 1);
                }
                else
                {
                    dic[istr] = dic[istr] + 1;
                }
            }
            return dic;
        }

        private static string CompareRandomNotewithMaga(Dictionary<string, int> magazine, Dictionary<string, int> ransom)
        {
            string result = "Yes";
            foreach (var note in ransom)
            {
                if (!magazine.ContainsKey(note.Key) || magazine[note.Key] < note.Value)
                {
                    return "No";
                }
                else
                {
                    result = "Yes";
                }
            }
            return result;
        }

        private static void HashTablesSample()
        {
            string[] tokens_m = Console.ReadLine().Split(' ');
            int m = Convert.ToInt32(tokens_m[0]);
            int n = Convert.ToInt32(tokens_m[1]);
            string[] magazine = Console.ReadLine().Split(' ');
            string[] ransom = Console.ReadLine().Split(' ');

            Dictionary<string, int> magazineMap = GetStringFrequency(magazine);
            Dictionary<string, int> ransonMap = GetStringFrequency(ransom);
            string result = "No";
            result = CompareRandomNotewithMaga(magazineMap, ransonMap);
            Console.WriteLine(result);
        }

        #endregion

        #region Stake and Queue

        #region Queue Implementation
        public class Queue
        {
            public class Node
            {
                public int data;
                public Node(int data)
                {
                    this.data = data;
                }
                public Node next;
            }
            private Node head;
            private Node tail;
            public bool isEmpty()
            {
                return head == null;
            }
            public int peak()
            {
                return head.data;
            }
            public void add(int data)
            {
                Node node = new Node(data);
                if (tail != null)
                {
                    tail.next = node;
                }
                tail = node;
                if (head == null)
                {
                    head = node;
                }
            }
            public int remove()
            {
                int data = head.data;
                head = head.next;
                if (head == null)
                {
                    tail = null;
                }
                return data;
            }
        }
        #endregion

        #region Stack Implementation
        public class Stack
        {
            public class Node
            {
                public int data;
                public Node next;
                public Node(int data)
                {
                    this.data = data;
                }
            }
            private Node top;
            public bool isEmpty()
            {
                return (top == null);
            }
            public int peek()
            {
                return top.data;
            }
            public void push(int data)
            {
                Node node = new Node(data);
                node.next = top;
                top = node;
            }
            public int pop()
            {
                int data = top.data;
                top = top.next;
                return data;
            }
        }
        #endregion

        #region Balanced Brackets / Palindrom

        public char[,] TOKENS = new char[3, 2] { { '{', '}' }, { '[', ']' }, { '(', ')' } };

        private bool IsOpenBracket(char val)
        {
            for (var i = 0; i < TOKENS.GetLength(0); i++)
            {
                if (TOKENS[i, 0] == val)
                    return true;
            }
            return false;
        }

        private bool matches(char left, char right)
        {

            for (var i = 0; i < TOKENS.GetLength(0); i++)
            {
                if (TOKENS[i, 0] == left)
                    return (TOKENS[0, i - 1] == right);
            }
            return false;
        }
        private bool CheckPalindrom(string expression)
        {
            Stack<char> tempStack = new Stack<char>();
            char[] inputCharArray = expression.ToCharArray();

            foreach (char val in inputCharArray)
            {
                if (IsOpenBracket(val))
                {
                    tempStack.Push(val);
                }
                else
                {
                    if (!matches(tempStack.Pop(), val) || tempStack.Count == 0)
                    {
                        return false;
                    }
                }
            }
            return tempStack.Count == 0;
        }


        private void Palindrom()
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int a0 = 0; a0 < t; a0++)
            {
                string expression = Console.ReadLine();
                bool result = CheckPalindrom(expression);
                if (result)
                    Console.WriteLine("Matches");
                else
                    Console.WriteLine("Not Matches");
            }
        }

        #endregion

        #endregion

        #region Bubble Sort
        private void bubbleSort()
        {
            string arrayInput = Console.ReadLine();
            string[] arrayString = arrayInput.Split(' ');
            int[] array = Array.ConvertAll(arrayString, s => Int32.Parse(s));
            bool isSorted = false;
            int lastUnsorted = array.Length - 1;
            while (!isSorted)
            {
                isSorted = true;
                for (int i = 0; i < lastUnsorted; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        Console.WriteLine($"Swapping {array[i]} with {array[i + 1]}");
                        swap(array, i, i + 1);
                        isSorted = false;
                    }
                }
                lastUnsorted--;
            }
            printArray(array);
        }
        private void printArray(int[] array)
        {
            Console.WriteLine("Sorted Array");
            foreach (int str in array)
            {
                Console.Write(str + ' ');
            }
        }

        private void swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private void bubbleSortProblem()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            bool isSorted = false;
            int Counter = 0;
            while (!isSorted)
            {
                isSorted = true;
                int lastUnsorted = a.Length - 1;
                for (int i = 0; i < lastUnsorted; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        Counter++;
                        swap(a, i, i + 1);
                        isSorted = false;
                    }
                }
                lastUnsorted--;
            }
            PrintResult(a, Counter);
        }
        private void PrintResult(int[] array, int counter)
        {
            Console.WriteLine($"Array is sorted in {counter} swaps");
            Console.WriteLine($"First Element : {array[0]}");
            Console.WriteLine($"Last Element : {array[array.Length - 1]}");
        }
        #endregion

        #region quick sort
        public void quicksort()
        {
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            quicksort(a, 0, a.Length - 1);
        }
        public void quicksort(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return;
            }
            int pivot = (left + right) / 2;
            int index = partition(array, left, right, pivot);
            quicksort(array, left, index - 1);
            quicksort(array, index, right);
        }

        public int partition(int[] array, int left, int right, int pivot)
        {
            while (left <= right)
            {
                while (array[left] < pivot)
                {
                    left++;
                }
                while (array[right] > pivot)
                {
                    right--;
                }
                if (left <= right)
                {
                    swap(array, left, right);
                    left++;
                    right--;
                }
            }
            return left;
        }
        #endregion

        #region Comparator
        public class Player
        {
            public string Name { get; set; }
            public int Score { get; set; }
        }
        public int Comparator(Player firstPlayer, Player secondPlayer)
        {
            if (firstPlayer.Score == secondPlayer.Score)
            {
                return firstPlayer.Name.CompareTo(secondPlayer.Name);
            }
            return firstPlayer.Score - secondPlayer.Score;
        }
        #endregion

        #region Merge Sort
        public void MergeSort()
        {
            string arrayInput = Console.ReadLine();
            string[] arrayString = arrayInput.Split(' ');
            int[] array = Array.ConvertAll(arrayString, s => Int32.Parse(s));

            MergeSort(array, new int[array.Length], 0, array.Length - 1);
        }
        public void MergeSort(int[] array, int[] temp, int leftStart, int rightEnd)
        {
            int middle = (leftStart + rightEnd) / 2;
            MergeSort(array, temp, leftStart, middle);
            MergeSort(array, temp, middle + 1, rightEnd);
            MergeHalves(array, temp, leftStart, rightEnd);
        }

        public void MergeHalves(int[] array, int[] temp, int leftStart, int rightEnd)
        {
            int leftEnd = (rightEnd + leftStart) / 2;
            int rightStart = leftEnd + 1;
            int size = rightEnd - leftStart + 1;

            int left = leftStart;
            int right = rightStart;
            int index = leftStart;

            while ((left <= leftEnd) && (right <= rightEnd))
            {
                if (array[left] <= array[right])
                {
                    temp[index] = array[left];
                    left++;
                }
                else
                {
                    temp[index] = array[right];
                    right++;
                }
                index++;
            }

            Array.Copy(array, left, temp, index, leftEnd - left + 1);
            Array.Copy(array, right, temp, index, rightEnd - right + 1);
            Array.Copy(temp, leftStart, array, rightEnd, size);
        }
        #endregion

        #region Binary Search
        //public bool binarySearchRecursive(int[] array, int x, int left, int right)
        //{
        //    if (left > right)
        //    {
        //        return false;
        //    }
        //    int mid = left + ((right - left) / 2);
        //    if (array[mid] == x)
        //    {
        //        return true;
        //    }
        //    else if (x < array[mid])
        //    {
        //        return binarySearchRecursive(array, x, left, mid - 1);
        //    }
        //    else (x > array[mid]){
        //        return binarySearchRecursive(array, x, mid + 1, right);
        //    }
        //}
        //public bool binarySearchiterative(int[] array, int x)
        //{
        //    int left = 0;
        //    int right = array.Length - 1;
        //    while (left <= right)
        //    {
        //        int mid = left + ((right - left) / 2);
        //        if (array[mid] == x)
        //        {
        //            return true;
        //        }
        //        else if (x < array[mid])
        //        {
        //            right = mid - 1;
        //        }
        //        else (x > array[mid]){
        //            left = mid + 1;
        //        }
        //    }
        //    return false;
        //}
        //public bool binarySearchRecursive(int[] array, int x)
        //{
        //    //return binarySearchRecursive(array, x, 0, array.Length - 1);
        //}


        #endregion
        #endregion

    }


}
