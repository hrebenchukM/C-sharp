using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace CSharpApplication.SearchInFiles2
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
            while (true)
            {
                Console.Write("Введите путь к каталогу: ");
                string Path = Console.ReadLine();
                Console.Write("Введите маску для файлов: ");
                string Mask = Console.ReadLine();





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

                try
                {
                    int fIndex = 0;

                    // Вызываем функцию поиска
                    ulong Count = FindFiles(di, regMask, ref fIndex);
                    Console.WriteLine("Всего обработано файлов: {0}.", Count);
                    if (Count > 0)
                    {

                        Console.WriteLine("Выберите действие:");
                        Console.WriteLine("1. Удалить все найденные файлы");
                        Console.WriteLine("2. Удалить указанный файл");
                        Console.WriteLine("3. Удалить диапазон файлов");
                        Console.Write("Ваш выбор: ");

                        string choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                ulong deletedCount = DeleteAllFiles(di, regMask);
                                break;

                            case "2":
                                Console.Write("Введите индекс файла для удаления: ");
                                int i = int.Parse(Console.ReadLine());
                                fIndex = 0;
                                ulong deletedFile = DeleteOneFile(di, regMask, ref fIndex, i);
                                if (deletedFile > 0)
                                {
                                    Console.WriteLine("Файл с индексом " + i + " успешно удалён.");
                                }
                                else
                                {
                                    Console.WriteLine("Файл с индексом " + i + " не найден.");
                                }
                                break;


                            case "3":
                                Console.Write("Введите начальный индекс для удаления: ");
                                int start = int.Parse(Console.ReadLine());
                                Console.Write("Введите конечный индекс для удаления: ");
                                int end = int.Parse(Console.ReadLine());


                                fIndex = 0;
                                ulong deletedFiles = DeleteFileRange(di, regMask, ref fIndex, start, end);
                                Console.WriteLine("Удалено файлов в диапазоне индексов {0}-{1}: {2}.", start, end, deletedFiles);


                                break;


                            default:
                                Console.WriteLine("Некорректный выбор.");
                                break;
                        }


                    }
                    else
                    {
                        Console.WriteLine("Файлы, по маске, не найдены.");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                Console.Write("Хотите заново? (1-да/0-нет): ");
                int repeat = int.Parse(Console.ReadLine());
                if (repeat == 0)
                {
                    break; 
                }
            }
        }


        // Функция поиска
        static ulong FindFiles(DirectoryInfo di, Regex regMask, ref int fIndex)
        {
           
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
                if (regMask.IsMatch(f.Name))
                {
                    ++fIndex;
                    // Увеличиваем счетчик
                    ++CountOfMatchFiles;
                    string res = fIndex + ") File: " + f.Name;
                    Console.WriteLine(res);
                
                   
                }
            }

            // Получаем список подкаталогов
            DirectoryInfo[] diSub = di.GetDirectories();
            // Для каждого из них вызываем (рекурсивно)
            // эту же функцию поиска
            foreach (DirectoryInfo diSubDir in diSub)
                CountOfMatchFiles += FindFiles(diSubDir, regMask,  ref fIndex);

            // Возврат количества обработанных файлов
            return CountOfMatchFiles;
        }



      
        static ulong DeleteAllFiles(DirectoryInfo di, Regex regMask)
        {

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
                if (regMask.IsMatch(f.Name))
                {
                    f.Delete();
                    // Увеличиваем счетчик
                    ++CountOfMatchFiles;
                    string res = "Deleted file: " + f.Name;
                    Console.WriteLine(res);


                }
            }

            // Получаем список подкаталогов
            DirectoryInfo[] diSub = di.GetDirectories();
            // Для каждого из них вызываем (рекурсивно)
            // эту же функцию поиска
            foreach (DirectoryInfo diSubDir in diSub)
                CountOfMatchFiles += DeleteAllFiles(diSubDir, regMask);

            // Возврат количества обработанных файлов
            return CountOfMatchFiles;
        }



        static ulong DeleteOneFile(DirectoryInfo di, Regex regMask, ref int fIndex, int i)
        {

            // Количество обработанных файлов
            ulong countOfDeletedFiles = 0;


            FileInfo[] fi = null;
            try
            {
                // Получаем список файлов
                fi = di.GetFiles();
            }
            catch
            {
                return countOfDeletedFiles;
            }


            // Перебираем список файлов
            foreach (FileInfo f in fi)
            {
                // Если файл соответствует маске
                if (regMask.IsMatch(f.Name))
                {
                    ++fIndex;

                    if (fIndex == i)
                    {
                        try
                        {
                            f.Delete();
                            Console.WriteLine("Deleted file: "+ f.Name);
                            ++countOfDeletedFiles;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error deleting file {0}: {1}", f.Name, ex.Message);
                        }

                        return countOfDeletedFiles; 
                    }
                }
            }

      

            // Получаем список подкаталогов
            DirectoryInfo[] diSub = di.GetDirectories();
            // Для каждого из них вызываем (рекурсивно)
            // эту же функцию поиска
            foreach (DirectoryInfo diSubDir in diSub)
            {
                countOfDeletedFiles += DeleteOneFile(diSubDir, regMask, ref fIndex, i);

                // Если файл уже удалён, выходим из рекурсии
                if (countOfDeletedFiles > 0)
                    break;
            }

            // Возврат количества удалённых файлов
            return countOfDeletedFiles;
        }




        static ulong DeleteFileRange(DirectoryInfo di, Regex regMask, ref int fIndex, int start, int end)
        {
            // Количество обработанных файлов
            ulong countOfDeletedFiles = 0;


            FileInfo[] fi = null;
            try
            {
                // Получаем список файлов
                fi = di.GetFiles();
            }
            catch
            {
                return countOfDeletedFiles;
            }


            // Перебираем список файлов
            foreach (FileInfo f in fi)
            {
                // Если файл соответствует маске
                if (regMask.IsMatch(f.Name))
                {
                    ++fIndex;

                    if (fIndex >= start && fIndex <= end)
                    {
                        try
                        {
                            f.Delete();
                            Console.WriteLine("Deleted file: {0}", f.Name);
                            ++countOfDeletedFiles;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error deleting file {0}: {1}", f.Name, ex.Message);
                        }
                    }
                }
            }

            // Получаем список подкаталогов
            DirectoryInfo[] diSub = di.GetDirectories();
            // Для каждого из них вызываем (рекурсивно)
            // эту же функцию поиска
            foreach (DirectoryInfo diSubDir in diSub)
                countOfDeletedFiles += DeleteFileRange(diSubDir, regMask, ref fIndex, start, end);

            // Возврат количества обработанных файлов
            return countOfDeletedFiles;
        }


    }
}