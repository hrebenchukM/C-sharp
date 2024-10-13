// See https://aka.ms/new-console-template for more information
using static System.Runtime.InteropServices.JavaScript.JSType;

using CSharp.Classes;
using System;
using System.Threading;


// Клиентская часть приложения
class Client
{
    static void Main(string[] args)
    {
        try
        {

            ApplicationSettingsHelper settings = new ApplicationSettingsHelper();
            UserInterface user = new UserInterface(settings);
            user.Menu();

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