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

                //Console.Title = "The title has changed!";
                //string s = "Это простая строка";
                //Console.WriteLine(s);
                //Console.BackgroundColor = ConsoleColor.Blue;
                //Console.ForegroundColor = ConsoleColor.Yellow;
                //Console.SetWindowSize(50, 30);
                //string result = string.Format("Длина строки: {0}", s.Length);
                //Console.WriteLine(result);

                //string t = s.Substring(4, 7); // возвращает подстроку из 7 символов, начиная с 4 позиции
                //Console.WriteLine(t);
                //Console.WriteLine(s[5]);

                //s = s.Replace("о", "О");
                //Console.WriteLine(s);

                //s = s.Remove(4, 8); // удаляет 8 символов, начиная с позиции 4
                //Console.WriteLine(s);

                ////str[5] = '!'; // недопустимо: доступ только на чтение
                //char[] ar = { 'с', 'т', 'р', 'о', 'к', 'а' };

                //string s2 = new string(ar);
                //Console.WriteLine(s2);
                //Console.WriteLine("Длина строки: " + s2.Length);

                //string[] arstr = { " Platform ", " .NET ", " Framework " };
                //for (int i = 0; i < arstr.Length; i++)
                //{
                //    Console.WriteLine(arstr[i]);
                //}
                //arstr[0] = " Common ";
                //arstr[1] = " Language ";
                //arstr[2] = " Runtime ";
                //for (int i = 0; i < arstr.Length; i++)
                //{
                //    Console.WriteLine(arstr[i]);
                //}

                //Console.WriteLine("Введите первую строку: ");
                //string s3 = Console.ReadLine();
                //Console.WriteLine("Введите вторую строку: ");
                //string s4 = Console.ReadLine();
                //if (s3.CompareTo(s4) > 0)
                //    Console.WriteLine(s3 + " больше, чем " + s4);
                //else if (s3.CompareTo(s4) < 0)
                //    Console.WriteLine(s4 + " больше, чем " + s3);
                //else
                //    Console.WriteLine("Строки равны");

                //string text = "To be or not be";
                //Console.WriteLine(" Индекс первого вхождения слова \"be\" = {0} ", text.IndexOf("be"));
                //Console.WriteLine(" Индекс последнего вхождения слова \"be\" = {0} ", text.LastIndexOf("be"));

                //Console.WriteLine();
                //string words = "Эта    строка  будет  разбита  на  массив  строк";
                //string[] arrayOfString = words.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //foreach (string s5 in arrayOfString)
                //{
                //    Console.WriteLine(s5);
                //}
                //string res = string.Join(" ", arrayOfString);
                //Console.WriteLine(res);

                //string str1 = "Я ";
                //string str2 = "учу ";
                //string str3 = "C#";
                //string str4 = str1 + str2 + str3;

                //Console.WriteLine("{0} + {1} + {2} = {3}", str1, str2, str3, str4);

                //str4 = str4.Replace("учу", "изучаю");
                //Console.WriteLine(str4);

                //str4 = str4.Insert(2, "упорно ").ToUpper();
                //Console.WriteLine(str4);

                //if (str4.Contains("упорно"))
                //    Console.WriteLine("Учу таки упорно :)");
                //else
                //    Console.WriteLine("Учу как могу");





                Console.WriteLine("Введите арифметическое выражение типо x + y - z:");
                string words = Console.ReadLine();
                string[] arrayOfString = words.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);



                if (arrayOfString.Contains("+") || arrayOfString.Contains("-"))
                {

                    int res = Convert.ToInt32(arrayOfString[0]);


   
                    string cur= "";

                    foreach (string s5 in arrayOfString)
                    {
                        if (s5 == "+" || s5 == "-")
                        {
                            cur = s5;
                        }
                        else
                        {
                            int next = Convert.ToInt32(s5);
                            if (cur == "+")
                            {
                                res += next;
                            }
                            else if (cur == "-")
                            {
                                res -= next;
                            }
                        }

                    }

                    Console.WriteLine("Результат: ");
                    Console.WriteLine(res);


                }

            }


           catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

    }
}
















