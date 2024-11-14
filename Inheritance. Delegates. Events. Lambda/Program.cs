using Inheritance._Delegates._Events._Lambda;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;


// Клиентская часть приложения
class Client
{

    // Классы-наблюдатели

    // Класс наблюдателя, который реагирует на событие финиша
    class ObserverEventFinish
    {
        public void See(string message)
        {
            Console.WriteLine("ObserverEventFinish: Событие обработано! " + message);
        }
    }
    class ObserverEventStart
    {
        public void See(string message)
        {
            Console.WriteLine("ObserverEventStart: Событие обработано! " + message);
        }
    }

    class ObserverEventStep
    {
        public void See(string message)
        {
            Console.WriteLine("ObserverEventStep: Событие обработано! " + message);
        }
    }



    static void Main(string[] args)
    {
        try
        {


            while (true)
            {
                Console.WriteLine("1.Запуск игры");
                Console.WriteLine("0.Выход");
                Console.Write("Выберите пунктик: ");

                string words = Console.ReadLine();

                switch (words)
                {
                    case "1":

                        Game game = new Game();


                        SportCar sportCar = new SportCar("BMW M4");
                        Passenger passenger = new Passenger("BMW X5");
                        Truck truck = new Truck("Iveco Stralis");
                        Bus bus = new Bus("Богдан А201");



                        ObserverEventStart obj1 = new ObserverEventStart(); // объект класса наблюдателя
                        ObserverEventStep obj2 = new ObserverEventStep(); // объект класса наблюдателя
                        ObserverEventFinish obj3 = new ObserverEventFinish();  // объект  класса наблюдателя


                        // добавление обработчиков к событию
                        sportCar.SportFinish += obj3.See;
                        truck.TruckFinish += obj3.See;
                        bus.BusFinish += obj3.See;
                        passenger.PassengerFinish += obj3.See;
                        game.Start += obj1.See;
                        game.Step += obj2.See;

                        game.Add(sportCar);
                        game.Add(truck);
                        game.Add(bus);
                        game.Add(passenger);

                        game.PrintAll();

                        game.StartGame();
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


