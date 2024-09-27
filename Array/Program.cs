// See https://aka.ms/new-console-template for more information

class MainClass
{
    //Точка входа в программу 
    static void Main()//статический метод а не функция(его вызывает система,CLR поэтому он не может быть зависимым от бьекта поэтому статик)
    {
        try
        {
            // Можно объявить массив без инициализации
            int[] arr3 = null;
            // Но его нельзя использовать, пока он не создан с помощью оператора new
            arr3 = new int[10];
            Random rnd = new();
            Console.WriteLine("Исходный целочисленный массив: ");

            for (int i = 0; i < arr3.Length; i++)
            {
                arr3[i] = rnd.Next(0,6);
                Console.Write("{0,4}", arr3[i]);
            }
            Console.WriteLine();


            int nNotNull = 0;
            for (int i = 0; i < arr3.Length; i++)
            {
                if (arr3[i] != 0)
                {
                    arr3[nNotNull] = arr3[i];
                    nNotNull++;
                }
            }

            
            for (int i = nNotNull; i < arr3.Length; i++)
            {
                arr3[i] = -1;
            }

            Console.WriteLine("Конечный целочисленный массив: ");

            for (int i = 0; i < arr3.Length; i++)
            {
                Console.Write("{0,4}", arr3[i]);
            }
            Console.WriteLine();


        }


        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
