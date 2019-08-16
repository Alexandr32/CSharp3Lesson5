using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp3Lesson5
{
    /// <summary>
    /// Класс для передачи введенного числа
    /// </summary>
    class NumberEntered
    {
        public int Number { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
            {
                NumberEntered numberEntered = new NumberEntered
                {
                    Number = number
                };

                Thread threadFactorial = new Thread(new ParameterizedThreadStart(Factorial));
                threadFactorial.Start(numberEntered);

                Thread threadSum = new Thread(new ParameterizedThreadStart(Sum));
                threadSum.Start(numberEntered);
            }
            else
            {
                Console.WriteLine("Введено не правильное значение");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Сумма натуральных чисел
        /// </summary>
        /// <param name="objNumb"></param>
        static void Sum(object objNumb)
        {

            if (objNumb is NumberEntered numb)
            {
                int n = numb.Number;
                int sum = 1;   // значение суммы

                for (int i = 2; i <= n; i++) // цикл начинаем с 2, т.к. нет смысла начинать с 1
                {
                    sum += i;
                }
                Console.WriteLine("Сумма чисел: " + sum);
            }
        }
        /// <summary>
        /// Факториал
        /// </summary>
        /// <param name="objNumb"></param>
        static void Factorial(object objNumb)
        {
            
            if (objNumb is NumberEntered numb)
            {
                int n = numb.Number;
                int factorial = 1;   // значение факториала

                for (int i = 2; i <= n; i++) // цикл начинаем с 2, т.к. нет смысла начинать с 1
                {
                    factorial *= i;
                }
                Console.WriteLine("Факториал числа: " + factorial);
            }
        }
    }
}
