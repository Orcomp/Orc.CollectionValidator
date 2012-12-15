using Orc.CollectionValidator.Utilits;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Orc.CollectionValidator.Test
{
    [TestClass()]
    public class ExpressionAnalizerTest
    {
        public void GetProppertyInfoTestHelper<T>()
        {
            var expected = typeof(GenericParameter).GetProperty("Id"); 
            var actual = ExpressionAnalizer.GetProppertyInfo<GenericParameter>(x => x.Id);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void GetProppertyInfoTest()
        {
            GetProppertyInfoTestHelper<GenericParameter>();
        }
    }
}
