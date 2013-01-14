using System;
using System.Collections.Generic;
using System.Linq;

namespace Orc.CollectionValidator
{

    public static class FloatCollectionValidatorExtensions 
    {

		public static CollectionValidator<float> AggregateEqualTo(this CollectionValidator<float> collectionValidator, Func<IEnumerable<float>, float> aggregator, float value, string errorMessage = null)
		{
			return collectionValidator.AggregateEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (float)x)), (double)value, errorMessage);
		}
		
		public static CollectionValidator<float> AggregateGreaterThanOrEqualTo(this CollectionValidator<float> collectionValidator,  Func<IEnumerable<float>, float> aggregator, float value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (float)x)), (float)value, errorMessage);
		}

		public static CollectionValidator<float> AggregateGreaterThan(this CollectionValidator<float> collectionValidator,  Func<IEnumerable<float>, float> aggregator, float value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (float)x)), (float)value, errorMessage);
		}

		public static CollectionValidator<float> AggregateLessThanOrEqualTo(this CollectionValidator<float> collectionValidator,  Func<IEnumerable<float>, float> aggregator, float value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (float)x)), (float)value, errorMessage);
		}

		public static CollectionValidator<float> AggregateLessThan(this CollectionValidator<float> collectionValidator,  Func<IEnumerable<float>, float> aggregator, float value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (float)x)), (float)value, errorMessage);
		}

		public static CollectionValidator<float> SumEqualTo(this CollectionValidator<float> collectionValidator,  float value, string errorMessage = null)
		{
			return collectionValidator.SumEqualTo((x) => (double)x, (float)value, errorMessage);
		}

		public static CollectionValidator<float> SumGreaterThanOrEqualTo(this CollectionValidator<float> collectionValidator,  float value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThanOrEqualTo((x) => (double)x, (float)value, errorMessage);
		}

		public static CollectionValidator<float> SumGreaterThan(this CollectionValidator<float> collectionValidator,  float value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThan((x) => (double)x,  (float)value, errorMessage);
		}

		public static CollectionValidator<float> SumLessThanOrEqualTo(this CollectionValidator<float> collectionValidator,  float value, string errorMessage = null)
		{
			return collectionValidator.SumLessThanOrEqualTo((x) => (double)x, (float)value, errorMessage);
		}

		public static CollectionValidator<float> SumLessThan(this CollectionValidator<float> collectionValidator,  float value, string errorMessage = null)
		{
			return collectionValidator.SumLessThan((x) => (double)x,  (float)value, errorMessage);
		}

		public static CollectionValidator<float> MinEqualTo(this CollectionValidator<float> collectionValidator,  float value, string errorMessage = null)
		{
			return collectionValidator.MinEqualTo((x) => (double)x, (float)value, errorMessage);
		}

		public static CollectionValidator<float> MinGreaterThanOrEqualTo(this CollectionValidator<float> collectionValidator,  float value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThanOrEqualTo((x) => (double)x, (float)value, errorMessage);
		}

		public static CollectionValidator<float> MinGreaterThan(this CollectionValidator<float> collectionValidator,  float value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThan((x) => (double)x, (float)value, errorMessage);
		}

		public static CollectionValidator<float> MinLessThanOrEqualTo(this CollectionValidator<float> collectionValidator,  float value, string errorMessage = null)
		{
			return collectionValidator.MinLessThanOrEqualTo((x) => (double)x,  (float)value, errorMessage);
		}

		public static CollectionValidator<float> MinLessThan(this CollectionValidator<float> collectionValidator,  float value, string errorMessage = null)
		{
			return collectionValidator.MinLessThan((x) => (double)x, (float)value, errorMessage);
		}

		public static CollectionValidator<float> MaxEqualTo(this CollectionValidator<float> collectionValidator,  float value, string errorMessage = null)
		{
			return collectionValidator.MaxEqualTo((x) => (double)x,  (float)value, errorMessage);
		}

		public static CollectionValidator<float> MaxGreaterThanOrEqualTo(this CollectionValidator<float> collectionValidator,  float value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThanOrEqualTo((x) => (double)x, (float)value, errorMessage);
		}

		public static CollectionValidator<float> MaxGreaterThan(this CollectionValidator<float> collectionValidator,  float value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThan((x) => (double)x, (float)value, errorMessage);
		}

		public static CollectionValidator<float> MaxLessThanOrEqualTo(this CollectionValidator<float> collectionValidator,  float value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThanOrEqualTo((x) => (double)x,  (float)value, errorMessage);
		}

		public static CollectionValidator<float> MaxLessThan(this CollectionValidator<float> collectionValidator,  float value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThan((x) => (double)x, (float)value, errorMessage);
		}
    }
}
