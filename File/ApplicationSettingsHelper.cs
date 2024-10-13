using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSharp.Classes;
using System;
using System.Threading;
using System.Drawing;


namespace CSharp.Classes
{
    class ApplicationSettingsHelper
    {

        private string title = "The title has changed!";
        private int width = 50;
        private int height = 30;
        private ConsoleColor backgroundColor = ConsoleColor.Black;
        private ConsoleColor foregroundColor = ConsoleColor.White;


        public string Title
        {
            get 
            {
                return title; 
            }
            set 
            { 
                title = value; 
            }
        }

        public int Width
        {
            get
            { 
                return width; 
            }
            set
            {
                if (value < 0) 
                    throw new ArgumentOutOfRangeException("Width must be > 1");
                width = value;
            }
        }

        public int Height
        {
            get 
            {
                return height;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Height must be > 1");
                height = value;
            }
        }

        public ConsoleColor BackgroundColor
        {
            get 
            { 
                return backgroundColor; 
            }
            set 
            {
                backgroundColor = value;
            }
        }

        public ConsoleColor ForegroundColor
        {
            get
            {
                return foregroundColor;
            }
            set
            {
                foregroundColor = value;
            }
        }

        public void LoadSettings(string path)
        {
            StreamReader sr = new StreamReader(path);

            try
            {
                Title = sr.ReadLine();
                Width = Convert.ToInt32(sr.ReadLine());
                Height = Convert.ToInt32(sr.ReadLine());

                string inputB = sr.ReadLine();
                string inputF = sr.ReadLine();
                
                  
                if (inputB == "Blue")
                {
                    BackgroundColor = ConsoleColor.Blue;
                }
                else if (inputB == "Yellow")
                {
                    BackgroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    BackgroundColor = ConsoleColor.Black;
                }


                if (inputF == "Blue")
                {
                    ForegroundColor = ConsoleColor.Blue;
                }
                else if (inputF == "Yellow")
                {
                    ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    ForegroundColor = ConsoleColor.White;
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

        public void SaveSettings(string path)
        {
            StreamWriter sw = new StreamWriter(path, false);
            try
            {

                sw.WriteLine(Title);
                sw.WriteLine(Width);
                sw.WriteLine(Height);
                sw.WriteLine(BackgroundColor);
                sw.WriteLine(ForegroundColor);
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


    }

}