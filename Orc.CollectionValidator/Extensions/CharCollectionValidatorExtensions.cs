using System;
using System.Collections.Generic;
using System.Linq;
using Orc.CollectionValidator.SpecificValidators;

namespace Orc.CollectionValidator
{

    public static class CharCollectionValidatorExtensions 
    {

		public static CollectionValidator<char> AggregateEqualTo(this CollectionValidator<char> collectionValidator, Func<IEnumerable<char>, char> aggregator, char value, string errorMessage = null)
		{
			return collectionValidator.AggregateEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (char)x)), (double)value, errorMessage);
		}
		
		public static CollectionValidator<char> AggregateGreaterThanOrEqualTo(this CollectionValidator<char> collectionValidator,  Func<IEnumerable<char>, char> aggregator, char value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (char)x)), (char)value, errorMessage);
		}

		public static CollectionValidator<char> AggregateGreaterThan(this CollectionValidator<char> collectionValidator,  Func<IEnumerable<char>, char> aggregator, char value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (char)x)), (char)value, errorMessage);
		}

		public static CollectionValidator<char> AggregateLessThanOrEqualTo(this CollectionValidator<char> collectionValidator,  Func<IEnumerable<char>, char> aggregator, char value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (char)x)), (char)value, errorMessage);
		}

		public static CollectionValidator<char> AggregateLessThan(this CollectionValidator<char> collectionValidator,  Func<IEnumerable<char>, char> aggregator, char value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (char)x)), (char)value, errorMessage);
		}

		public static CollectionValidator<char> SumEqualTo(this CollectionValidator<char> collectionValidator,  char value, string errorMessage = null)
		{
			return collectionValidator.SumEqualTo((x) => (double)x, (char)value, errorMessage);
		}

		public static CollectionValidator<char> SumGreaterThanOrEqualTo(this CollectionValidator<char> collectionValidator,  char value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThanOrEqualTo((x) => (double)x, (char)value, errorMessage);
		}

		public static CollectionValidator<char> SumGreaterThan(this CollectionValidator<char> collectionValidator,  char value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThan((x) => (double)x,  (char)value, errorMessage);
		}

		public static CollectionValidator<char> SumLessThanOrEqualTo(this CollectionValidator<char> collectionValidator,  char value, string errorMessage = null)
		{
			return collectionValidator.SumLessThanOrEqualTo((x) => (double)x, (char)value, errorMessage);
		}

		public static CollectionValidator<char> SumLessThan(this CollectionValidator<char> collectionValidator,  char value, string errorMessage = null)
		{
			return collectionValidator.SumLessThan((x) => (double)x,  (char)value, errorMessage);
		}

		public static CollectionValidator<char> MinEqualTo(this CollectionValidator<char> collectionValidator,  char value, string errorMessage = null)
		{
			return collectionValidator.MinEqualTo((x) => (double)x, (char)value, errorMessage);
		}

		public static CollectionValidator<char> MinGreaterThanOrEqualTo(this CollectionValidator<char> collectionValidator,  char value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThanOrEqualTo((x) => (double)x, (char)value, errorMessage);
		}

		public static CollectionValidator<char> MinGreaterThan(this CollectionValidator<char> collectionValidator,  char value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThan((x) => (double)x, (char)value, errorMessage);
		}

		public static CollectionValidator<char> MinLessThanOrEqualTo(this CollectionValidator<char> collectionValidator,  char value, string errorMessage = null)
		{
			return collectionValidator.MinLessThanOrEqualTo((x) => (double)x,  (char)value, errorMessage);
		}

		public static CollectionValidator<char> MinLessThan(this CollectionValidator<char> collectionValidator,  char value, string errorMessage = null)
		{
			return collectionValidator.MinLessThan((x) => (double)x, (char)value, errorMessage);
		}

		public static CollectionValidator<char> MaxEqualTo(this CollectionValidator<char> collectionValidator,  char value, string errorMessage = null)
		{
			return collectionValidator.MaxEqualTo((x) => (double)x,  (char)value, errorMessage);
		}

		public static CollectionValidator<char> MaxGreaterThanOrEqualTo(this CollectionValidator<char> collectionValidator,  char value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThanOrEqualTo((x) => (double)x, (char)value, errorMessage);
		}

		public static CollectionValidator<char> MaxGreaterThan(this CollectionValidator<char> collectionValidator,  char value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThan((x) => (double)x, (char)value, errorMessage);
		}

		public static CollectionValidator<char> MaxLessThanOrEqualTo(this CollectionValidator<char> collectionValidator,  char value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThanOrEqualTo((x) => (double)x,  (char)value, errorMessage);
		}

		public static CollectionValidator<char> MaxLessThan(this CollectionValidator<char> collectionValidator,  char value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThan((x) => (double)x, (char)value, errorMessage);
		}
    }
}
