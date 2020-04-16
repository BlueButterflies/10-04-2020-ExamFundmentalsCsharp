using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> mirror = new List<string>();

            string input = Console.ReadLine();

            Regex regex = new Regex(@"([@|#])(?<wordOne>[A-Za-z]{3,})\1{2}(?<wordTwo>[A-Za-z]{3,})\1");
            MatchCollection match = regex.Matches(input);

            int counter = 0;

            foreach (Match matches in match)
            {
                if (matches.Success)
                {
                    string wordOne = matches.Groups["wordOne"].Value;
                    string wordTwo = matches.Groups["wordTwo"].Value;

                    char[] wordTwoToChar = wordTwo.ToCharArray();
                    Array.Reverse(wordTwoToChar);

                    if (wordOne == new string(wordTwoToChar))
                    {
                        string result = $"{wordOne} <=> {wordTwo}";

                        mirror.Add(result);
                    }
                    counter++;
                }
            }
            if (counter > 0)
            {
                Console.WriteLine($"{counter} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            if (mirror.Count > 0)
            {
                Console.WriteLine("The mirror words are:");

                Console.WriteLine(string.Join(", ", mirror));


            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }
    }
}


