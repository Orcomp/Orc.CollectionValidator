using System;
using System.Collections.Generic;
using System.Linq;

namespace Orc.CollectionValidator
{

    public static class ByteCollectionValidatorExtensions 
    {

		public static CollectionValidator<byte> AggregateEqualTo(this CollectionValidator<byte> collectionValidator, Func<IEnumerable<byte>, byte> aggregator, byte value, string errorMessage = null)
		{
			return collectionValidator.AggregateEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (byte)x)), (double)value, errorMessage);
		}
		
		public static CollectionValidator<byte> AggregateGreaterThanOrEqualTo(this CollectionValidator<byte> collectionValidator,  Func<IEnumerable<byte>, byte> aggregator, byte value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (byte)x)), (byte)value, errorMessage);
		}

		public static CollectionValidator<byte> AggregateGreaterThan(this CollectionValidator<byte> collectionValidator,  Func<IEnumerable<byte>, byte> aggregator, byte value, string errorMessage = null)
		{
			return collectionValidator.AggregateGreaterThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (byte)x)), (byte)value, errorMessage);
		}

		public static CollectionValidator<byte> AggregateLessThanOrEqualTo(this CollectionValidator<byte> collectionValidator,  Func<IEnumerable<byte>, byte> aggregator, byte value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThanOrEqualTo((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (byte)x)), (byte)value, errorMessage);
		}

		public static CollectionValidator<byte> AggregateLessThan(this CollectionValidator<byte> collectionValidator,  Func<IEnumerable<byte>, byte> aggregator, byte value, string errorMessage = null)
		{
			return collectionValidator.AggregateLessThan((x) => (double)x, (collection) => (double)aggregator(collection.Select(x => (byte)x)), (byte)value, errorMessage);
		}

		public static CollectionValidator<byte> SumEqualTo(this CollectionValidator<byte> collectionValidator,  byte value, string errorMessage = null)
		{
			return collectionValidator.SumEqualTo((x) => (double)x, (byte)value, errorMessage);
		}

		public static CollectionValidator<byte> SumGreaterThanOrEqualTo(this CollectionValidator<byte> collectionValidator,  byte value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThanOrEqualTo((x) => (double)x, (byte)value, errorMessage);
		}

		public static CollectionValidator<byte> SumGreaterThan(this CollectionValidator<byte> collectionValidator,  byte value, string errorMessage = null)
		{
			return collectionValidator.SumGreaterThan((x) => (double)x,  (byte)value, errorMessage);
		}

		public static CollectionValidator<byte> SumLessThanOrEqualTo(this CollectionValidator<byte> collectionValidator,  byte value, string errorMessage = null)
		{
			return collectionValidator.SumLessThanOrEqualTo((x) => (double)x, (byte)value, errorMessage);
		}

		public static CollectionValidator<byte> SumLessThan(this CollectionValidator<byte> collectionValidator,  byte value, string errorMessage = null)
		{
			return collectionValidator.SumLessThan((x) => (double)x,  (byte)value, errorMessage);
		}

		public static CollectionValidator<byte> MinEqualTo(this CollectionValidator<byte> collectionValidator,  byte value, string errorMessage = null)
		{
			return collectionValidator.MinEqualTo((x) => (double)x, (byte)value, errorMessage);
		}

		public static CollectionValidator<byte> MinGreaterThanOrEqualTo(this CollectionValidator<byte> collectionValidator,  byte value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThanOrEqualTo((x) => (double)x, (byte)value, errorMessage);
		}

		public static CollectionValidator<byte> MinGreaterThan(this CollectionValidator<byte> collectionValidator,  byte value, string errorMessage = null)
		{
			return collectionValidator.MinGreaterThan((x) => (double)x, (byte)value, errorMessage);
		}

		public static CollectionValidator<byte> MinLessThanOrEqualTo(this CollectionValidator<byte> collectionValidator,  byte value, string errorMessage = null)
		{
			return collectionValidator.MinLessThanOrEqualTo((x) => (double)x,  (byte)value, errorMessage);
		}

		public static CollectionValidator<byte> MinLessThan(this CollectionValidator<byte> collectionValidator,  byte value, string errorMessage = null)
		{
			return collectionValidator.MinLessThan((x) => (double)x, (byte)value, errorMessage);
		}

		public static CollectionValidator<byte> MaxEqualTo(this CollectionValidator<byte> collectionValidator,  byte value, string errorMessage = null)
		{
			return collectionValidator.MaxEqualTo((x) => (double)x,  (byte)value, errorMessage);
		}

		public static CollectionValidator<byte> MaxGreaterThanOrEqualTo(this CollectionValidator<byte> collectionValidator,  byte value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThanOrEqualTo((x) => (double)x, (byte)value, errorMessage);
		}

		public static CollectionValidator<byte> MaxGreaterThan(this CollectionValidator<byte> collectionValidator,  byte value, string errorMessage = null)
		{
			return collectionValidator.MaxGreaterThan((x) => (double)x, (byte)value, errorMessage);
		}

		public static CollectionValidator<byte> MaxLessThanOrEqualTo(this CollectionValidator<byte> collectionValidator,  byte value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThanOrEqualTo((x) => (double)x,  (byte)value, errorMessage);
		}

		public static CollectionValidator<byte> MaxLessThan(this CollectionValidator<byte> collectionValidator,  byte value, string errorMessage = null)
		{
			return collectionValidator.MaxLessThan((x) => (double)x, (byte)value, errorMessage);
		}
    }
}
