namespace Orc.CollectionValidator.Test.Helpers
{
    using System.Collections.Generic;

    public class ComposedValidationDataFactory
    {
        private ComposedValidationDataFactory()
        {
        }

        public static readonly ComposedValidationDataFactory Instance = new ComposedValidationDataFactory();

        public IEnumerable<GenericParameter> DuplicatesAndElementsValidData()
        {
            return new[]
                       {
                           new GenericParameter { ID = 1, FirstName = "John", LastName = "Smith" },
                           new GenericParameter { ID = 2, FirstName = "Sara", LastName = "Lee" },
                           new GenericParameter { ID = 3, FirstName = "Ivan", LastName = "Susanin" },
                           new GenericParameter { ID = 4, FirstName = "Peter", LastName = "Obama" },
                           new GenericParameter { ID = 5, FirstName = "Serge", LastName = "Been" },
                           new GenericParameter { ID = 6, FirstName = "Armen", LastName = "Oganesyan" }
                       };
        }

        public IEnumerable<GenericParameter> DuplicatesAndElementsInvalidData()
        {
            return new[]
                       {
                           new GenericParameter { ID = 1, FirstName = "John", LastName = "Smith" },
                           new GenericParameter { ID = 1, FirstName = "John", LastName = "Smith" },
                           new GenericParameter { ID = 3, FirstName = null, LastName = null },
                           null,
                           new GenericParameter { ID = 5, FirstName = "Serge", LastName = "Been" },
                           new GenericParameter { ID = 6, FirstName = "Armen", LastName = "Oganesyan" }
                       };
        }
    }
}
