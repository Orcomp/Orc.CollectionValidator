using Orc.CollectionValidator.Utilits;

namespace Orc.CollectionValidator.SpecificValidators
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Orc.CollectionValidator.Interfaces;
	using System.Linq.Expressions;

	public class AggregateValidator<T, K> : AbstractCollectionValidator<T>, ICollectionValidator<T>
	{
		private readonly Func<T, K> selector;
		private readonly Predicate<K> condition;
		private readonly Func<IEnumerable<K>, K> aggregator;
		private readonly string errorMessage;
		private const string DefaultErrorMessage = "Invalid aggregate value";

		public AggregateValidator(Func<T, K> selector, Func<IEnumerable<K>, K> aggregator, Predicate<K> condition, string errorMessage = null)
			: base(string.IsNullOrEmpty(errorMessage) ? DefaultErrorMessage : errorMessage)
		{
			this.selector = selector;
			this.aggregator = aggregator;
			this.condition = condition;
			this.errorMessage = errorMessage;
		}

		/// <summary>
		/// This function validates collection
		/// </summary>
		/// <param name="collection">
		/// The collection.
		/// </param>
		/// <returns>
		/// The <see cref="ValidationResults"/>.
		/// </returns>
		public override ValidationResults Validate(IEnumerable<T> collection)
		{
			var values = collection.Select(x => selector(x));
			var aggregateValue = aggregator(values);
			return condition(aggregateValue) ? ValidationResults.Success : new ValidationResults( new [] { new AggregateValidationResult<K>() { ErrorMessage = errorMessage, ActualValue = aggregateValue } } );
		}

	}

	public class AggregateValidator<T> : AggregateValidator<T, T>
	{
		public AggregateValidator(Func<IEnumerable<T>, T> aggregator, Predicate<T> condition, string errorMessage = null)
			: base((x)=>x, aggregator, condition, errorMessage)
		{
			
		}
		
	}
}
