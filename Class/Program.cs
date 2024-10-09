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
            Date date = new Date();
        date.PrintDate();
        Console.WriteLine("Day of the Week: {0}", date.Day_Of_Week);


            Date date2 = new Date(10, 10, 2024); 
        date2.PrintDate();

        Console.WriteLine("Days diff:{0} ", date.DaysDiff(date2));


        date2.DaysAdd(3);
        date2.PrintDate();


        Date dateTest = date + 2;
        dateTest.PrintDate();

        int diff = date2 - date;
        Console.WriteLine("Diff in days: {0}", diff);



        Date incr= ++date;
        incr.PrintDate();


        Date decr = --date2;
        decr.PrintDate();

        Console.WriteLine("date > date2: {0}", date > date2);
        Console.WriteLine("date < date2: {0}", date < date2);
        Console.WriteLine("date == date2: {0}", date == date2);
        Console.WriteLine("date != date2: {0}", date != date2);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
