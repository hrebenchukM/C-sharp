using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSharp.Classes;
using System;
using System.Threading;


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
                Validator(value, month, year);
                day = value;
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
                Validator(day, value, year);
                month = value;

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
                Validator(day, month, value);
                year = value;
            }
        }
        public string Day_Of_Week
        {
            get
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
        }
        private int nDaysInM(int year, int month)
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
            Validator(d, m, y);
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
            if (days < 0)
                throw new ArgumentOutOfRangeException("Days to add must be > 0.");

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

        public static int operator -(Date date1, Date date2)
        {
            return date1.DaysDiff(date2);
        }

        public static Date operator +(Date date, int days)
        {
            Date dateNew = new Date(date.Day, date.Month, date.Year);
            dateNew.DaysAdd(days);
            return dateNew;
        }


        public static Date operator ++(Date date)
        {
            Date dateNew = new Date(date.Day, date.Month, date.Year);
            dateNew.DaysAdd(1);
            return dateNew;
        }



        public static Date operator --(Date date)
        {
            Date dateNew = new Date(date.Day, date.Month, date.Year);
            dateNew.DaysAdd(-1);
            return dateNew;
        }
        // Операторы отношения перегружаются парами 1) < > 2)== != 3)>= <=

        public static bool operator >(Date date1, Date date2)
        {
            return date1.DaysDiff(date2) > 0;
        }

        public static bool operator <(Date date1, Date date2)
        {
            return date1.DaysDiff(date2) < 0;
        }

        public static bool operator ==(Date date1, Date date2)
        {
            return date1.Day == date2.Day && date1.Month == date2.Month && date1.Year == date2.Year;
        }

        public static bool operator !=(Date date1, Date date2)
        {
            return !(date1 == date2);
        }



        private void Validator(int d, int m, int y)
        {
            if (y < 0)
                throw new ArgumentOutOfRangeException("Year can't be < 0.");
            if (m < 1 || m > 12)
                throw new ArgumentOutOfRangeException("Month must be from 1 to 12.");
            if (d < 1 || d > nDaysInM(y, m))
                throw new ArgumentOutOfRangeException("Day is not true for this month.");
        }


    }

}