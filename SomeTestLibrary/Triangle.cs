using System;
using System.Collections.Generic;

namespace SomeTestLibrary
{
    /// <summary>
    /// Triangle class
    /// </summary>
    public class Triangle : IShape
    {
        private double _a;
        private double _b;
        private double _c;

        /// <summary>
        /// Create new triangle
        /// </summary>
        /// <param name="a">Side A</param>
        /// <param name="b">Side B</param>
        /// <param name="c">Side C</param>
        public Triangle(double a, double b, double c)
        {
            Validate(a,b,c);
            _a = a;
            _b = b;
            _c = c;
        }

        /// <summary>
        /// Side A
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
        /// Side B
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
        /// Side C
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
        /// Get triangle area
        /// </summary>
        /// <returns>Area</returns>
        public double GetArea()
        {
            var halfPerimeter = (A + B + C) / 2;
            var area = 
                Math.Sqrt(halfPerimeter * (halfPerimeter - 1) * (halfPerimeter - B) * (halfPerimeter - C));
            return area;
        }

        /// <summary>
        /// Validates triangle existence
        /// </summary>
        /// <param name="a">Side A</param>
        /// <param name="b">Side B</param>
        /// <param name="c">Side C</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// In case if parameters didn't fit method throws ArgumentOutOfRangeException
        /// </exception>
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
        /// Checks if triangle is right
        /// </summary>
        /// <param name="tolerance">
        /// Tolerance of calculations (default value is 0.0001).
        /// Maximum value is 1 but greater than zero
        /// </param>
        /// <returns>Boolean value true in case triangle is right and false otherwise</returns>
        public bool IsRight(double tolerance = 0.0001)
        {
            GuardTolerance(tolerance);
            
            var l = new List<double>(new[] {A, B, C});
            l.Sort();

            return Math.Abs((l[2] * l[2]) - (l[0] * l[0] + l[1]*l[1])) < tolerance;
        }

        /// <summary>
        /// Validates range of computation tolerance
        /// </summary>
        /// <param name="tolerance">Input tolerance</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws exception in case tolerance not in the allowed range
        /// </exception>
        private void GuardTolerance(double tolerance)
        {
            if (tolerance <= 0)
                throw new ArgumentOutOfRangeException(nameof(tolerance), "Tolerance should be greater than zero");
            if (tolerance >= 1)
                throw new ArgumentOutOfRangeException(nameof(tolerance), "Tolerance should be less than 1");
        }
    }
}