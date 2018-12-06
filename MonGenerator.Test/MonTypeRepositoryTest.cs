using NUnit.Framework;

namespace MonGenerator.Tests
{
    [TestFixture]
    public class MonTypeRepositoryTest
    {

        MonTypeDictionaryRepository monTypeRepo;
        [SetUp]
        public void Setup()
        {
            monTypeRepo = new MonTypeDictionaryRepository();
        }
        [Test]
        public void MonTypeRepositoryInstantiateTest()
        {
            var actual = monTypeRepo;
            System.Type expected = typeof(MonTypeDictionaryRepository);
            Assert.IsInstanceOf(expected, actual);
        }
        [Test]
        public void MonTypeRepositoryAddTest()
        {
            //--Arrange
            MonType monType = new MonType("guy", 0, 1, 1);
            var testDelegate = new TestDelegate(delegate { monTypeRepo.Add(monType); });

            //--Act and Assert
            Assert.DoesNotThrow(testDelegate);
        }
    }
}