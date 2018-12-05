using NUnit.Framework;

namespace MonGenerator.Tests
{
    [TestFixture]
    public class MonTypeTest
    {
        [TestCase("newMon", 0, 5, 5, true)]
        public void MonTypeValidTest(string speciesName, int id, int attack, int hp, bool isValid)
        {
            //--Arrange
            MonType monType = new MonType(speciesName, id, attack, hp);
            var expected = isValid;

            //--Act
            var actual = monType.Validate();

            //--Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("newMon", 0, 5, 5)]
        public void MonTypeValuesTest(string speciesName, int id, int attack, int hp)
        {
            //--Arrange
            MonType monType = new MonType(speciesName, id, attack, hp);
            var expectedId = id;
            var expectedHp = hp;
            var expectedAttack = attack;
            var expectedSpeciesName = speciesName;

            //--Act
            var actualId = monType.Id;
            var actualHp = monType.Hp;
            var actualAttack = monType.Attack;
            var actualSpeciesName = monType.SpeciesName;
            var actualValid = monType.Validate();

            //--Assert
            Assert.AreEqual(expectedId, actualId);
            Assert.AreEqual(expectedSpeciesName, actualSpeciesName);
            Assert.AreEqual(expectedAttack, actualAttack);
            Assert.AreEqual(expectedHp, actualHp);
            Assert.IsTrue(actualValid);
        }
    }
}