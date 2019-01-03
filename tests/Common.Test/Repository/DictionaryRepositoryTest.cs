using System;
using Common.Repository;
using NUnit.Framework;

namespace Common.Repository.Tests
{
    public class TestEntity : IEntity
    {
        public TestEntity(int id) : base(id) { }
    }
    [TestFixture]
    public class DictionaryRepositoryTest
    {
        [Test]
        public void AddMemberTest()
        {
            //-- Arrange
            var dictionaryRepository = new DictionaryRepository<TestEntity>();
            var testEntity = new TestEntity(0);
            var expected = testEntity.Id;

            //-- Act
            dictionaryRepository.Add(testEntity);
            var actual = dictionaryRepository.FindById(testEntity.Id).Id;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}