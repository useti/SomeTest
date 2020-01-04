using System;

namespace SomeTestLibrary
{
    /// <summary>
    /// Circle class
    /// </summary>
    public class Circle : IShape
    {
        private double _radius;

        /// <summary>
        /// Create new circle
        /// </summary>
        /// <param name="r">Radius of the circle</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws ArgumentOutOfRangeException exception when radius is negative
        /// </exception>
        public Circle(double r)
        {
            Validate(r);
            Radius = r;
        }

        /// <summary>
        /// Radius of the circle
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws ArgumentOutOfRangeException exception when radius is negative
        /// </exception>
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
        /// Calculate circle area
        /// </summary>
        /// <returns>
        /// Circle area
        /// </returns>
        public double GetArea()
        {
            var area = Math.PI * Radius * Radius;
            return area;
        }

        /// <summary>
        /// Validates circle parameters
        /// </summary>
        /// <param name="r">Radius of the circle</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws ArgumentOutOfRangeException exception when radius is negative
        /// </exception>
        private void Validate(double r)
        {
            if (r < 0)
                throw new ArgumentOutOfRangeException(nameof(r), "Radius should be non-negative");
        }
    }
}