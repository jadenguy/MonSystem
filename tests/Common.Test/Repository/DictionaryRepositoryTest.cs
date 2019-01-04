using NUnit.Framework;

namespace Common.Repository.Tests
{

    [TestFixture]
    public class DictionaryRepositoryTest
    {
        [Test]
        public void DictionaryRepositoryCrudTest()
        {
            //-- Arrange
            var dictionaryRepository = new DictionaryRepository<EquatableStringEntity>();
            var testEntity = new EquatableStringEntity(1) { Data = "response1" };
            var updateEntity = new EquatableStringEntity(1) { Data = "response2" };
            var expectedAdded = new EquatableStringEntity(1) { Data = "response1" };
            var expectedUpdated = new EquatableStringEntity(1) { Data = "response2" };
            var expectedExceptionType = typeof(System.Collections.Generic.KeyNotFoundException);
            var expectedExceptionMessage = "The given key '1' was not present in the dictionary.";

            //-- Act

            //-- Create
            dictionaryRepository.Add(testEntity);

            //-- Read
            var actualAdded = dictionaryRepository.FindById(testEntity.Id);

            //-- Update
            dictionaryRepository.Update(updateEntity);
            var actualUpdated = dictionaryRepository.FindById(testEntity.Id);

            //-- Delete
            dictionaryRepository.Delete(testEntity);
            EquatableStringEntity actualDeleted;
            System.Exception actualException;
            try
            {
                actualDeleted = dictionaryRepository.FindById(testEntity.Id);
                actualException = new System.Exception();
            }
            catch (System.Collections.Generic.KeyNotFoundException ex)
            {
                actualDeleted = null;
                actualException = ex;
            }
            catch (System.Exception ex)
            {
                actualException = ex;
                throw;
            }
            var actualExceptionType = actualException.GetType();
            var actualExceptionMessage = actualException.Message;

            //-- Assert               
            Assert.AreEqual(expectedAdded, actualAdded);
            Assert.AreEqual(expectedUpdated, actualUpdated);
            Assert.AreNotEqual(expectedAdded, actualUpdated);
            Assert.IsNull(actualDeleted);
            Assert.AreEqual(expectedExceptionType, actualExceptionType);
            Assert.AreEqual(expectedExceptionMessage, actualExceptionMessage);
        }
    }
}