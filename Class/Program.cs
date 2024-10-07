using CSharp.Classes;
using System;

namespace CSharp.Classes
{
    class Date
    {
        //поля day, month, year;
        private int day = 8;
        private int month = 10;
        private int year = 2024;


        // свойства Day, Month, Year, Day_Of_Week;
        public int Day
        {
            get
            {
                return day;
            }
            set
            {
                if (year < 0 || month < 1 || month > 12)
                {
                    day = 1;
                }

                else if (value > nDaysInM(month, year))
                {
                    day = nDaysInM(month, year);
                }
                else
                {
                    day = value;
                }

            }
        }

        public int Month
        {
            get
            {
                return month;
            }
            set
            {
                if (value < 1 || value > 12)
                {
                    month = 1; 
                }

                else
                {
                    month = value;
                }

                if (day > nDaysInM(month, year))
                {
                    day = nDaysInM(month, year);
                }

            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        public  int nDaysInM(int year, int month)
        {
            if (month < 1 || month > 12)
                return 0; 

          

            if (month == 2)
                return leapYear(year) ? 29 : 28;

            return (month == 4 || month == 6 || month == 9 || month == 11) ? 30 : 31;
        }

        //конструктор по умолчанию
        public Date() { }

        //конструктор с параметрами
        public Date(int d, int m, int y)
        {
            year = y;
            month = m;
            day = d; 
        }




        //метод вывода даты на экран
        public void PrintDate()
        {
            Console.WriteLine("{0}/{1}/{2}", Day, Month, Year);
        }



        // Метод для проверки високосного года
        private bool leapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }
        public string Day_Of_Week()
        {
            int m = Month;
            int y = Year;

            if (m < 3)
            {
                m += 12;
                y--;
            }

            int d = Day;

            // Zeller's  formula
            int K = y % 100; // год в столетии
            int J = y / 100; // столетие

            // Формула дня недели
            int f = d + (13 * (m + 1)) / 5 + K + (K / 4) + (J / 4) - (2 * J);
            int dayOfWeek = f % 7;

            //  7 может дать отрицательные значения 
            if (dayOfWeek < 0)
                dayOfWeek += 7;

            switch (dayOfWeek)
            {
                case 0: return "Saturday";
                case 1: return "Sunday";
                case 2: return "Monday";
                case 3: return "Tuesday";
                case 4: return "Wednesday";
                case 5: return "Thursday";
                case 6: return "Friday";
                default: return "";
            }
        }
        public int DaysDiff(Date other)
        {
            int tDays = 0;
            int yearDiff = other.Year - Year;
            tDays += yearDiff * 365 + (yearDiff / 4) - (yearDiff / 100) + (yearDiff / 400);

            if (other.Month > Month)
            {
                for (int m = Month; m < other.Month; m++)
                {
                    tDays += nDaysInM(Year, m);
                }
            }
            else if (other.Month < Month)
            {
                for (int m = other.Month; m < Month; m++)
                {
                    tDays -= nDaysInM(other.Year, m);
                }
            }

            tDays += other.Day - Day;

            return tDays;
        }
        public void DaysAdd(int days)
        {
            day += days;

            while (day > nDaysInM(year, month))
            {
                day -= nDaysInM(year, month);
                month++;

                if (month > 12)
                {
                    month = 1;
                    year++;
                }
            }

            while (day < 1)
            {
                month--;

                if (month < 1)
                {
                    month = 12;
                    year--;
                }

                day += nDaysInM(year, month);
            }
        }



    }

}

// Клиентская часть приложения
class Client
{
    static void Main(string[] args)
    {
       
        Date date = new Date();
        date.PrintDate();
        Console.WriteLine("Day of the Week:{0} ", date.Day_Of_Week());

      
        Date date2 = new Date(10, 12, 2024); 
        date2.PrintDate();

        Console.WriteLine("Days differencs:{0} ", date.DaysDiff(date2));


        date2.DaysAdd(30);
        date2.PrintDate();
    }
}
