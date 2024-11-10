using System;
using System.Threading;
// Иногда основанием для существования метода служит то обстоятельство, 
// что он должен быть вызван только один раз посредством делегата. 
// В подобных случаях можно воспользоваться анонимной функцией, чтобы не создавать отдельный метод.
// Анонимная функция, по существу, представляет собой безымянный кодовый блок, 
// передаваемый конструктору делегата. 
// Преимущество анонимной функции состоит, в частности, в ее простоте. 
// Благодаря ей отпадает необходимость объявлять отдельный метод, 
// единственное назначение которого состоит в том, что он передается делегату.

using Anonymous_functions;




// Клиентская часть приложения
class Client
{

    // Классы-наблюдатели

    class ObserverEventHealth
    {
        public void See(string message)
        {
            Console.WriteLine("ObserverEventHealth. Событие обработано! " + message);
        }
    }

    class ObserverEventHunger
    {
        public void See(string message)
        {
            Console.WriteLine("ObserverEventHunger. Событие обработано! " + message);
        }
    }

    class ObserverEventHappiness
    {
        public void See(string message)
        {
            Console.WriteLine("ObserverEventHappiness. Событие обработано! " + message);
        }
    }



    class ObserverEventSleep
    {
        public void See(string message)
        {
            Console.WriteLine("ObserverEventSleep. Событие обработано! " + message);
        }
    }



    class ObserverEventIllness
    {
        public void See(string message)
        {
            Console.WriteLine("ObserverEventIllness. Событие обработано! " + message);
        }
    }
    static void Main()
    {
        try
        {

            Tamagotchi tamagotchi = new Tamagotchi();
            bool gameRunning = true;
            while (gameRunning)
            {
                Console.WriteLine("1.Запуск игры");
                Console.WriteLine("0.Выход");
                Console.Write("Выберите пунктик: ");

                string words = Console.ReadLine();

                switch (words)
                {
                    case "1":


                        ObserverEventHealth obj1 = new ObserverEventHealth(); // объект класса наблюдателя
                        ObserverEventHunger obj2 = new ObserverEventHunger(); // объект класса наблюдателя
                        ObserverEventHappiness obj3 = new ObserverEventHappiness(); // объект класса наблюдателя
                        ObserverEventSleep obj4 = new ObserverEventSleep(); // объект класса наблюдателя
                        ObserverEventIllness obj5 = new ObserverEventIllness(); // объект класса наблюдателя

                        // добавление обработчиков к событию
                        tamagotchi.HealthState += obj1.See;
                        tamagotchi.HungerState += obj2.See;
                        tamagotchi.HappinessState += obj3.See;
                        tamagotchi.SleepState += obj4.See;
                        tamagotchi.IllnessState += obj5.See;



                      

                        //// 2 вариант Подписка на события с помощью лямбда-выражений анонимной функции
                        //tamagotchi.HealthState += message => Console.WriteLine(message);
                        //tamagotchi.HungerState += message => Console.WriteLine(message);
                        //tamagotchi.HappinessState += message => Console.WriteLine(message);
                        //tamagotchi.SleepState += message => Console.WriteLine(message);
                        //tamagotchi.IllnessState += message => Console.WriteLine(message);


                        ////3 вариант Подписка на события с использованием делегатов анонимных функций
                        //tamagotchi.HealthState += new StateHandler((message) =>
                        //{
                        //    Console.WriteLine(message);
                        //});

                        //tamagotchi.HungerState += new StateHandler((message) =>
                        //{
                        //    Console.WriteLine(message);
                        //});

                        //tamagotchi.HappinessState += new StateHandler((message) =>
                        //{
                        //    Console.WriteLine(message);
                        //});

                        //tamagotchi.SleepState += new StateHandler((message) =>
                        //{
                        //    Console.WriteLine(message);
                        //});

                        //tamagotchi.IllnessState += new StateHandler((message) =>
                        //{
                        //    Console.WriteLine(message);
                        //});



                        // Запуск игры
                        tamagotchi.Play();
                        gameRunning=false;  
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

       
    
