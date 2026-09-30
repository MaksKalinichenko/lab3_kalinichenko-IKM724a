using System;
using System.Text;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("=== Лабораторна робота №3, варіант 6 ===");
                Console.WriteLine("1 - Найбільший спільний дільник (НСД) двох чисел");
                Console.WriteLine("2 - Видалення повторюваних елементів з масиву");
                Console.WriteLine("0 - Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Task1();
                        break;
                    case "2":
                        Task2();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                        break;
                }
            }
        }

        // Завдання 1
        static void Task1()
        {
            Console.WriteLine("\n--- Завдання 1: НСД двох чисел ---");

            Console.WriteLine("Введіть перше ціле число:");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Введіть друге ціле число:");
            int b = int.Parse(Console.ReadLine());

            if (a == 0 && b == 0)
            {
                Console.WriteLine("НСД для двох нулів не визначений.");
                return;
            }

            int x = Math.Abs(a);
            int y = Math.Abs(b);

            while (y != 0)
            {
                int temp = y;
                y = x % y;
                x = temp;
            }

            Console.WriteLine($"НСД({a}, {b}) = {x}");
        }

        // Завдання 2
        static void Task2()
        {
            Console.WriteLine("\n--- Завдання 2: видалення повторюваних елементів ---");

            Console.WriteLine("Введіть кількість елементів масиву:");
            int n = int.Parse(Console.ReadLine());

            if (n <= 0)
            {
                Console.WriteLine("Розмір масиву має бути більшим за 0.");
                return;
            }

            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Елемент [{i}]: ");
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Початковий масив: ");
            PrintArray(array, array.Length);

            int[] temp = new int[n];
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                bool exists = false;

                for (int j = 0; j < count; j++)
                {
                    if (temp[j] == array[i])
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    temp[count] = array[i];
                    count++;
                }
            }

            int[] result = new int[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = temp[i];
            }

            Console.Write("Масив без повторів: ");
            PrintArray(result, result.Length);
            Console.WriteLine($"Видалено елементів: {n - count}");
        }

        static void PrintArray(int[] arr, int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}