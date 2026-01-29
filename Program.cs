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

              //2 задание дневник настроений

                string FileName = "C:\\Users\\242416\\Desktop\\Документы\\Дневник.txt";

                Console.WriteLine("ДНЕВНИК НАСТРОЕНИЙ");
                Console.WriteLine($"Сегодня {DateTime.Now}");

                // Ввод данных
                Console.Write("Оцените настроение (1-5): ");
                string mood = Console.ReadLine();

                Console.Write("Введите комментарий: ");
                string comment = Console.ReadLine();

                string record = $"[{DateTime.Now}] Настроение: {mood}/5 - {comment}";

                // Запись в файл
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    writer.WriteLine(record);
                }

                Console.WriteLine("Запись добавлена!");

                // Динамический массив
                List<string> lines = new List<string>();

                // Чтение файла в List
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
             // Вывод последних 3 записей
            Console.WriteLine("\Последние 3 записи:");

            int start = lines.Count - 3;
            if (start < 0)
                start = 0;

            int number = 1;
            for (int i = lines.Count - 1; i >= start; i--)
            {
                Console.WriteLine($"{number}. {lines[i]}");
                number++;
            }



            //4 задание конвертер текста


            string fileSource = "C:\\Users\\242416\\Desktop\\Документы\\исходный.txt";

            string fileResult = "C:\\Users\\242416\\Desktop\\Документы\\обработанный.txt";


            // Читаем файл

            string[] lines = File.ReadAllLines(fileSource);

            int countBefore = lines.Length;


            // Обработка

            List<string> result = new List<string>();

            int num = 1;

            for (int i = 0; i < lines.Length; i++)

            {
   
                if (lines[i].Trim() != "")
    
                {
        
                    result.Add($"{num}. {lines[i].ToUpper()}");
        
                    num++;
    
                }

            }


            // Сохраняем

            File.WriteAllLines(fileResult, result);


            // Статистика

            Console.WriteLine($"Строк до: {countBefore}");

            Console.WriteLine($"Строк после: {result.Count}");

            Console.WriteLine("\nПервые 3 строки:");

            for (int i = 0; i < 3 && i < result.Count; i++)

            {

                Console.WriteLine(result[i]);

            }
            
        }
    }
}
