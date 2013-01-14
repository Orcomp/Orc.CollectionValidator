namespace Orc.CollectionValidator.Test
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Orc.CollectionValidator.SpecificValidators;
    using Orc.CollectionValidator.Test.Helpers;

    [TestClass]
    public class OrderedValidatorTest
    {
        const string ErrorMessageText = "error message text";

        [TestMethod]
        public void CaValidateUsingDefaultComparer()
        {
            var validTestingData = TestingDataFactory.Ordered.CreateSimpleOrderedData();
			var invalidTestingData = TestingDataFactory.Ordered.CreateSimpleUnorderedData();

            var myStringCollectionValidator = new OrderedValidator<int>();

			var result = myStringCollectionValidator.Validate(validTestingData.Collection);
            Assert.IsTrue(result.IsValid);

            result = myStringCollectionValidator.Validate(invalidTestingData.Collection);
            Assert.IsFalse(result.IsValid);

		}

        [TestMethod]
        public void CanValidateUsingProperties()
        {
			var validatorById = new OrderedValidator<GenericParameter, int>(g => g.ID);
            Assert.IsTrue(validatorById.Validate( TestingDataFactory.Ordered.CreateOrderedData().Collection).IsValid);            
            Assert.IsTrue(validatorById.Validate(TestingDataFactory.Ordered.CreateOrderedDataWithDuplicates().Collection).IsValid);
            Assert.IsTrue(validatorById.Validate( TestingDataFactory.Ordered.CreateEmptyData().Collection).IsValid);
            Assert.IsFalse(validatorById.Validate( TestingDataFactory.Ordered.CreateUnorderedData().Collection).IsValid);
			Assert.IsFalse(validatorById.Validate( TestingDataFactory.Ordered.CreateUnorderedDataWithDuplicates().Collection).IsValid);

			var x = new[] { 1, 2, 3 };
			x.Min();
        }

		[TestMethod]
		public void UsesCustomErrorMessage()
		{
			var validatorById = new OrderedValidator<GenericParameter, int>(g => g.ID, errorMessage: ErrorMessageText);
			var result = validatorById.Validate(TestingDataFactory.Ordered.CreateUnorderedDataWithDuplicates().Collection);
			Assert.IsTrue(result.Count() == 1);
			Assert.AreEqual(result.First().ErrorMessage, ErrorMessageText);

		}
    }
}
