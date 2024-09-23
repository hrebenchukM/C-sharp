

class MainClass
{
    //Точка входа в программу 
    static void Main()//статический метод а не функция(его вызывает система,CLR поэтому он не может быть зависимым от бьекта поэтому статик)
    {
        try
        {
            ////Логические литералы
            //Console.WriteLine(true);//WriteLine метод статический класса консоль, вызывается на классе, если не стаический метод то вызывается на обьекте
            //Console.WriteLine(false);

            ////Целочисленнные литералы
            //Console.WriteLine(-7);
            //Console.WriteLine(7);
            //Console.WriteLine(0b111);//7
            //Console.WriteLine(0b1001);//9
            //Console.WriteLine(0x1A);//26
            //Console.WriteLine(0xFF);//255

            ////Вещественные литералы
            //Console.WriteLine(0.92e4);//0,92*10^4
            //Console.WriteLine(7.2E-1);//7,2*10^-1

            ////Символьные литералы
            //Console.WriteLine('C');
            //Console.WriteLine('#');


            ////Строковые литералы
            //Console.WriteLine("Привет,мир\n");
            //Console.WriteLine("Hello, World!\n");
            //Console.WriteLine("Привет C#");
            //Console.WriteLine("Привет\t C#");//табуляция
            //Console.WriteLine("Привет \b C#");//удаление пробела
            //Console.WriteLine("Привет\r C#");//возврат корректки на первую позицию(C#ивет)
            //Console.WriteLine("\"Привет C#\"");//" "
            //Console.WriteLine("\\Привет C#\\");//\ \
            //Console.WriteLine(@"\Привет
            //              C#\");//табуляция и на новой строке руками

            ////sbyte a = -153
            ////sbyte a = (sbyte)-153;
            //sbyte a = -100;
            //Console.WriteLine(a);
            //Console.WriteLine("System.SByte.MinValue{0}", SByte.MinValue);
            //Console.WriteLine("System.SByte.MaxValue{0}", sbyte.MaxValue);

            //byte b = 100;
            //Console.WriteLine(b);
            //Console.WriteLine("System.Byte.MinValue{0}", System.Byte.MinValue);
            //Console.WriteLine("System.Byte.MaxValue{0}", byte.MaxValue);

            //int c = -32765;
            ////a=c//неявное преобразование запрещено
            //a = (sbyte)c;
            //Console.WriteLine(c);
            //Console.WriteLine(a);
            //Console.WriteLine("System.Int32.MinValue{0}", System.Int32.MinValue);
            //Console.WriteLine("System.Int32.MaxValue{0}", int.MaxValue);

            //uint d = 153;
            //Console.WriteLine(d);
            //Console.WriteLine("System.UInt32.MinValue{0}", System.UInt32.MinValue);
            //Console.WriteLine("System.UInt32.MaxValue{0}", uint.MaxValue);

            //Console.WriteLine("System.Int16.MinValue{0}", System.Int16.MinValue);
            //Console.WriteLine("System.Int16.MaxValue{0}", short.MaxValue);
            //Console.WriteLine("System.Int16.MinValue{0}", System.UInt16.MinValue);
            //Console.WriteLine("System.Int16.MaxValue{0}", ushort.MaxValue);

            //Console.WriteLine("System.Int64.MinValue{0}", System.Int64.MinValue);
            //Console.WriteLine("System.Int64.MaxValue{0}", long.MaxValue);

            //Console.WriteLine("System.UInt64.MinValue{0}", System.UInt64.MinValue);
            //Console.WriteLine("System.UInt64.MaxValue{0}", ulong.MaxValue);


            //char e = 'A';
            //Console.WriteLine(e);
            //Console.WriteLine("System.Char.MinValue{0}", (int)System.Char.MinValue);
            //Console.WriteLine("System.Char.MaxValue{0}", (int)char.MaxValue);

            //double f = 12345.6789;
            //Console.WriteLine(f);
            //Console.WriteLine("System.Double.MinValue{0}", System.Double.MinValue);
            //Console.WriteLine("System.Double.MaxValue{0}", double.MaxValue);


            ////float g = 75.535;//неявное преобразование запрещено
            //float g = 75.535f;
            //Console.WriteLine(g);
            //Console.WriteLine("System.Single.MinValue{0}", System.Single.MinValue);
            //Console.WriteLine("System.Single.MaxValue{0}", float.MaxValue);

            //decimal h = 12345.6789M;//десятичное число с иксированной точностью
            //Console.WriteLine(h);
            //Console.WriteLine("System.Decimal.MinValue{0}", System.Decimal.MinValue);
            //Console.WriteLine("System.Decimal.MaxValue{0}", decimal.MaxValue);

            //bool i = true;
            //Console.WriteLine(i);
            ////bool i =1;// неявное преобразование запрещено
            //i = false;
            //Console.WriteLine(i);



            //const double number = 578.7;
            //string str = number.ToString();
            //Console.WriteLine(str);

            //Console.WriteLine("Input string:");
            //str = Console.ReadLine();//cin
            //double real = double.Parse(str);
            //Console.WriteLine(real + 10);

            //Console.WriteLine("Input string:");
            //str = Console.ReadLine();
            //real = Convert.ToDouble(str);
            //Console.WriteLine(real + 10);






            //int aa = 0;
            //int bb = 0;
            //double cc = 0;
            //double dd = 0;

            //Console.WriteLine("Input int number:");
            //aa = int.Parse(Console.ReadLine());
            //Console.WriteLine("Input int number:");
            //bb = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Result{0}/{1}={2}", aa, bb, aa / bb);
            //Console.WriteLine("Result{0}%{1}={2}", aa, bb, aa % bb);



            //Console.WriteLine("Input fractional number:");
            //cc = double.Parse(Console.ReadLine());
            //Console.WriteLine("Input fractional number:");
            //dd = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("Result{0}/{1}={2}", cc, dd, cc / dd);
            //Console.WriteLine("Result{0}%{1}={2}", cc, dd, cc % dd);





            //int aaa = 10, bbb = 5, ccc = 7, ddd = 8;//&& ||
            //if (aaa < bbb && ++ccc <= ddd)//++ccc не выполнится ,т.к сокращенная схема
            //{
            //    Console.WriteLine("No string!");
            //}
            //else
            //{
            //    Console.WriteLine("a={0} b = {1} c={2} d={3} ", aaa, bbb, ccc, ddd);
            //}

            //if (aaa < bbb & ++ccc <= ddd)
            //{//& | ^


            //    Console.WriteLine("No string!");

            //}
            //else
            //{
            //    Console.WriteLine("a={0} b = {1} c={2} d={3} ", aaa, bbb, ccc, ddd);
            //}





            //if (aaa < bbb ^ --ccc <= ddd)
            //{

            //    Console.WriteLine("a={0} b = {1} c={2} d={3} ", aaa, bbb, ccc, ddd);


            //}
            //else
            //{
            //    Console.WriteLine("No string!");
            //}

            //if(aaa>0)
            //{

            //    Console.WriteLine("Значение переменной a отлично от нуля!");
            //}



            /*
    //ошибка компиляции : выражение в скобках должно иметь тип бул
   if(a)
   {

           Console.WriteLine("Значение переменной a отлично от нуля!");
   }
    //ошибка компиляции : к типу бул преобразование нет
   if((bool)a)
   {

           Console.WriteLine("Значение переменной a отлично от нуля!");
   }



    */


            ///////////////////////////////////////////HOMEWORK!!!!!!!//////////////////
            /////////////////////////1//////////////////////////////////////////////////
            Console.WriteLine("Input number:");//1234321
            string str = Console.ReadLine();

            bool isPalindrome = true;
            int length = str.Length;//7


            for (int i = 0; i < length / 2; i++)//0 1 2 3 
            {
                if (str[i] != str[length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
                // 1=1,2=2,3=3,4=4
            }

            if (isPalindrome)
            {
                Console.WriteLine($"Number {str} is palindrome.");//1234321
            }
            else
            {
                Console.WriteLine($"Number {str} is not a pslindrome.");
            }


            /////////////////////////2//////////////////////////////////////////////////
            Console.WriteLine("Input number:");//12345
            string userStr = Console.ReadLine();

            Console.WriteLine("Input count of steps:");//3
            int userN = int.Parse(Console.ReadLine());

            Console.WriteLine("Input 1 if right or 2 if left:");//2
            int rl = int.Parse(Console.ReadLine());


            if (rl == 2)
            {
                userStr = userStr.Substring(userN) + userStr.Substring(0, userN);//45 + 123 = 45123 
            }
            else if (rl == 1)
            {
                userStr = userStr.Substring(userStr.Length - userN) + userStr.Substring(0, userStr.Length - userN);
            }
            else
            {
                Console.WriteLine("1 or 2!");
                return;
            }

            Console.WriteLine("Result{0}", userStr);



            /////////////////////////3//////////////////////////////////////////////////
            Console.WriteLine("Input  15 int numbers:");//523341222567801
            int maxLen = 0; 
            int start = 0;
            int curLen = 1; 
            int curStart = 1; 
            int prevNum = int.Parse(Console.ReadLine()); // 5

            for (int i = 2; i <= 15; i++)
            {
                int curNum = int.Parse(Console.ReadLine());//2 \3 \3 \4 \1 \2 \2 \2 \5 \6 \7 \8 \0 \1
                if (curNum >= prevNum)//5>=5 \3>=2 \ 3>=3 \ 4>=3 \2>=1 \2>=2 \2>=2 \5>=2 \6>=5 \7>=6 \8>=7 \1>=0
                {
                    curLen++;//\2 \3 \4 \2 \3 \4 \5 \6 \7 \8 \2
                }
                else//2<5 \1<4 \0<8
                {
                    if (curLen > maxLen) //1>0 \ 4>1 
                    {
                        maxLen = curLen;//1\ 4 \8
                        start = curStart;//1 \ 3 \6
                    }
                    curLen = 1;
                    curStart = i; //1 \2 \6 \15
                }
                prevNum = curNum;
            }
            if (curLen > maxLen)
            {
                maxLen = curLen;
                start = curStart;
            }
            Console.WriteLine("Max len {0}", maxLen);//8
            Console.WriteLine("start index {0}", start);//6
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
