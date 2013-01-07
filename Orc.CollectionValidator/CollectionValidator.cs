namespace Orc.CollectionValidator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using FluentValidation;
    using Orc.CollectionValidator.Interfaces;
    using Orc.CollectionValidator.SpecificValidators;


    /// <summary>
    /// Main collection validation class.
    /// </summary>
    /// <typeparam name="T">Type of collection elements.
    /// </typeparam>
    public class CollectionValidator<T> : ICollectionValidator<T>, IFluentCollectionValidator<CollectionValidator<T>, T>
    {
        /// <summary>
        /// The list of validators.
        /// </summary>
        private readonly IList<ICollectionValidator<T>> validators = new List<ICollectionValidator<T>>();

        private readonly ElementValidator<T> elementValidator;


        public CollectionValidator()
        {
            this.elementValidator = new ElementValidator<T>();
            this.validators.Add(this.elementValidator);
        }       

        /// <summary>
        /// Adds UniqueValidator to validation sequence.
        /// </summary>
        /// <param name="errorMessage">
        /// The error Message.
        /// </param>
        /// <param name="properties">
        /// Set of key properties to check uniqueness of collection item.
        /// </param>
        /// <returns>
        /// The <see cref="CollectionValidator"/>.
        /// </returns>
        public CollectionValidator<T> Unique(string errorMessage = null, params Expression<Func<T, object>>[] properties)
        {
            this.validators.Add(
                properties.Any()
                    ? new UniqueValidator<T>(properties, errorMessage)
                    : new UniqueValidator<T>(errorMessage));
            return this;
        }

		public CollectionValidator<T> CoundEqualTo(int count, string errorMessage = null)
		{
			this.validators.Add(new CountValidator<T>(i => i == count, errorMessage));
			return this;
		}
       
        public CollectionValidator<T> CountGreaterThan(int count, string errorMessage = null)
        {
            this.validators.Add(new CountValidator<T>(i => i > count, errorMessage));
            return this;
        }

        public CollectionValidator<T> CountLessThan(int count, string errorMessage = null)
        {
            this.validators.Add(new CountValidator<T>(i => i < count, errorMessage));
            return this;
        }

        public CollectionValidator<T> CountGreaterOrEqualTo(int count, string errorMessage = null)
        {
            this.validators.Add(new CountValidator<T>(i => i >= count, errorMessage));
            return this;
        }

        public CollectionValidator<T> CountLessOrEqualTo(int count, string errorMessage = null)
        {
            this.validators.Add(new CountValidator<T>(i => i <= count, errorMessage));
            return this;
        }

        public CollectionValidator<T> CountCondition(Predicate<int> condition, string errorMessage = null)
        {
            this.validators.Add(new CountValidator<T>(condition, errorMessage));
            return this;
        }

		public CollectionValidator<T> AggregateCondition(Func<IEnumerable<T>, T> aggregator, Predicate<T> condition, string errorMessage = null)
		{
			this.validators.Add(new AggregateValidator<T>(aggregator, condition, errorMessage));
			return this;
		}

		public CollectionValidator<T> AggregateCondition<K>(Func<T, K> selector, Func<IEnumerable<K>, K> aggregator, Predicate<K> condition, string errorMessage = null)
		{
			this.validators.Add(new AggregateValidator<T, K>(selector, aggregator, condition, errorMessage));
			return this;
		}

		public CollectionValidator<T> AggregateEqualTo(Func<T, double> selector, Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null)
		{
			return AggregateCondition(selector, aggregator, (x) => x == value , errorMessage);
		}

		public CollectionValidator<T> AggregateGreaterThanOrEqualTo(Func<T, double> selector, Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null)
		{
			return AggregateCondition(selector, aggregator, (x) => x >= value, errorMessage);
		}

		public CollectionValidator<T> AggregateGreaterThan(Func<T, double> selector, Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null)
		{
			return AggregateCondition(selector, aggregator, (x) => x > value, errorMessage);
		}

		public CollectionValidator<T> AggregateLessThanOrEqualTo(Func<T, double> selector, Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null)
		{
			return AggregateCondition(selector, aggregator, (x) => x <= value, errorMessage);
		}

		public CollectionValidator<T> AggregateLessThan(Func<T, double> selector, Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null)
		{
			return AggregateCondition(selector, aggregator, (x) => x < value, errorMessage);
		}

		public CollectionValidator<T> SumEqualTo(Func<T, double> selector, double value, string errorMessage = null)
		{
			return AggregateEqualTo(selector, (collection)=> collection.Sum(), value, errorMessage);
		}

		public CollectionValidator<T> SumGreaterThanOrEqualTo(Func<T, double> selector,double value, string errorMessage = null)
		{
			return AggregateGreaterThanOrEqualTo(selector, (collection) => collection.Sum(), value, errorMessage);
		}

		public CollectionValidator<T> SumGreaterThan(Func<T, double> selector,  double value, string errorMessage = null)
		{
			return AggregateGreaterThan(selector, (collection) => collection.Sum(), value, errorMessage);
		}

		public CollectionValidator<T> SumLessThanOrEqualTo(Func<T, double> selector, double value, string errorMessage = null)
		{
			return AggregateLessThanOrEqualTo(selector, (collection) => collection.Sum(), value, errorMessage);
		}

		public CollectionValidator<T> SumLessThan(Func<T, double> selector, double value, string errorMessage = null)
		{
			return AggregateLessThan(selector, (collection) => collection.Sum(), value, errorMessage);
		}

		public CollectionValidator<T> MinEqualTo(Func<T, double> selector, double value, string errorMessage = null)
		{
			return AggregateEqualTo(selector, (collection) => collection.Min(), value, errorMessage);
		}

		public CollectionValidator<T> MinGreaterThanOrEqualTo(Func<T, double> selector, double value, string errorMessage = null)
		{
			return AggregateGreaterThanOrEqualTo(selector, (collection) => collection.Min(), value, errorMessage);
		}

		public CollectionValidator<T> MinGreaterThan(Func<T, double> selector, double value, string errorMessage = null)
		{
			return AggregateGreaterThan(selector, (collection) => collection.Min(), value, errorMessage);
		}

		public CollectionValidator<T> MinLessThanOrEqualTo(Func<T, double> selector, double value, string errorMessage = null)
		{
			return AggregateLessThanOrEqualTo(selector, (collection) => collection.Min(), value, errorMessage);
		}

		public CollectionValidator<T> MinLessThan(Func<T, double> selector, double value, string errorMessage = null)
		{
			return AggregateLessThan(selector, (collection) => collection.Min(), value, errorMessage);
		}

		public CollectionValidator<T> MaxEqualTo(Func<T, double> selector, double value, string errorMessage = null)
		{
			return AggregateEqualTo(selector, (collection) => collection.Max(), value, errorMessage);
		}

		public CollectionValidator<T> MaxGreaterThanOrEqualTo(Func<T, double> selector, double value, string errorMessage = null)
		{
			return AggregateGreaterThanOrEqualTo(selector, (collection) => collection.Max(), value, errorMessage);
		}

		public CollectionValidator<T> MaxGreaterThan(Func<T, double> selector, double value, string errorMessage = null)
		{
			return AggregateGreaterThan(selector, (collection) => collection.Max(), value, errorMessage);
		}

		public CollectionValidator<T> MaxLessThanOrEqualTo(Func<T, double> selector, double value, string errorMessage = null)
		{
			return AggregateLessThanOrEqualTo(selector, (collection) => collection.Max(), value, errorMessage);
		}

		public CollectionValidator<T> MaxLessThan(Func<T, double> selector, double value, string errorMessage = null)
		{
			return AggregateLessThan(selector, (collection) => collection.Max(), value, errorMessage);
		}


        public CollectionValidator<T> Single()
        {
            this.validators.Add(new CountValidator<T>(x => x == 1));
            return this;
        }

		public CollectionValidator<T> Ordered<K>(Func<T, K> keySelector, string errorMessage = null)
		{
			this.validators.Add(new OrderedValidator<T, K>(keySelector, null, OrderDirection.Ascending, errorMessage));
			return this;
		}

		public CollectionValidator<T> Ordered<K>(Func<T, K> keySelector, IComparer<K> keyComparer, string errorMessage = null)
		{
			this.validators.Add(new OrderedValidator<T, K>(keySelector, keyComparer, OrderDirection.Ascending, errorMessage));
			return this;
		}

		public CollectionValidator<T> OrderedDescending<K>(Func<T, K> keySelector, string errorMessage = null)
		{
			this.validators.Add(new OrderedValidator<T, K>(keySelector, null, OrderDirection.Descending, errorMessage));
			return this;
		}

		public CollectionValidator<T> OrderedDescending<K>(Func<T, K> keySelector, IComparer<K> keyComparer, string errorMessage = null)
		{
			this.validators.Add(new OrderedValidator<T, K>(keySelector, keyComparer, OrderDirection.Descending, errorMessage));
			return this;
		}

        public CollectionValidator<T> ElementValidation(AbstractValidator<T> validator)
        {
            this.elementValidator.AddValidator(validator);
            return this;
        }

        public CollectionValidator<T> ElementValidation<TProp>(Expression<Func<T, TProp>> property, Func<IRuleBuilder<T, TProp>, IRuleBuilderOptions<T, TProp>> validationRule)
        {
            validationRule(this.elementValidator.CreatePropertyRule(property));
            return this;
        }

        public CollectionValidator<T> ElementValidation(Func<IRuleBuilder<ElementWrapper<T>, T>, IRuleBuilderOptions<ElementWrapper<T>, T>> validationRule)
        {
            validationRule(this.elementValidator.CreateRule());
            return this;
        }

        public CollectionValidator<T> ElementValidationMessage(string errorMessage)
        {
            this.elementValidator.SetErrorMessage(errorMessage);
            return this;
        }


        public ValidationResults Validate(IEnumerable<T> collection)
        {
            if (validators.Count == 0)
                throw new InvalidOperationException("Collection validator not configured.");
            return
                new ValidationResults(
                    this.validators.Select(validator => validator.Validate(collection))
                        .SelectMany(varRes => varRes)
                        .ToArray());

        }
    }
}
