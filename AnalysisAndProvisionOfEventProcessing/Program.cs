using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisAndProvisionOfEventProcessing
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                // Запрос чисел у пользователя
                Console.Write("Введите первое число: ");
                int num1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите второе число: ");
                int num2 = Convert.ToInt32(Console.ReadLine());

                // Выполнение деления
                int result = Divide(num1, num2);
                Console.WriteLine($"Результат деления: {result}");

                // Запись результата в файл
                WriteResultToFile(result);
            }
            catch (FormatException ex)
            {
                // Логируем ошибку, выводим подробности
                Console.WriteLine($"Ошибка: Введите корректные числа. {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                // Логируем ошибку деления на ноль
                Console.WriteLine($"Ошибка: Деление на ноль. {ex.Message}");
            }
            catch (IOException ex)
            {
                // Логируем ошибку записи в файл
                Console.WriteLine($"Ошибка записи в файл: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Логируем любые другие ошибки
                Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Программа завершена.");
            }
        }

        // Метод для деления
        static int Divide(int num1, int num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Невозможно делить на ноль.");
            }
            return num1 / num2;
        }

        // Метод для записи результата в файл
        static void WriteResultToFile(int result)
        {
            string path = "result.txt";
            try
            {
                File.WriteAllText(path, $"Результат деления: {result}");
                Console.WriteLine($"Результат успешно записан в файл {path}.");
            }
            catch (IOException ex)
            {
                // Логируем ошибку записи в файл
                throw new IOException("Ошибка при записи в файл.", ex);
            }
            Console.ReadLine();
        }
    }
}
