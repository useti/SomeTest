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
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public double Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("R","Radius should be non-negative");
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Circle(double r)
        {
            if(r < 0)
                throw new ArgumentOutOfRangeException("r","Radius should be non-negative");
            Radius = r;
        }
    }
}