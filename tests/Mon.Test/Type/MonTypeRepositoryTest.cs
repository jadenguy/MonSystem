using NUnit.Framework;

namespace Mon.Type.Tests
{
    [TestFixture]
    public class MonTypeRepositoryTest
    {

        MonTypeRepository monTypeRepository;
        [SetUp]
        public void Setup()
        {
            monTypeRepository = new MonTypeRepository();
        }
        [Test]
        public void MonTypeRepositoryInstantiateTest()
        {
            var actual = monTypeRepository;
            System.Type expected = typeof(MonTypeRepository);
            Assert.IsInstanceOf(expected, actual);
        }
        [Test]
        public void MonTypeRepositoryAddTest()
        {
            //--Arrange
            MonType monType = new MonType("guy", 42, 0, 0, 0);
            var testDelegate = new TestDelegate(delegate { monTypeRepository.Add(monType); });

            //--Act and Assert
            Assert.DoesNotThrow(testDelegate);
        }
    }
}