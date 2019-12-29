namespace SomeTestLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class SomeTest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static double GetArea<T>(T input) where T : IShape
        {
            return input.GetArea();
        }
    }
}