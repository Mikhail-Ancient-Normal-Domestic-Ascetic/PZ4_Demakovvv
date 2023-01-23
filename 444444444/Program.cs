using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _444444444
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HAIL CHERKASHIN!");
            //Защищенный блок
            try
            {
                //Создание объекта
                Triangle Ob = new Triangle(3, 4, 5);
                //Проверка на существование треугольника
                //если существует - напечатаем стороны
                //дабы не оставлять пустой оператор ;
                if (Ob)
                    Ob.PrintSides();
                //Иначе - кидаем исключение
                else
                    throw new Exception("Треугольника с такими сторонами не существует");
                //Печатаем периметр
                Console.WriteLine("Периметр={0}", Ob.Perimetr());
                //Печатаем площадь
                Console.WriteLine("Площадь={0}", Ob.Square());
            }
            //Ловим исключение
            catch (Exception e)
            {
                //Пишем сообщение, хранящееся в исключении
                Console.WriteLine(e.Message);
            }
            //Блок выполняющийся в любом случае
            finally
            {
                //Дабы консоль не закрывалась до нажатия на кнопку
                Console.ReadKey();
            }
        }
        //Целевой класс
        class Triangle
        {
            //Стороны
            int a, b, c;
            //Свойства a
            public int A
            {
                //Геттер
                get
                {
                    return a;
                }
                //Сеттер
                set
                {
                    a = value;
                }
            }
            //Свойства b
            public int B
            {
                get
                {
                    return b;
                }
                set
                {
                    b = value;
                }
            }
            //Свойства c
            public int C
            {
                get
                {
                    return c;
                }
                set
                {
                    c = value;
                }
            }
            //Свойство проверки треугольника
            public bool isTriangle
            {
                get
                {
                    //Если подходит под условие существования треугольника
                    //возвращаем true, иначе false
                    if (a + b > c && a + c > b && b + c > a)
                    {
                        return true;
                    }
                    return false;
                }

            }
            //Конструктор с тремя параметрами
            public Triangle(int a_, int b_, int c_)
            {
                //Проверка на положительность сторон треугольника
                isCorrect(a_, b_, c_);
                //Установка значений через сеттеры
                A = a_;
                B = b_;
                C = c_;
            }
            //Функция печати длин сторон
            public void PrintSides()
            {
                Console.WriteLine("сторона 'a' равна {0}, сторона 'b' равна {1}, сторона 'c' равна {2}", a, b, c);
            }
            //Функция вычисления периметра
            public int Perimetr()
            {
                return a + b + c;
            }
            //Функция вычисления площади
            public double Square()
            {
                //Площадь считаем по формуле Геррона
                return Math.Sqrt(halfper(this) * (halfper(this) - a) * (halfper(this) - b)
                    * (halfper(this) - c));
            }
            //Подсчет полупериметра треугольника
            static double halfper(Triangle Ob)
            {
                return Ob.Perimetr() / 2.0;
            }
            //Проверка на положительность сторон
            static void isCorrect(int a, int b, int c)
            {
                if (a < 0 || b < 0 || c < 0)
                    //Если нет - кидаем исключение
                    throw new Exception("Стороны треугольника не могут быть отрицательными");
            }
            //Перегрузка инкремента
            public static Triangle operator ++(Triangle Ob)
            {
                //Возвращаем объект с измененными сторонами
                return new Triangle(++Ob.a, ++Ob.b, ++Ob.c);
            }
            //Перегрузка декремента
            public static Triangle operator --(Triangle Ob)
            {
                return new Triangle(--Ob.a, --Ob.b, --Ob.c);
            }
            //Перегрузка оператора умножения(в данном случае на скаляр)
            public static Triangle operator *(Triangle Ob, int mult)
            {
                return new Triangle(Ob.a * mult, Ob.b * mult, Ob.c * mult);
            }
            //Перевод в строку
            public override string ToString()
            {
                //Печатаем стороны через геттеры
                return "Sides: " + "a is " + A + " b is " + B + " c is " + C;
            }
            //Индексатор. idx - индекс
            public int this[int idx]
            {
                //Если idx=1 возвращаем a
                //если idx=2 возвращаем b
                //если idx=3 возвращем c
                //иначе кидаем исключение
                get
                {
                    if (idx == 1)
                        return a;
                    else if (idx == 2)
                        return b;
                    else if (idx == 3)
                        return c;
                    else
                        throw new Exception("idx can be only 1, 2 and 3");
                }
                //Если idx=1 устанавливаем a
                //если idx=2 устанавливаем b
                //если idx=3 устанавливаем c
                //иначе кидаем исключение
                set
                {
                    if (idx == 1)
                        a = value;
                    else if (idx == 2)
                        b = value;
                    else if (idx == 3)
                        c = value;
                    else
                        throw new Exception("idx can be only 1, 2 and 3");
                }
            }
            //Перегрузка оператора true
            //проверка на существование треугольника
            public static bool operator true(Triangle t)
            {
                return t.isTriangle;
            }
            //Перегрузка оператора true
            //проверка на существование треугольника
            public static bool operator false(Triangle t)
            {
                return t.isTriangle;
            }
        };
    }
}