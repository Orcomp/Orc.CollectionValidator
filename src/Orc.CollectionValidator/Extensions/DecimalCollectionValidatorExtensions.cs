using System;
using System.Collections.Generic;
using System.Linq;

namespace Orc.CollectionValidator
{

    public static class DecimalCollectionValidatorExtensions 
    {

		public static CollectionValidator<decimal> AggregateEqualTo(this CollectionValidator<decimal> collectionValidator, Func<IEnumerable<decimal>, decimal> aggregator, decimal value, string errorMessage = null)
		{
			return collectionValidator.AggregateEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (decimal)x)), (double)value, errorMessage);
		}
		
		public static CollectionValidator<decimal> AggregateGreaterThanOrEqualTo(this CollectionValidator<decimal> collectionValidator,  Func<IEnumerable<decimal>, decimal> aggregator, decimal value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (decimal)x)), (double)value, errorMessage);
		}

		public static CollectionValidator<decimal> AggregateGreaterThan(this CollectionValidator<decimal> collectionValidator,  Func<IEnumerable<decimal>, decimal> aggregator, decimal value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (decimal)x)), (double)value, errorMessage);
		}

		public static CollectionValidator<decimal> AggregateLessThanOrEqualTo(this CollectionValidator<decimal> collectionValidator,  Func<IEnumerable<decimal>, decimal> aggregator, decimal value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (decimal)x)), (double)value, errorMessage);
		}

		public static CollectionValidator<decimal> AggregateLessThan(this CollectionValidator<decimal> collectionValidator,  Func<IEnumerable<decimal>, decimal> aggregator, decimal value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (decimal)x)), (double)value, errorMessage);
		}

		public static CollectionValidator<decimal> SumEqualTo(this CollectionValidator<decimal> collectionValidator,  decimal value, string errorMessage = null)
		{
			return collectionValidator.SumEqualTo((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<decimal> SumGreaterThanOrEqualTo(this CollectionValidator<decimal> collectionValidator,  decimal value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThanOrEqualTo((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<decimal> SumGreaterThan(this CollectionValidator<decimal> collectionValidator,  decimal value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThan((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<decimal> SumLessThanOrEqualTo(this CollectionValidator<decimal> collectionValidator,  decimal value, string errorMessage = null)
		{
			return collectionValidator.SumLessThanOrEqualTo((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<decimal> SumLessThan(this CollectionValidator<decimal> collectionValidator,  decimal value, string errorMessage = null)
		{
			return collectionValidator.SumLessThan((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<decimal> MinEqualTo(this CollectionValidator<decimal> collectionValidator,  decimal value, string errorMessage = null)
		{
			return collectionValidator.MinEqualTo((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<decimal> MinGreaterThanOrEqualTo(this CollectionValidator<decimal> collectionValidator,  decimal value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThanOrEqualTo((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<decimal> MinGreaterThan(this CollectionValidator<decimal> collectionValidator,  decimal value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThan((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<decimal> MinLessThanOrEqualTo(this CollectionValidator<decimal> collectionValidator,  decimal value, string errorMessage = null)
		{
			return collectionValidator.MinLessThanOrEqualTo((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<decimal> MinLessThan(this CollectionValidator<decimal> collectionValidator,  decimal value, string errorMessage = null)
		{
			return collectionValidator.MinLessThan((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<decimal> MaxEqualTo(this CollectionValidator<decimal> collectionValidator,  decimal value, string errorMessage = null)
		{
			return collectionValidator.MaxEqualTo((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<decimal> MaxGreaterThanOrEqualTo(this CollectionValidator<decimal> collectionValidator,  decimal value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThanOrEqualTo((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<decimal> MaxGreaterThan(this CollectionValidator<decimal> collectionValidator,  decimal value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThan((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<decimal> MaxLessThanOrEqualTo(this CollectionValidator<decimal> collectionValidator,  decimal value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThanOrEqualTo((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<decimal> MaxLessThan(this CollectionValidator<decimal> collectionValidator,  decimal value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThan((x) => (double)x, (double)value, errorMessage);
		}
    }
}
