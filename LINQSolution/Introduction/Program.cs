using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Introduction
{
    class Program
    {
        private static string path = @"C:\Windows";

        static void Main(string[] args)
        {
            ShowLargeFilesWithOutLinq(path);
            ShowLargeFilesWithLinq(path);
            Console.Read();
        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            var files = new DirectoryInfo(path)
                .GetFiles()
                .OrderByDescending(f => f.Length)
                .Take(5)
                .ToList();

            foreach (var file in files)
                Console.WriteLine(file.Name + ":" + file.Length);
        }

        private static void ShowLargeFilesWithOutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());
            for(var i = 0; i < 5; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine(file.Name + " : " + file.Length);
            }
            

        }
        public class FileInfoComparer : IComparer<FileInfo>
        {
            public int Compare(FileInfo x, FileInfo y)
            {
                return y.Length.CompareTo(x.Length);
            }
        }
       
    }
    public static class StringExtension
    {
        static public double ToDouble(this string data)
        {
            double result = double.Parse(data);
            return result;
        }
    }

}
