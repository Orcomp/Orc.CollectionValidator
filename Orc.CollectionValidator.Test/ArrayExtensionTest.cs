namespace Orc.CollectionValidator.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Orc.CollectionValidator.Utilits;

    [TestClass]
    public class ArrayExtensionTest
    {        
        int[] array = new[] { 0, 1, 2, 3, 1, 1, 2, 3, 4, 5, 3, 4 };        

        public void SimpleFindAllIndexesTestHelper()
        {
            var expected = new List<int> { 1, 4, 5 };

            var actual = this.array.FindAllIndexes(0, new int[0], 1);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        public void ComparerFindAllIndexesTestHelper()
        {
            var expected = new List<int> { 1, 4, 5 };

            var actual = this.array.FindAllIndexes(0, new int[0], 1, EqualityComparer<int>.Default);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        public void SkipFindAllIndexesTestHelper()
        {
            var expected = new List<int> { 1, 5 };

            var actual = this.array.FindAllIndexes(0, new[] { 4 }, 1, EqualityComparer<int>.Default);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void FindAllIndexesTest()
        {
            this.SimpleFindAllIndexesTestHelper();
            this.ComparerFindAllIndexesTestHelper();
            this.SkipFindAllIndexesTestHelper();
        }
    }
}
