namespace Orc.CollectionValidator.Test.Helpers
{
    using System.Collections.Generic;

    public class ElementValidationTestingDataFactory
    {
        private ElementValidationTestingDataFactory()
        {
        }

        public static readonly ElementValidationTestingDataFactory Instance = new ElementValidationTestingDataFactory();

        public IEnumerable<int> SimpleRange(int min, int max)
        {
            for (var i = min; i <= max; i++)
            {
                yield return i;
            }
        }


        public IEnumerable<GenericParameter> CollectionWithNullFirstNames()
        {
            return new[]
                       {
                           new GenericParameter { ID = 1, FirstName = null, LastName = "Smith" },
                           new GenericParameter { ID = 2, FirstName = "Sara", LastName = "Lee" },
                           new GenericParameter { ID = 3, FirstName = "Ivan", LastName = "Susanin" },
                           new GenericParameter { ID = 4, FirstName = "Peter", LastName = "Obama" },
                           new GenericParameter { ID = 5, FirstName = "Serge", LastName = "Been" },
                           new GenericParameter { ID = 6, FirstName = "Armen", LastName = "Oganesyan" }
                       };
        }        

        public IEnumerable<GenericParameter> CollectionWithShortFirstNames()
        {
            return new[]
                       {
                           new GenericParameter { ID = 1, FirstName = "J", LastName = "Smith" },
                           new GenericParameter { ID = 2, FirstName = "Sara", LastName = "Lee" },
                           new GenericParameter { ID = 3, FirstName = "Ivan", LastName = "Susanin" },
                           new GenericParameter { ID = 4, FirstName = "Peter", LastName = "Obama" },
                           new GenericParameter { ID = 5, FirstName = "Serge", LastName = "Been" },
                           new GenericParameter { ID = 6, FirstName = "Armen", LastName = "Oganesyan" }
                       };
        }

        public IEnumerable<GenericParameter> CollectionWithEmptyLastNames()
        {
            return new[]
                       {
                           new GenericParameter { ID = 1, FirstName = "John", LastName = string.Empty },
                           new GenericParameter { ID = 2, FirstName = "Sara", LastName = "Lee" },
                           new GenericParameter { ID = 3, FirstName = "Ivan", LastName = "Susanin" },
                           new GenericParameter { ID = 4, FirstName = "Peter", LastName = "Obama" },
                           new GenericParameter { ID = 5, FirstName = "Serge", LastName = "Been" },
                           new GenericParameter { ID = 6, FirstName = "Armen", LastName = "Oganesyan" }
                       };
        }

        public IEnumerable<GenericParameter> CollectionWithNullElement()
        {
            return new[]
                       {
                           null,
                           new GenericParameter { ID = 2, FirstName = "Sara", LastName = "Lee" },
                           new GenericParameter { ID = 3, FirstName = "Ivan", LastName = "Susanin" },
                           new GenericParameter { ID = 4, FirstName = "Peter", LastName = "Obama" },
                           new GenericParameter { ID = 5, FirstName = "Serge", LastName = "Been" },
                           new GenericParameter { ID = 6, FirstName = "Armen", LastName = "Oganesyan" }
                       };
        }
    }
}
