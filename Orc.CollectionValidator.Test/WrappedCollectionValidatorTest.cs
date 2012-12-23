namespace Orc.CollectionValidator.Test
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Orc.CollectionValidator.Test.Helpers;
    using Orc.CollectionValidator.Utilits;

    [TestClass]
    public class WrappedCollectionValidatorTest
    {
        [TestMethod]
        public void CanValidateSimpleUnique()
        {
            var validTstingData = TestingDataFactory.Unique.CreateSimpleUniqueData();
            var invalidTestingData = TestingDataFactory.Unique.CreateSimpleNotUniqueData();
            var trueValidator = validTstingData.Collection.BuildValidator().Unique();
            var falseValidator = invalidTestingData.Collection.BuildValidator().Unique();
            Assert.IsTrue(trueValidator.Validate().IsValid);
            Assert.IsFalse(falseValidator.Validate().IsValid);
        }

        [TestMethod]
        public void CanValidateUsingProperties()
        {
            var fullyValidData = TestingDataFactory.Unique.CreateUniqueData();
            var duplicatedIdData = TestingDataFactory.Unique.CreateDuplicatedIdData();
            var duplicatedLastNameData = TestingDataFactory.Unique.CreateDuplicatedLastNameData();
            var duplicatedNamesData = TestingDataFactory.Unique.CreateDuplicatedNamesData();

            Assert.IsTrue(fullyValidData.Collection.BuildValidator().Unique(null, x => x.ID).Validate().IsValid);
            Assert.IsTrue(duplicatedLastNameData.Collection.BuildValidator().Unique(null, x => x.ID).Validate().IsValid);
            Assert.IsTrue(duplicatedNamesData.Collection.BuildValidator().Unique(null, x => x.ID).Validate().IsValid);
            Assert.IsFalse(duplicatedIdData.Collection.BuildValidator().Unique(null, x => x.ID).Validate().IsValid);

            Assert.IsTrue(fullyValidData.Collection.BuildValidator().Unique(null, x => x.LastName).Validate().IsValid);
            Assert.IsFalse(duplicatedLastNameData.Collection.BuildValidator().Unique(null, x => x.LastName).Validate().IsValid);
            Assert.IsFalse(duplicatedNamesData.Collection.BuildValidator().Unique(null, x => x.LastName).Validate().IsValid);
            Assert.IsTrue(duplicatedIdData.Collection.BuildValidator().Unique(null, x => x.LastName).Validate().IsValid);

            Assert.IsTrue(fullyValidData.Collection.BuildValidator().Unique(null, x => x.ID).Unique(null, x => x.LastName).Validate().IsValid);
            Assert.IsFalse(duplicatedLastNameData.Collection.BuildValidator().Unique(null, x => x.ID).Unique(null, x => x.LastName).Validate().IsValid);
            Assert.IsFalse(duplicatedNamesData.Collection.BuildValidator().Unique(null, x => x.ID).Unique(null, x => x.LastName).Validate().IsValid);
            Assert.IsFalse(duplicatedIdData.Collection.BuildValidator().Unique(null, x => x.ID).Unique(null, x => x.LastName).Validate().IsValid);

            Assert.IsTrue(fullyValidData.Collection.BuildValidator().Unique(null, x => x.LastName, x => x.FirstName).Validate().IsValid);
            Assert.IsTrue(duplicatedLastNameData.Collection.BuildValidator().Unique(null, x => x.LastName, x => x.FirstName).Validate().IsValid);
            Assert.IsFalse(duplicatedNamesData.Collection.BuildValidator().Unique(null, x => x.LastName, x => x.FirstName).Validate().IsValid);
            Assert.IsTrue(duplicatedIdData.Collection.BuildValidator().Unique(null, x => x.LastName, x => x.FirstName).Validate().IsValid);
        }

        [TestMethod]
        public void CanValidateCount()
        {
            var arr = new[] { 1, 2, 3, 4, 5 };

            Assert.IsFalse(arr.BuildValidator().CountGreaterThan(6).CountLessThan(8).Validate().IsValid);

            Assert.IsFalse(arr.BuildValidator().CountGreaterThan(2).CountLessThan(4).Validate().IsValid);

            Assert.IsTrue(arr.BuildValidator().CountGreaterThan(3).CountLessThan(6).Validate().IsValid);
        }

        [TestMethod]
        public void CanValidateSingleElementCollection()
        {
            var single = new[] { 1 };
            var multiple = new[] { 1, 2 };
            var empty = new int[0];
            
            Assert.IsTrue(single.BuildValidator().Single().Validate().IsValid);
            Assert.IsFalse(multiple.BuildValidator().Single().Validate().IsValid);
            Assert.IsFalse(empty.BuildValidator().Single().Validate().IsValid);
        }

        [TestMethod]
        public void CanValidateCountAndDuplicates()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };

            Assert.IsTrue(list.BuildValidator().CountGreaterThan(3).Unique().Validate().IsValid);

            list.Add(2);
            Assert.IsFalse(list.BuildValidator().CountGreaterThan(3).Unique().Validate().IsValid);
        }        
    }
}
