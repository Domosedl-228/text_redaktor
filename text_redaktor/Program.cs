using System;
using System.IO;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Создать новый файл");
            Console.WriteLine("2. Открыть файл");
            Console.WriteLine("3. Редактировать файл");
            Console.WriteLine("4. Сохранить файл");
            Console.WriteLine("5. Выход");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Неверный ввод. Попробуйте снова.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateNewFile();
                    break;
                case 2:
                    OpenFile();
                    break;
                case 3:
                    EditFile();
                    break;
                case 4:
                    SaveFile();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static string currentFileName = null;
    static string currentFileContent = null;

    static void CreateNewFile()
    {
        Console.Write("Введите имя нового файла: ");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            Console.WriteLine("Файл с таким именем уже существует.");
            return;
        }

        currentFileName = fileName;
        currentFileContent = "";
        Console.WriteLine($"Файл {fileName} создан.");
    }

    static void OpenFile()
    {
        Console.Write("Введите имя файла для открытия: ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }

        currentFileName = fileName;
        currentFileContent = File.ReadAllText(fileName);
        Console.WriteLine($"Файл {fileName} открыт.");
    }

    static void EditFile()
    {
        if (currentFileName == null)
        {
            Console.WriteLine("Файл не выбран. Выберите или создайте файл сначала.");
            return;
        }

        Console.WriteLine("Введите текст для редактирования (для завершения редактирования введите 'exit'): ");
        string newText = Console.ReadLine();

        while (newText != "exit")
        {
            currentFileContent += newText + Environment.NewLine;
            newText = Console.ReadLine();
        }
    }

    static void SaveFile()
    {
        if (currentFileName == null)
        {
            Console.WriteLine("Файл не выбран. Выберите или создайте файл сначала.");
            return;
        }

        File.WriteAllText(currentFileName, currentFileContent);
        Console.WriteLine($"Файл {currentFileName} сохранен.");
    }
}