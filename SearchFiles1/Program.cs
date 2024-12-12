using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpApplication.SearchInFiles
{
    // Класс для поиска текста в файлах, заданных DOS'вской маской
    class Search
    {
        /*
         class Directory https://msdn.microsoft.com/ru-ru/library/system.io.directory(v=vs.110).aspx
         class DirectoryInfo https://msdn.microsoft.com/ru-ru/library/system.io.directoryinfo(v=vs.110).aspx
         class File https://learn.microsoft.com/ru-ru/dotnet/api/system.io.file?view=net-6.0
         class FileInfo https://msdn.microsoft.com/ru-ru/library/system.io.fileinfo(v=vs.110).aspx
         */
        static void Main()
        {
            Console.Write("Введите путь к каталогу: ");
            string Path = Console.ReadLine();
            Console.Write("Введите маску для файлов: ");
            string Mask = Console.ReadLine();


            Console.Write("Введите начальную дату (yyyy-mm-dd): ");
            DateTime start;
            start = DateTime.Parse(Console.ReadLine());



            Console.Write("Введите конечную дату (yyyy-mm-dd): ");
            DateTime end;
            end = DateTime.Parse(Console.ReadLine());


            //Console.Write("Введите текст для поиска в файлах: ");
            //string Text = Console.ReadLine();

            // Дописываем слэш (в случае его отсутствия)
            if (Path[Path.Length - 1] != '\\')
                Path += '\\';

            // Создание объекта на основе введенного пути
            DirectoryInfo di = new DirectoryInfo(Path);
            // Если путь не существует
            if (!di.Exists)
            {
                Console.WriteLine("Некорректный путь!!!");
                return;
            }

            // Преобразуем введенную маску для файлов 
            // в регулярное выражение

            // Заменяем . на \.
            Mask = Mask.Replace(".", @"\.");
            // Заменяем ? на .
            Mask = Mask.Replace("?", "."); // ????.txt  ....\.txt
            // Заменяем * на .*
            Mask = Mask.Replace("*", ".*");// *.txt   .*\.txt
            // Указываем, что требуется найти точное соответствие маске
            Mask = "^" + Mask + "$";

            // Создание объекта регулярного выражения
            // на основе маски
            Regex regMask = new Regex(Mask, RegexOptions.IgnoreCase);

            // Экранируем спецсимволы во введенном тексте
            //Text = Regex.Escape(Text);
            // Создание объекта регулярного выражения
            // на основе текста
            //Regex regText = Text.Length == 0 ? null : new Regex(Text, RegexOptions.IgnoreCase);
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter("../../../Data/group.txt", false);

                // Вызываем функцию поиска
                ulong Count = FindFilesByDate(start, end, di, regMask, sw);
                Console.WriteLine("Всего обработано файлов: {0}.", Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sw.Close();
               
            }
        }   

        // Функция поиска
        static ulong FindFilesByDate(DateTime start, DateTime end, DirectoryInfo di, Regex regMask, StreamWriter sw)
        {
            // Поток для чтения из файла
            //StreamReader sr = null;
            // Список найденных совпадений
            //MatchCollection mc = null;

            // Количество обработанных файлов
            ulong CountOfMatchFiles = 0;

            FileInfo[] fi = null;
            try
            {
                // Получаем список файлов
                fi = di.GetFiles();
            }
            catch
            {
                return CountOfMatchFiles;
            }

            // Перебираем список файлов
            foreach (FileInfo f in fi)
            {
                // Если файл соответствует маске
                if (regMask.IsMatch(f.Name) && f.LastWriteTime >= start &&
                        f.LastWriteTime <= end)
                {
                    // Увеличиваем счетчик
                    ++CountOfMatchFiles;
                    string res = "File: " + f.Name + " Дата последней модификации: " + f.LastWriteTime;
                    Console.WriteLine(res);
                    sw.WriteLine(res);



                    //if (regText != null)
                    //{
                    //    try
                    //    {
                    //        // Открываем файл
                    //        sr = new StreamReader(di.FullName + @"\" + f.Name,
                    //            Encoding.Default);
                    //        // Считываем целиком
                    //        string Content = sr.ReadToEnd();
                    //        // Закрываем файл
                    //        sr.Close();
                    //        // Ищем заданный текст
                    //        mc = regText.Matches(Content);
                    //        // Перебираем список вхождений
                    //        foreach (Match m in mc)
                    //        {
                    //            Console.WriteLine("Текст найден в позиции {0}.", m.Index);
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        Console.WriteLine(ex.Message);
                    //    }
                    //}
                }
            }

            // Получаем список подкаталогов
            DirectoryInfo[] diSub = di.GetDirectories();
            // Для каждого из них вызываем (рекурсивно)
            // эту же функцию поиска
            foreach (DirectoryInfo diSubDir in diSub)
                CountOfMatchFiles += FindFilesByDate(start, end, diSubDir, regMask, sw);

            // Возврат количества обработанных файлов
            return CountOfMatchFiles;
        }
    }
}