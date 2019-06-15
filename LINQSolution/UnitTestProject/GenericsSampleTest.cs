using GenericsSamples;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class GenericsSampleTest
    {
        [TestMethod]
        public void TestDictionaryCollectionSample()
        {

            var runningClass = new Vendor();
            var expected = new Dictionary<string, Vendor> {
                { "ABC",
                    new Vendor
                    {
                        VendorId = 5,
                        CompanyName = "ABC copy",
                        Email = "abc@abc.com"
                    }
                },
                { "CDFS",
                    new Vendor
                        {
                        VendorId = 3,
                        CompanyName = "CFS copy",
                        Email = "csdf@sdcxf.com"
                    }
                }
            };
            var actual = runningClass.DictionaryCollectionSample();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
