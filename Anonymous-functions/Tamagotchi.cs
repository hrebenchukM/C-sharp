using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous_functions
{
    public delegate void StateHandler(string message);

    class Tamagotchi//Тамагочи(объект наблюдения)
    {
        private int health = 100;
        private int hunger = 0;
        private int happiness = 100;
        private int sleep = 100;
        private int illness = 0;

        private string curReq;
        private Random rnd = new Random();

        //5 событий
        public event StateHandler HealthState;
        public event StateHandler HungerState;
        public event StateHandler HappinessState;
        public event StateHandler SleepState;
        public event StateHandler IllnessState;


        public void Play()
        {
            while (health > 0)
            {
                Request();
                Print();

                Console.WriteLine("Тамагочи просит: {0}", curReq);
                Console.WriteLine("Удовлетворить просьбу? (1-Да, 0-Нет): ");
                int res = int.Parse(Console.ReadLine());

                if (res == 1)
                {
                    Respond(true);
                }
                else
                {
                    Respond(false);
                }

                if (illness >= 3)
                {
                    illness++;
                    health = 0;
                    Console.WriteLine("Тамагочи заболел слишком сильно и умер. Плохой Вы друг!!!");
                    break; // Завершаем игру
                }

                Thread.Sleep(2000);
            }
        }

        private void Respond(bool response)
        {
            hunger += 10;
            sleep -= 10;
            if (response)
            {
                illness = 0;

                switch (curReq)
                {
                    case "покормить":
                        hunger = 0;
                        if (hunger > 100) hunger = 100;
                        HungerState?.Invoke("Вы удовлетворили просьбу: " + curReq+"Уровень голода: " + hunger+ "%");
                        break;
                    case "погулять":
                        happiness = 100;
                        if (happiness > 100) happiness = 100;
                        HappinessState?.Invoke("Вы удовлетворили просьбу: " + curReq + "Уровень счастья: " + happiness+ "%");
                        break;
                    case "усыпить":
                        sleep = 100;
                        SleepState?.Invoke("Вы удовлетворили просьбу: " + curReq + "Уровень сна: " + sleep+ "%");
                        break;
                    case "полечить":
                        illness = 0;
                        health = 100;
                        if (health > 100) health = 100;
                        HealthState?.Invoke("Вы удовлетворили просьбу: " + curReq + "Уровень здоровья: " + health+ "%");

                        break;
                    case "поиграть":
                        happiness = 100;
                        if (happiness > 100) happiness = 100;
                        HappinessState?.Invoke("Вы удовлетворили просьбу: " + curReq + "Уровень счастья: " + happiness+ "%");
                        break;
                }

            }
            else
            {

                illness++;
                health -= 34;
                happiness -= 10;

                HealthState?.Invoke("Уровень здоровья: " + health + " % "+" Ухудшение здоровья...");
                HappinessState?.Invoke("Уровень счастья: " + happiness + " % " + " Ухудшение счастья...");

            }
        }

        private void Request()
        {
            string[] req = { "покормить", "погулять", "усыпить", "полечить", "поиграть" };
            string newReq;
            do
            {
                newReq = req[rnd.Next(req.Length)];
            } while (newReq == curReq);

            curReq = newReq;
        }

        private void Print()
        {

            Console.WriteLine("        (\\_/)  ");
            Console.WriteLine("       ( -o- ) ");
            Console.WriteLine("      -(     )-  ");
            Console.WriteLine("       ( ___ )  ");
            Console.WriteLine("       _:   :_   ");

            Console.WriteLine("Статус Тамагочи:");
            Console.WriteLine("Здоровье: {0}%", health);
            Console.WriteLine("Голод: {0}%", hunger);
            Console.WriteLine("Счастье: {0}%", happiness);
            Console.WriteLine("Сон: {0}%", sleep);
            Console.WriteLine("Болезнь: {0}", illness);

        }
    }
}
