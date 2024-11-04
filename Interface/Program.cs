// See https://aka.ms/new-console-template for more information
using static System.Runtime.InteropServices.JavaScript.JSType;

using Interface;
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
            ArrayList workers = new ArrayList
            {
                new Worker { Name = "Анатолий" },
                new Worker { Name = "Леонид" },
                new Worker { Name = "Евгений" },
                new Worker { Name = "Игорь" }
            };
            TeamLeader teamLeader = new TeamLeader { Name = "Машуля" };
            Team team = new Team(workers, teamLeader);

            House house = new House();


            while (true)
            {


                Console.WriteLine("\n1.Начать строительство дома");
                Console.WriteLine("2.Показать текущее строительство дома ");
                Console.WriteLine("0.Выход");
                Console.Write("Выберите пунктик: ");

                string words = Console.ReadLine();

                switch (words)
                {
                    case "1":
                        team.BuildHouse(house);
                        break;

                    case "2":
                        house.PrintInfo();
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