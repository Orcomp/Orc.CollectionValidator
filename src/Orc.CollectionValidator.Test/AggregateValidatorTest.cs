namespace Orc.CollectionValidator.Test
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Orc.CollectionValidator.SpecificValidators;
    using Orc.CollectionValidator.Test.Helpers;

    [TestClass]
    public class AggregateValidatorTest
    {
        const string ErrorMessageText = "error message text";

        [TestMethod]
        public void TestSumSimple()
        {
			var testData = new[] { 1, 2, 3 };

			var test = new AggregateValidator<int>((collection) => collection.Sum(), (sum) => sum == 6);
			Assert.IsTrue(test.Validate(testData).IsValid);

		}

		[TestMethod]
		public void TestSumWithSelector()
		{
			var testData = new[] { new GenericParameter { ID = 1 }, new GenericParameter { ID = 2 }, new GenericParameter { ID = 3 } };
			var test = new AggregateValidator<GenericParameter, int>((p) => p.ID, (collection) => collection.Sum(), (sum) => sum == 6);
			Assert.IsTrue(test.Validate(testData).IsValid);
		}

		[TestMethod]
		public void TestSumWithError()
		{
			var testData = new[] { new GenericParameter { ID = 1 }, new GenericParameter { ID = 2 }, new GenericParameter { ID = 3 } };
			var test = new AggregateValidator<GenericParameter, int>((p) => p.ID, (collection) => collection.Sum(), (sum) => sum == 5, ErrorMessageText);
			var result = test.Validate(testData);
			Assert.IsFalse(result.IsValid);
			Assert.IsTrue(result.Count() == 1);
			Assert.IsTrue(result.ElementAt(0) is AggregateValidationResult<int>);
			Assert.AreEqual(((AggregateValidationResult<int>)result.ElementAt(0)).ActualValue, 6);
			Assert.AreEqual(result.ElementAt(0).ErrorMessage, ErrorMessageText);
		}

    }
}
