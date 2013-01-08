using System;
using System.Collections.Generic;
using System.Linq;
using Orc.CollectionValidator.SpecificValidators;

namespace Orc.CollectionValidator
{

    public static class LongCollectionValidatorExtensions 
    {

		public static CollectionValidator<long> AggregateEqualTo(this CollectionValidator<long> collectionValidator, Func<IEnumerable<long>, long> aggregator, long value, string errorMessage = null)
		{
			return collectionValidator.AggregateEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (long)x)), (double)value, errorMessage);
		}
		
		public static CollectionValidator<long> AggregateGreaterThanOrEqualTo(this CollectionValidator<long> collectionValidator,  Func<IEnumerable<long>, long> aggregator, long value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (long)x)), (long)value, errorMessage);
		}

		public static CollectionValidator<long> AggregateGreaterThan(this CollectionValidator<long> collectionValidator,  Func<IEnumerable<long>, long> aggregator, long value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (long)x)), (long)value, errorMessage);
		}

		public static CollectionValidator<long> AggregateLessThanOrEqualTo(this CollectionValidator<long> collectionValidator,  Func<IEnumerable<long>, long> aggregator, long value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (long)x)), (long)value, errorMessage);
		}

		public static CollectionValidator<long> AggregateLessThan(this CollectionValidator<long> collectionValidator,  Func<IEnumerable<long>, long> aggregator, long value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (long)x)), (long)value, errorMessage);
		}

		public static CollectionValidator<long> SumEqualTo(this CollectionValidator<long> collectionValidator,  long value, string errorMessage = null)
		{
			return collectionValidator.SumEqualTo((x) => (double)x, (long)value, errorMessage);
		}

		public static CollectionValidator<long> SumGreaterThanOrEqualTo(this CollectionValidator<long> collectionValidator,  long value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThanOrEqualTo((x) => (double)x, (long)value, errorMessage);
		}

		public static CollectionValidator<long> SumGreaterThan(this CollectionValidator<long> collectionValidator,  long value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThan((x) => (double)x,  (long)value, errorMessage);
		}

		public static CollectionValidator<long> SumLessThanOrEqualTo(this CollectionValidator<long> collectionValidator,  long value, string errorMessage = null)
		{
			return collectionValidator.SumLessThanOrEqualTo((x) => (double)x, (long)value, errorMessage);
		}

		public static CollectionValidator<long> SumLessThan(this CollectionValidator<long> collectionValidator,  long value, string errorMessage = null)
		{
			return collectionValidator.SumLessThan((x) => (double)x,  (long)value, errorMessage);
		}

		public static CollectionValidator<long> MinEqualTo(this CollectionValidator<long> collectionValidator,  long value, string errorMessage = null)
		{
			return collectionValidator.MinEqualTo((x) => (double)x, (long)value, errorMessage);
		}

		public static CollectionValidator<long> MinGreaterThanOrEqualTo(this CollectionValidator<long> collectionValidator,  long value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThanOrEqualTo((x) => (double)x, (long)value, errorMessage);
		}

		public static CollectionValidator<long> MinGreaterThan(this CollectionValidator<long> collectionValidator,  long value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThan((x) => (double)x, (long)value, errorMessage);
		}

		public static CollectionValidator<long> MinLessThanOrEqualTo(this CollectionValidator<long> collectionValidator,  long value, string errorMessage = null)
		{
			return collectionValidator.MinLessThanOrEqualTo((x) => (double)x,  (long)value, errorMessage);
		}

		public static CollectionValidator<long> MinLessThan(this CollectionValidator<long> collectionValidator,  long value, string errorMessage = null)
		{
			return collectionValidator.MinLessThan((x) => (double)x, (long)value, errorMessage);
		}

		public static CollectionValidator<long> MaxEqualTo(this CollectionValidator<long> collectionValidator,  long value, string errorMessage = null)
		{
			return collectionValidator.MaxEqualTo((x) => (double)x,  (long)value, errorMessage);
		}

		public static CollectionValidator<long> MaxGreaterThanOrEqualTo(this CollectionValidator<long> collectionValidator,  long value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThanOrEqualTo((x) => (double)x, (long)value, errorMessage);
		}

		public static CollectionValidator<long> MaxGreaterThan(this CollectionValidator<long> collectionValidator,  long value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThan((x) => (double)x, (long)value, errorMessage);
		}

		public static CollectionValidator<long> MaxLessThanOrEqualTo(this CollectionValidator<long> collectionValidator,  long value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThanOrEqualTo((x) => (double)x,  (long)value, errorMessage);
		}

		public static CollectionValidator<long> MaxLessThan(this CollectionValidator<long> collectionValidator,  long value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThan((x) => (double)x, (long)value, errorMessage);
		}
    }
}
