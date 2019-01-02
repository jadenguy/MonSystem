using NUnit.Framework;

namespace MonGenerator.Tests
{
    [TestFixture]
    public class MonStatsGenericTest
    {
        [TestCase(1, 5, 3, false, 3)]
        [TestCase(1, 5, 3, true, 3)]
        [TestCase(1, 5, 5, false, 4)]
        [TestCase(1, 5, 5, true, 5)]
        [TestCase(1, 5, 1, false, 2)]
        [TestCase(1, 5, 1, true, 1)]
        public void MonStatIntBetweenMethodTest(int low, int high, int value, bool inclusive, int expectedValue)
        {
            //--Arrange
            var expected = expectedValue;
            //--Act
            var actual = MonStats.IntBetween(value, low, high, inclusive);
            //--Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase(MonStatRanges.attackMin, MonStatRanges.attackMax, 0, 1)]
        [TestCase(MonStatRanges.attackMin, MonStatRanges.attackMax, 256, 255)]
        [TestCase(MonStatRanges.hpMin, MonStatRanges.hpMax, 0, 1)]
        [TestCase(MonStatRanges.hpMin, MonStatRanges.hpMax, 256, 255)]
        [TestCase(MonStatRanges.levelMin, MonStatRanges.levelMax, 0, 1)]
        [TestCase(MonStatRanges.levelMin, MonStatRanges.levelMax, 256, 100)]
        public void MonStatInRangeMethodTest(MonStatRanges low, MonStatRanges high, int value, int expectedValue)
        {
            //--Arrange
            var expected = expectedValue;
            //--Act
            var actual = MonStats.InRange(value, low, high);
            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 1, 1, 1)]
        [TestCase(null, 1, 1, 1)]
        [TestCase(1, 1, 1, 1)]
        [TestCase(100, 100, 100, 100)]
        [TestCase(101, 100, 100, 100)]
        public void MonStatsTestGenericStatsTest(int level, int expectedLevel, int expectedAttack, int expectedHp)
        {
            //--Arrange
            MonStats stats = new MonStats(level);
            //--Act

            var actualLevel = stats.Level;
            var actualHp = stats.Hp;
            var actualAttack = stats.Attack;

            //--Assert
            Assert.AreEqual(expectedLevel, actualLevel);
            Assert.AreEqual(expectedAttack, actualAttack);
            Assert.AreEqual(expectedHp, actualHp);
        }

    }
}