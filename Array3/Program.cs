// See https://aka.ms/new-console-template for more information

class MainClass
{
    //Точка входа в программу 
    static void Main()//статический метод а не функция(его вызывает система,CLR поэтому он не может быть зависимым от бьекта поэтому статик)
    {
        try
        {
            int N = 5;
            int M = 5; 
            // Можно объявить массив без инициализации
            int[,] arr3;
            // Но его нельзя использовать, пока он не создан с помощью оператора new
            /*
            arr3[0,0] = 0; // Ошибка компиляции
            arr3 = { {0, 3}, {7, 17}, {25, 0} }; // Ошибка компиляции
            */
            arr3 = new int[N, M];

            Random rnd = new();

            Console.WriteLine("Исходный целочисленный массив: ");

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    arr3[i,j] = rnd.Next(0, 101);
                    Console.Write("{0,4}", arr3[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Введите количество столбцов сдвига:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите направление сдвига (1 - вправо, 2 - влево):");
            int direction = int.Parse(Console.ReadLine());


            
            if (direction == 1)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int temp = arr3[i, 0]; 
                        for (int k = 0; k < M - 1; k++)
                        {
                            arr3[i, k] = arr3[i, k + 1];
                        }
                        arr3[i, M - 1] = temp; 
                    }
                }
            }
         
            else if (direction == 2)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int temp = arr3[i, M - 1]; 
                        for (int k = M - 1; k > 0; k--)
                        {
                            arr3[i, k] = arr3[i, k - 1]; 
                        }
                        arr3[i, 0] = temp; 
                    }
                }
            }


            Console.WriteLine("Конечный целочисленный массив: ");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write("{0,4}", arr3[i, j]);
                }
                Console.WriteLine();
            }
        }
        
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
