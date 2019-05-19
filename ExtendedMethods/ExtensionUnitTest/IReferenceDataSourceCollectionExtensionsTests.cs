using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtendedMethods;


namespace ExtendedMethodsTest
{
    [TestClass]
    public class IReferenceDataSourceCollectionExtensionsTests
    {
        [TestMethod]
        public void GetAllItemsByCode_Array()
        {
            var sources = new IReferenceDataSource[] {new SqlReferenceDataSource (),new XmlReferenceDataSource(),
                new ApiReferenceDataSource()};

            var items= sources.GetAllItemsByCode("xyz");
            Assert.AreEqual(6, items.Count());
        }
    }
}
