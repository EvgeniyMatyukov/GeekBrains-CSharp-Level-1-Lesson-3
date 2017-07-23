using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Автор Матюков Евгений
//Программа демонстрирует работу структуры комплексных чисел;


namespace complex
{
    class Program
    {
        struct Complex
        {
            public double im;
            public double re;

            public Complex Add(Complex x)
            {
                Complex y;
                y.im = im + x.im;
                y.re = re + x.re;
                return y;
            }

            public Complex Sub(Complex x)
            {
                Complex y;
                y.im = im - x.im;
                y.re = re - x.re;
                return y;
            }

            public Complex Mul(Complex x)
            {
                Complex y;
                y.im = im * x.im + re * x.im;
                y.re = re * x.im - im * x.re;
                return y;
            }

            public string ToStr()
            {
                if (im < 0) return re + "" + im + "i";
                return re + "+" + im + "i";
            }
        }

        static void Main(string[] args)
        {

            Complex a, b;

            a.re = 1;
            a.im = 2;

            b.re = 3;
            b.im = 4;

            Console.Write("Сумма комплексных чисел {0} и {1} = ", a.ToStr(), b.ToStr());
            Console.WriteLine(a.Add(b).ToStr());

            Console.Write("\nРазность комплексных чисел {0} и {1} = ", a.ToStr(), b.ToStr());
            Console.WriteLine(a.Sub(b).ToStr());

            Console.Write("\nПроизведение комплексных чисел {0} и {1} = ", a.ToStr(), b.ToStr());
            Console.WriteLine(a.Mul(b).ToStr());

            Console.ReadKey();

        }
    }
}
