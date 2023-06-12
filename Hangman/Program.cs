using System.Globalization;
using System.IO;

namespace Hangman
{
    internal class Program
    {
        // Get the count of lines in the file
        public static int GetLinesCount(string filePath)
        {
            try
            {
                // Create a StreamReader instance to read the file
                using (StreamReader sr = new StreamReader(filePath))
                {
                    return File.ReadLines(filePath).Count();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return -1;
        }

        // Choose a random word from the file
        public static string ChooseRandomWord(string filePath, int lineCount)
        {
            Random random = new Random();
            int lineNumber = random.Next(1, lineCount);
            try
            {
                // Create a StreamReader instance to read the file
                using (StreamReader sr = new StreamReader(filePath))
                {
                    // Read lines until the desired line number
                    for (int i = 1; i < lineNumber; i++)
                    {
                        sr.ReadLine();
                    }
                    // Read the desired line
                    string choosenWord = sr.ReadLine();

                    return choosenWord;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return null;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            string filePath = "your/path/to/file.txt";
            int lineCount = GetLinesCount(filePath);
            string word = ChooseRandomWord(filePath, lineCount);
            int attempts = 7;

            while (attempts > 0)
            {
                string userInput = Console.ReadLine();
                if (userInput == word)
                {
                    Console.WriteLine("You win");
                    break;
                }
                attempts--;
            }
        }
    }
}