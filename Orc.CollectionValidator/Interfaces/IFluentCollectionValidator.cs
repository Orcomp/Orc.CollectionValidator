namespace Orc.CollectionValidator.Interfaces
{
    using System;
    using System.Linq.Expressions;

    public interface IFluentCollectionValidator<TBuilder, T>
        where TBuilder : IFluentCollectionValidator<TBuilder, T>
    {
        TBuilder Unique(
            string errorMessage = null, params Expression<Func<T, object>>[] properties);

        TBuilder CountGreaterThan(int count, string errorMessage = null);

        TBuilder CountLessThan(int count, string errorMessage = null);

        TBuilder CountGreaterOrEqualTo(int count, string errorMessage = null);

        TBuilder CountLessOrEqualTo(int count, string errorMessage = null);

        TBuilder CountCondition(Predicate<int> condition, string errorMessage = null);

        TBuilder Single();

        TBuilder ElementValidation(FluentValidation.AbstractValidator<T> validator);

        TBuilder ElementValidation<TProp>(
            Expression<Func<T, TProp>> property,
            Func<FluentValidation.IRuleBuilder<T, TProp>, FluentValidation.IRuleBuilderOptions<T, TProp>>
                validationRules);
    }
}
