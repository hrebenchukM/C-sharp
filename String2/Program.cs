
// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
namespace CSharp.String
{
    class MainClass
    {
        static void Main()
        {
            try
            {
            Console.WriteLine("Введите текст:");
            string words = Console.ReadLine();

                if (words.Contains("."))
                {
                

                    string res = "";
                    bool s = true; 
                    string last= ".!?";

                    foreach (char c in words)
                    {
                        if (s && (c >= 'a' && c <= 'z'))

                        {

                            res += char.ToUpper(c);
                            s = false; 
                        }
                        else if (last.Contains(c))
                        {
                            res += c;
                            s = true; 
                        }
                        else
                        {
                            res += c;
                        }
                    }
                    Console.WriteLine("Результат: " + res);
                }

                }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
















