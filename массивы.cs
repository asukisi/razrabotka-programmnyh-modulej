using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Запуск задач
        Task1();
        Task2();
        Task3();
    }

    // Задача 1: Работа с одномерным массивом
    static void Task1()
    {
        Console.WriteLine("\n=== Задача 1: Работа с одномерным массивом ===");

        // Создаем массив из 10 элементов со случайными значениями от 1 до 100
        int[] array = new int[10];
        Random random = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 101); // Генерация случайного числа от 1 до 100
        }

        // Вывод исходного массива
        Console.WriteLine("Исходный массив: " + string.Join(", ", array));

        // Находим максимальный, минимальный элементы, среднее значение и сумму
        int max = array.Max();
        int min = array.Min();
        double average = array.Average();
        int sum = array.Sum();

        // Вывод результатов
        Console.WriteLine($"Максимальный элемент: {max}");
        Console.WriteLine($"Минимальный элемент: {min}");
        Console.WriteLine($"Среднее значение: {average:F2}");
        Console.WriteLine($"Сумма элементов: {sum}");

        // Меняем местами максимальный и минимальный элементы
        int maxIndex = Array.IndexOf(array, max);
        int minIndex = Array.IndexOf(array, min);
        array[maxIndex] = min;
        array[minIndex] = max;

        // Вывод измененного массива
        Console.WriteLine("Измененный массив: " + string.Join(", ", array));
    }

    // Задача 2: Работа с двумерным массивом
    static void Task2()
    {
        Console.WriteLine("\n=== Задача 2: Работа с двумерным массивом ===");

        // Создаем двумерный массив 5x5 со случайными значениями от 1 до 100
        int[,] matrix = new int[5, 5];
        Random random = new Random();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                matrix[i, j] = random.Next(1, 101); // Генерация случайного числа
            }
        }

        // Вывод исходного массива
        Console.WriteLine("Исходный массив:");
        PrintMatrix(matrix);

        // Поиск максимального элемента в каждой строке и минимального в каждом столбце
        Console.WriteLine("Максимальные элементы в каждой строке:");
        for (int i = 0; i < 5; i++)
        {
            int maxInRow = Enumerable.Range(0, 5).Max(j => matrix[i, j]);
            Console.WriteLine($"Строка {i + 1}: {maxInRow}");
        }

        Console.WriteLine("Минимальные элементы в каждом столбце:");
        for (int j = 0; j < 5; j++)
        {
            int minInColumn = Enumerable.Range(0, 5).Min(i => matrix[i, j]);
            Console.WriteLine($"Столбец {j + 1}: {minInColumn}");
        }

        // Среднее значение элементов в каждой строке
        Console.WriteLine("Средние значения в каждой строке:");
        for (int i = 0; i < 5; i++)
        {
            double averageInRow = Enumerable.Range(0, 5).Average(j => matrix[i, j]);
            Console.WriteLine($"Строка {i + 1}: {averageInRow:F2}");
        }

        // Сумма элементов в каждом столбце
        Console.WriteLine("Сумма элементов в каждом столбце:");
        for (int j = 0; j < 5; j++)
        {
            int sumInColumn = Enumerable.Range(0, 5).Sum(i => matrix[i, j]);
            Console.WriteLine($"Столбец {j + 1}: {sumInColumn}");
        }

        // Меняем местами строки с максимальной и минимальной суммой элементов
        int maxSumRow = 0, minSumRow = 0;
        int maxSum = int.MinValue, minSum = int.MaxValue;

        for (int i = 0; i < 5; i++)
        {
            int rowSum = Enumerable.Range(0, 5).Sum(j => matrix[i, j]);
            if (rowSum > maxSum)
            {
                maxSum = rowSum;
                maxSumRow = i;
            }
            if (rowSum < minSum)
            {
                minSum = rowSum;
                minSumRow = i;
            }
        }

        // Перестановка строк
        for (int j = 0; j < 5; j++)
        {
            int temp = matrix[maxSumRow, j];
            matrix[maxSumRow, j] = matrix[minSumRow, j];
            matrix[minSumRow, j] = temp;
        }

        // Вывод измененного массива
        Console.WriteLine("Измененный массив:");
        PrintMatrix(matrix);
    }

    // Вспомогательный метод для вывода двумерного массива
    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }
    }

    // Задача 3: Работа с циклами
    static void Task3()
    {
        Console.WriteLine("\n=== Задача 3: Работа с циклами ===");

        // Таблица умножения от 1 до 10
        Console.WriteLine("Таблица умножения:");
        for (int i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= 10; j++)
            {
                Console.Write($"{i * j,4}");
            }
            Console.WriteLine();
        }

        // Вычисление факториала числа, введенного пользователем
        Console.Write("\nВведите число для вычисления факториала: ");
        if (int.TryParse(Console.ReadLine(), out int number) && number >= 0)
        {
            long factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }
            Console.WriteLine($"Факториал числа {number}: {factorial}");
        }
        else
        {
            Console.WriteLine("Введено некорректное значение.");
        }
    }
}
