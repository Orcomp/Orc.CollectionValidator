namespace Orc.CollectionValidator.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Orc.CollectionValidator.Test.Helpers;

    [TestClass]
    public class UniqueValidatorTest
    {
        const string ErrorMessageText = "error message text";

        [TestMethod]
        public void CanValidateUsingDefaultEqualityComparer()
        {
            var validTstingData = UniqueTestingDataFactory.CreateSimpleUniqueData();
            var invalidTestingData = UniqueTestingDataFactory.CreateSimpleNotUniqueData();

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
            var fullyValidData = UniqueTestingDataFactory.CreateUniqueData();
            var duplicatedIdData = UniqueTestingDataFactory.CreateDuplicatedIdData();
            var duplicatedLastNameData = UniqueTestingDataFactory.CreateDuplicatedLastNameData();
            var duplicatedNamesData = UniqueTestingDataFactory.CreateDuplicatedNamesData();

            var validatorById = new UniqueValidator<GenericParameter>(new Expression<Func<GenericParameter, object>>[]
                                                                          {
                                                                              x => x.ID
                                                                          });

            Assert.IsTrue(validatorById.Validate(fullyValidData.Collection).IsValid);            
            Assert.IsTrue(validatorById.Validate(duplicatedLastNameData.Collection).IsValid);
            Assert.IsTrue(validatorById.Validate(duplicatedNamesData.Collection).IsValid);

            var result = validatorById.Validate(duplicatedIdData.Collection);
            Assert.IsFalse(result.IsValid);
            var equals = duplicatedIdData.IsActualDuplicatesCorrect(
                ((UniqueValidationResult)result.First()).DuplicatedItems);
            Assert.IsTrue(equals);

            var expectedErrorMessage = "Duplicated items were found in collection";
            var actuelErrorMessage = result.First().ErrorMessage;
            Assert.AreEqual(expectedErrorMessage, actuelErrorMessage);

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
            actuelErrorMessage = result.First().ErrorMessage;
            Assert.AreEqual(expectedErrorMessage, actuelErrorMessage);
        }            
    }
}
