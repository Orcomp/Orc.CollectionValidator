using System;
using System.Collections.Generic;
using System.Linq;

namespace Orc.CollectionValidator
{

    public static class UShortCollectionValidatorExtensions 
    {

		public static CollectionValidator<ushort> AggregateEqualTo(this CollectionValidator<ushort> collectionValidator, Func<IEnumerable<ushort>, ushort> aggregator, ushort value, string errorMessage = null)
		{
			return collectionValidator.AggregateEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (ushort)x)), (double)value, errorMessage);
		}
		
		public static CollectionValidator<ushort> AggregateGreaterThanOrEqualTo(this CollectionValidator<ushort> collectionValidator,  Func<IEnumerable<ushort>, ushort> aggregator, ushort value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (ushort)x)), (ushort)value, errorMessage);
		}

		public static CollectionValidator<ushort> AggregateGreaterThan(this CollectionValidator<ushort> collectionValidator,  Func<IEnumerable<ushort>, ushort> aggregator, ushort value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (ushort)x)), (ushort)value, errorMessage);
		}

		public static CollectionValidator<ushort> AggregateLessThanOrEqualTo(this CollectionValidator<ushort> collectionValidator,  Func<IEnumerable<ushort>, ushort> aggregator, ushort value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (ushort)x)), (ushort)value, errorMessage);
		}

		public static CollectionValidator<ushort> AggregateLessThan(this CollectionValidator<ushort> collectionValidator,  Func<IEnumerable<ushort>, ushort> aggregator, ushort value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (ushort)x)), (ushort)value, errorMessage);
		}

		public static CollectionValidator<ushort> SumEqualTo(this CollectionValidator<ushort> collectionValidator,  ushort value, string errorMessage = null)
		{
			return collectionValidator.SumEqualTo((x) => (double)x, (ushort)value, errorMessage);
		}

		public static CollectionValidator<ushort> SumGreaterThanOrEqualTo(this CollectionValidator<ushort> collectionValidator,  ushort value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThanOrEqualTo((x) => (double)x, (ushort)value, errorMessage);
		}

		public static CollectionValidator<ushort> SumGreaterThan(this CollectionValidator<ushort> collectionValidator,  ushort value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThan((x) => (double)x,  (ushort)value, errorMessage);
		}

		public static CollectionValidator<ushort> SumLessThanOrEqualTo(this CollectionValidator<ushort> collectionValidator,  ushort value, string errorMessage = null)
		{
			return collectionValidator.SumLessThanOrEqualTo((x) => (double)x, (ushort)value, errorMessage);
		}

		public static CollectionValidator<ushort> SumLessThan(this CollectionValidator<ushort> collectionValidator,  ushort value, string errorMessage = null)
		{
			return collectionValidator.SumLessThan((x) => (double)x,  (ushort)value, errorMessage);
		}

		public static CollectionValidator<ushort> MinEqualTo(this CollectionValidator<ushort> collectionValidator,  ushort value, string errorMessage = null)
		{
			return collectionValidator.MinEqualTo((x) => (double)x, (ushort)value, errorMessage);
		}

		public static CollectionValidator<ushort> MinGreaterThanOrEqualTo(this CollectionValidator<ushort> collectionValidator,  ushort value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThanOrEqualTo((x) => (double)x, (ushort)value, errorMessage);
		}

		public static CollectionValidator<ushort> MinGreaterThan(this CollectionValidator<ushort> collectionValidator,  ushort value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThan((x) => (double)x, (ushort)value, errorMessage);
		}

		public static CollectionValidator<ushort> MinLessThanOrEqualTo(this CollectionValidator<ushort> collectionValidator,  ushort value, string errorMessage = null)
		{
			return collectionValidator.MinLessThanOrEqualTo((x) => (double)x,  (ushort)value, errorMessage);
		}

		public static CollectionValidator<ushort> MinLessThan(this CollectionValidator<ushort> collectionValidator,  ushort value, string errorMessage = null)
		{
			return collectionValidator.MinLessThan((x) => (double)x, (ushort)value, errorMessage);
		}

		public static CollectionValidator<ushort> MaxEqualTo(this CollectionValidator<ushort> collectionValidator,  ushort value, string errorMessage = null)
		{
			return collectionValidator.MaxEqualTo((x) => (double)x,  (ushort)value, errorMessage);
		}

		public static CollectionValidator<ushort> MaxGreaterThanOrEqualTo(this CollectionValidator<ushort> collectionValidator,  ushort value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThanOrEqualTo((x) => (double)x, (ushort)value, errorMessage);
		}

		public static CollectionValidator<ushort> MaxGreaterThan(this CollectionValidator<ushort> collectionValidator,  ushort value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThan((x) => (double)x, (ushort)value, errorMessage);
		}

		public static CollectionValidator<ushort> MaxLessThanOrEqualTo(this CollectionValidator<ushort> collectionValidator,  ushort value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThanOrEqualTo((x) => (double)x,  (ushort)value, errorMessage);
		}

		public static CollectionValidator<ushort> MaxLessThan(this CollectionValidator<ushort> collectionValidator,  ushort value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThan((x) => (double)x, (ushort)value, errorMessage);
		}
    }
}
