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
    static void Main()
    {
        try
        {

            Tamagotchi tamagotchi = new Tamagotchi();

            while (true)
            {
                Console.WriteLine("1.Запуск игры");
                Console.WriteLine("0.Выход");
                Console.Write("Выберите пунктик: ");

                string words = Console.ReadLine();

                switch (words)
                {
                    case "1":
                        // Подписка на события с помощью лямбда-выражений анонимной функции
                        tamagotchi.State += (message) =>
                        {
                            Console.WriteLine(message);
                        };
                        // Подписка на события с помощью делегата анонимной функции

                        //tamagotchi.State += delegate (string message)
                        //{
                        //    Console.WriteLine(message);
                        //};

                        // Запуск игры
                        tamagotchi.Play();
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

       
    
