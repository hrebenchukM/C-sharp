using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_class
{

    abstract class Shape
    {
        public abstract void Show();// Show() — вывод на экран информации о фигуре;
        public abstract void Area();// Area() – вычисление площади фигуры;
        public abstract void Save(StreamWriter sw);// Save() — сохранение фигуры в файл; 
        public abstract void Load(StreamReader sr);// Load() — считывание фигуры из файла. 
    }

    class Triangle : Shape
    {
        private int legA;//катет а
        private int legB;//катет b

        public Triangle(int legA, int legB)
        {
            this.legA = legA;
            this.legB = legB;
        }

        public override void Show()// Show() — вывод на экран информации о Triangle;
        {
            Console.WriteLine("\nTriangle: leg A = {0}, leg B = {1}", legA, legB);
        }
        public override void Area()// Area() – вычисление площади Triangle;
        {
            Console.WriteLine("\nSquare of Triangle: {0}", 0.5 * legA * legB);
        }
        public override void Save(StreamWriter sw)// Save() — сохранение Triangle в файл; 
        {
            sw.WriteLine(" Triangle");
            sw.WriteLine(legA);
            sw.WriteLine(legB);
        }
        public override void Load(StreamReader sr)// Load() — считывание Triangle из файла .
        {
            legA = Convert.ToInt32(sr.ReadLine());
            legB = Convert.ToInt32(sr.ReadLine());
          
        }
    }

    class Rectangle : Shape
    {
        //координаті левого верхнего угла
        private int xLeftTop;
        private int yLeftTop;

        //координаті правого нижнего угла
        private int xRightBottom;
        private int yRightBottom;


        public Rectangle(int xLeftTop, int yLeftTop, int xRightBottom, int yRightBottom)
        {
            this.xLeftTop = xLeftTop;
            this.yLeftTop = yLeftTop;
            this.xRightBottom = xRightBottom;
            this.yRightBottom = yRightBottom;
        }

        public override void Show()// Show() — вывод на экран информации о Rectangle;
        {
            Console.WriteLine("\nRectangle: LeftTop = ({0},{1}),RightBottom =({2},{3})", xLeftTop, yLeftTop,xRightBottom, yRightBottom);
        }
        public override void Area()// Area() – вычисление площади Rectangle;
        {
            int a;
            int b;
            a = xRightBottom - xLeftTop;
            b = yLeftTop - yRightBottom;
            Console.WriteLine("\nSquare of Rectangle: {0}", a * b);
        }

        public override void Save(StreamWriter sw)// Save() — сохранение Rectangle в файл; 
        {
            sw.WriteLine("Rectangle");
            sw.WriteLine(xLeftTop);
            sw.WriteLine(yLeftTop);
            sw.WriteLine(xRightBottom);
            sw.WriteLine(yRightBottom);
         
        }
        public override void Load(StreamReader sr)// Load() — считывание Rectangle из файла .
        {

            xLeftTop = Convert.ToInt32(sr.ReadLine());
            yLeftTop = Convert.ToInt32(sr.ReadLine());
            xRightBottom = Convert.ToInt32(sr.ReadLine());
            yRightBottom = Convert.ToInt32(sr.ReadLine());
        }
    }


    class Circle : Shape
    {
        // координаті центра и радиуса
        private int XCenter;
        private int yCenter;
        private int radius;

        public Circle(int XCenter, int yCenter, int radius)
        {
            this.XCenter = XCenter;
            this.yCenter = yCenter;
            this.radius = radius;
        }

        public override void Show()// Show() — вывод на экран информации о Circle;
        {
            Console.WriteLine("\nCircle: Center = ({0},{1}), radius = {2}", XCenter, yCenter, radius);
        }
        public override void Area()// Area() – вычисление площади Circle;
        {
            Console.WriteLine("\nSquare of Circle: {0}", Math.PI * radius * radius);
        }

        public override void Save(StreamWriter sw)// Save() — сохранение Circle в файл;
        {
            sw.WriteLine("Circle");
            sw.WriteLine(XCenter);
            sw.WriteLine(yCenter);
            sw.WriteLine(radius);
        }
        public override void Load(StreamReader sr)// Load() — считывание Circle из файла .
        {
            XCenter = Convert.ToInt32(sr.ReadLine());
            yCenter = Convert.ToInt32(sr.ReadLine());
            radius = Convert.ToInt32(sr.ReadLine());
        }
    }



    class ShapeArrayLinks//класс, в котором инкапсулируется массив ссылок типа Shape
    {
        private ArrayList shapes = new ArrayList();
        //добавление фигуры в массив;
        public void Add(Shape s)
        {
            shapes.Add(s);
        }
       // удаление фигуры из массива;
        //public void Remove(Shape s)
        //{
        //    shapes.Remove(s);
        //}
        public void Remove(string shapeName)
        {
            bool found = false;
            for (int i = 0; i < shapes.Count; i++)
            {
                Shape shape = (Shape)shapes[i];
                if (shapeName == "Triangle" || shapeName == "Rectangle" || shapeName == "Circle")
                {
                    // Removes the element at index 5.
                    //myAL.RemoveAt(5);
                    shapes.RemoveAt(i);
                    Console.WriteLine("After removing the shape: {0}", shapeName);
                    found = true;
                    break;
                }

            }
            if (!found)
            {
                Console.WriteLine("No such student: {0}", shapeName);
            }
        }



        //печать всех фигур;
        public void PrintAll()
        {
            foreach (Shape s in shapes)
            {
                s.Show();
            }
        }
        //печать фигур указанного типа(следует применять средства динамической идентификации типа is или as как в примере с конференции )
        public void PrintByType(string shapeName)
        {
            foreach (Shape s in shapes)
            {
                if ((s is Triangle t) && (shapeName == "Triangle"))
                {

                    t.Show();
                }
                else if ((s is Rectangle r) && (shapeName == "Rectangle"))
                {
                    r.Show();
                }
                else if ((s is Circle c) && (shapeName == "Circle"))
                {
                    c.Show();
                }
            }
        }
        //вычисление площади всех фигур
        public void AreaAll()
        {
            foreach (Shape s in shapes)
            {
                s.Area();
            }
        }

        //вычисление площади фигур указанного типа (следует применять средства динамической идентификации типа is или as как в примере с конференции)

        public void AreaByType(string shapeName)
        {
            foreach (Shape s in shapes)
            {
                if ((s is Triangle t)&&(shapeName== "Triangle"))
                {
                    t.Area();
                }
                else if ((s is Rectangle r)&& (shapeName == "Rectangle"))
                {
                    r.Area();
                }
                else if ((s is Circle c)&& (shapeName == "Circle"))
                {
                    c.Area();
                }
            }
        }
        //сохранение фигур в файл
        public void SaveAll(string path)
        {
            StreamWriter sw = new StreamWriter(path, false);
            try
            {
                foreach (Shape s in shapes)
                {
                    s.Save(sw);
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

        //загрузка фигур из файла
        public void LoadAll(string path)
        {
            StreamReader sr = new StreamReader(path);
            try
            {
                string line;//текущая строка 

                while ((line = sr.ReadLine()) != null)
                {
                    Shape s = null;
                    if (line == "Triangle")
                    {

                        s = new Triangle(0, 0);
                        s.Load(sr);
                    }
                    else if (line == "Rectangle")
                    {

                        s = new Rectangle(0, 0, 0, 0);
                        s.Load(sr);
                    }
                    else if (line == "Circle")
                    {

                        s = new Circle(0, 0, 0);
                        s.Load(sr);
                    }
                    else
                    {
                        Console.WriteLine("Неопознанный обьект (НО - не НЛО)");
                        continue;
                    }
                    if (s != null)
                    {
                        Add(s); 
                    }
                  
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
    }

}


