using System;
using System.Collections.Generic;
using System.Linq;

namespace Orc.CollectionValidator
{

    public static class UIntCollectionValidatorExtensions 
    {

		public static CollectionValidator<uint> AggregateEqualTo(this CollectionValidator<uint> collectionValidator, Func<IEnumerable<uint>, uint> aggregator, uint value, string errorMessage = null)
		{
			return collectionValidator.AggregateEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (uint)x)), (double)value, errorMessage);
		}
		
		public static CollectionValidator<uint> AggregateGreaterThanOrEqualTo(this CollectionValidator<uint> collectionValidator,  Func<IEnumerable<uint>, uint> aggregator, uint value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (uint)x)), (uint)value, errorMessage);
		}

		public static CollectionValidator<uint> AggregateGreaterThan(this CollectionValidator<uint> collectionValidator,  Func<IEnumerable<uint>, uint> aggregator, uint value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (uint)x)), (uint)value, errorMessage);
		}

		public static CollectionValidator<uint> AggregateLessThanOrEqualTo(this CollectionValidator<uint> collectionValidator,  Func<IEnumerable<uint>, uint> aggregator, uint value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (uint)x)), (uint)value, errorMessage);
		}

		public static CollectionValidator<uint> AggregateLessThan(this CollectionValidator<uint> collectionValidator,  Func<IEnumerable<uint>, uint> aggregator, uint value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (uint)x)), (uint)value, errorMessage);
		}

		public static CollectionValidator<uint> SumEqualTo(this CollectionValidator<uint> collectionValidator,  uint value, string errorMessage = null)
		{
			return collectionValidator.SumEqualTo((x) => (double)x, (uint)value, errorMessage);
		}

		public static CollectionValidator<uint> SumGreaterThanOrEqualTo(this CollectionValidator<uint> collectionValidator,  uint value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThanOrEqualTo((x) => (double)x, (uint)value, errorMessage);
		}

		public static CollectionValidator<uint> SumGreaterThan(this CollectionValidator<uint> collectionValidator,  uint value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThan((x) => (double)x,  (uint)value, errorMessage);
		}

		public static CollectionValidator<uint> SumLessThanOrEqualTo(this CollectionValidator<uint> collectionValidator,  uint value, string errorMessage = null)
		{
			return collectionValidator.SumLessThanOrEqualTo((x) => (double)x, (uint)value, errorMessage);
		}

		public static CollectionValidator<uint> SumLessThan(this CollectionValidator<uint> collectionValidator,  uint value, string errorMessage = null)
		{
			return collectionValidator.SumLessThan((x) => (double)x,  (uint)value, errorMessage);
		}

		public static CollectionValidator<uint> MinEqualTo(this CollectionValidator<uint> collectionValidator,  uint value, string errorMessage = null)
		{
			return collectionValidator.MinEqualTo((x) => (double)x, (uint)value, errorMessage);
		}

		public static CollectionValidator<uint> MinGreaterThanOrEqualTo(this CollectionValidator<uint> collectionValidator,  uint value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThanOrEqualTo((x) => (double)x, (uint)value, errorMessage);
		}

		public static CollectionValidator<uint> MinGreaterThan(this CollectionValidator<uint> collectionValidator,  uint value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThan((x) => (double)x, (uint)value, errorMessage);
		}

		public static CollectionValidator<uint> MinLessThanOrEqualTo(this CollectionValidator<uint> collectionValidator,  uint value, string errorMessage = null)
		{
			return collectionValidator.MinLessThanOrEqualTo((x) => (double)x,  (uint)value, errorMessage);
		}

		public static CollectionValidator<uint> MinLessThan(this CollectionValidator<uint> collectionValidator,  uint value, string errorMessage = null)
		{
			return collectionValidator.MinLessThan((x) => (double)x, (uint)value, errorMessage);
		}

		public static CollectionValidator<uint> MaxEqualTo(this CollectionValidator<uint> collectionValidator,  uint value, string errorMessage = null)
		{
			return collectionValidator.MaxEqualTo((x) => (double)x,  (uint)value, errorMessage);
		}

		public static CollectionValidator<uint> MaxGreaterThanOrEqualTo(this CollectionValidator<uint> collectionValidator,  uint value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThanOrEqualTo((x) => (double)x, (uint)value, errorMessage);
		}

		public static CollectionValidator<uint> MaxGreaterThan(this CollectionValidator<uint> collectionValidator,  uint value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThan((x) => (double)x, (uint)value, errorMessage);
		}

		public static CollectionValidator<uint> MaxLessThanOrEqualTo(this CollectionValidator<uint> collectionValidator,  uint value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThanOrEqualTo((x) => (double)x,  (uint)value, errorMessage);
		}

		public static CollectionValidator<uint> MaxLessThan(this CollectionValidator<uint> collectionValidator,  uint value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThan((x) => (double)x, (uint)value, errorMessage);
		}
    }
}
