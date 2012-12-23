namespace Orc.CollectionValidator.Test
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Orc.CollectionValidator.Test.Helpers;
    using System.Collections.Generic;
    using FluentValidation;

    [TestClass]
    public class CollectionValidatorTest
    {
        const string ErrorMessageText = "error message text";

        [TestMethod]
        public void CanValidateSimpleUnique()
        {
            var validTstingData = TestingDataFactory.Unique.CreateSimpleUniqueData();
            var invalidTestingData = TestingDataFactory.Unique.CreateSimpleNotUniqueData();
            var validator = new CollectionValidator<string>().Unique();
            Assert.IsTrue(validator.Validate(validTstingData.Collection).IsValid);
            Assert.IsFalse(validator.Validate(invalidTestingData.Collection).IsValid);
        }

        [TestMethod]
        public void CanValidateUsingProperties()
        {
            var fullyValidData = TestingDataFactory.Unique.CreateUniqueData();
            var duplicatedIdData = TestingDataFactory.Unique.CreateDuplicatedIdData();
            var duplicatedLastNameData = TestingDataFactory.Unique.CreateDuplicatedLastNameData();
            var duplicatedNamesData = TestingDataFactory.Unique.CreateDuplicatedNamesData();

            var validator = new CollectionValidator<GenericParameter>();
            validator.Unique(null, x => x.ID);

            Assert.IsTrue(validator.Validate(fullyValidData.Collection).IsValid);
            Assert.IsTrue(validator.Validate(duplicatedLastNameData.Collection).IsValid);
            Assert.IsTrue(validator.Validate(duplicatedNamesData.Collection).IsValid);
            Assert.IsFalse(validator.Validate(duplicatedIdData.Collection).IsValid);

            validator = new CollectionValidator<GenericParameter>().Unique(null, x => x.LastName);

            Assert.IsTrue(validator.Validate(fullyValidData.Collection).IsValid);
            Assert.IsFalse(validator.Validate(duplicatedLastNameData.Collection).IsValid);
            Assert.IsFalse(validator.Validate(duplicatedNamesData.Collection).IsValid);
            Assert.IsTrue(validator.Validate(duplicatedIdData.Collection).IsValid);

            validator.Unique(null, x => x.ID);
            Assert.IsTrue(validator.Validate(fullyValidData.Collection).IsValid);
            Assert.IsFalse(validator.Validate(duplicatedLastNameData.Collection).IsValid);
            Assert.IsFalse(validator.Validate(duplicatedNamesData.Collection).IsValid);
            Assert.IsFalse(validator.Validate(duplicatedIdData.Collection).IsValid);

            validator = new CollectionValidator<GenericParameter>().Unique(null, x => x.LastName, x => x.FirstName);
            Assert.IsTrue(validator.Validate(fullyValidData.Collection).IsValid);
            Assert.IsTrue(validator.Validate(duplicatedLastNameData.Collection).IsValid);
            Assert.IsFalse(validator.Validate(duplicatedNamesData.Collection).IsValid);
            Assert.IsTrue(validator.Validate(duplicatedIdData.Collection).IsValid);
        }

        [TestMethod]
        public void CanValidateCount()
        {
            var arr = new[] { 1, 2, 3, 4, 5 };

            var range6To8Validator = new CollectionValidator<int>().CountGreaterThan(6).CountLessThan(8);
            Assert.IsFalse(range6To8Validator.Validate(arr).IsValid);

            var range2To4Validator = new CollectionValidator<int>().CountGreaterThan(2).CountLessThan(4);
            Assert.IsFalse(range2To4Validator.Validate(arr).IsValid);

            var range3To6Validator = new CollectionValidator<int>().CountGreaterThan(3).CountLessThan(6);
            Assert.IsTrue(range3To6Validator.Validate(arr).IsValid);
        }

        [TestMethod]
        public void CanValidateSingleElementCollection()
        {
            var single = new[] { 1 };
            var multiple = new[] { 1, 2 };
            var empty = new int[0];

            var validator = new CollectionValidator<int>().Single();
            Assert.IsTrue(validator.Validate(single).IsValid);
            Assert.IsFalse(validator.Validate(multiple).IsValid);
            Assert.IsFalse(validator.Validate(empty).IsValid);
        }

        [TestMethod]
        public void CanValidateCountAndDuplicates()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };

            var validator = new CollectionValidator<int>().CountGreaterThan(3).Unique();
            Assert.IsTrue(validator.Validate(list).IsValid);

            list.Add(2);
            var result = validator.Validate(list);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void CanValidateElements()
        {
            var normalCollection = TestingDataFactory.Unique.CreateUniqueData();
            var shortFirstNameCollection = TestingDataFactory.ElementValidation.CollectionWithShortFirstNames();
            var emptyLastNameCollection = TestingDataFactory.ElementValidation.CollectionWithEmptyLastNames();
            var nullElementCollection = TestingDataFactory.ElementValidation.CollectionWithNullElement();

            var validator =
                new CollectionValidator<GenericParameter>()
                    .ElementValidation(new InlineValidator<GenericParameter>
                                           {
                                               v => v.RuleFor(x => x.FirstName).Length(2, 10)
                                           })
                    .ElementValidation(x => x.LastName, lastName => lastName.NotEmpty())
                    .ElementValidation(x => x.NotNull())
                    .ElementValidationMessage(ErrorMessageText);
           
            Assert.IsTrue(validator.Validate(normalCollection.Collection).IsValid);
            Assert.IsFalse(validator.Validate(shortFirstNameCollection).IsValid);
            Assert.IsFalse(validator.Validate(emptyLastNameCollection).IsValid);

            var result = validator.Validate(nullElementCollection);
            Assert.IsFalse(validator.Validate(nullElementCollection).IsValid);
            Assert.AreEqual(result.First().ErrorMessage, ErrorMessageText);
        }

        [TestMethod]
        public void CanValidateDuplicatesAndElements()
        {
            var validCollection = TestingDataFactory.ComposedValidation.DuplicatesAndElementsValidData();
            var invalidCollection = TestingDataFactory.ComposedValidation.DuplicatesAndElementsInvalidData();

            var validator =
                new CollectionValidator<GenericParameter>().ElementValidation(x => x.NotNull())
                                                           .ElementValidation(
                                                               x => x.FirstName, firstName => firstName.NotEmpty())
                                                           .Unique(null, x => x.ID);

            Assert.IsTrue(validator.Validate(validCollection).IsValid);
            Assert.IsFalse(validator.Validate(invalidCollection).IsValid);
        }

        public void CanValidateCountAndElements()
        {
            var invalidCollection = TestingDataFactory.ElementValidation.SimpleRange(2, 7);
            var validCollection = TestingDataFactory.ElementValidation.SimpleRange(3, 6);

            var validator =
                new CollectionValidator<int>().CountLessThan(5)
                                              .CountGreaterThan(2)
                                              .ElementValidation(x => x.LessThanOrEqualTo(6))
                                              .ElementValidation(x => x.GreaterThan(2));
            
            Assert.IsTrue(validator.Validate(validCollection).IsValid);
            Assert.IsFalse(validator.Validate(invalidCollection).IsValid);
        }
    }
}
