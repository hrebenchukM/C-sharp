// See https://aka.ms/new-console-template for more information
using static System.Runtime.InteropServices.JavaScript.JSType;

using StandartInterface;
using System.Collections;
using System;
using System.Threading;


// Клиентская часть приложения
class Client
{
    static void Main(string[] args)
    {
        try
        {
            Academy_Group group = new Academy_Group();

            while (true)
            {


                Console.WriteLine("1.Добавить студента");
                Console.WriteLine("2.Удалить студента");
                Console.WriteLine("3.Редактировать студента");
                Console.WriteLine("4. Поиск студента");
                Console.WriteLine("5.Распечатать группу");
                Console.WriteLine("6.Записать в файл");
                Console.WriteLine("7. Прочитать из файла");
                Console.WriteLine("8. Отсортировать студентов по среднему балу/номеру группы");
                Console.WriteLine("0.Выход");
                Console.Write("Выберите пунктик: ");

                string words = Console.ReadLine();

                switch (words)
                {
                    case "1"://1.Добавить студента
                        Console.Write("Введите имя: ");
                        string nameA = Console.ReadLine();
                        Console.Write("Введите фамилию: ");
                        string surnameA = Console.ReadLine();
                        Console.Write("Введите возраст: ");
                        int ageA = int.Parse(Console.ReadLine());
                        Console.Write("Введите телефон: ");
                        string phoneA = Console.ReadLine();
                        Console.Write("Введите средний бал: ");
                        double averageA = double.Parse(Console.ReadLine());
                        Console.Write("введите номер группы: ");
                        string number_of_groupA = Console.ReadLine();
                        group.Add(new Student(nameA, surnameA, ageA, phoneA, averageA, number_of_groupA));
                        break;

                    case "2"://Удалить студента
                        Console.Write("Введите фамилию: ");
                        string surnameR = Console.ReadLine();
                        group.Remove(surnameR);
                        break;

                    case "3"://Редактировать студента

                        Console.Write("Введите фамилию студента которого будем редактировать: ");
                        string surnameE = Console.ReadLine();

                        Console.Write("Введите новое имя: ");
                        string nameE = Console.ReadLine();
                        Console.Write("Введите новую фамилию: ");
                        string surnameE2 = Console.ReadLine();
                        Console.Write("Введите новый возраст: ");
                        int ageE = int.Parse(Console.ReadLine());
                        Console.Write("Введите новый телефон: ");
                        string phoneE = Console.ReadLine();
                        Console.Write("Введите новый средний бал: ");
                        double averageE = double.Parse(Console.ReadLine());
                        Console.Write("введите новый номер группы: ");
                        string number_of_groupE = Console.ReadLine();
                        group.Edit(surnameE, new Student(nameE, surnameE2, ageE, phoneE, averageE, number_of_groupE));
                        break;

                    case "4"://Поиск студента
                        Console.Write("Введите фамилию: ");
                        string surnameS = Console.ReadLine();
                        group.Search(surnameS);
                        break;

                    case "5"://Распечатать группу
                        group.Print();
                        break;


                    case "6"://Записать в файл
                        Console.Write("Записать файл: ");
                        group.Save("../../../Data/group.txt");
                        Console.WriteLine("сохранено.");

                        break;

                    case "7"://Прочитать из файла

                        Console.Write("Прочитать файл: ");
                        group.Load("../../../Data/group.txt");
                        Console.WriteLine("Загружено:");
                        break;
                    case "8"://Отсортировать студентов по среднему балу/номеру группы
                        Console.Write("Выберите пунктик критерия: ");
                        Console.Write("\n1.Отсортировать студентов по среднему балу:");
                        Console.Write("\n2.Отсортировать студентов по названию группы:\n");
                        string choice = Console.ReadLine();
                        IComparer icomparer = null;
                        if (choice == "1")
                        {
                            icomparer = new Student.SortByAverage();
                        }
                        if (choice == "2")
                        {
                            icomparer = new Student.SortByNumber_of_group();
                        }
                        group.Sort(icomparer); 
                        Console.WriteLine("Сортировка завершена.");
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