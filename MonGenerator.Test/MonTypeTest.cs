using NUnit.Framework;

namespace MonGenerator.Tests
{
    [TestFixture]
    public class MonTypeTest
    {
        [TestCase("newMon",0, 5, 5, true)]
        public void MonTypeValid(string speciesName, int Id, int attack, int hp, bool isValid)
        {
            //--Arrange
            MonType monType = new MonType(speciesName,Id,attack,hp);
            var expected = isValid;
            
            //--Act
            var actual = monType.Validate();
            
            //--Assert
            Assert.AreEqual(expected,actual);
        }
    }
}