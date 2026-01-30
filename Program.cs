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
                using (StreamWriter writer = new StreamWriter(FileName, true))
                {
                    writer.WriteLine(record);
                }

                Console.WriteLine("Запись добавлена!");

                // Динамический массив
                List<string> lines = new List<string>();

                // Чтение файла в List
                using (StreamReader reader = new StreamReader(FileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
           Console.WriteLine("\nПоследние 3 записи:");

            // Вывод 3 записей: определяем, сколько записей у нас есть
            int total = lines.Count;
            Console.WriteLine($"Всего записей в дневнике: {total}");


            // определяем, сколько записей показывать (не более 3)
            int recordsToShow = 3;
            if (total < 3)
            {
                recordsToShow = total;  // Если меньше 3, показываем все
            }

            Console.WriteLine($"Показываем {recordsToShow} последних записей:");
            Console.WriteLine("(самые новые - сверху)");

            // 3. Выводим в обратном порядке
            for (int i = 0; i < recordsToShow; i++)

            {
                // Рассчитываем номер записи для вывода
                int recordNumber = recordsToShow - i;  // 3, 2, 1 для отображения
   
                // Рассчитываем индекс в списке (идем с конца)
                int listIndex = total - 1 - i;  // Самые новые = большие индексы
                Console.WriteLine($"{recordNumber}. {lines[listIndex]}");
            }



            // 4 задание конвертер текста
            string fileSource = "C:\\Users\\242416\\Documents\\4задание\\исходный.txt";
            string fileResult = "C:\\Users\\242416\\Documents\\4задание\\обработанный.txt";

            int countBefore = 0;
            int countAfter = 0;
            List<string> result = new List<string>();

            // Читаем файл через StreamReader
            using (StreamReader reader = new StreamReader(fileSource))
            {
                string line;
                int num = 1;

                while ((line = reader.ReadLine()) != null)
                {
                    countBefore++;  // Считаем все строки
                    // Обработка: если строка не пустая (после удаления пробелов)
                    if (line.Trim() != "")
                    {
                        // Добавляем номер и переводим в верхний регистр
                        result.Add($"{num}. {line.ToUpper()}");
                        num++;
                    }
                }
    
                countAfter = result.Count;  // Сколько строк осталось после обработки
            }

            using (StreamWriter writer = new StreamWriter(fileResult))
            {
                foreach (string processedLine in result)
                {
                    writer.WriteLine(processedLine);  // Записываем каждую обработанную строку
                }
            }

            // Статистика
            Console.WriteLine($"Строк до обработки: {countBefore}");
            Console.WriteLine($"Строк после обработки: {countAfter}");
            Console.WriteLine($"Удалено пустых строк: {countBefore - countAfter}");
            Console.WriteLine("\nПервые 3 строки результата:");

            // Выводим первые 3 строки результата
            int linesToShow = Math.Min(3, result.Count);  // На случай, если строк меньше 3
            for (int i = 0; i < linesToShow; i++)
            {
                Console.WriteLine(result[i]);
            }
            
        }
    }
}
