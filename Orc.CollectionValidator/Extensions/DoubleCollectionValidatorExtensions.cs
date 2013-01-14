using System;
using System.Collections.Generic;
using System.Linq;

namespace Orc.CollectionValidator
{

    public static class CollectionValidatorExtensions 
    {

		public static CollectionValidator<double> AggregateEqualTo(this CollectionValidator<double> collectionValidator,  Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null)
		{
			return collectionValidator.AggregateEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (double)x)), (double)value, errorMessage);
		}

		public static CollectionValidator<double> AggregateGreaterThanOrEqualTo(this CollectionValidator<double> collectionValidator,  Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThanOrEqualTo((x) => (double)x, aggregator, (double)value, errorMessage);
		}

		public static CollectionValidator<double> AggregateGreaterThan(this CollectionValidator<double> collectionValidator,  Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThan((x) => (double)x, aggregator, (double)value, errorMessage);
		}

		public static CollectionValidator<double> AggregateLessThanOrEqualTo(this CollectionValidator<double> collectionValidator,  Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThanOrEqualTo((x) => (double)x, aggregator, (double)value, errorMessage);
		}

		public static CollectionValidator<double> AggregateLessThan(this CollectionValidator<double> collectionValidator,  Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThan((x) => (double)x, aggregator, (double)value, errorMessage);
		}

		public static CollectionValidator<double> SumEqualTo(this CollectionValidator<double> collectionValidator,  double value, string errorMessage = null)
		{
			return collectionValidator.SumEqualTo((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<double> SumGreaterThanOrEqualTo(this CollectionValidator<double> collectionValidator,  double value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThanOrEqualTo((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<double> SumGreaterThan(this CollectionValidator<double> collectionValidator,  double value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThan((x) => (double)x,  (double)value, errorMessage);
		}

		public static CollectionValidator<double> SumLessThanOrEqualTo(this CollectionValidator<double> collectionValidator,  double value, string errorMessage = null)
		{
			return collectionValidator.SumLessThanOrEqualTo((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<double> SumLessThan(this CollectionValidator<double> collectionValidator,  double value, string errorMessage = null)
		{
			return collectionValidator.SumLessThan((x) => (double)x,  (double)value, errorMessage);
		}

		public static CollectionValidator<double> MinEqualTo(this CollectionValidator<double> collectionValidator,  double value, string errorMessage = null)
		{
			return collectionValidator.MinEqualTo((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<double> MinGreaterThanOrEqualTo(this CollectionValidator<double> collectionValidator,  double value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThanOrEqualTo((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<double> MinGreaterThan(this CollectionValidator<double> collectionValidator,  double value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThan((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<double> MinLessThanOrEqualTo(this CollectionValidator<double> collectionValidator,  double value, string errorMessage = null)
		{
			return collectionValidator.MinLessThanOrEqualTo((x) => (double)x,  (double)value, errorMessage);
		}

		public static CollectionValidator<double> MinLessThan(this CollectionValidator<double> collectionValidator,  double value, string errorMessage = null)
		{
			return collectionValidator.MinLessThan((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<double> MaxEqualTo(this CollectionValidator<double> collectionValidator,  double value, string errorMessage = null)
		{
			return collectionValidator.MaxEqualTo((x) => (double)x,  (double)value, errorMessage);
		}

		public static CollectionValidator<double> MaxGreaterThanOrEqualTo(this CollectionValidator<double> collectionValidator,  double value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThanOrEqualTo((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<double> MaxGreaterThan(this CollectionValidator<double> collectionValidator,  double value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThan((x) => (double)x, (double)value, errorMessage);
		}

		public static CollectionValidator<double> MaxLessThanOrEqualTo(this CollectionValidator<double> collectionValidator,  double value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThanOrEqualTo((x) => (double)x,  (double)value, errorMessage);
		}

		public static CollectionValidator<double> MaxLessThan(this CollectionValidator<double> collectionValidator,  double value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThan((x) => (double)x, (double)value, errorMessage);
		}
    }
}
