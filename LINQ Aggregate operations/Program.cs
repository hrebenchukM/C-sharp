using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace LINQ
{

    class Good
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {


      

            List<Good> goods1 = new List<Good>()
            {
            new Good()
            { Id = 1, Title = "Nokia 1100", Price = 450.99, Category = "Mobile" },
            new Good()
            { Id = 2, Title = "Iphone 4", Price = 5000, Category = "Mobile" },
            new Good()
            { Id = 3, Title = "Refregirator 5000", Price = 2555, Category = "Kitchen" },
            new Good()
            { Id = 4, Title = "Mixer", Price = 150, Category = "Kitchen" },
            new Good()
            { Id = 5, Title = "Magnitola", Price = 1499, Category = "Car" },
            new Good()
            { Id = 6, Title = "Samsung Galaxy", Price = 3100, Category = "Mobile" },
            new Good()
            { Id = 7, Title = "Auto Cleaner", Price = 2300, Category = "Car" },
            new Good()
            { Id = 8, Title = "Owen", Price = 700, Category = "Kitchen" },
            new Good()
            { Id = 9, Title = "Siemens Turbo", Price = 3199, Category = "Mobile" },
            new Good()
            { Id = 10, Title = "Lighter", Price = 150, Category = "Car" }
            };

            Console.WriteLine("1) Выбрать товары категории Mobile, цена которых превышает 1000 грн");
           

            // 1 способ через LINQ
            var result1 =  from good in goods1
                           where good.Category == "Mobile"
                           where good.Price > 1000
                           select good;

            foreach (var good in result1)
            {
                Console.WriteLine("{0} : {1}", good.Title, good.Price);
            }
            Console.WriteLine();

            // 2 способ через методы расширения LINQ
             result1 = goods1.Where(good => good.Category == "Mobile")
                .Where(good => good.Price > 1000);

            foreach (var good in result1)
            {
                Console.WriteLine("{0} : {1}", good.Title, good.Price);
            }
            Console.WriteLine();






            Console.WriteLine("2)  Вывести название и цену тех товаров, которые не относятся к категории Kitchen,\r\nцена которых превышает 1000 грн.  ");
            // 1 способ через LINQ
            var result2 = from good in goods1
                          where good.Category != "Kitchen"
                          where good.Price > 1000
                          select good;

            foreach (var good in result2)
            {
                Console.WriteLine("{0} : {1}", good.Title, good.Price);
            }
            Console.WriteLine();

            // 2 способ через методы расширения LINQ
          
            result2 = goods1.Where(good => good.Category != "Kitchen")
                .Where(good => good.Price > 1000);

            foreach (var good in result2)
            {
                Console.WriteLine("{0} : {1}", good.Title, good.Price);
            }
            Console.WriteLine();



            Console.WriteLine("3) Вычислить среднее значение всех цен товаров. ");
            // 1 способ через LINQ
            var result3 = (from good in goods1
                          select good.Price).Average();
            Console.WriteLine(result3);
            Console.WriteLine('\n');


            // 2 способ через методы расширения LINQ
          
            result3 = goods1.Average(good => good.Price);
            Console.WriteLine(result3);
            Console.WriteLine('\n');



            Console.WriteLine("4) Вывести список категорий без повторений.  ");
            // 1 способ через LINQ
            var result4 = (from good in goods1
                          select good.Category).Distinct();

            foreach (var category in result4)
            {
                Console.WriteLine(category);
            }
            Console.WriteLine();


            // 2 способ через методы расширения LINQ

            result4 = goods1.Select(good => good.Category).Distinct();

            foreach (var category in result4)
            {
                Console.WriteLine(category);
            }
            Console.WriteLine();


            Console.WriteLine("5) Вывести названия и категории товаров в алфавитном порядке, упорядоченных по\r\nназванию. ");

            // 1 способ через LINQ
            var result5 =  from good in goods1
                           orderby good.Title
                           select new
                           {
                               good.Title,
                               good.Category
                           };

            foreach (var good in result5)
            {
                Console.WriteLine("{0} : {1}", good.Title,good.Category);
            }
            Console.WriteLine();

            // 2 способ через методы расширения LINQ

            result5 = goods1.OrderBy(good => good.Title)
           .Select(good => new
           {
               good.Title,
               good.Category
           });

            foreach (var good in result5)
            {
                Console.WriteLine("{0} : {1}", good.Title, good.Category);
            }
            Console.WriteLine();

            Console.WriteLine("6) Посчитать суммарное количество товаров категорий Сar и Mobile. ");
            // 1 способ через LINQ
            // Для получения числа элементов в выборке используется метод Count()
            // Метод Count() в одной из версий также может принимать лямбда-выражение, 
            // которое устанавливает условие выборки. 

            var result6 = (from good in goods1 where good.Category == "Car" || good.Category == "Mobile" select good).Count();

            Console.WriteLine(result6);
            Console.WriteLine('\n');


            // 2 способ через методы расширения LINQ
            result6 = goods1.Count(good => good.Category == "Car" || good.Category == "Mobile");
            Console.WriteLine(result6);
            Console.WriteLine('\n');


            Console.WriteLine("7) Вывести список категорий и количество товаров каждой категории");
            //Результатом оператора group является выборка, которая состоит из групп.
            // Выражение group department by department.Country into g определяет переменную g, которая будет содержать группу.
            // С помощью этой переменной мы можем затем создать новый объект анонимного типа: 
            // select new { Name = g.Key, Count = g.Count() }
            // Теперь результат запроса LINQ будет представлять набор объектов таких анонимных типов, 
            // у которых два свойства Name и Count

            // 1 способ через LINQ


            var result7 = from good in goods1
                          group good by good.Category into g
                          select new { Name = g.Key, Count = g.Count() };

            foreach (var group in result7)
            {
                Console.WriteLine("{0} : {1}", group.Name, group.Count);
            }
            Console.WriteLine();
            // 2 способ через методы расширения LINQ
            //// Аналогичный запрос можно построить с помощью метода расширения GroupBy


            result7 = goods1.GroupBy(good => good.Category)
                       .Select(g => new { Name = g.Key, Count = g.Count() });

            foreach (var group in result7)
                Console.WriteLine("{0} : {1}", group.Name, group.Count);
            Console.WriteLine('\n');




        }
    }
}