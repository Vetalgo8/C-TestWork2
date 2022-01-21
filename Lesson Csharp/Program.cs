using System;
using GroupDocs.Comparison;
using GroupDocs.Comparison.Options;
using GroupDocs.Comparison.Result;
using System.IO;
namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathSourse, pathTarget, pathResult;
            bool flag = false;
            do
            {
                Console.WriteLine("Enter the path to the source file: ");
                pathSourse = Console.ReadLine();
                if (File.Exists(pathSourse))
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("File does not exist. Try again.");
                }
            } while (!flag);
            flag = false;
            do
            {
                Console.WriteLine("Enter the path to the target file: ");
                pathTarget = Console.ReadLine();
                if (File.Exists(pathTarget))
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("File does not exist. Try again.");
                }
            } while (!flag);
            flag = false;
            do
            {
                Console.WriteLine("Enter the desired path of the result file: ");
                pathResult = Console.ReadLine();
                if (Directory.Exists(pathResult))
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Directory does not exist. Try again.");
                }
            } while (!flag);

            CompareOptions compareOptions = new();
            compareOptions.DetalisationLevel = DetalisationLevel.High;
            compareOptions.ShowDeletedContent = true;
            compareOptions.ShowInsertedContent = true;

            using (Comparer comparer = new(pathSourse))
            {
                comparer.Add(pathTarget);
                comparer.Compare(pathResult + "result.txt", compareOptions);
            }
            Console.WriteLine("Job done!");
        }
    }
}
 