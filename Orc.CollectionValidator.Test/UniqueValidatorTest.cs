namespace Orc.CollectionValidator.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UniqueValidatorTest
    {
        [TestMethod]
        public void SimpleValidation()
        {
            var validCollection = new List<string> { "a", "b", "c" };
            var invalidCollection = new List<string> { "a", "b", "a" };

            var myStringCollectionValidator = new CollectionValidator<string>();
            myStringCollectionValidator.Unique();

            var validCollectionValidationResults = myStringCollectionValidator.Validate(validCollection);
            Assert.IsTrue(validCollectionValidationResults.IsValid);

            var invalidCollectionValidationResults = myStringCollectionValidator.Validate(invalidCollection);
            Assert.IsFalse(invalidCollectionValidationResults.IsValid);
        }

        class MyClass
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        [TestMethod]
        public void PropertiesValidation()
        {
            var validCollection1 = new List<MyClass>
                                      {
                                          new MyClass { ID = 1, FirstName = "John", LastName = "Smith" },
                                          new MyClass { ID = 2, FirstName = "Sara", LastName = "Lee" },
                                          new MyClass { ID = 3, FirstName = "Ivan", LastName = "Susanin" }
                                      };
            var invalidCollection1 = new List<MyClass>
                                      {
                                          new MyClass { ID = 1, FirstName = "John", LastName = "Smith" },
                                          new MyClass { ID = 1, FirstName = "Sara", LastName = "Lee" },
                                          new MyClass { ID = 3, FirstName = "Ivan", LastName = "Susanin" }
                                      };
            var invalidCollection2 = new List<MyClass>
                                      {
                                          new MyClass { ID = 1, FirstName = "John", LastName = "Smith" },
                                          new MyClass { ID = 2, FirstName = "John", LastName = "Smith" },
                                          new MyClass { ID = 3, FirstName = "Ivan", LastName = "Susanin" }
                                      };
            var validator = new CollectionValidator<MyClass>();
            validator.Unique(x => x.ID);

            var validCollectionValidationResults = validator.Validate(validCollection1);
            Assert.IsTrue(validCollectionValidationResults.IsValid);

            var invalidCollectionValidationResults = validator.Validate(invalidCollection1);
            Assert.IsFalse(invalidCollectionValidationResults.IsValid);

            validCollectionValidationResults = validator.Validate(invalidCollection2);
            Assert.IsTrue(validCollectionValidationResults.IsValid);

            validator.Unique(x => x.FirstName, x => x.LastName);

            invalidCollectionValidationResults = validator.Validate(invalidCollection2);
            Assert.IsTrue(invalidCollectionValidationResults.IsValid);

            invalidCollectionValidationResults = validator.Validate(invalidCollection1);
            Assert.IsFalse(invalidCollectionValidationResults.IsValid);
        }
    }
}
