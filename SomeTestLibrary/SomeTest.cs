namespace SomeTestLibrary
{
    /// <summary>
    /// Some generic class for some test task...
    /// </summary>
    public class SomeTest
    {
        /// <summary>
        /// Generic method to calculate shape area
        /// </summary>
        /// <param name="input">Shape to calculate area</param>
        /// <typeparam name="T">Shape, class inherited from IShape interface</typeparam>
        /// <returns>Shape area</returns>
        public static double GetArea<T>(T input) where T : IShape
        {
            return input.GetArea();
        }
    }
}