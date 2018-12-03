using NUnit.Framework;

namespace MonGenerator.Tests
{
    [TestFixture]
    public class MonStatsTest
    {
        [TestCase(1)]
        [TestCase(99)]
        public void MonStatsTestAttack(int level)
        {
            //arrange
            MonStats stats = new MonStats(level);
            var expected = level;

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