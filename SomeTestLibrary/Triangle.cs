using System;

namespace SomeTestLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Triangle : IShape
    {
        /// <summary>
        /// 
        /// </summary>
        public double A { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double B { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double C { get; set; }
        
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
        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }
    }
}