using System;
using System.Collections.Generic;
using System.Linq;


namespace LINQ
{

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
 

            // Создадим набор пользователей и выберем из них тех...
            List<Person> persons = new List<Person>()
            {
            new Person(){ Name = "Andrey", Age = 24, City = "Kyiv"},
            new Person(){ Name = "Liza", Age = 18, City = "Odesa" },
            new Person(){ Name = "Oleg", Age = 15, City = "London" },
            new Person(){ Name = "Sergey", Age = 55, City = "Kyiv" },
            new Person(){ Name = "Sergey", Age = 32, City = "Lviv" }
            };


            Console.WriteLine("1) Выбрать людей, старших 25 лет.");

             // 1 способ через LINQ
            var selectedPersons1 = from person in persons
                                where person.Age > 25
                                select person;
            foreach (var person in selectedPersons1)
                Console.WriteLine("{0} - {1} - {2}", person.Name, person.Age,person.City);
            Console.WriteLine('\n');

            // 2 способ через методы расширения LINQ
            selectedPersons1 = persons.Where(p => p.Age > 25);
            foreach (var person in selectedPersons1)
                Console.WriteLine("{0} - {1} - {2}", person.Name, person.Age, person.City);
            Console.WriteLine('\n');


            Console.WriteLine("2) Выбрать людей, проживающих не в Лондоне. ");


            // 1 способ через LINQ
            var selectedPersons2 = from person in persons
                                  where person.City != "London"
                                  select person;
            foreach (var person in selectedPersons2)
                Console.WriteLine("{0} - {1} - {2}", person.Name, person.Age, person.City);
            Console.WriteLine('\n');

            // 2 способ через методы расширения LINQ
            selectedPersons2 = persons.Where(p => p.City != "London");
            foreach (var person in selectedPersons2)
                Console.WriteLine("{0} - {1} - {2}", person.Name, person.Age, person.City);
            Console.WriteLine('\n');

            Console.WriteLine("3) Выбрать имена людей, проживающих в Киеве. ");

           
            // 1 способ через LINQ
            var selectedPersons3 = from person in persons
                                   where person.City == "Kyiv"
                                   select person;
            foreach (var person in selectedPersons3)
                Console.WriteLine("{0}", person.Name);
            Console.WriteLine('\n');

            // 2 способ через методы расширения LINQ
            selectedPersons3 = persons.Where(p => p.City == "Kyiv");
            foreach (var person in selectedPersons3)
                Console.WriteLine("{0}", person.Name);
            Console.WriteLine('\n');


            Console.WriteLine("4) Выбрать людей, старших 35 лет, с именем Sergey. ");


            // 1 способ через LINQ
            var selectedPersons4 = from person in persons
                                   where person.Age > 35
                                   where person.Name == "Sergey"
                                   select person;
            foreach (var person in selectedPersons4)
                Console.WriteLine("{0} - {1} - {2}", person.Name, person.Age, person.City);
            Console.WriteLine('\n');


            // 2 способ через методы расширения LINQ
            selectedPersons4 = persons.Where(p => p.Age > 35 && p.Name == "Sergey");
            foreach (var person in selectedPersons4)
                Console.WriteLine("{0} - {1} - {2}", person.Name, person.Age, person.City);
            Console.WriteLine('\n');


            Console.WriteLine("5) Выбрать людей, проживающих в Одессе. ");
            // 1 способ через LINQ
            var selectedPersons5 = from person in persons
                                   where person.City == "Odesa"
                                   select person;
            foreach (var person in selectedPersons5)
                Console.WriteLine("{0} - {1} - {2}", person.Name, person.Age, person.City);
            Console.WriteLine('\n');

            // 2 способ через методы расширения LINQ
            selectedPersons5 = persons.Where(p => p.City == "Odesa");
            foreach (var person in selectedPersons5)
                Console.WriteLine("{0} - {1} - {2}", person.Name, person.Age, person.City);
            Console.WriteLine('\n');






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