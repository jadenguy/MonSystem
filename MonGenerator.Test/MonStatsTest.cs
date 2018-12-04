using NUnit.Framework;

namespace MonGenerator.Tests
{
    [TestFixture]
    public class MonStatsTest
    {
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(99)]
        [TestCase(100)]
        public void MonStatsTestAttack(int level)
        {
            //arrange
            MonStats stats = new MonStats(level);

            int expected;
            if (level > 99)
            {
                expected = 99;
            }
            else if (level < 0)
            {
                expected = 0;
            }
            else
            {
                expected = level;
            }
            //act
            var actual = stats.Attack;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase(1)]
        [TestCase(99)]
        public void MonStatsTestHp(int level)
        {
            //arrange
            MonStats stats = new MonStats(level);
            var expected = level;

            //act
            var actual = stats.Hp;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase(1)]
        [TestCase(99)]
        public void MonStatsTestLevel(int level)
        {
            //arrange
            MonStats stats = new MonStats(level);
            var expected = level;

            //act
            var actual = stats.Level;

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}