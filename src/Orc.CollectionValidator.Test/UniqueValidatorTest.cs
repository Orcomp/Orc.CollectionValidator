namespace Orc.CollectionValidator.Test
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Orc.CollectionValidator.SpecificValidators;
    using Orc.CollectionValidator.Test.Helpers;

    [TestClass]
    public class UniqueValidatorTest
    {
        const string ErrorMessageText = "error message text";

        [TestMethod]
        public void CanValidateUsingDefaultEqualityComparer()
        {
            var validTstingData = TestingDataFactory.Unique.CreateSimpleUniqueData();
            var invalidTestingData = TestingDataFactory.Unique.CreateSimpleNotUniqueData();

            var myStringCollectionValidator = new UniqueValidator<string>();

            var result = myStringCollectionValidator.Validate(validTstingData.Collection);
            Assert.IsTrue(result.IsValid);

            result = myStringCollectionValidator.Validate(invalidTestingData.Collection);
            Assert.IsFalse(result.IsValid);

            var equals = invalidTestingData.IsActualDuplicatesCorrect(
                ((UniqueValidationResult)result.First()).DuplicatedItems);
            Assert.IsTrue(equals);
        }

        [TestMethod]
        public void CanValidateUsingProperties()
        {
            var fullyValidData = TestingDataFactory.Unique.CreateUniqueData();
            var duplicatedIdData = TestingDataFactory.Unique.CreateDuplicatedIdData();
            var duplicatedLastNameData = TestingDataFactory.Unique.CreateDuplicatedLastNameData();
            var duplicatedNamesData = TestingDataFactory.Unique.CreateDuplicatedNamesData();

            var validatorById = new UniqueValidator<GenericParameter>(new Expression<Func<GenericParameter, object>>[]
                                                                          {
                                                                              x => x.ID
                                                                          });

            Assert.IsTrue(validatorById.Validate(fullyValidData.Collection).IsValid);            
            Assert.IsTrue(validatorById.Validate(duplicatedLastNameData.Collection).IsValid);
            Assert.IsTrue(validatorById.Validate(duplicatedNamesData.Collection).IsValid);

            var result = validatorById.Validate(duplicatedIdData.Collection);
            Assert.IsFalse(result.IsValid);
            var equals = duplicatedIdData.IsActualDuplicatesCorrect(((UniqueValidationResult) result.First()).DuplicatedItems);
            Assert.IsTrue(equals);

            var expectedErrorMessage = "Duplicated items were found in collection";
            var actualErrorMessage = result.First().ErrorMessage;
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);

            var validatorByNames =
                new UniqueValidator<GenericParameter>(
                    new Expression<Func<GenericParameter, object>>[] { x => x.FirstName, x => x.LastName },
                    ErrorMessageText);

            Assert.IsTrue(validatorByNames.Validate(fullyValidData.Collection).IsValid);
            Assert.IsTrue(validatorByNames.Validate(duplicatedIdData.Collection).IsValid);
            Assert.IsTrue(validatorByNames.Validate(duplicatedLastNameData.Collection).IsValid);
            
            result = validatorByNames.Validate(duplicatedNamesData.Collection);
            Assert.IsFalse(result.IsValid);
            equals = duplicatedNamesData.IsActualDuplicatesCorrect(
                ((UniqueValidationResult)result.First()).DuplicatedItems);
            Assert.IsTrue(equals);

            expectedErrorMessage = ErrorMessageText;
            actualErrorMessage = result.First().ErrorMessage;
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }
    }
}
