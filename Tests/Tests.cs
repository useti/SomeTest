using System;
using NUnit.Framework;
using SomeTestLibrary;

namespace Tests
{
    public class Tests
    {
        private Circle _circle;
        private double _circleArea;
        private Triangle _triangle;
        private double _triangleArea;

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
        public void SomeTest_Circle_ValidateConstructor()
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
        public void SomeTest_Circle_ValidateRadius()
        {
            Assert.Throws<ArgumentOutOfRangeException>(delegate { _circle.Radius = -1; });
            Assert.AreEqual(1, _circle.Radius);
            Assert.DoesNotThrow(delegate { _circle.Radius = 1; });
            Assert.AreEqual(1, _circle.Radius);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void SomeTest_Circle_GetArea()
        {
            Assert.AreEqual(_circleArea, _circle.GetArea());
            Assert.AreEqual(_circleArea,SomeTest.GetArea(_circle));
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void SomeTest_Triangle_GetArea()
        {
            Assert.AreEqual(_triangleArea, _triangle.GetArea());
            Assert.AreEqual(_triangleArea, SomeTest.GetArea(_triangle));
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void SomeTest_Triangle_ValidateConstructor()
        {
            // Case a
            Assert.Throws<ArgumentOutOfRangeException>(delegate
            {
                var testTriangle = new Triangle(3, 1, 1);
            });
            Assert.Throws<ArgumentOutOfRangeException>(delegate
            {
                var testTriangle = new Triangle(-1, 1, 1);
            });
            
            // Case b
            Assert.Throws<ArgumentOutOfRangeException>(delegate
            {
                var testTriangle = new Triangle(1, 3, 1);
            });
            Assert.Throws<ArgumentOutOfRangeException>(delegate
            {
                var testTriangle = new Triangle(1, -1, 1);
            });
            
            // Case c
            Assert.Throws<ArgumentOutOfRangeException>(delegate
            {
                var testTriangle = new Triangle(1, 1, 3);
            });
            Assert.Throws<ArgumentOutOfRangeException>(delegate
            {
                var testTriangle = new Triangle(1, 1, -1);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void SomeTest_Triangle_ValidateProperties()
        {
            // Case a
            Assert.Throws<ArgumentOutOfRangeException>(delegate { _triangle.A = 3; });
            Assert.AreEqual(1, _triangle.A);
            Assert.Throws<ArgumentOutOfRangeException>(delegate { _triangle.A = -1; });
            Assert.AreEqual(1, _triangle.A);
            Assert.DoesNotThrow(delegate { _triangle.A = 1; });
            Assert.AreEqual(1, _triangle.A);
            
            // Case b
            Assert.Throws<ArgumentOutOfRangeException>(delegate { _triangle.B = 3; });
            Assert.AreEqual(1, _triangle.B);
            Assert.Throws<ArgumentOutOfRangeException>(delegate { _triangle.B = -1; });
            Assert.AreEqual(1, _triangle.B);
            Assert.DoesNotThrow(delegate { _triangle.B = 1; });
            Assert.AreEqual(1, _triangle.B);
            
            // Case c
            Assert.Throws<ArgumentOutOfRangeException>(delegate { _triangle.C = 3; });
            Assert.AreEqual(1, _triangle.C);
            Assert.Throws<ArgumentOutOfRangeException>(delegate { _triangle.C = -1; });
            Assert.AreEqual(1, _triangle.C);
            Assert.DoesNotThrow(delegate { _triangle.C = 1; });
            Assert.AreEqual(1, _triangle.C);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void SomeTest_Triangle_IsRight()
        {
            Assert.IsFalse(_triangle.IsRight());

            var a = 1;
            var b = 1;
            var c = Math.Sqrt(2);
            
            var testTriangle = new Triangle(a,b,c);
            Assert.IsTrue(testTriangle.IsRight());

            testTriangle.B = c;
            testTriangle.C = b;
            Assert.IsTrue(testTriangle.IsRight());

            testTriangle.A = c;
            testTriangle.B = a;
            Assert.IsTrue(testTriangle.IsRight());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void SomeTest_Triangle_IsRight_ToleranceGuard()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate
                {
                    _triangle.IsRight(-1);
                });
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate
                {
                    _triangle.IsRight(0);
                });
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate
                {
                    _triangle.IsRight(1);
                });
            Assert.DoesNotThrow(
                delegate
                {
                    _triangle.IsRight(0.1);
                });
        }
    }
}