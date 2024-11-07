// See https://aka.ms/new-console-template for more information
using static System.Runtime.InteropServices.JavaScript.JSType;
using Delegates_Events;
using System;
using System.Security.Principal;
using System.Net.NetworkInformation;

//Издатель(CreditCard) определяет события и вызывает их.
//Подписчик (Show_Message, Color_Message) подписывается на эти события и выполняет действия, когда события срабатывают.



// Клиентская часть приложения
class Client

{   // (ПОДПИСЧИК)-не знают о внутреннем состоянии издателя, они просто получают уведомления и выполняют нужные действия (вывод сообщений и т.д.)
    // Обработчик события: просто выводит сообщение 
    private static void Show_Message(string message)
    {
        Console.WriteLine(message);
    }

    // (ПОДПИСЧИК) 
    // Обработчик события: выводит сообщение с зелёным цветом
    private static void Color_Message(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    static void Main(string[] args)
    {
        try
        {
            CreditCard account = new CreditCard("4577 2344 2344 4345", "Name Surname", "04/25", 2004, 15000, 2000);
        
            while (true)
            {
                Console.WriteLine("1.Пополнение счёта");
                Console.WriteLine("2.Расход денег со счёта");
                Console.WriteLine("3.Смена PIN");
                Console.WriteLine("0.Выход");
                Console.Write("Выберите пунктик: ");

                string words = Console.ReadLine();

                switch (words)
                {
                    case "1"://1.Пополнение счёта
                        Console.Write("Введите сумму пополнение счёта: ");
                        int sumP = int.Parse(Console.ReadLine());

                        // Подписываем обработчики на события
                        account.Add += Show_Message; //Подписка метода Show_Message на событие  account.Add 
                        account.AchievingSum += Color_Message;  // Подписка метода Color_Message на событие   account.AchievingSum 



                        account.Put(sumP);// Вызов метода 
                        account.AchievingSum -= Color_Message;// Отписка метода Color_Message от события AchievingSum
                        account.Add -= Show_Message;// Отписка метода Show_Message от события Add
                        break;

                    case "2"://Расход денег со счёта
                        Console.Write("Введите сумму снятия со счёта: ");
                        int sumD = int.Parse(Console.ReadLine());
                        account.Del += Show_Message;  
                        account.StartCredit += Color_Message; 
                        account.Withdraw(sumD);
                        account.StartCredit -= Color_Message;
                        account.Del -= Show_Message;
                        break;

                    case "3"://Смена PIN
                        Console.Write("Введите новый PIN: ");
                        int pin = int.Parse(Console.ReadLine());
                        account.NewPin += Show_Message;  
                        account.ChangePinCode(pin);
                        account.NewPin -= Show_Message;
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