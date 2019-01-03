using NUnit.Framework;


namespace Common.Repository.Tests
{
    [TestFixture]
    public class EquatableStringEntityTest
    {
        [Test]
        public void EquatableTest()
        {
            //-- Arrange
            var actualZero = new EquatableStringEntity(0) { Data = "entity 0" };
            var wrongOneOne = new EquatableStringEntity(1) { Data = "entity 1" };
            var wrongOneZero = new EquatableStringEntity(1) { Data = "entity 0" };
            var wrongZeroOne = new EquatableStringEntity(0) { Data = "entity 1" };
            var expectedZeroId = 0;
            var expectedZeroData = "entity 0";
            var expectedZero = new EquatableStringEntity(0) { Data = "entity 0" };

            //-- Act
            var actualZeroId = actualZero.Id;
            var actualZeroData = actualZero.Data;

            //-- Assert
            Assert.AreEqual(expectedZeroId, actualZeroId);
            Assert.AreEqual(expectedZeroData, actualZeroData);
            Assert.AreEqual(expectedZero, actualZero);
            Assert.AreNotEqual(expectedZero, wrongOneOne);
            Assert.AreNotEqual(expectedZero, wrongOneZero);
            Assert.AreNotEqual(expectedZero, wrongZeroOne);
        }
    }
}