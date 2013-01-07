namespace Orc.CollectionValidator.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Orc.CollectionValidator.Test.Helpers;
    using Orc.CollectionValidator.Utilits;

    [TestClass]
    public class ExtensionsTest
    {
        private readonly int[] array = new[] { 0, 1, 2, 3, 1, 1, 2, 3, 4, 5, 3, 4 };

        [TestMethod]
        public void CanFindAllIndexes()
        {
            var expected = new List<int> { 1, 4, 5 };

            var actual = this.array.FindAllIndexes(0, new int[0], 1);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void CanFindAllIndexesUsingComparer()
        {
            var expected = new List<int> { 1, 4, 5 };

            var actual = this.array.FindAllIndexes(0, new int[0], 1, EqualityComparer<int>.Default);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void CanFindAllIndexesUsingComparerAndSkipList()
        {
            var expected = new List<int> { 1, 5 };

            var actual = this.array.FindAllIndexes(0, new[] { 4 }, 1, EqualityComparer<int>.Default);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void CanGetProppertyInfo()
        {
            var obj = new GenericParameter();
            var expected = obj.GetType().GetProperty("ID");
            Expression<Func<GenericParameter, object>> expression = x => x.ID;
            var actual = expression.GetPropertyInfo();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetProppertyInfoTest()
        {
            this.CanGetProppertyInfo();
        }
    }
}
