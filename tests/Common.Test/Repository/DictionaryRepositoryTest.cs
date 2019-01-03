using NUnit.Framework;

namespace Common.Repository.Tests
{
  
    [TestFixture]
    public class DictionaryRepositoryTest
    {
        [Test]
        public void CrudTest()
        {
            //-- Arrange
            var dictionaryRepository = new DictionaryRepository<EquatableStringEntity>();
            var testEntity = new EquatableStringEntity(1) { Data = "response1" };
            var updateEntity = new EquatableStringEntity(1) { Data = "response2" };
            var expectedAdded = new EquatableStringEntity(1) { Data = "response1" };
            var expectedUpdate = new EquatableStringEntity(1) { Data = "response2" };

            //-- Act

            try
            {
                //-- Create
                dictionaryRepository.Add(testEntity);

                //-- Read
                var actualAdded = dictionaryRepository.FindById(testEntity.Id);

                //-- Update
                dictionaryRepository.Update(updateEntity);
                var actualUpdated = dictionaryRepository.FindById(testEntity.Id);

                //-- Delete
                dictionaryRepository.Delete(testEntity);
                EquatableStringEntity actualDeleted = null;
                try
                {
                    actualDeleted = dictionaryRepository.FindById(testEntity.Id);
                }
                catch (System.Collections.Generic.KeyNotFoundException)
                {
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }

                //-- Assert
                Assert.AreEqual(expectedAdded, actualAdded);
                Assert.AreEqual(expectedUpdate, actualUpdated);
                Assert.IsNull(actualDeleted);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex);
                Assert.Fail();
            }
        }
    }
}