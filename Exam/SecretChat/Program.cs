using System;
using System.Linq;
using System.Text;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string commands = Console.ReadLine();

            while (commands != "Reveal")
            {
                string[] infoCommand = commands.Split(":|:");

                switch (infoCommand[0])
                {
                    case "InsertSpace":
                        input = input.Insert(int.Parse(infoCommand[1]), " ");

                        Console.WriteLine(input);
                        break;
                    case "Reverse":
                        string substring = infoCommand[1];

                        if (input.Contains(substring))
                        {
                            string result = input.Substring(input.IndexOf(substring), substring.Length);
                            input = input.Remove(input.IndexOf(substring), substring.Length);
                            char[] chars = result.ToArray();
                            Array.Reverse(chars);

                            input = input + new string(chars);
                            Console.WriteLine(input);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "ChangeAll":

                        input = input.Replace(infoCommand[1], infoCommand[2]);

                        Console.WriteLine(input);
                        break;
                }
                commands = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {input}");
        }
    }
}
