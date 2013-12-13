namespace Orc.CollectionValidator.SpecificValidators
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Orc.CollectionValidator.Interfaces;
	using System.Linq.Expressions;

	public class OrderedValidator<TSource, TKey> : AbstractCollectionValidator<TSource>, ICollectionValidator<TSource> 
	{
		private readonly OrderDirection orderDirection;
		private const string DefaultErrorMessage = "Invalid collection order";
		private readonly IComparer<TKey> keyComparer; 
		private readonly Func<TSource, TKey> keySelector; 

		public OrderedValidator(Func<TSource, TKey> keySelector, IComparer<TKey> keyComparer = null, OrderDirection direction = OrderDirection.Ascending, string errorMessage = null)
			: base(string.IsNullOrEmpty(errorMessage) ? DefaultErrorMessage : errorMessage)
		{
			this.keySelector = keySelector;
			this.keyComparer = keyComparer ?? Comparer<TKey>.Default;
			this.orderDirection = direction;
		}

		public override ValidationResults Validate(IEnumerable<TSource> collection)
		{
			
			return !collection.SequenceEqual(
				orderDirection == OrderDirection.Ascending ? collection.OrderBy(keySelector, keyComparer) : collection.OrderByDescending(keySelector, keyComparer))
					   ? ValidationResults.Failed(this.ErrorMessage) 
					   : ValidationResults.Success;
		}
	}

	public class OrderedValidator<TSource> : OrderedValidator<TSource,TSource> 
	{

		public OrderedValidator(IComparer<TSource> comparer = null, OrderDirection direction = OrderDirection.Ascending, string errorMessage = null)
			: base((s)=>s, comparer, direction, errorMessage) 
		{
		}
		
	}

	public enum OrderDirection
	{
		Ascending,
		Descending
	}
}
