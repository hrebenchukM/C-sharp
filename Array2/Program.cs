// See https://aka.ms/new-console-template for more information

class MainClass
{
    //Точка входа в программу 
    static void Main()//статический метод а не функция(его вызывает система,CLR поэтому он не может быть зависимым от бьекта поэтому статик)
    {
        try
        {
            int N = 5;
            // Можно объявить массив без инициализации
            int[,] arr3;
            // Но его нельзя использовать, пока он не создан с помощью оператора new
            /*
            arr3[0,0] = 0; // Ошибка компиляции
            arr3 = { {0, 3}, {7, 17}, {25, 0} }; // Ошибка компиляции
            */
            arr3 = new int[N,N] ;

            int value = 1;
            int row = N / 2, col = N / 2; 
            arr3[row, col] = value++;





            int steps = 1; 
            int direction = 0;
            while (value <= N * N)
            {
                for (int i = 0; i < steps; i++)
                {
                    if (value > N * N)
                    {
                        break;
                    }


                    switch (direction)
                    {
                        case 0: row--; break; // вверх
                        case 1: col--; break; // влево
                        case 2: row++; break; // вниз
                        case 3: col++; break; // вправо
                    }

                    arr3[row, col] = value++;
                }

               

                direction++;
                if (direction == 4)
                {
                    direction = 0;

                }
                if (direction % 2 == 0)
                {
                    steps++;
                }

            }



            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
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
