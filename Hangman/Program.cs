using System.Globalization;
using System.IO;

namespace Hangman
{
    internal class Program
    {

        public static int GetLinesCount(string filePath)
        {
            try
            {
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

        public static string ChooseRandomWord(string filePath, int lineCount)
        {
            Random random = new Random();
            int lineNumber = random.Next(1, lineCount);
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    for (int i = 1; i < lineNumber; i++)
                    {
                        sr.ReadLine();
                    }
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