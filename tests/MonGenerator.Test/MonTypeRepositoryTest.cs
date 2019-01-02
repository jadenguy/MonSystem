using NUnit.Framework;

namespace MonGenerator.Tests
{
    [TestFixture]
    public class MonTypeRepositoryTest
    {

        MonTypeDictionaryRepository monTypeRepository;
        [SetUp]
        public void Setup()
        {
            monTypeRepository = new MonTypeDictionaryRepository();
        }
        [Test]
        public void MonTypeDictionaryRepositoryInstantiateTest()
        {
            var actual = monTypeRepository;
            System.Type expected = typeof(MonTypeDictionaryRepository);
            Assert.IsInstanceOf(expected, actual);
        }
        [Test]
        public void MonTypeRepositoryAddTest()
        {
            //--Arrange
            MonType monType = new MonType("guy", 0, 1, 1);
            var testDelegate = new TestDelegate(delegate { monTypeRepository.Add(monType); });

            //--Act and Assert
            Assert.DoesNotThrow(testDelegate);
        }
    }
}