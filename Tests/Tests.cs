using System;
using NUnit.Framework;
using SomeTestLibrary;

namespace Tests
{
    public class Tests
    {
        private Triangle _triangle;
        private Circle _circle;
        private double _triangleArea;
        private double _circleArea;

        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _triangle = new Triangle (1,1,1);
            _circle = new Circle(1);
            _triangleArea = Math.Sqrt(1.5 * (1.5 - 1) * (1.5 - 1) * (1.5 - 1));
            _circleArea = Math.PI * 1 * 1;
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestTriangle_GetArea()
        {
            Assert.AreEqual(_triangleArea,_triangle.GetArea());
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestCircle_GetArea()
        {
            Assert.AreEqual(_circleArea, _circle.GetArea());
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestCircle_NegativeConstructor()
        {
            Assert.Throws<ArgumentOutOfRangeException>(delegate
            {
                var testCircle = new Circle(-1);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestCircle_NegativeRadius()
        {
            var testCircle = new Circle(1);
            Assert.Throws<ArgumentOutOfRangeException>(delegate { testCircle.Radius = -1; });
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void SomeTest_Circle_GetArea()
        {
            Assert.AreEqual(_circleArea,SomeTest.GetArea(_circle));
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void SomeTest_Triangle_GetArea()
        {
            Assert.AreEqual(_triangleArea, SomeTest.GetArea(_triangle));
        }
    }
}