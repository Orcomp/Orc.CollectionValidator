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
        [TestMethod]
        public void CanValidateSimpleUnique()
        {
            var validTstingData = UniqueTestingDataFactory.CreateSimpleUniqueData();
            var invalidTestingData = UniqueTestingDataFactory.CreateSimpleNotUniqueData();
            var validator = new CollectionValidator<string>().Unique();
            Assert.IsTrue(validator.Validate(validTstingData.Collection).IsValid);
            Assert.IsFalse(validator.Validate(invalidTestingData.Collection).IsValid);
        }

        [TestMethod]
        public void CanValidateUsingProperties()
        {
            var fullyValidData = UniqueTestingDataFactory.CreateUniqueData();
            var duplicatedIdData = UniqueTestingDataFactory.CreateDuplicatedIdData();
            var duplicatedLastNameData = UniqueTestingDataFactory.CreateDuplicatedLastNameData();
            var duplicatedNamesData = UniqueTestingDataFactory.CreateDuplicatedNamesData();

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
        public void CanValidateElementsUsingRules()
        {
           // var validator = new CollectionValidator<int>().ElementValidation(
             //   x => x, x => x.LessThan(2));
           // FluentValidation.Internal.PropertyRule.Create()
           // new FluentValidation.InlineValidator<GenericParameter>().AddRule(IRuleBuilderOptions<GenericParameter,string>)

            Assert.Inconclusive("Not implemented yet");
        }
    }
}
