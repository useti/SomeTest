using System;

namespace SomeTestLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Circle : IShape
    {
        private double _radius;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Circle(double r)
        {
            Validate(r);
            Radius = r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public double Radius
        {
            get => _radius;
            set
            {
                Validate(value);
                _radius = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            var area = Math.PI * Radius * Radius;
            return area;
        }

        private void Validate(double r)
        {
            if (r < 0)
                throw new ArgumentOutOfRangeException(nameof(r), "Radius should be non-negative");
        }
    }
}