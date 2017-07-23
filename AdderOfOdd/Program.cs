using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Автор Матюков Евгений
//Программа суммирует все положительные нечетные числа пока не будет введен 0
namespace AdderOfOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа суммирует все положительные нечётные числа");

            string str;
            int number, sumOfOdd = 0;
            bool numIsCorrect;

            do
            {
                Console.Write("Введите целое число или 0 для завершения: ");

                do
                {
                    str = Console.ReadLine();
                    numIsCorrect = int.TryParse(str, out number);
                    if (!numIsCorrect) Console.Write("Ошибка ввода. Попробуйте ещё раз: ");
                } while (!numIsCorrect);

                if (number % 2 > 0) sumOfOdd += number;
            } while (number != 0);

            Console.WriteLine("\nСумма всех нечетных положительных чисел: " + sumOfOdd);
            Console.ReadKey();
        }
    }
}
