using NUnit.Framework;

namespace MonGenerator.Tests
{
    [TestFixture]
    public class MonStatsTest
    {
        [TestCase(1)]
        public void MonStatsTestAttack(int level)
        {
            //arrange
            MonStats stats = new MonStats(level);
            var expected = 1;

            //act
            var actual = stats.Attack;

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}