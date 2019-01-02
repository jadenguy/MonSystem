using NUnit.Framework;
using MonGenerator.Type;

namespace MonGenerator.Type.Tests
{
    [TestFixture]
    public class MonTypeTest
    {
        [TestCase("newMon", 0, 5, 5, true)]
        [TestCase("newMon", 0, 5, 95, true)]
        [TestCase("newMon", 0, 200, -200, false)]
        [TestCase("newMon", 0, 100, -100, true)]
        [TestCase("newMon", 0, 5, 100, false)]
        public void MonTypeValuesValidTest(string speciesName, int id, int attack, int hp, bool isValid)
        {
            //--Arrange
            MonType monType = new MonType(speciesName, id, attack, hp);
            var expectedId = id;
            var expectedHp = hp;
            var expectedAttack = attack;
            var expectedSpeciesName = speciesName;
            var expectedValid = isValid;

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
            Assert.AreEqual(expectedValid, actualValid);
        }
    }
}