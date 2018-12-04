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

        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(100, 100)]
        [TestCase(101, 100)]
        public void MonStatsTestGenericAttackTest(int level, int expectedAttack)
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
        public void MonStatsTestGenericHpTest(int level, int expectedHp)
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
        public void MonStatsTestGenericLevelTest(int level, int expectedLevel)
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