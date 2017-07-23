using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Автор Матюков Евгений
//Программа демонстрирует работу с классом комплексных чисел
namespace ComplexClass
{
    class Complex
    {
        double im;
        double re;

        public Complex()
        {
            im = 0;
            re = 0;
        }

        public Complex(double re, double im)
        {
            this.im = im;
            this.re = re;
        }

        public Complex Add(Complex x)
        {
            Complex y = new Complex();
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }

        public Complex Sub(Complex x)
        {
            Complex y = new Complex();
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }

        public Complex Mul(Complex x)
        {
            Complex y = new Complex();
            y.im = im * x.im + re * x.im;
            y.re = re * x.im - im * x.re;
            return y;
        }

        public double Im
        {
            get
            {
                return im;
            }

            set
            {
                im = value;
            }
        }

        public double Re
        {
            get 
            { 
                return re; 
            }
            set
            {
                re = value;
            }
        }

        public string ToStr()
        {
            if (im < 0) return re + "" + im + "i";
            return re + "+" + im + "i";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Complex a = new Complex(1,2); //пример задания значения через конструктор
            Complex b = new Complex();

            b.Re = 3; //пример задания значения с помощью set {}
            b.Im = 4; 

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
