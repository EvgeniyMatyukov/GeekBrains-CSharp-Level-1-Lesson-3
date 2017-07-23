using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Автор Матюков Евгений
//Программа демонстрирует работу с дробями
namespace fraction
{
    class Fraction
    {
        int whole;          //целое
        int numerator;      //числитель
        int denominator;    //знаменатель

        public Fraction(int whole) //конструктор для целого числа
        {
                this.whole = whole;
                this.numerator = 0;
                this.denominator = 1;
        }

        public Fraction(int numerator, int denominator) //конструктор для числителя и знаменателя
        {
            if (denominator == 0)
            {
                this.whole = 0;
                this.numerator = 0;
                this.denominator = 1;
            }
            else
            {
                if (denominator < 0)
                {
                    numerator *= -1;
                    denominator *= -1;
                }

                this.whole = 0;
                this.numerator = numerator;
                this.denominator = denominator;
            }
        }

        public Fraction(int whole, int numerator, int denominator) //конструктор для целого, числителя и знаменателя
        {
            if (denominator == 0)
            {
                this.whole = 0;
                this.numerator = 0;
                this.denominator = 1;
            }
            else
            {
                if (numerator < 0)
                {
                    whole *= -1;
                    numerator *= -1;
                }

                if (denominator < 0)
                {
                    whole *= -1;
                    denominator *= -1;
                }

                this.whole = whole;
                this.numerator = numerator;
                this.denominator = denominator;
            }
        }

        private int Nod(int a, int b) //рассчитать наибольший общий делитель
        {
            return b != 0 ? Nod(b, a % b) : a;
        }

        public void ToSimplifyFraction() //на входе любая дробь, на выходе упрощенная неправильная дробь
        {
            if (whole > 0)
            {
                numerator += whole * denominator;
            }
            if (whole < 0)
            {
                numerator += -1 * whole * denominator;
                numerator *= -1;
            }
            whole = 0;

            int nod = Nod(numerator, denominator);
            numerator /= nod;
            denominator /= nod;
        }

        private void ToSimplifyFraction(Fraction fr) //на входе любая дробь, на выходе упрощенная неправильная дробь
        {
            if (fr.whole > 0)
            {
                fr.numerator += fr.whole * fr.denominator;
            }
            if (fr.whole < 0)
            {
                fr.numerator += -1 * fr.whole * fr.denominator;
                fr.numerator *= -1;
            }
            fr.whole = 0;

            int nod = Nod(fr.numerator, fr.denominator);
            fr.numerator /= nod;
            fr.denominator /= nod;
        }

        public void ToMixedNumber() //на входе любая дробь, на выходе смешанная дробь
        {
            ToSimplifyFraction(); //упростить дробь

            if (numerator < 0 && denominator < 0)
            {
                numerator *= -1;
                denominator *= -1;
            }

            whole = numerator / denominator;

            if (whole != 0)
            {
                if (numerator < 0) numerator *= -1;
                if (denominator < 0) denominator *= -1;
            }
            else if (denominator < 0)
            {
                denominator *= -1;
                numerator *= -1;
            }
            
            numerator %= denominator;
        }

        private void ToMixedNumber(Fraction fr) //на входе любая дробь, на выходе смешанная дробь
        {
            ToSimplifyFraction(fr); //упростить дробь

            if (fr.numerator < 0 && fr.denominator < 0)
            {
                fr.numerator *= -1;
                fr.denominator *= -1;
            }

            fr.whole = fr.numerator / fr.denominator;

            if (fr.whole != 0)
            {
                if (fr.numerator < 0) fr.numerator *= -1;
                if (fr.denominator < 0) fr.denominator *= -1;
            }
            else if (fr.denominator < 0)
            {
                    fr.denominator *= -1;
                    fr.numerator *= -1;
            }

            fr.numerator %= fr.denominator;
        }

        public Fraction Add(Fraction x) //сложить дроби
        {
           //преобразовать дробь в неправильную и упростить
           ToSimplifyFraction(); 
           ToSimplifyFraction(x);

           Fraction y = new Fraction(numerator * x.denominator + x.numerator * denominator, denominator * x.denominator);

           //преобразовать дробь в смешанную
           ToMixedNumber(y);
           ToMixedNumber(x);
           ToMixedNumber();
           return y;
        }

        public Fraction Sub(Fraction x) //вычесть дроби
        {
            //преобразовать дробь в неправильную и упростить
            ToSimplifyFraction(); //упростить дробь
            ToSimplifyFraction(x); //упростить дробь

            Fraction y = new Fraction(numerator * x.denominator - x.numerator * denominator, denominator * x.denominator);

            //преобразовать дробь в смешанную
            ToMixedNumber(y);
            ToMixedNumber(x);
            ToMixedNumber();
            return y;
        }

        
        public Fraction Mul(Fraction x)
        {
            //преобразовать дробь в неправильную и упростить
            ToSimplifyFraction(); //упростить дробь
            ToSimplifyFraction(x); //упростить дробь

            Fraction y = new Fraction(numerator * x.numerator, denominator * x.denominator);

            //преобразовать дробь в смешанную
            ToMixedNumber(y);
            ToMixedNumber(x);
            ToMixedNumber();
            return y;
        }

        
        public Fraction Div(Fraction x)
        {
            //преобразовать дробь в неправильную и упростить
            ToSimplifyFraction(); 
            ToSimplifyFraction(x); 

            Fraction y = new Fraction(numerator * x.denominator, denominator * x.numerator);

            //преобразовать дробь в смешанную
            ToMixedNumber(y); 
            ToMixedNumber(x);
            ToMixedNumber();
            return y;
        
        }
        
        public string ToStr() //возвращает дробь в текстовом формате
        {
            if (whole !=0 && numerator == 0) return whole + "";
            if (whole == 0 && numerator != 0 && denominator == 1) return numerator + "";
            if (whole == 0) return numerator + "/" + denominator;
            return whole + " " + numerator + "/" + denominator;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //для проверки
            //Fraction a = new Fraction(6); // целое
            //Fraction a = new Fraction(7, 15); // числитель, знаменатель
            //Fraction a = new Fraction(-6, 7, 15); // целое, числитель, знаменатель

            Fraction a = new Fraction(6, 7, 15); // целое, числитель, знаменатель
            Fraction b = new Fraction(7, 5, 6);

            
            Console.WriteLine(a.ToStr() + " + " + b.ToStr() + " = " + a.Add(b).ToStr());
            Console.WriteLine(a.ToStr() + " - " + b.ToStr() + " = " + a.Sub(b).ToStr());
            Console.WriteLine(a.ToStr() + " * " + b.ToStr() + " = " + a.Mul(b).ToStr());
            Console.WriteLine(a.ToStr() + " / " + b.ToStr() + " = " + a.Div(b).ToStr());
            Console.WriteLine(b.ToStr() + " / " + a.ToStr() + " = " + b.Div(a).ToStr());
            
            Console.ReadKey();

        }
    }
}
