﻿//Class Work 
using System;
using System.Text.RegularExpressions;

namespace Regular_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            //__________________________1_______________________________________________
            //Написать приложение, проверяющее с помощью регулярного
            //выражения корректность ввода фамилии и инициалов
            //пользователя в следующем виде: Иванов И.И.либо Иванов ИИ
            //__________________________________________________________________________

            Console.WriteLine("Введите фамилию и инициалы в формате  Иванов И.И.либо Иванов ИИ");
            string Input1 = Console.ReadLine();
            string pattern1 = @"^[А-ЯЁ][а-яё]+ ([А-ЯЁ]+\.[А-ЯЁ]+\.|[А-ЯЁ]{2})$|^$[A-Z][a-z]+ ([A-Z]+\.[A-Z]+\.|[A-Z]{2})";//Аслан спросил про дву точки и возможность на англ 
            //^ — начало строки
            //[А-ЯЁ][а-яё]+ — фамилия  с большой , затем идут  строчные символов.
            // пробел между фамилией и инициалами.
            //[А - ЯЁ]\. — первая большая и точка.
            //[А-ЯЁ]\. — второй большая и точка.
            //| —  "или".
            //[А-ЯЁ]{2} — состоит из двух больших без точек.
    
            Regex regex1 = new Regex(pattern1);
            
            if (regex1.IsMatch(Input1))
                Console.WriteLine("Фамилия и инициалы введены правильно!");
            else
                Console.WriteLine("Фамилия и инициалы введены не правильно!");


            //__________________________2_______________________________________________
            // Написать приложение, проверяющее с помощью регулярного
            //выражения корректность ввода адреса электронной почты.
            //Адрес электронной почты должен иметь следующий вид:
            // login @host,
            // где login - последовательность из букв, цифр и символа "_", начинающаяся с буквы.Длина - от 3 до 16 символов.
            //host - строка вида mail.ru или mail.odessa.ua и т.п.В конце host должен содержать от 2 до 3 символов(ua, com, net,ru и т.д.)
            //__________________________________________________________________________

            Console.WriteLine("Введите адрес электронной почты в формате login@host(например, mary_123@mail.odesa.ua)");
            string Input2 = Console.ReadLine();
            string pattern2 = @"^[a-z][a-z0-9_]{2,15}@([a-z]+\.[a-z]{2,3}|[a-z]+\.[a-z]+\.[a-z]{2,3})$"
;           //^[a-z] — первый символ login маленькая буква длина 1 
            //[a-z0-9_] — последовательность из маленьких букв, цифр или символа _
            // { 2,15} -, длина от 2 до 15
            //  @ — "@" login@host
            //  [a-z]+ \.  - mail.
            // [a-z]{2,3} - от 2 до 3 маленьких букв (ua, com, net,ru и т.д.)
            //| —  "или".
            //  [a-z]+ \.  - mail.
            //  [a-z]+ \.  - odesa.
            // [a-z]{2,3} - от 2 до 3 маленьких букв (ua, com, net,ru и т.д.)

            Regex regex2 = new Regex(pattern2, RegexOptions.IgnoreCase);//IgnoreCase спрашивал Аслан на случай пользователь введет с большой 

            if (regex2.IsMatch(Input2))
                Console.WriteLine("Адрес электронной почты введено правильно!");
            else
                Console.WriteLine("Адрес электронной почты введено не правильно!");






            //__________________________3_______________________________________________
            //Написать приложение, проверяющее с помощью регулярного
            //  выражения корректность ввода даты в формате Число-МесяцГод(например, 01 - 04 - 2015)
            //__________________________________________________________________________

            Console.WriteLine("Введите дату в формате Число-Месяц-Год(например, 01 - 04 - 2015)");
            string Input3 = Console.ReadLine();
            string pattern3 = @"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-\d{4}$";
            Regex regex3 = new Regex(pattern3);
            //Дни
            //0[1-9] Первая 0, вторая от 1 до 9 -> примерчик 05
            //|[12][0-9] или первая 1 или 2 , вторая от 0 до 9  -> примерчик 15
            //|3[01] первая 3 ,вторая 1 или 0 -> примерчик 31 
            //- дефис
            //Месяці
            //0[1-9] Первая 0, вторая от 1 до 9  -> примерчик 05
            //|1[0-2] Первая 1,втора от 0 до 2  -> примерчик 12 
            //- дефис
            //Год
            //\d  любая цифра (0-9)  //Оля спрашивала проверки на даты кроме высокосного года ибо там не надо 
            //{4} количество
            if (regex3.IsMatch(Input3))
                Console.WriteLine("Время введено правильно!");
            else
                Console.WriteLine("Время введено не правильно!");
        }
    }
}