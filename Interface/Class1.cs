using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Interface
{

    class House 
    {
        protected Basement basement;
        protected ArrayList walls = new ArrayList() ;
        protected Door door;
        protected ArrayList windows = new ArrayList();
        protected Roof roof;


        public Basement Basement
        {
            get
            {
                return basement;
            }
            set
            {
                basement = value;
            }
        }


        public ArrayList Walls
        {
            get
            {
                return walls;
            }
            set
            {
                walls = value;
            }
        }

        public Door Door
        {
            get
            {
                return door;
            }
            set
            {
                door = value;
            }
        }

        public ArrayList Windows
        {
            get
            {
                return windows;
            }
            set
            {
                windows = value;
            }
        }

        public Roof Roof
        {
            get
            {
                return roof;
            }
            set
            {
                roof = value;
            }
        }

        //конструктор по умолчанию 
        public House()
        {
            basement = new Basement();
            door = new Door();
            roof = new Roof();
            for (int i = 0; i < 4; i++)
            {
                walls.Add(new Wall());
            }
               
            for (int i = 0; i < 4; i++)
            {
                windows.Add(new Window());
            }
        }

        //конструктор с параметрами
        public House(Basement b, ArrayList wall, Door d, ArrayList wind, Roof r)
        {
            Console.WriteLine("Конструктор класса House");
            basement = b;
            walls = wall;
            door = d;    
            windows =wind;
            roof = r;

        }

        //метод Print для вывода информации на экран
        public void Print()
        {
            Console.WriteLine();
            Console.WriteLine();

            if (roof.Ready)
            {
               
                Console.WriteLine("         _____________     ");
                Console.WriteLine("        / \\           \\     ");
                Console.WriteLine("       /   \\           \\   ");
                Console.WriteLine("      /     \\           \\   ");
                Console.WriteLine("     /_______\\___________\\ ");

            }
          

            int wallN = 0;
            foreach (Wall wall in walls)
            {
                if (wall.Ready)
                {
                    wallN++;
                }
            }
            if (wallN > 0)
            {
          
                Console.WriteLine("     |       |           |   ");

            }

            int windN = 0;
            foreach (Window window in windows)
            {
                if (window.Ready)
                {
                    windN++;
                }
            }
            if (windN > 0)
            {
               Console.WriteLine("     |  []   |  [] [] [] |   ");
            }

            if (door.Ready)
            {
          
                Console.WriteLine("     |  ___  |           |   ");
                Console.WriteLine("     |  |*|  |           |   ");
                Console.WriteLine("     |__|_|__|___________|   ");

            }

            if (basement.Ready)
            {
         
                Console.WriteLine("     |___________________|   ");
            } 
            //дом состоит из одного  фундамента, четырёх стен, одной двери, четырёх окон и  одной крыши.
            if (basement.Ready && wallN == 4 && windN == 4 && door.Ready && roof.Ready)
            {
             
                Console.ForegroundColor = ConsoleColor.Magenta; 
                Console.WriteLine("         _____________     ");
                Console.WriteLine("        / \\           \\     ");
                Console.WriteLine("       /   \\           \\   ");
                Console.WriteLine("      /     \\           \\   ");
                Console.WriteLine("     /_______\\___________\\ ");
                Console.WriteLine("     |       |           | "); 
                Console.WriteLine("     |  []   |  [] [] [] |   "); 
                Console.WriteLine("     |  ___  |           |   "); 
                Console.WriteLine("     |  |*|  |           |   "); 
                Console.WriteLine("     |__|_|__|___________|   "); 
                Console.WriteLine("     |_______|___________|   ");
              
                Console.ResetColor();
                Console.WriteLine("\nВаш дом готов\n");
            }
            else
            {
                Console.WriteLine("\nВаш дом не готов\n");
            }

        }

        public void PrintInfo()
        {
            if (basement.Ready)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("{0}, ", basement.Name);
                Console.ResetColor();
            }

           
          

            int wallN = 0;
            foreach (Wall wall in walls)
            {
                if (wall.Ready)
                {
                    wallN++;
                }
            }
            if (wallN > 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("стены {0} ,", wallN);
                Console.ResetColor();
            }
            if (door.Ready)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("{0}, ", door.Name);
                Console.ResetColor();
            }

            int windN = 0;
            foreach (Window window in windows)
            {
                if (window.Ready)
                {
                    windN++;
                }
            }
            if (windN > 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("окна {0} ,", windN);
                Console.ResetColor();
            }

           
            if (roof.Ready)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("{0} .", roof.Name);
                Console.ResetColor();

            }

          
        }


    }
    class Basement : IPart
    {
        private string name = "фундамент";

        public bool Ready
        {
            get;
            set;
        } 
        public Basement()
        {
            Ready = false;
        }

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

    }

    class Wall : IPart
    {
        private string name = "стена";

        public bool Ready
        {
            get;
            set;
        }
        public Wall()
        {
            Ready = false;
        }

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
    }

    class Door : IPart
    {
        private string name = "дверь";

        public bool Ready
        {
            get;
            set;
        }
        public Door()
        {
            Ready = false;
        }
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
    }


    class Window : IPart
    {
        private string name = "окно";

        public bool Ready
        {
            get;
            set;
        }
        public Window()
        {
            Ready = false;
        }
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
    }

    class Roof : IPart
    {
        private string name = "крыша";

        public bool Ready
        {
            get;
            set;
        }
        public Roof()
        {
            Ready = false;
        }
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
    }

    class Worker : IWorker
    {
        private string name;

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

        public void Build(IPart part)
        {
            if (!part.Ready)
            {
                Console.WriteLine("-Рабочий {0}: Сейчас строится {1} ", name, part.Name);
                part.Ready = true;
            }
        }
    }




    class TeamLeader : IWorker
    {

        private string name = "Бригадир";
        public string Name { get; set; }

        public void Build(IPart part)
        {
            // он не строит, а формирует отчёт о том, что уже построено и какая часть работы выполнена
        }
        public void Report(House house)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nПриехал {0}.", name);
            Console.ResetColor();
            Console.WriteLine("-{0}: уже готово : ", name);
            house.PrintInfo();
            house.Print();
          
        }


    }


    class Team 
    {
        private ArrayList workers;
        private TeamLeader teamLeader;
        
        public Team(ArrayList w, TeamLeader t)
        {
            workers = w;
            teamLeader = t;
        }

        public void BuildHouse(House house)
        {
          
            Random rnd = new();
            int i = rnd.Next(workers.Count);
            Worker bWorker = (Worker)workers[i];

            teamLeader.Report(house);
            bWorker.Build(house.Basement);


            teamLeader.Report(house);

            if (house.Basement.Ready)
            {
                foreach (Wall wall in house.Walls)
                {
                    foreach (Worker worker in workers)
                    {
                        int iw = rnd.Next(workers.Count);
                        Worker wWorker = (Worker)workers[iw];
                        wWorker.Build(wall);
                    }
                }
                teamLeader.Report(house);

                if (house.Walls.Count == 4)
                {
                    int id = rnd.Next(workers.Count);
                    Worker dWorker = (Worker)workers[id];
                    dWorker.Build(house.Door);
                    teamLeader.Report(house);

                    if (house.Door.Ready)
                    {
                        foreach (Window window in house.Windows)
                        {
                            foreach (Worker worker in workers)
                            {
                                int wi = rnd.Next(workers.Count);
                                Worker workerW = (Worker)workers[wi];
                                workerW.Build(window);
                            }
                        }
                        teamLeader.Report(house);

                        if (house.Walls.Count == 4)
                        {

                            int ir = rnd.Next(workers.Count);
                            Worker rWorker = (Worker)workers[ir];
                            rWorker.Build(house.Roof);
                        }

                    }

                  
                }

            }

            teamLeader.Report(house);
        }

    }


}
