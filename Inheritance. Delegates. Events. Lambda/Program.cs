using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace Abstract_class
{

    public delegate void StateHandler(string message);


    //1. Разработать абстрактный класс «автомобиль» (класс Car). Собрать в
    //нем все общие поля, свойства (например, скорость) и методы
    //(например, ехать).
    abstract class Car
    {
        public int Speed { get; set; } // скорость 
        public string Name { get; set; } 
        public int Position { get; set; } 
        public abstract void Show(); 
        public abstract void Drive();// метод ехать

    }

    // 2. Разработать классы автомобилей с конкретной реализацией
    //конструкторов, свойств и методов.В классы автомобилей добавить
    //необходимые события(например, финиш).

    // Класс издатель спортивного автомобиля 
    class SportCar : Car
    {

        public event StateHandler SportFinish;// событие финиш

        public SportCar(string name)
        {
            Name = name;
            Speed = new Random().Next(150, 250);
            Position = 0;
        }

        public override void Show()
        {
            Console.WriteLine("\nSportCar: {0}, Speed: {1} km/h\n", Name, Speed);
        }

        public override void Drive()
        {
            Speed = new Random().Next(150, 250);
            Position += Speed / 10;
            if (Position >= 100)
            {
                SportFinish?.Invoke(Name+ " (SportCar) достиг финиша с результатом: " + Position +"км.");
            }
        }
    }

    // Класс издатель грузового автомобиля
    class Truck : Car
    {
        public event StateHandler TruckFinish;// событие финиш

        public Truck(string name)
        {
            Name = name;
            Speed = new Random().Next(60, 120);
            Position = 0;
        }

        public override void Show()
        {
            Console.WriteLine("Truck: {0}, Speed: {1} km/h\n", Name, Speed);
        }

        public override void Drive()
        {
            Speed = new Random().Next(60, 120);
            Position += Speed / 10;
            if (Position >= 100)
            {
                TruckFinish?.Invoke(Name + " (Truck) достиг финиша с результатом: " + Position + "км.");
            }
        }
    }

    // Класс издатель автобуса
    class Bus : Car
    {
        public event StateHandler BusFinish;// событие финиш


        public Bus(string name)
        {
            Name = name;
            Speed = new Random().Next(60, 120);
            Position = 0;
        }

        public override void Show()
        {
            Console.WriteLine("Bus: {0}, Speed: {1} km/h\n", Name, Speed);
        }

        public override void Drive()
        {
            Speed = new Random().Next(60, 120);
            Position += Speed / 10;
            if (Position >= 100)
            {
                BusFinish?.Invoke(Name + " (Bus) достиг финиша с результатом: " + Position + "км.");
            }
        }
    }

    // Класс издатель легкового автомобиля
    class Passenger : Car
    {
        public event StateHandler PassengerFinish;// событие финиш

        public Passenger(string name)
        {
            Name = name;
            Speed = new Random().Next(80, 150);
            Position = 0;
        }

        public override void Show()
        {
            Console.WriteLine("Passenger Car: {0}, Speed: {1} km/h\n", Name, Speed);

        }

        public override void Drive()
        {
            Speed = new Random().Next(80, 150);
            Position += Speed / 10;
            if (Position >= 100)
            {
                PassengerFinish?.Invoke(Name + " (Passenger) достиг финиша с результатом: " + Position + "км.");
            }
        }
    }

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


    // 3. Класс игры должен производить запуск соревнований автомобилей,
    //выводить сообщения о текущем положении автомобилей, выводить
    //сообщение об автомобиле, победившем в гонках.
    // Класс игры
    class Game
    {
        // 4. Создать делегаты, обеспечивающие вызов методов из классов
        //автомобилей(например, выйти на старт, начать гонку).
        private List<Car> cars = new List<Car>();
        public event StateHandler Start; // Событие для старта 
        public event StateHandler Step; // Событие для шагов 
        public void Add(Car car)
        {
            cars.Add(car);
        }

        //  запуск соревнований автомобилей
        public void StartGame()
        {

            Start?.Invoke("Гонка началась!");
            bool end = false;

            while (!end)
            {
                foreach (var car in cars)
                {
                    // Уведомление об окончании гонки(прибытии какого -либо
                    ////автомобиля на финиш) реализовать с помощью событий( в Drive).
                    car.Drive();
                    Step?.Invoke("Шаг гонки завершен.");
                    Console.Clear();  // очистка экрана-если закоментить строку то выводятся изменения
                    // выводить сообщения о текущем положении автомобилей
                    Console.WriteLine("Позиция машин в гонке:");
                    foreach (var c in cars)
                    {
                        Console.WriteLine("{0}: {1}km/h :{2} км", c.Name,c.Speed, c.Position);
                    }

                 
                    foreach (var c in cars)
                    {
                    
                        Console.Write(new string('-', c.Position / 2));
                        Console.WriteLine("["+ c.Name+ "]->"); 
                   
                    }
                    //  5.Игра заканчивается, когда какой-то из автомобилей проехал
                    //определенное расстояние(старт в положении 0, финиш в положении
                    //100).
                    if (car.Position >= 100)
                    {
                        //выводить сообщение об автомобиле, победившем в гонках.
                        Console.WriteLine("Победитель: {0}!", car.Name);
                        end = true;
                        break;
                    }
                }

                Thread.Sleep(600);
            
            }
        }

        // Print всех автомобилей
        public void PrintAll()
        {
            foreach (Car car in cars)
            {
                car.Show();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           
            Game game = new Game();

            
            SportCar sportCar = new SportCar("BMW M4");
            Passenger passenger = new Passenger("BMW X5");
            Truck truck = new Truck("Iveco Stralis");
            Bus bus = new Bus("Богдан А201");



            ObserverEventStart obj1 = new ObserverEventStart(); // объект класса наблюдателя
            ObserverEventStep obj2 = new ObserverEventStep(); // объект класса наблюдателя
            ObserverEventFinish obj3= new ObserverEventFinish();  // объект  класса наблюдателя


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
        }
    }
}
