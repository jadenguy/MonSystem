using NUnit.Framework;

namespace MonGenerator.Tests
{
    [TestFixture]
    public class MonStatsTestGeneric
    {
        [TestCase(1, 5, 3, false, 3)]
        [TestCase(1, 5, 5, false, 4)]
        [TestCase(1, 5, 5, true, 5)]
        [TestCase(1, 5, 1, false, 2)]
        [TestCase(1, 5, 1, true, 1)]
        public void MonStatIntBetweenTest(int low, int high, int value, bool inclusive, int expectedValue)
        {
            //--Arrange
            var expected = expectedValue;
            //--Act
            var actual = MonStats.IntBetween(value, low, high, inclusive);
            //--Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(100, 100)]
        [TestCase(101, 100)]
        public void MonStatsTestGenericAttack(int level, int expectedAttack)
        {
            //--Arrange
            MonStats stats = new MonStats(level);
            var expected = expectedAttack;
            //--Act
            var actual = stats.Attack;

            //--Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(100, 100)]
        [TestCase(101, 100)]
        public void MonStatsTestGenericHp(int level, int expectedHp)
        {
            //--Arrange
            MonStats stats = new MonStats(level);
            var expected = expectedHp;

            //--Act
            var actual = stats.Hp;

            //--Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(100, 100)]
        [TestCase(101, 100)]
        public void MonStatsTestGenericLevel(int level, int expectedLevel)
        {
            //--Arrange
            MonStats stats = new MonStats(level);
            var expected = expectedLevel;

            //--Act
            var actual = stats.Level;

            //--Assert
            Assert.AreEqual(expected, actual);
        }
    }
}