using NUnit.Framework;

namespace Mon.Stats.Tests
{
    [TestFixture]
    public class MonStatsGenericTest
    {
        [TestCase(MonStatRanges.attackMin, MonStatRanges.attackMax, 0, 1)]
        [TestCase(MonStatRanges.attackMin, MonStatRanges.attackMax, 256, 255)]
        [TestCase(MonStatRanges.hpMin, MonStatRanges.hpMax, 0, 1)]
        [TestCase(MonStatRanges.hpMin, MonStatRanges.hpMax, 256, 255)]
        [TestCase(MonStatRanges.levelMin, MonStatRanges.levelMax, 0, 1)]
        [TestCase(MonStatRanges.levelMin, MonStatRanges.levelMax, 256, 100)]
        [TestCase(MonStatRanges.levelMin, MonStatRanges.levelMax, null, 1)]
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
        [TestCase(1, 1, 1, 1)]
        [TestCase(100, 100, 100, 100)]
        [TestCase(101, 100, 100, 100)]
        [TestCase(null, 1, 1, 1)]
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