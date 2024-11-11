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
        

        Console.WriteLine("1) Выбрать имена и фамилии сотрудников, работающих в Украине, но не в Одессе");

            //// 1 способ через LINQ
            var result1 = from employee in employees
                     join department in departments on employee.DepId equals department.Id
                     where department.Country== "Ukraine"
                     where department.City != "Odesa"
                     select new
                     {
                         employee.FirstName,
                         employee.LastName,
                         employee.Age
                     };

            foreach (var employee in result1)
            {
                Console.WriteLine(employee.FirstName + " " + employee.LastName + " " + employee.Age);
            }
            Console.WriteLine();




            //// 2 способ через методы расширения LINQ
            result1 = employees.Join(departments, employee => employee.DepId, department => department.Id, (employee, department) => new
            {
                employee.FirstName,
                employee.LastName,
                employee.Age,
                department.Country,
                department.City
            })
            .Where(x => x.Country == "Ukraine" && x.City != "Odesa")
            .Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.Age
            });


            foreach (var employee in result1)
            {
                Console.WriteLine(employee.FirstName + " " + employee.LastName + " " + employee.Age);
            }
            Console.WriteLine();


            Console.WriteLine("2) Вывести список стран без повторений");
            // Результатом оператора group является выборка, которая состоит из групп.
            // Выражение group department by department.Country into g определяет переменную g, которая будет содержать группу. 
            // С помощью этой переменной мы можем затем создать новый объект анонимного типа: 
            // select new { Name = g.Key, Count = g.Count() } 
            // Теперь результат запроса LINQ будет представлять набор объектов таких анонимных типов, 
            // у которых два свойства Name и Count


            // 1 способ через LINQ
            var result2 = from department in departments
                          group department by department.Country into g
                          select new { Name = g.Key, Count = g.Count() };

            foreach (var group in result2)
            {
                Console.WriteLine("{0} : {1}", group.Name, group.Count);
            }
            Console.WriteLine();


            //// 2 способ через методы расширения LINQ
            result2 = departments.GroupBy(department => department.Country)
                        .Select(g => new { Name = g.Key, Count = g.Count() });
            foreach (var group in result2)
                Console.WriteLine("{0} : {1}", group.Name, group.Count);
            Console.WriteLine('\n');



            Console.WriteLine("3) Выбрать 3-x первых сотрудников, возраст которых превышает 25 лет. ");
            // Метод Skip() пропускает определенное количество элементов, 
            // а метод Take() извлекает определенное число элементов


            // 1 способ через LINQ
            var result3 = (from employee in employees
                           where employee.Age > 25
                           select employee).Take(3);  // Извлечем три первых элемента

            foreach (var employee in result3)
                Console.WriteLine(employee.FirstName + " " + employee.LastName + " " + employee.Age);
            Console.WriteLine('\n');

            //// 2 способ через методы расширения LINQ

            result3 = employees.Where(employee => employee.Age>25).Take(3);


            foreach (var employee in result3)
                Console.WriteLine(employee.FirstName + " " + employee.LastName + " " + employee.Age);
            Console.WriteLine('\n');

            Console.WriteLine("4) Выбрать имена, фамилии и возраст студентов из Киева, возраст которых превышает 23 года.  ");//Таких нет , ибо им по 22


            //// 1 способ через LINQ
            var result4 = from employee in employees
                          join department in departments on employee.DepId equals department.Id
                          where department.City == "Kyiv"
                          where employee.Age > 23
                          select new
                          {
                              employee.FirstName,
                              employee.LastName,
                              employee.Age
                          };

            foreach (var employee in result4)
            {
                Console.WriteLine(employee.FirstName + " " + employee.LastName + " " + employee.Age);
            }
            Console.WriteLine();




            //// 2 способ через методы расширения LINQ
            result4 = employees.Join(departments, employee => employee.DepId, department => department.Id, (employee, department) => new
            {
                employee.FirstName,
                employee.LastName,
                employee.Age,
               department.City
            })
            .Where(x => x.City == "Kyiv" && x.Age > 23)
            .Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.Age
            });


            foreach (var employee in result4)
            {
                Console.WriteLine(employee.FirstName + " " + employee.LastName + " " + employee.Age);
            }
            Console.WriteLine();


            /*
             Список используемых методов расширения LINQ

                Select: определяет проекцию выбранных значений
                Where: определяет фильтр выборки
                OrderBy: упорядочивает элементы по возрастанию
                OrderByDescending: упорядочивает элементы по убыванию
                ThenBy: задает дополнительные критерии для упорядочивания элементов возрастанию
                ThenByDescending: задает дополнительные критерии для упорядочивания элементов по убыванию
                Join: соединяет две коллекции по определенному признаку
                GroupBy: группирует элементы по ключу
                ToLookup: группирует элементы по ключу, при этом все элементы добавляются в словарь
                GroupJoin: выполняет одновременно соединение коллекций и группировку элементов по ключу
                Reverse: располагает элементы в обратном порядке
                All: определяет, все ли элементы коллекции удовлятворяют определенному условию
                Any: определяет, удовлетворяет хотя бы один элемент коллекции определенному условию
                Contains: определяет, содержит ли коллекция определенный элемент
                Distinct: удаляет дублирующиеся элементы из коллекции
                Except: возвращает разность двух коллекцию, то есть те элементы, которые содератся только в одной коллекции
                Union: объединяет две однородные коллекции
                Intersect: возвращает пересечение двух коллекций, то есть те элементы, которые встречаются в обоих коллекциях
                Count: подсчитывает количество элементов коллекции, которые удовлетворяют определенному условию
                Sum: подсчитывает сумму числовых значений в коллекции
                Average: подсчитывает cреднее значение числовых значений в коллекции
                Min: находит минимальное значение
                Max: находит максимальное значение
                Take: выбирает определенное количество элементов
                Skip: пропускает определенное количество элементов
                TakeWhile: возвращает цепочку элементов последовательности, до тех пор, пока условие истинно
                SkipWhile: пропускает элементы в последовательности, пока они удовлетворяют заданному условию, и затем возвращает оставшиеся элементы
                Concat: объединяет две коллекции
                Zip: объединяет две коллекции в соответствии с определенным условием
                First: выбирает первый элемент коллекции
                FirstOrDefault: выбирает первый элемент коллекции или возвращает значение по умолчанию
                Single: выбирает единственный элемент коллекции, если коллекция содердит больше или меньше одного элемента, то генерируется исключение
                SingleOrDefault: выбирает первый элемент коллекции или возвращает значение по умолчанию
                ElementAt: выбирает элемент последовательности по определенному индексу
                ElementAtOrDefault: выбирает элемент коллекции по определенному индексу или возвращает значение по умолчанию, если индекс вне допустимого диапазона
                Last: выбирает последний элемент коллекции
                LastOrDefault: выбирает последний элемент коллекции или возвращает значение по умолчанию
            */
        }
    }
}