namespace Orc.CollectionValidator.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Orc.CollectionValidator;
    using System.Linq;
    using Orc.CollectionValidator.SpecificValidators;

    [TestClass]
    public class CountValidatorTest
    {
        const string ErrorMessageText = "error message text";        

        [TestMethod]
        public void CanValidate()
        {
            var arr = new[] { 1, 2, 3, 4, 5 };
            var countGreaterThen4 = new CountValidator<int>(count => count > 4);
            var countGreaterThen5 = new CountValidator<int>(count => count > 5, ErrorMessageText);
            var countLessThan6 = new CountValidator<int>(count => count < 6);
            var countLessThan3 = new CountValidator<int>(count => count < 3);

            Assert.IsTrue(countGreaterThen4.Validate(arr).IsValid);

            var result = countGreaterThen5.Validate(arr);
            Assert.IsFalse(result.IsValid);
            var expectedErrorMessage = ErrorMessageText;
            var actualErrorMessage = result.First().ErrorMessage;
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);

            Assert.IsTrue(countLessThan6.Validate(arr).IsValid);            

            result = countLessThan3.Validate(arr);
            Assert.IsFalse(result.IsValid);
            expectedErrorMessage = "Invalid collection items count";
            actualErrorMessage = result.First().ErrorMessage;
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }
    }
}
