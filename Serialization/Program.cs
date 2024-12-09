// See https://aka.ms/new-console-template for more information
using static System.Runtime.InteropServices.JavaScript.JSType;

using Serialization;
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
                Console.WriteLine("8. Сериализация Xml");
                Console.WriteLine("9. Десериализация Xml");
                Console.WriteLine("10. Сериализация Json");
                Console.WriteLine("11. Десериализация Json");
                Console.WriteLine("12. Сериализация Soap");
                Console.WriteLine("13. Десериализация Soap");
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
                        Console.Write("Введите имя: ");
                        string nameE = Console.ReadLine();
                        Console.Write("Введите фамилию: ");
                        string surnameE = Console.ReadLine();
                        Console.Write("Введите возраст: ");
                        int ageE = int.Parse(Console.ReadLine());
                        Console.Write("Введите телефон: ");
                        string phoneE = Console.ReadLine();
                        Console.Write("Введите средний бал: ");
                        double averageE = double.Parse(Console.ReadLine());
                        Console.Write("введите номер группы: ");
                        string number_of_groupE = Console.ReadLine();
                        group.Edit(surnameE, new Student(nameE, surnameE, ageE, phoneE, averageE, number_of_groupE));
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

                    case "8":

                        Console.Write("Сериализация Xml: ");
                        group.SerializeToXml("data.xml");
                        Console.WriteLine("Конец сериализации Xml:");
                        break;
                    case "9":
                        Console.Write("Десериализация Xml: ");
                        group.DeserializeFromXml("data.xml");
                        Console.WriteLine("Конец десериализации Xml:");
                        break;

                    case "10":

                        Console.Write("Сериализация Json: ");
                        group.SerializeToJson("data.json");
                        Console.WriteLine("Конец сериализации Json:");
                        break;
                    case "11":
                        Console.Write("Десериализация Json: ");
                        group.DeserializeFromJson("data.json");
                        Console.WriteLine("Конец десериализации Json:");
                        break;

                    case "12":

                        Console.Write("Сериализация Soap: ");
                        group.SerializeToSoap("list.xml");
                        Console.WriteLine("Конец сериализации Soap:");
                        break;
                    case "13":
                        Console.Write("Десериализация Soap: ");
                        group.DeserializeFromSoap("list.xml");
                        Console.WriteLine("Конец десериализации Soap:");
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