namespace Orc.CollectionValidator.Test.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using FluentValidation;

    public class GenericParameterValidator : ValidatorFactoryBase
    {

        public override IValidator CreateInstance(Type validatorType)
        {
            //new CollectionValidator<int>().ElementPropRule()
            //new IRuleBuilderOptions<int,int>().

            throw new NotImplementedException();
        }
    }
}
