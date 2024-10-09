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


            Console.WriteLine("Введите дату1 типо : 08 10 2024");
            string words = Console.ReadLine();
            string[] arrayOfString = words.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            if (arrayOfString.Length != 3)
            {
                throw new ArgumentException("Incorrect data");
            }


            Date date1 = new Date(Convert.ToInt32(arrayOfString[0]),
                              Convert.ToInt32(arrayOfString[1]),
                              Convert.ToInt32(arrayOfString[2]));


            date1.PrintDate();
            Console.WriteLine("Day of the Week: {0}", date1.Day_Of_Week);




            Console.WriteLine("Введите дату2 типо : 08 10 2024");
            string words2 = Console.ReadLine();
            string[] arrayOfString2 = words2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (arrayOfString2.Length != 3)
            {
                throw new ArgumentException("Incorrect data");
            }




            Date date222 = new Date(Convert.ToInt32(arrayOfString2[0]),
                              Convert.ToInt32(arrayOfString2[1]),
                              Convert.ToInt32(arrayOfString2[2]));


            date222.PrintDate();
            Console.WriteLine("Day of the Week: {0}", date222.Day_Of_Week);




            date222.DaysAdd(9);
            date222.PrintDate();















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



            Date incr = ++date;
            incr.PrintDate();


            Date decr = --date2;
            decr.PrintDate();

            Console.WriteLine("date > date2: {0}", date > date2);
            Console.WriteLine("date < date2: {0}", date < date2);
            Console.WriteLine("date == date2: {0}", date == date2);
            Console.WriteLine("date != date2: {0}", date != date2);

           
            //Date date20 = new Date(10, 22, 2024);
            //date20.PrintDate();

            Date date22 = new Date(10, 22, 2024);
            date22.DaysAdd(-5);
            date22.PrintDate();



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