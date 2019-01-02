using System;
using Common.Math;
using NUnit.Framework;

namespace Common.Math.Tests
{
    [TestFixture]
    public class BetweenExtensionTest
    {
        [TestCase(1, 5, 3, 3)]
        [TestCase(1, 5, 5, 5)]
        [TestCase(1, 5, 6, 5)]
        [TestCase(1, 5, 1, 1)]
        [TestCase(1, 5, 0, 1)]
        [TestCase(null, 5, 1, 1)]
        public void intInBetweenIITest(int low, int high, int value, int expectedValue)
        {
            //--Arrange
            var expected = expectedValue;
            //--Act
            var actual = value.InBetweenII(low, high);
            //--Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase(1, 5, 3, 3)]
        [TestCase(1, 5, 5, 4)]
        [TestCase(1, 5, 1, 2)]
        [TestCase(1, 5, null, 2)]
        public void intInBetweenEETest(int low, int high, int value, int expectedValue)
        {
            //--Arrange
            var expected = expectedValue;
            //--Act
            var actual = value.IntBetweenEE(low, high);
            //--Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase(1, 5, 3, 3)]
        [TestCase(1, 5, 5, 4)]
        [TestCase(1, 5, 1, 1)]
        [TestCase(1, 5, null, 1)]
        public void intInBetweenIETest(int low, int high, int value, int expectedValue)
        {
            //--Arrange
            var expected = expectedValue;
            //--Act
            var actual = value.IntBetweenIE(low, high);
            //--Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase(1, 5, 3, 3)]
        [TestCase(1, 5, 5, 5)]
        [TestCase(1, 5, 1, 2)]
        [TestCase(1, 5, null, 2)]
        public void intInBetweenEITest(int low, int high, int value, int expectedValue)
        {
            //--Arrange
            var expected = expectedValue;
            //--Act
            var actual = value.IntBetweenEI(low, high);
            //--Assert
            Assert.AreEqual(expected, actual);
        }
    }
}