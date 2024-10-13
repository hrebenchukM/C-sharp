using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSharp.Classes;
using System;
using System.Threading;


namespace CSharp.Classes
{
  

    class UserInterface
    {

        private ApplicationSettingsHelper settings;
        public UserInterface(ApplicationSettingsHelper settings)
        {
            this.settings = settings;
        }
        public void Menu()
        {
            while (true)
            {
               
                Console.WriteLine("1.Заголовок: {0}", settings.Title);
                Console.WriteLine("2.1)Ширина: {0}", settings.Width);
                Console.WriteLine("2.2)Высота : {0}", settings.Height);
                Console.WriteLine("3.Цвет фона: {0}", settings.BackgroundColor);
                Console.WriteLine("4.Цвет текста: {0}", settings.ForegroundColor);
                Console.WriteLine("5.Прочитать настройки из файла");
                Console.WriteLine("6.Записать новые настройки в файл");
                Console.WriteLine("0.Выход");
                Console.Write("Выберите пунктик: ");

                string words = Console.ReadLine();

                switch (words)
                {
                    case "1":
                        Console.Write("Введите заголовок: ");
                        settings.Title = Console.ReadLine();
                        Console.Title = settings.Title;
                        break;

                    case "2":
                        Console.Write("Введите ширину: ");
                        settings.Width = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите высоту: ");
                        settings.Height = Convert.ToInt32(Console.ReadLine());
                        Console.SetWindowSize(settings.Width, settings.Height);
                        break;

                    case "3":
                        Console.Write("Введите цвет фона: ");
                        string inputB = Console.ReadLine();

                      
                        if (inputB == "Blue")
                        {
                            settings.BackgroundColor = ConsoleColor.Blue;
                            Console.BackgroundColor = ConsoleColor.Blue;
                        }
                        else if (inputB == "Yellow")
                        {
                            settings.BackgroundColor = ConsoleColor.Yellow;
                            Console.BackgroundColor = ConsoleColor.Yellow;
                        }
                       
                        else
                        {
                            Console.WriteLine("Ошибочка");
                        }

                        break;

                    case "4":
                    
                        Console.Write("Введите цвет текста: ");
                        string inputF = Console.ReadLine();

                      
                        if (inputF == "Blue")
                        {
                            settings.ForegroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else if (inputF == "Yellow")
                        {
                            settings.ForegroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
   
                        else
                        {
                            Console.WriteLine("Ошибочка");
                        }
                        break;

                    case "5":
                        Console.Write("Прочитать файл: ");
                        settings.LoadSettings("../../../Data/settings.txt");
                        Console.WriteLine("Настройки загружены:");
                        break;

                    case "6":
                        Console.Write("Записать файл: ");
                        settings.SaveSettings("../../../Data/settings.txt");
                        Console.WriteLine("Настройки сохранены.");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Ошибочка");
                        break;
                }

            }
        }
    }

}