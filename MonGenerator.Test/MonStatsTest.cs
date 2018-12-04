using NUnit.Framework;

namespace MonGenerator.Tests
{
    [TestFixture]
    public class MonStatsTestGeneric
    {
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(100, 100)]
        [TestCase(101, 100)]
        public void MonStatsTestGenericAttack(int level, int expectedAttack)
        {
            //arrange
            MonStats stats = new MonStats(level);
            var expected = expectedAttack;
            //act
            var actual = stats.Attack;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(100, 100)]
        [TestCase(101, 100)]
        public void MonStatsTestGenericHp(int level, int expectedHp)
        {
            //arrange
            MonStats stats = new MonStats(level);
            var expected = expectedHp;

            //act
            var actual = stats.Hp;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(100, 100)]
        [TestCase(101, 100)]
        public void MonStatsTestGenericLevel(int level, int expectedLevel)
        {
            //arrange
            MonStats stats = new MonStats(level);
            var expected = expectedLevel;

            //act
            var actual = stats.Level;

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}