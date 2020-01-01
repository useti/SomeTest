using System;
using System.Collections.Generic;

namespace SomeTestLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Triangle : IShape
    {
        private double _a;
        private double _b;
        private double _c;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public Triangle(double a, double b, double c)
        {
            Validate(a,b,c);
            _a = a;
            _b = b;
            _c = c;
        }

        /// <summary>
        /// 
        /// </summary>
        public double A
        {
            get => _a;
            set
            {
                Validate(value, _b, _c);
                _a = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double B
        {
            get => _b;
            set
            {
                Validate(_a, value, _c);
                _b = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double C
        {
            get => _c;
            set
            {
                Validate(_a, _b, value);
                _c = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            var halfPerimeter = (A + B + C) / 2;
            var area = 
                Math.Sqrt(halfPerimeter * (halfPerimeter - 1) * (halfPerimeter - B) * (halfPerimeter - C));
            return area;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void Validate(double a, double b, double c)
        {
            if (a < 0)
                throw new ArgumentOutOfRangeException(nameof(a), "Side A should be non-negative");
            if (b < 0)
                throw new ArgumentOutOfRangeException(nameof(b), "Side B should be non-negative");
            if (c < 0)
                throw new ArgumentOutOfRangeException(nameof(c), "Side C should be non-negative");

            if(a > b+c)
                throw new ArgumentOutOfRangeException(nameof(a),"Invalid triangle - Side A invalid");
            if(b > a+c)
                throw new ArgumentOutOfRangeException(nameof(b), "Invalid triangle - Side B invalid");
            if(c > a+b)
                throw new ArgumentOutOfRangeException(nameof(c), "Invalid triangle - Side C invalid");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public bool IsRight(double tolerance = 0.0001)
        {
            GuardTolerance(tolerance);
            
            var l = new List<double>(new[] {A, B, C});
            l.Sort();

            return Math.Abs((l[2] * l[2]) - (l[0] * l[0] + l[1]*l[1])) < tolerance;
        }

        private void GuardTolerance(double tolerance)
        {
            if (tolerance <= 0)
                throw new ArgumentOutOfRangeException(nameof(tolerance), "Tolerance should be greater than zero");
            if (tolerance >= 1)
                throw new ArgumentOutOfRangeException(nameof(tolerance), "Tolerance should be less than 1");
        }
    }
}