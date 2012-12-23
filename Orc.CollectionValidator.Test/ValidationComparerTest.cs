namespace Orc.CollectionValidator.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Orc.CollectionValidator.SpecificValidators;
    using Orc.CollectionValidator.Test.Helpers;

    [TestClass]
    public class ValidationComparerTest
    {
        [TestMethod]
        public void CanCompareUsingUserDefinedEqualsFunction()
        {
            var comparer = new ValidationComparer<GenericParameter>((x, y) => x.ID == y.ID);
            var obj1 = new GenericParameter { ID = 1, FirstName = "John", LastName = "Smith" };
            var obj2 = new GenericParameter { ID = 1, FirstName = "Ivan", LastName = "Ivanov" };
            var obj3 = new GenericParameter { ID = 2, FirstName = "Ivan", LastName = "Ivanov" };

            Assert.IsTrue(comparer.Equals(obj1, obj2));
            Assert.IsFalse(comparer.Equals(obj1, obj3));
            Assert.IsFalse(comparer.Equals(obj2, obj3));
        }

        [TestMethod]
        public void CanCompareUsingParameters()
        {            
            var comparer1 = new ValidationComparer<GenericParameter>(x => x.ID);
            var comparer2 = new ValidationComparer<GenericParameter>(x => x.LastName, x => x.FirstName);
            var obj1 = new GenericParameter { ID = 1, FirstName = "John", LastName = "Smith" };
            var obj2 = new GenericParameter { ID = 1, FirstName = "Ivan", LastName = "Ivanov" };
            var obj3 = new GenericParameter { ID = 2, FirstName = "Ivan", LastName = "Ivanov" };

            Assert.IsTrue(comparer1.Equals(obj1, obj2));
            Assert.IsFalse(comparer1.Equals(obj1, obj3));
            Assert.IsFalse(comparer1.Equals(obj2, obj3));

            Assert.IsFalse(comparer2.Equals(obj1, obj2));
            Assert.IsFalse(comparer2.Equals(obj1, obj3));
            Assert.IsTrue(comparer2.Equals(obj2, obj3));
        }    
    }
}
