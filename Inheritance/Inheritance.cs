using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Inheritance
{

    class Person
    {
        //защищённые поля name (имя), surname (фамилия), age (возраст),phone(телефон);
        protected string name;
        protected string surname;
        protected int age;
        protected string phone;


        //свойства Name, Surname, Age, Phone;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        //конструктор по умолчанию 
        public Person()
        {
        }
        //конструктор с параметрами
        public Person( string n, string s,int a, string p)
        {
            Console.WriteLine("Конструктор класса Person");
            name = n;
            surname = s;
            age = a;
            phone = p;

        }

        //метод Print для вывода информации на экран
        public void Print()
        {
            Console.WriteLine("Name: {0}, Surname: {1}, Age: {2}, Phone: {3}",name,surname,age,phone);
        }
    }


    class Student : Person
    {
        //защищённые поля average (средний балл), number_of_group (номер группы);

        protected double average;
        protected string number_of_group;

        //свойства Average, Number_Of_Group;
        public double Average
        {
            get
            {
                return average;
            }
            set
            {
                average = value;
            }
        }

        public string Number_of_group
        {
            get
            {
                return number_of_group;
            }
            set
            {
                number_of_group = value;
            }
        }


        //конструктор по умолчанию 
        public Student()
        {
        }
        //конструктор с параметрами
        public Student(string n, string s, int a,string p,double average,string number_of_group)
             : base(n,s,a,p)
        {
            Console.WriteLine("Конструктор класса Student");
            this.average = average;
            this.number_of_group = number_of_group;
        }

        //метод Print для вывода информации на экран;

        public void Print()
        {
            base.Print();
            Console.WriteLine("Average: {0}, Number of group: {1} ",average,number_of_group);
        }
    }


    class Academy_Group
    {
        // Creates and initializes a new ArrayList.
        //ArrayList myAL = new ArrayList();
        //необобщенная коллекция ArrayList вместо массива
        private ArrayList students;//переменная students - ссылочная переменная, которая указывает на объект коллекции ArrayList, где хранятся ссылки на студентов.


        //счётчик count количества студентов в группе;
        public int Count
        {
            get
            {
                return students.Count; // Возвращает количество студентов в ArrayList
            }
        }

        //конструктор по умолчанию;
        public Academy_Group()
        {
            students = new ArrayList(); //проинициализировала ArrayList
        }



        //метод Add для добавления студентов в группу;
        public void Add(Student student)
        {
            // myAL.Add("Hello");
            students.Add(student); // добавления студента в ArrayList
            Console.WriteLine("Added {0}.", student.Name);
        }

        // метод Remove для удаления студента из группы (критерий удаления – фамилия);
        public void Remove(string surname)
        {
            bool found = false;
            for (int i = 0; i < students.Count; i++)
            {
                Student student = (Student)students[i];// извлечением итого объекта из ArrayList(ОБДЖЕКТЫ) и его приведением к типу Student
                if (student.Surname == surname)
                {
                    // Removes the element at index 5.
                    //myAL.RemoveAt(5);
                    students.RemoveAt(i);
                    Console.WriteLine("After removing the student: {0}", surname);
                    found = true;
                    break;
                }
              
            }
            if (!found)
            {
                Console.WriteLine("No such student: {0}", surname);
            }
        }

        // метод Edit для редактирования сведений о студенте(критерий – фамилия студента);
        public void Edit(string surname, Student newStudent)
        {

            bool found = false;
            for (int i = 0; i < students.Count; i++)
            {
                Student student = (Student)students[i];// извлечением итого объекта из ArrayList(ОБДЖЕКТЫ) и его приведением к типу Student
                if (student.Surname == surname)
                {
                    students[i] = newStudent;
                    Console.WriteLine("After editing the student: {0}", surname);
                    found = true;
                    break;
                }
            
            }
            if (!found)
            {
                Console.WriteLine("No such student: {0}", surname);
            }
        }

        //метод печати группы Print;
        public void Print()
        {
            Console.WriteLine("Students in the group:");
            //форич предпочтительнее в принте в отличии от фор ибо нам не нужно контролировать индексы и менять коллекцию, а просто нужен принт
            foreach (Student student in students)
            {
                student.Print(); 
            }
        }

        //метод Save для сохранения данных в файл;
        public void Save(string path)
        {
            StreamWriter sw = new StreamWriter(path,false );
            try
            {
                foreach (Student student in students)
                {
                    sw.WriteLine(student.Name);
                    sw.WriteLine(student.Surname);
                    sw.WriteLine(student.Age);
                    sw.WriteLine(student.Phone);
                    sw.WriteLine(student.Average);
                    sw.WriteLine(student.Number_of_group);
                    sw.WriteLine();//пустая строка разделитель
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка сохранения: {0}", e.Message);
            }
            finally
            {
                sw.Close();
            }
        }



        //метод Load для загрузки данных из файла;
        public void Load(string path)
        {
            StreamReader sr = new StreamReader(path);
            try
            {
                string line;//текущая строка 
                while ((line = sr.ReadLine()) != null)
                {

                    Student student = new Student
                    {
                        Name = line,//Мария
                        Surname = sr.ReadLine(),//Гребенчук
                        Age = Convert.ToInt32(sr.ReadLine()),//19
                        Phone = sr.ReadLine(),//380972860462
                        Average = Convert.ToDouble(sr.ReadLine()),//9
                        Number_of_group = sr.ReadLine()//P222
                    };

                  
                    students.Add(student);
                    sr.ReadLine();//пропуск пустой строки
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка загрузк: {0}", e.Message);
            }
            finally
            {
                sr.Close();
            }
        }

        //метод Search для поиска студента по заданному критерию
        public void Search(string surname)
        {
            bool found = false;
            //форич предпочтительнее в поиске в отличии от фор ибо нам не нужно контролировать индексы и менять коллекцию, а просто нужен принт поиска

            foreach (Student student in students)
            {
                if (student.Surname == surname)
                {
                    Console.WriteLine("After searching the student: {0},info about him:", surname);
                    student.Print();
                    found = true; 
                    break;
                }
        
            }
            if (!found)
            {
                Console.WriteLine("No such student: {0}", surname); 
            }
        }



    }

}