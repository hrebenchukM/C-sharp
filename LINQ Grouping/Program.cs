using System;
using System.Collections.Generic;
using System.Linq;


namespace LINQ
{

    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int DepId { get; set; }
    }
    class Department
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }




    class Program
    {
        static void Main(string[] args)
        {


            // Создадим набор пользователей и выберем из них тех...
            List<Department> departments = new List<Department>()
            {
                new Department(){ Id = 1, Country = "Ukraine", City = "Lviv" },
                new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
                new Department(){ Id = 3, Country = "France", City = "Paris" },
                new Department(){ Id = 4, Country = "Ukraine", City = "Odesa" }
            };

            List<Employee> employees = new List<Employee>()
            {
            new Employee()
            { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
            new Employee()
            { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
            new Employee()
            { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
            new Employee()
            { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
            new Employee()
            { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
            new Employee()
            { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
            new Employee()
            { Id = 7, FirstName = "Nikita", LastName = " Krotov ", Age = 27, DepId = 4 }
            };


            Console.WriteLine("1) Упорядочить имена и фамилии сотрудников по алфавиту, которые\r\nпроживают в Украине. Выполнить запрос немедленно. ");
            // Принцип Lazy Load заключается в том, что загрузка данных в память не происходит до момента, 
            // пока они действительно не понадобятся.
            // Lazy Load позволяет нам многократно использовать один и тот же запрос к одному источнику, 
            // с гарантией получения самых актуальных данных.

            // LINQ может быть выполнен немедленно. Для этого необходимо заключить весь запрос в скобки, и 
            // вызвать один из методов преобразования ToList (), ToArray(), ToDictionary().

            // Для сортировки набора данных по возрастанию используется оператор orderby
            // Вместо оператора orderby можно использовать метод расширения OrderBy

            //// 1 способ через LINQ
            var result1 = (from employee in employees
                          join department in departments on employee.DepId equals department.Id
                          where department.Country == "Ukraine"
                          orderby employee.FirstName, employee.LastName
                          select new { employee.FirstName, employee.LastName }).ToList();

            foreach (var employee in result1)
            {
                Console.WriteLine("{0} : {1}", employee.FirstName, employee.LastName);
            }
            Console.WriteLine();

        //// 2 способ через методы расширения LINQ
        //ThenBy: задает дополнительные критерии для упорядочивания элементов возрастанию

        result1 = employees.Join(departments, employee => employee.DepId, department => department.Id, (employee, department) => new
            {
                employee.FirstName,
                employee.LastName,
                department.Country
            })
            .Where(x => x.Country == "Ukraine")
            .OrderBy(x => x.FirstName)
             .ThenBy(x => x.LastName)
            .Select(x => new
            {
                x.FirstName,
                x.LastName,
            }).ToList();


            foreach (var employee in result1)
            {
                Console.WriteLine("{0} : {1}", employee.FirstName, employee.LastName);
            }
            Console.WriteLine();






            Console.WriteLine("2) Отсортировать сотрудников по возрастам по убыванию. Вывести Id,\r\nFirstName, LastName, Age. Выполнить запрос немедленно ");
            //// 1 способ через LINQ
            var result2 = (from employee in employees
                           orderby employee.Age descending
                           select new
                           {
                               employee.Id,
                               employee.FirstName, 
                               employee.LastName,
                               employee.Age
                           }).ToList();

            foreach (var employee in result2)
            {
                Console.WriteLine("{0} : {1} : {2} : {3}", employee.Id, employee.FirstName, employee.LastName, employee.Age);
            }
            Console.WriteLine();

            //// 2 способ через методы расширения LINQ
            result2 = employees.OrderByDescending(employee => employee.Age)
            .Select(employee => new
            {
                employee.Id,
                employee.FirstName,
                employee.LastName,
                employee.Age
            }).ToList();
           
            foreach (var employee in result2)
            {
                Console.WriteLine("{0} : {1} : {2} : {3}", employee.Id, employee.FirstName, employee.LastName, employee.Age);
            }
            Console.WriteLine();


            Console.WriteLine("3) Сгруппировать студентов по возрасту. Вывести возраст и сколько раз он\r\nвстречается в списке. ");
            // Результатом оператора group является выборка, которая состоит из групп.
            // Выражение group department by department.Country into g определяет переменную g, которая будет содержать группу. 
            // С помощью этой переменной мы можем затем создать новый объект анонимного типа: 
            // select new { Name = g.Key, Count = g.Count() } 
            // Теперь результат запроса LINQ будет представлять набор объектов таких анонимных типов, 
            // у которых два свойства Name и Count


            // 1 способ через LINQ
            var result3 = from employee in employees
                          group employee by employee.Age into g
                          select new { Name = g.Key, Count = g.Count() };

            foreach (var group in result3)
            {
                Console.WriteLine("{0} : {1}", group.Name, group.Count);
            }
            Console.WriteLine();


            //// 2 способ через методы расширения LINQ
            // Аналогичный запрос можно построить с помощью метода расширения GroupBy

            result3 = employees.GroupBy(employee => employee.Age)
                        .Select(g => new { Name = g.Key, Count = g.Count() });
            foreach (var group in result3)
                Console.WriteLine("{0} : {1}", group.Name, group.Count);
            Console.WriteLine('\n');



     
        }
    }
}