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
        
        public static void DisplayCharacters(char[] chars)
        {
            Console.Clear();
            for(int i = 0; i < chars.Length; i++)
            {
                Console.Write("_ ");
            }
            Console.Write($"({chars.Length})\n");
        }

        public static void DisplayEndScreen(string word, bool isWin)
        {
            Console.Clear();
            if(isWin)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You win");
                Console.WriteLine($"Guessed word is {word}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You lose");
                Console.WriteLine($"Guessed word is {word}");
            }
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            string filePath = "your/path/to/file.txt";
            int lineCount = GetLinesCount(filePath);
            string word = ChooseRandomWord(filePath, lineCount);
            int attempts = 7;
            char[] chars= word.ToCharArray();

            while (attempts > 0)
            {
                DisplayCharacters(chars);
                string userInput = Console.ReadLine();
                if (userInput == word)
                {
                    DisplayEndScreen(word, true);
                    break;
                }
                attempts--;
            }
            if (attempts == 0)
            {
                DisplayEndScreen(word, false);
            }
        }
    }
}