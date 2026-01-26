using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _26._01_пракимческая_работа
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "ПервоеЗадание.txt";

            Console.WriteLine("Создаем файл с данными об мне...");

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("-Меня зовут Дина");
                writer.WriteLine("-Мне 17 лет");
                writer.WriteLine("-Я слушаю вайперр");
                writer.WriteLine("-Мое хобби - музыка");
                writer.WriteLine("-Мечтаю работать из дома");
            }
            Console.WriteLine("Файл создан. Исходное содержимое:");

            using (StreamReader reader = new StreamReader(fileName))
            {
                Console.WriteLine(reader.ReadToEnd());
            }

            //вывод строк с счетчиком в начале
            using (StreamReader reader = new StreamReader(fileName))
            {
                int lineNumber = 1;
                string line;
                //читаем пока не достигнем конца 
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"Строка {lineNumber}: {line}.");
                    lineNumber++;
                }
            }
            //общее кол-во строк в файле
            int lineCount = 0;
                using (StreamReader reader = new StreamReader(fileName))
                {
                    while (reader.ReadLine() != null)
                    {
                        lineCount++;
                    }
                }

                Console.WriteLine($"\nВ файле найдено строк: {lineCount}");
            
        }
    }
}
