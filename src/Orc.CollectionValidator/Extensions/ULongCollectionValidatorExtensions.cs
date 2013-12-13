using System;
using System.Collections.Generic;
using System.Linq;

namespace Orc.CollectionValidator
{

    public static class ULongCollectionValidatorExtensions 
    {

		public static CollectionValidator<ulong> AggregateEqualTo(this CollectionValidator<ulong> collectionValidator, Func<IEnumerable<ulong>, ulong> aggregator, ulong value, string errorMessage = null)
		{
			return collectionValidator.AggregateEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (ulong)x)), (double)value, errorMessage);
		}
		
		public static CollectionValidator<ulong> AggregateGreaterThanOrEqualTo(this CollectionValidator<ulong> collectionValidator,  Func<IEnumerable<ulong>, ulong> aggregator, ulong value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (ulong)x)), (ulong)value, errorMessage);
		}

		public static CollectionValidator<ulong> AggregateGreaterThan(this CollectionValidator<ulong> collectionValidator,  Func<IEnumerable<ulong>, ulong> aggregator, ulong value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (ulong)x)), (ulong)value, errorMessage);
		}

		public static CollectionValidator<ulong> AggregateLessThanOrEqualTo(this CollectionValidator<ulong> collectionValidator,  Func<IEnumerable<ulong>, ulong> aggregator, ulong value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (ulong)x)), (ulong)value, errorMessage);
		}

		public static CollectionValidator<ulong> AggregateLessThan(this CollectionValidator<ulong> collectionValidator,  Func<IEnumerable<ulong>, ulong> aggregator, ulong value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (ulong)x)), (ulong)value, errorMessage);
		}

		public static CollectionValidator<ulong> SumEqualTo(this CollectionValidator<ulong> collectionValidator,  ulong value, string errorMessage = null)
		{
			return collectionValidator.SumEqualTo((x) => (double)x, (ulong)value, errorMessage);
		}

		public static CollectionValidator<ulong> SumGreaterThanOrEqualTo(this CollectionValidator<ulong> collectionValidator,  ulong value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThanOrEqualTo((x) => (double)x, (ulong)value, errorMessage);
		}

		public static CollectionValidator<ulong> SumGreaterThan(this CollectionValidator<ulong> collectionValidator,  ulong value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThan((x) => (double)x,  (ulong)value, errorMessage);
		}

		public static CollectionValidator<ulong> SumLessThanOrEqualTo(this CollectionValidator<ulong> collectionValidator,  ulong value, string errorMessage = null)
		{
			return collectionValidator.SumLessThanOrEqualTo((x) => (double)x, (ulong)value, errorMessage);
		}

		public static CollectionValidator<ulong> SumLessThan(this CollectionValidator<ulong> collectionValidator,  ulong value, string errorMessage = null)
		{
			return collectionValidator.SumLessThan((x) => (double)x,  (ulong)value, errorMessage);
		}

		public static CollectionValidator<ulong> MinEqualTo(this CollectionValidator<ulong> collectionValidator,  ulong value, string errorMessage = null)
		{
			return collectionValidator.MinEqualTo((x) => (double)x, (ulong)value, errorMessage);
		}

		public static CollectionValidator<ulong> MinGreaterThanOrEqualTo(this CollectionValidator<ulong> collectionValidator,  ulong value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThanOrEqualTo((x) => (double)x, (ulong)value, errorMessage);
		}

		public static CollectionValidator<ulong> MinGreaterThan(this CollectionValidator<ulong> collectionValidator,  ulong value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThan((x) => (double)x, (ulong)value, errorMessage);
		}

		public static CollectionValidator<ulong> MinLessThanOrEqualTo(this CollectionValidator<ulong> collectionValidator,  ulong value, string errorMessage = null)
		{
			return collectionValidator.MinLessThanOrEqualTo((x) => (double)x,  (ulong)value, errorMessage);
		}

		public static CollectionValidator<ulong> MinLessThan(this CollectionValidator<ulong> collectionValidator,  ulong value, string errorMessage = null)
		{
			return collectionValidator.MinLessThan((x) => (double)x, (ulong)value, errorMessage);
		}

		public static CollectionValidator<ulong> MaxEqualTo(this CollectionValidator<ulong> collectionValidator,  ulong value, string errorMessage = null)
		{
			return collectionValidator.MaxEqualTo((x) => (double)x,  (ulong)value, errorMessage);
		}

		public static CollectionValidator<ulong> MaxGreaterThanOrEqualTo(this CollectionValidator<ulong> collectionValidator,  ulong value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThanOrEqualTo((x) => (double)x, (ulong)value, errorMessage);
		}

		public static CollectionValidator<ulong> MaxGreaterThan(this CollectionValidator<ulong> collectionValidator,  ulong value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThan((x) => (double)x, (ulong)value, errorMessage);
		}

		public static CollectionValidator<ulong> MaxLessThanOrEqualTo(this CollectionValidator<ulong> collectionValidator,  ulong value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThanOrEqualTo((x) => (double)x,  (ulong)value, errorMessage);
		}

		public static CollectionValidator<ulong> MaxLessThan(this CollectionValidator<ulong> collectionValidator,  ulong value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThan((x) => (double)x, (ulong)value, errorMessage);
		}
    }
}
