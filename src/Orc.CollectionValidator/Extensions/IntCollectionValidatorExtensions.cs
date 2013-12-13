using System;
using System.Collections.Generic;
using System.Linq;

namespace Orc.CollectionValidator
{

    public static class IntCollectionValidatorExtensions 
    {

		public static CollectionValidator<int> AggregateEqualTo(this CollectionValidator<int> collectionValidator, Func<IEnumerable<int>, int> aggregator, int value, string errorMessage = null)
		{
			return collectionValidator.AggregateEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (int)x)), (double)value, errorMessage);
		}
		
		public static CollectionValidator<int> AggregateGreaterThanOrEqualTo(this CollectionValidator<int> collectionValidator,  Func<IEnumerable<int>, int> aggregator, int value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (int)x)), (int)value, errorMessage);
		}

		public static CollectionValidator<int> AggregateGreaterThan(this CollectionValidator<int> collectionValidator,  Func<IEnumerable<int>, int> aggregator, int value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (int)x)), (int)value, errorMessage);
		}

		public static CollectionValidator<int> AggregateLessThanOrEqualTo(this CollectionValidator<int> collectionValidator,  Func<IEnumerable<int>, int> aggregator, int value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (int)x)), (int)value, errorMessage);
		}

		public static CollectionValidator<int> AggregateLessThan(this CollectionValidator<int> collectionValidator,  Func<IEnumerable<int>, int> aggregator, int value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (int)x)), (int)value, errorMessage);
		}

		public static CollectionValidator<int> SumEqualTo(this CollectionValidator<int> collectionValidator,  int value, string errorMessage = null)
		{
			return collectionValidator.SumEqualTo((x) => (double)x, (int)value, errorMessage);
		}

		public static CollectionValidator<int> SumGreaterThanOrEqualTo(this CollectionValidator<int> collectionValidator,  int value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThanOrEqualTo((x) => (double)x, (int)value, errorMessage);
		}

		public static CollectionValidator<int> SumGreaterThan(this CollectionValidator<int> collectionValidator,  int value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThan((x) => (double)x,  (int)value, errorMessage);
		}

		public static CollectionValidator<int> SumLessThanOrEqualTo(this CollectionValidator<int> collectionValidator,  int value, string errorMessage = null)
		{
			return collectionValidator.SumLessThanOrEqualTo((x) => (double)x, (int)value, errorMessage);
		}

		public static CollectionValidator<int> SumLessThan(this CollectionValidator<int> collectionValidator,  int value, string errorMessage = null)
		{
			return collectionValidator.SumLessThan((x) => (double)x,  (int)value, errorMessage);
		}

		public static CollectionValidator<int> MinEqualTo(this CollectionValidator<int> collectionValidator,  int value, string errorMessage = null)
		{
			return collectionValidator.MinEqualTo((x) => (double)x, (int)value, errorMessage);
		}

		public static CollectionValidator<int> MinGreaterThanOrEqualTo(this CollectionValidator<int> collectionValidator,  int value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThanOrEqualTo((x) => (double)x, (int)value, errorMessage);
		}

		public static CollectionValidator<int> MinGreaterThan(this CollectionValidator<int> collectionValidator,  int value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThan((x) => (double)x, (int)value, errorMessage);
		}

		public static CollectionValidator<int> MinLessThanOrEqualTo(this CollectionValidator<int> collectionValidator,  int value, string errorMessage = null)
		{
			return collectionValidator.MinLessThanOrEqualTo((x) => (double)x,  (int)value, errorMessage);
		}

		public static CollectionValidator<int> MinLessThan(this CollectionValidator<int> collectionValidator,  int value, string errorMessage = null)
		{
			return collectionValidator.MinLessThan((x) => (double)x, (int)value, errorMessage);
		}

		public static CollectionValidator<int> MaxEqualTo(this CollectionValidator<int> collectionValidator,  int value, string errorMessage = null)
		{
			return collectionValidator.MaxEqualTo((x) => (double)x,  (int)value, errorMessage);
		}

		public static CollectionValidator<int> MaxGreaterThanOrEqualTo(this CollectionValidator<int> collectionValidator,  int value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThanOrEqualTo((x) => (double)x, (int)value, errorMessage);
		}

		public static CollectionValidator<int> MaxGreaterThan(this CollectionValidator<int> collectionValidator,  int value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThan((x) => (double)x, (int)value, errorMessage);
		}

		public static CollectionValidator<int> MaxLessThanOrEqualTo(this CollectionValidator<int> collectionValidator,  int value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThanOrEqualTo((x) => (double)x,  (int)value, errorMessage);
		}

		public static CollectionValidator<int> MaxLessThan(this CollectionValidator<int> collectionValidator,  int value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThan((x) => (double)x, (int)value, errorMessage);
		}
    }
}
