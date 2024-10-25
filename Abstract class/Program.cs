// See https://aka.ms/new-console-template for more information
using static System.Runtime.InteropServices.JavaScript.JSType;

using Abstract_class;
using System;
using System.Threading;


// Клиентская часть приложения
class Client
{
    static void Main(string[] args)
    {
        try
        {
            ShapeArrayLinks shapeArray = new ShapeArrayLinks();

            while (true)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n-Добавить:");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1.1 Triangle");
                Console.WriteLine("1.2 Rectangle");
                Console.WriteLine("1.3 Circle");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-Удалить:");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("2.1 Triangle");
                Console.WriteLine("2.2 Rectangle");
                Console.WriteLine("2.3 Circle");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-Площадь фигур типа:");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("3.1 Triangle");
                Console.WriteLine("3.2 Rectangle");
                Console.WriteLine("3.3 Circle");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("4. Площадь всех фигур");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-Распечатать фигуры типа");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("5.1 Triangle");
                Console.WriteLine("5.2 Rectangle");
                Console.WriteLine("5.3 Circle");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("6.Распечатать все фигуры");
                Console.WriteLine("7.Записать в файл все фигуры");
                Console.WriteLine("8. Прочитать из файла все фигуры");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("0.Выход");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Выберите пунктик: ");
                Console.ResetColor();


                string words = Console.ReadLine();

                switch (words)
                {
                    case "1.1":
                            Console.Write("Введите длину катета legA:");
                            int legA= Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите длину катета legB:");
                            int legB= Convert.ToInt32(Console.ReadLine());
                            shapeArray.Add(new Triangle(legA, legB));
                         break;

                    case "1.2":
                        Console.Write("Введите Х левого верхнего угла x:");
                        int xLeftTop = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите Y левого верхнего угла у:");
                        int yLeftTop = Convert.ToInt32(Console.ReadLine());


                        Console.Write("Введите Х правого нижнего угла x:");
                        int xRightBottom = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите Y правого нижнего угла у:");
                        int yRightBottom = Convert.ToInt32(Console.ReadLine());

                        shapeArray.Add(new Rectangle(xLeftTop, yLeftTop, xRightBottom, yRightBottom));
                        break;

                    case "1.3":
                        Console.Write("Введите Х  центра x:");
                        int xCenter = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите Y центра у:");
                        int yCenter = Convert.ToInt32(Console.ReadLine());


                        Console.Write("Введите радиус :");
                        int radius = Convert.ToInt32(Console.ReadLine());

                        shapeArray.Add(new Circle(xCenter, yCenter, radius));
                        break;

                    case "2.1":
                        shapeArray.Remove("Triangle");
                     break;

                    case "2.2":
                        shapeArray.Remove("Rectangle");
                        break;

                    case "2.3":
                        shapeArray.Remove("Circle");
                        break;


                    case "3.1":
                        shapeArray.AreaByType("Triangle");
                        break;
                        break;
                    case "3.2":
                        shapeArray.AreaByType("Rectangle");
                        break;
                    case "3.3":
                        shapeArray.AreaByType("Circle");
                        break;

                    case "4":
                        shapeArray.AreaAll();
                        break;

              
                    case "5.1":
                        shapeArray.PrintByType("Triangle");
                        break;
                    case "5.2":
                        shapeArray.PrintByType("Rectangle");
                        break;
                    case "5.3":
                        shapeArray.PrintByType("Circle");
                        break;

                    case "6":
                        shapeArray.PrintAll();
                        break;


                    case "7"://Записать в файл
                        Console.Write("Записать файл: ");
                        shapeArray.SaveAll("../../../Data/shapes.txt");
                        Console.WriteLine("сохранено.");

                        break;

                    case "8"://Прочитать из файла

                        Console.Write("Прочитать файл: ");
                        shapeArray.LoadAll("../../../Data/shapes.txt");
                        Console.WriteLine("Загружено:");
                        break;


                    case "0"://Выход
                        return;

                    default:
                        Console.WriteLine("Ошибочка");
                        break;
                }

            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("По окончании try-блока.");
        }

    }
}