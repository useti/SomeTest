using System;
using SomeTestLibrary;

namespace UsageExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                const int a = 1;
                const int b = 1;
                const int c = 1;
                var triangle = new Triangle(a, b, c);
                
                Console.WriteLine(
                    $"Area of triangle with sides " +
                    $"a={triangle.A}, b={triangle.B}, c={triangle.C} " +
                    $"is {triangle.GetArea()} " +
                    $"or {SomeTest.GetArea(triangle)} " +
                    $"and Is Right = {triangle.IsRight()}\r\n");

                triangle.C = Math.Sqrt(2);

                Console.WriteLine(
                    $"Area of triangle with sides " +
                    $"a={triangle.A}, b={triangle.B}, c={triangle.C} " +
                    $"is {triangle.GetArea()} " +
                    $"or {SomeTest.GetArea(triangle)} " +
                    $"and Is Right = {triangle.IsRight()}\r\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            try
            {
                const int r = 1;
                var circle = new Circle(r);

                Console.WriteLine(
                    $"Area of circle with radius r={r} " +
                    $"is {circle.GetArea()} " +
                    $"or {SomeTest.GetArea(circle)}\r\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }
    }
}