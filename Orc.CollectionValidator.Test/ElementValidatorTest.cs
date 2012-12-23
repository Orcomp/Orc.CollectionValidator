namespace Orc.CollectionValidator.Test
{
    using System.Linq;
    using FluentValidation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Orc.CollectionValidator.SpecificValidators;
    using Orc.CollectionValidator.Test.Helpers;

    [TestClass]
    public class ElementValidatorTest
    {
        const string ErrorMessageText = "error message text";

        [TestMethod]
        public void CanValidateElement()
        {
            var validCollection = TestingDataFactory.ElementValidation.SimpleRange(3, 5);
            var invalidCollection = TestingDataFactory.ElementValidation.SimpleRange(1, 6);
            var validator = new ElementValidator<int>();
            validator.CreateRule().LessThan(6).GreaterThan(2);

            Assert.IsTrue(validator.Validate(validCollection).IsValid);
            Assert.IsFalse(validator.Validate(invalidCollection).IsValid);
        }

        [TestMethod]
        public void CanValidateElementByProperties()
        {
            var nullFirstNameCollection = TestingDataFactory.ElementValidation.CollectionWithNullFirstNames();
            var emptyLastNameCollection = TestingDataFactory.ElementValidation.CollectionWithEmptyLastNames();
            var nullElementCollection = TestingDataFactory.ElementValidation.CollectionWithNullElement();

            var notNullFirstNameValidator = new ElementValidator<GenericParameter>();
            notNullFirstNameValidator.CreatePropertyRule(x => x.FirstName).NotNull();

            var notEmptyLastNameValidator = new ElementValidator<GenericParameter>();
            notEmptyLastNameValidator.CreatePropertyRule(x => x.LastName).NotEmpty();

            var compositePropertiesValidator = new ElementValidator<GenericParameter>();
            compositePropertiesValidator.CreatePropertyRule(x => x.FirstName).NotNull();
            compositePropertiesValidator.CreatePropertyRule(x => x.LastName).NotEmpty();

            Assert.IsTrue(notNullFirstNameValidator.Validate(emptyLastNameCollection).IsValid);
            Assert.IsTrue(notEmptyLastNameValidator.Validate(nullFirstNameCollection).IsValid);            

            Assert.IsFalse(notNullFirstNameValidator.Validate(nullFirstNameCollection).IsValid);
            Assert.IsFalse(notEmptyLastNameValidator.Validate(emptyLastNameCollection).IsValid);

            Assert.IsTrue(notNullFirstNameValidator.Validate(nullElementCollection).IsValid);
            Assert.IsTrue(notEmptyLastNameValidator.Validate(nullElementCollection).IsValid);
            Assert.IsTrue(compositePropertiesValidator.Validate(nullElementCollection).IsValid);

            Assert.IsFalse(compositePropertiesValidator.Validate(nullFirstNameCollection).IsValid);
            Assert.IsFalse(compositePropertiesValidator.Validate(emptyLastNameCollection).IsValid);
        }

        [TestMethod]
        public void CanValidateElementAndProperty()
        {
            var nullFirstNameCollection = TestingDataFactory.ElementValidation.CollectionWithNullFirstNames();
            var emptyLastNameCollection = TestingDataFactory.ElementValidation.CollectionWithEmptyLastNames();
            var nullElementCollection = TestingDataFactory.ElementValidation.CollectionWithNullElement();

            var compositeValidator = new ElementValidator<GenericParameter>();
            compositeValidator.CreatePropertyRule(x => x.LastName).NotEmpty();
            compositeValidator.CreateRule().NotNull();

            Assert.IsTrue(compositeValidator.Validate(nullFirstNameCollection).IsValid);
            Assert.IsFalse(compositeValidator.Validate(emptyLastNameCollection).IsValid);
            Assert.IsFalse(compositeValidator.Validate(nullElementCollection).IsValid);
        }

        [TestMethod]
        public void CanUseFluentValidation()
        {
            var nullFirstNameCollection = TestingDataFactory.ElementValidation.CollectionWithNullFirstNames();
            var emptyLastNameCollection = TestingDataFactory.ElementValidation.CollectionWithEmptyLastNames();     
            var nullElementCollection = TestingDataFactory.ElementValidation.CollectionWithNullElement();

            var notNullFirstNameValidator = new ElementValidator<GenericParameter>();
            notNullFirstNameValidator.AddValidator(new InlineValidator<GenericParameter>
                                                       {
                                                           v => v.RuleFor(x => x.FirstName).NotNull()
                                                       });

            var notEmptyLastNameValidator = new ElementValidator<GenericParameter>();
            notEmptyLastNameValidator.AddValidator(new InlineValidator<GenericParameter>
                                                       {
                                                           v => v.RuleFor(x => x.LastName).NotEmpty()
                                                       });

            var compositePropertiesValidator = new ElementValidator<GenericParameter>();
            compositePropertiesValidator.AddValidator(new InlineValidator<GenericParameter>
                                                           {
                                                               v => v.RuleFor(x => x.FirstName).NotNull()
                                                           });
            compositePropertiesValidator.AddValidator(new InlineValidator<GenericParameter>
                                                       {
                                                           v => v.RuleFor(x => x.LastName).NotEmpty()
                                                       });

            Assert.IsTrue(notNullFirstNameValidator.Validate(emptyLastNameCollection).IsValid);
            Assert.IsTrue(notEmptyLastNameValidator.Validate(nullFirstNameCollection).IsValid);

            Assert.IsFalse(notNullFirstNameValidator.Validate(nullFirstNameCollection).IsValid);
            Assert.IsFalse(notEmptyLastNameValidator.Validate(emptyLastNameCollection).IsValid);

            Assert.IsTrue(notNullFirstNameValidator.Validate(nullElementCollection).IsValid);
            Assert.IsTrue(notEmptyLastNameValidator.Validate(nullElementCollection).IsValid);
            Assert.IsTrue(compositePropertiesValidator.Validate(nullElementCollection).IsValid);

            Assert.IsFalse(compositePropertiesValidator.Validate(nullFirstNameCollection).IsValid);
            Assert.IsFalse(compositePropertiesValidator.Validate(emptyLastNameCollection).IsValid);
        }

        [TestMethod]
        public void CanUseElementAndFluentValidation()
        {
            var nullFirstNameCollection = TestingDataFactory.ElementValidation.CollectionWithNullFirstNames();
            var emptyLastNameCollection = TestingDataFactory.ElementValidation.CollectionWithEmptyLastNames();
            var nullElementCollection = TestingDataFactory.ElementValidation.CollectionWithNullElement();

            var compositeValidator = new ElementValidator<GenericParameter>();
            compositeValidator.AddValidator(new InlineValidator<GenericParameter>
                                                {
                                                    v => v.RuleFor(x => x.LastName).NotEmpty()
                                                });
            compositeValidator.CreateRule().NotNull();

            Assert.IsTrue(compositeValidator.Validate(nullFirstNameCollection).IsValid);
            Assert.IsFalse(compositeValidator.Validate(emptyLastNameCollection).IsValid);
            Assert.IsFalse(compositeValidator.Validate(nullElementCollection).IsValid);
        }

        [TestMethod]
        public void CanValidateByProppertyAndElementAndFluentValidation()
        {
            var nullFirstNameCollection = TestingDataFactory.ElementValidation.CollectionWithNullFirstNames();
            var shortFirstNameCollection = TestingDataFactory.ElementValidation.CollectionWithShortFirstNames();
            var emptyLastNameCollection = TestingDataFactory.ElementValidation.CollectionWithEmptyLastNames();
            var nullElementCollection = TestingDataFactory.ElementValidation.CollectionWithNullElement();

            var compositeValidator = new ElementValidator<GenericParameter>();
            compositeValidator.AddValidator(new InlineValidator<GenericParameter>
                                                {
                                                    v => v.RuleFor(x => x.LastName).NotEmpty()
                                                });
            compositeValidator.CreateRule().NotNull();
            compositeValidator.CreatePropertyRule(x => x.FirstName).NotEmpty();

            Assert.IsFalse(compositeValidator.Validate(nullFirstNameCollection).IsValid);
            Assert.IsFalse(compositeValidator.Validate(emptyLastNameCollection).IsValid);
            Assert.IsFalse(compositeValidator.Validate(nullElementCollection).IsValid);
            Assert.IsTrue(compositeValidator.Validate(shortFirstNameCollection).IsValid);
        }

        [TestMethod]
        public void CanSetErrorMessage()
        {
            var invalidCollection = TestingDataFactory.ElementValidation.SimpleRange(1, 6);
            var validator = new ElementValidator<int>();
            validator.CreateRule().LessThan(6).GreaterThan(2);
            validator.SetErrorMessage(ErrorMessageText);
            var result = validator.Validate(invalidCollection);

            Assert.AreEqual(result.First().ErrorMessage, ErrorMessageText);
        }
    }
}

