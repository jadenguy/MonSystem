using NUnit.Framework;
using MonGenerator.Type;

namespace MonGenerator.Type.Tests
{
    [TestFixture]
    public class MonTypeTest
    {
        [TestCase("newMon", 0, 5, 5, 0, true)]
        [TestCase("newMon", 0, 5, 95, 0, true)]
        [TestCase("newMon", 0, 200, -200, 0, false)]
        [TestCase("newMon", 0, 100, -100, 0, true)]
        [TestCase("newMon", 0, 5, 100, 0, false)]
        public void MonTypeValuesValidTest(string speciesName, int id, int attack, int hp, int speed, bool isValid)
        {
            //--Arrange
            MonType monType = new MonType(speciesName, id, attack, hp, speed);
            var expectedId = id;
            var expectedHp = hp;
            var expectedAttack = attack;
            var expectedSpeed = speed;
            var expectedSpeciesName = speciesName;
            var expectedValid = isValid;

            //--Act
            var actualId = monType.Id;
            var actualHp = monType.Hp;
            var actualAttack = monType.Attack;
            var actualSpeed = monType.Speed;
            var actualSpeciesName = monType.SpeciesName;
            var actualValid = monType.Validate();

            //--Assert
            Assert.AreEqual(expectedId, actualId);
            Assert.AreEqual(expectedSpeciesName, actualSpeciesName);
            Assert.AreEqual(expectedHp, actualHp);
            Assert.AreEqual(expectedAttack, actualAttack);
            Assert.AreEqual(expectedSpeed, actualSpeed);
            Assert.AreEqual(expectedValid, actualValid);
        }
    }
}