using System.Collections.Generic;

namespace Orc.CollectionValidator.Interfaces
{
	using System;
	using System.Linq.Expressions;

	public interface IFluentCollectionValidator<out TBuilder, T>
		where TBuilder : IFluentCollectionValidator<TBuilder, T>
	{
		TBuilder Unique(
			string errorMessage = null, params Expression<Func<T, object>>[] properties);

		TBuilder CountGreaterThan(int count, string errorMessage = null);

		TBuilder CountLessThan(int count, string errorMessage = null);

		TBuilder CountGreaterOrEqualTo(int count, string errorMessage = null);

		TBuilder CountLessOrEqualTo(int count, string errorMessage = null);

		TBuilder CountCondition(Predicate<int> condition, string errorMessage = null);

		TBuilder AggregateCondition(Func<IEnumerable<T>, T> aggregator, Predicate<T> condition, string errorMessage = null);

		TBuilder AggregateCondition<K>(Func<T, K> selector, Func<IEnumerable<K>, K> aggregator, Predicate<K> condition, string errorMessage = null);

		TBuilder AggregateEqualTo(Func<T, double> selector, Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null);

		TBuilder AggregateGreaterThanOrEqualTo(Func<T, double> selector, Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null);

		TBuilder AggregateGreaterThan(Func<T, double> selector, Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null);

		TBuilder AggregateLessThanOrEqualTo(Func<T, double> selector, Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null);

		TBuilder AggregateLessThan(Func<T, double> selector, Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null);

		TBuilder SumEqualTo(Func<T, double> selector, double value, string errorMessage = null);

		TBuilder SumGreaterThanOrEqualTo(Func<T, double> selector, double value, string errorMessage = null);

		TBuilder SumGreaterThan(Func<T, double> selector, double value, string errorMessage = null);

		TBuilder SumLessThanOrEqualTo(Func<T, double> selector, double value, string errorMessage = null);

		TBuilder SumLessThan(Func<T, double> selector, double value, string errorMessage = null);

		TBuilder MinEqualTo(Func<T, double> selector, double value, string errorMessage = null);

		TBuilder MinGreaterThanOrEqualTo(Func<T, double> selector, double value, string errorMessage = null);

		TBuilder MinGreaterThan(Func<T, double> selector, double value, string errorMessage = null);

		TBuilder MinLessThanOrEqualTo(Func<T, double> selector, double value, string errorMessage = null);

		TBuilder MinLessThan(Func<T, double> selector, double value, string errorMessage = null);

		TBuilder MaxEqualTo(Func<T, double> selector, double value, string errorMessage = null);

		TBuilder MaxGreaterThanOrEqualTo(Func<T, double> selector, double value, string errorMessage = null);

		TBuilder MaxGreaterThan(Func<T, double> selector, double value, string errorMessage = null);

		TBuilder MaxLessThanOrEqualTo(Func<T, double> selector, double value, string errorMessage = null);

		TBuilder MaxLessThan(Func<T, double> selector, double value, string errorMessage = null);

		TBuilder Single();

		TBuilder ElementValidation(FluentValidation.AbstractValidator<T> validator);

		TBuilder ElementValidation<TProp>(
			Expression<Func<T, TProp>> property,
			Func<FluentValidation.IRuleBuilder<T, TProp>, FluentValidation.IRuleBuilderOptions<T, TProp>>
				validationRules);

		TBuilder ElementValidation(
			Func<FluentValidation.IRuleBuilder<ElementWrapper<T>, T>, FluentValidation.IRuleBuilderOptions<ElementWrapper<T>, T>>
				validationRules);

		TBuilder ElementValidationMessage(string errorMessage);
	}
}
