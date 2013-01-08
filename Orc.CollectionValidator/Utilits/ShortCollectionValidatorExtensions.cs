using System;
using System.Collections.Generic;
using System.Linq;
using Orc.CollectionValidator.SpecificValidators;

namespace Orc.CollectionValidator
{

    public static class shortCollectionValidatorExtensions 
    {

		public static CollectionValidator<short> AggregateEqualTo(this CollectionValidator<short> collectionValidator, Func<IEnumerable<short>, short> aggregator, short value, string errorMessage = null)
		{
			return collectionValidator.AggregateEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (short)x)), (double)value, errorMessage);
		}
		
		public static CollectionValidator<short> AggregateGreaterThanOrEqualTo(this CollectionValidator<short> collectionValidator,  Func<IEnumerable<short>, short> aggregator, short value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (short)x)), (short)value, errorMessage);
		}

		public static CollectionValidator<short> AggregateGreaterThan(this CollectionValidator<short> collectionValidator,  Func<IEnumerable<short>, short> aggregator, short value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (short)x)), (short)value, errorMessage);
		}

		public static CollectionValidator<short> AggregateLessThanOrEqualTo(this CollectionValidator<short> collectionValidator,  Func<IEnumerable<short>, short> aggregator, short value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (short)x)), (short)value, errorMessage);
		}

		public static CollectionValidator<short> AggregateLessThan(this CollectionValidator<short> collectionValidator,  Func<IEnumerable<short>, short> aggregator, short value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (short)x)), (short)value, errorMessage);
		}

		public static CollectionValidator<short> SumEqualTo(this CollectionValidator<short> collectionValidator,  short value, string errorMessage = null)
		{
			return collectionValidator.SumEqualTo((x) => (double)x, (short)value, errorMessage);
		}

		public static CollectionValidator<short> SumGreaterThanOrEqualTo(this CollectionValidator<short> collectionValidator,  short value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThanOrEqualTo((x) => (double)x, (short)value, errorMessage);
		}

		public static CollectionValidator<short> SumGreaterThan(this CollectionValidator<short> collectionValidator,  short value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThan((x) => (double)x,  (short)value, errorMessage);
		}

		public static CollectionValidator<short> SumLessThanOrEqualTo(this CollectionValidator<short> collectionValidator,  short value, string errorMessage = null)
		{
			return collectionValidator.SumLessThanOrEqualTo((x) => (double)x, (short)value, errorMessage);
		}

		public static CollectionValidator<short> SumLessThan(this CollectionValidator<short> collectionValidator,  short value, string errorMessage = null)
		{
			return collectionValidator.SumLessThan((x) => (double)x,  (short)value, errorMessage);
		}

		public static CollectionValidator<short> MinEqualTo(this CollectionValidator<short> collectionValidator,  short value, string errorMessage = null)
		{
			return collectionValidator.MinEqualTo((x) => (double)x, (short)value, errorMessage);
		}

		public static CollectionValidator<short> MinGreaterThanOrEqualTo(this CollectionValidator<short> collectionValidator,  short value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThanOrEqualTo((x) => (double)x, (short)value, errorMessage);
		}

		public static CollectionValidator<short> MinGreaterThan(this CollectionValidator<short> collectionValidator,  short value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThan((x) => (double)x, (short)value, errorMessage);
		}

		public static CollectionValidator<short> MinLessThanOrEqualTo(this CollectionValidator<short> collectionValidator,  short value, string errorMessage = null)
		{
			return collectionValidator.MinLessThanOrEqualTo((x) => (double)x,  (short)value, errorMessage);
		}

		public static CollectionValidator<short> MinLessThan(this CollectionValidator<short> collectionValidator,  short value, string errorMessage = null)
		{
			return collectionValidator.MinLessThan((x) => (double)x, (short)value, errorMessage);
		}

		public static CollectionValidator<short> MaxEqualTo(this CollectionValidator<short> collectionValidator,  short value, string errorMessage = null)
		{
			return collectionValidator.MaxEqualTo((x) => (double)x,  (short)value, errorMessage);
		}

		public static CollectionValidator<short> MaxGreaterThanOrEqualTo(this CollectionValidator<short> collectionValidator,  short value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThanOrEqualTo((x) => (double)x, (short)value, errorMessage);
		}

		public static CollectionValidator<short> MaxGreaterThan(this CollectionValidator<short> collectionValidator,  short value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThan((x) => (double)x, (short)value, errorMessage);
		}

		public static CollectionValidator<short> MaxLessThanOrEqualTo(this CollectionValidator<short> collectionValidator,  short value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThanOrEqualTo((x) => (double)x,  (short)value, errorMessage);
		}

		public static CollectionValidator<short> MaxLessThan(this CollectionValidator<short> collectionValidator,  short value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThan((x) => (double)x, (short)value, errorMessage);
		}
    }
}
