using System;

class Program
{
    static int ReadNumber(int start, int end)
    {
        int number;
        if (int.TryParse(Console.ReadLine(), out number))
        {
            if (number >= start && number <= end)
            {
                return number;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Число не знаходиться в дiапазонi [start...end].");
            }
        }
        else
        {
            throw new FormatException("Введено недiйсне число.");
        }
    }

    static void Main(string[] args)
    {
        int start = 1;
        int end = 100;

        int[] numbers = new int[10];
        for (int i = 0; i < 10; i++)
        {
            try
            {
                Console.Write($"Введiть число {i + 1}: ");
                numbers[i] = ReadNumber(start, end);

                if (i > 0 && numbers[i] <= numbers[i - 1])
                {
                    Console.WriteLine("Число має бути бiльшим за попереднє.");
                    i--;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
                i--;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
                i--;
            }
        }

        Console.WriteLine("Введенi числа:");
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
