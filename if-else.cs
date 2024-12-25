using System;

class Program
{
    static void Main()
    {
        // Запуск частей программы
        AgeCategoryProgram();
        TriangleProgram();
    }

    // Часть 1: Конструкции if-else
    static void AgeCategoryProgram()
    {
        Console.WriteLine("\n=== Часть 1: Определение категории возраста ===");

        while (true)
        {
            Console.Write("\nВведите возраст (или 'exit' для выхода): ");
            string input = Console.ReadLine();

            // Проверка команды выхода
            if (input.ToLower() == "exit") break;

            // Проверка корректности ввода
            if (!int.TryParse(input, out int age) || age < 0)
            {
                Console.WriteLine("Ошибка: введите корректное целое число.");
                continue;
            }

            // Определение категории возраста
            if (age <= 12)
            {
                Console.WriteLine("Категория: Детство");
                AskAboutSchool();
            }
            else if (age <= 19)
            {
                Console.WriteLine("Категория: Подростковый возраст");
                AskAboutSchool();
            }
            else if (age <= 39)
            {
                Console.WriteLine("Категория: Молодость");
            }
            else if (age <= 64)
            {
                Console.WriteLine("Категория: Средний возраст");
            }
            else
            {
                Console.WriteLine("Категория: Старость");
            }
        }
    }

    // Метод для запроса обучения в школе
    static void AskAboutSchool()
    {
        Console.Write("Человек учится в школе? (да/нет): ");
        string response = Console.ReadLine()?.ToLower();

        if (response == "да" || response == "yes")
        {
            Console.WriteLine("Человек учится в школе.");
        }
        else if (response == "нет" || response == "no")
        {
            Console.WriteLine("Человек не учится в школе.");
        }
        else
        {
            Console.WriteLine("Некорректный ответ.");
        }
    }

    // Часть 2: Тернарные операции
    static void TriangleProgram()
    {
        Console.WriteLine("\n=== Часть 2: Проверка треугольника ===");

        while (true)
        {
            Console.Write("\nВведите длины сторон треугольника (или 'exit' для выхода): ");
            string input = Console.ReadLine();

            // Проверка команды выхода
            if (input.ToLower() == "exit") break;

            // Парсинг сторон треугольника
            string[] parts = input.Split();
            if (parts.Length != 3 || 
                !int.TryParse(parts[0], out int a) || 
                !int.TryParse(parts[1], out int b) || 
                !int.TryParse(parts[2], out int c) || 
                a <= 0 || b <= 0 || c <= 0)
            {
                Console.WriteLine("Ошибка: введите три положительных целых числа.");
                continue;
            }

            // Проверка возможности существования треугольника
            bool canFormTriangle = a + b > c && a + c > b && b + c > a;
            string triangleMessage = canFormTriangle
                ? "Треугольник можно образовать."
                : "Треугольник нельзя образовать.";
            Console.WriteLine(triangleMessage);

            if (canFormTriangle)
            {
                // Определение типа треугольника
                string triangleType = (a == b && b == c)
                    ? "Равносторонний треугольник."
                    : (a == b || a == c || b == c)
                        ? "Равнобедренный треугольник."
                        : "Разносторонний треугольник.";
                Console.WriteLine($"Тип треугольника: {triangleType}");
            }
        }
    }
}
