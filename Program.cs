using System;
using System.IO;

class FileComparer
{
    static void Main()
    {
        Console.WriteLine("File Comparer");

        Console.Write("Enter the path to the first file: ");
        string filePath1 = Console.ReadLine();

        Console.Write("Enter the path to the second file: ");
        string filePath2 = Console.ReadLine();

        try
        {
            if (!File.Exists(filePath1) || !File.Exists(filePath2))
            {
                Console.WriteLine("One or both of the specified files do not exist.");
                return;
            }

            string content1 = File.ReadAllText(filePath1);
            string content2 = File.ReadAllText(filePath2);

            if (content1 == content2)
            {
                Console.WriteLine("The files are identical.");
            }
            else
            {
                Console.WriteLine("The files are different.");
                CompareAndDisplayDifferences(content1, content2);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    static void CompareAndDisplayDifferences(string content1, string content2)
    {
        string[] lines1 = content1.Split('\n');
        string[] lines2 = content2.Split('\n');

        int maxLength = Math.Max(lines1.Length, lines2.Length);

        Console.WriteLine("\nDifferences:");

        for (int i = 0; i < maxLength; i++)
        {
            if (i < lines1.Length && i < lines2.Length && lines1[i] != lines2[i])
            {
                Console.WriteLine($"Line {i + 1}:");
                Console.WriteLine($"File 1: {lines1[i]}");
                Console.WriteLine($"File 2: {lines2[i]}");
                Console.WriteLine();
            }
            else if (i < lines1.Length && i >= lines2.Length)
            {
                Console.WriteLine($"Line {i + 1}:");
                Console.WriteLine($"File 1: {lines1[i]}");
                Console.WriteLine("File 2: (end of file)");
                Console.WriteLine();
            }
            else if (i >= lines1.Length && i < lines2.Length)
            {
                Console.WriteLine($"Line {i + 1}:");
                Console.WriteLine("File 1: (end of file)");
                Console.WriteLine($"File 2: {lines2[i]}");
                Console.WriteLine();
            }
        }
    }
}