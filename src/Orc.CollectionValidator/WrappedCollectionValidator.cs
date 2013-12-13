namespace Orc.CollectionValidator
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Orc.CollectionValidator.Interfaces;

    public class WrappedCollectionValidator<T> : IWrappedValidator, IFluentCollectionValidator<WrappedCollectionValidator<T>, T>
    {
        private readonly CollectionValidator<T> validator;

        private readonly IEnumerable<T> collection; 

        internal WrappedCollectionValidator(IEnumerable<T> collection)
        {
            this.collection = collection;
            this.validator = new CollectionValidator<T>();
        }

        public WrappedCollectionValidator<T> Unique(string errorMessage = null, params Expression<Func<T, object>>[] properties)
        {
            this.validator.Unique(errorMessage, properties);
            return this;
        }

        public WrappedCollectionValidator<T> CountGreaterThan(int count, string errorMessage = null)
        {
            this.validator.CountGreaterThan(count, errorMessage);
            return this;
        }

        public WrappedCollectionValidator<T> CountLessThan(int count, string errorMessage = null)
        {
            this.validator.CountLessThan(count, errorMessage);
            return this;
        }

        public WrappedCollectionValidator<T> CountGreaterOrEqualTo(int count, string errorMessage = null)
        {
            this.validator.CountGreaterOrEqualTo(count, errorMessage);
            return this;
        }

        public WrappedCollectionValidator<T> CountLessOrEqualTo(int count, string errorMessage = null)
        {
            this.validator.CountLessOrEqualTo(count);
            return this;
        }

        public WrappedCollectionValidator<T> CountCondition(Predicate<int> condition, string errorMessage = null)
        {
            this.validator.CountCondition(condition, errorMessage);
            return this;
        }

        public WrappedCollectionValidator<T> Single()
        {
            this.validator.Single();
            return this;
        }        


        public WrappedCollectionValidator<T> ElementValidation(FluentValidation.AbstractValidator<T> validator)
        {
            this.validator.ElementValidation(validator);
            return this;
        }
        
        public WrappedCollectionValidator<T> ElementValidation<TProp>(Expression<Func<T, TProp>> property, Func<FluentValidation.IRuleBuilder<T, TProp>, FluentValidation.IRuleBuilderOptions<T, TProp>> validationRule)
        {
            this.validator.ElementValidation(property, validationRule);
            return this;
        }

        public WrappedCollectionValidator<T> ElementValidation(Func<FluentValidation.IRuleBuilder<ElementWrapper<T>, T>, FluentValidation.IRuleBuilderOptions<ElementWrapper<T>, T>> validationRule)
        {
            this.validator.ElementValidation(validationRule);
            return this;
        }
        
        public WrappedCollectionValidator<T> ElementValidationMessage(string errorMessage)
        {
            this.validator.ElementValidationMessage(errorMessage);
            return this;
        }

        public ValidationResults Validate()
        {
            return this.validator.Validate(this.collection);
        }


		public WrappedCollectionValidator<T> AggregateCondition(Func<IEnumerable<T>, T> aggregator, Predicate<T> condition, string errorMessage = null)
		{
			this.validator.AggregateCondition(aggregator, condition, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> AggregateCondition<K>(Func<T, K> selector, Func<IEnumerable<K>, K> aggregator, Predicate<K> condition, string errorMessage = null)
		{
			this.validator.AggregateCondition(selector, aggregator, condition, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> AggregateEqualTo(Func<T, double> selector, Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null)
		{
			this.validator.AggregateEqualTo(selector, aggregator, value, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> AggregateGreaterThanOrEqualTo(Func<T, double> selector, Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null)
		{
			this.validator.AggregateGreaterThanOrEqualTo(selector, aggregator, value,  errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> AggregateGreaterThan(Func<T, double> selector, Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null)
		{
			this.validator.AggregateGreaterThan(selector, aggregator, value, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> AggregateLessThanOrEqualTo(Func<T, double> selector, Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null)
		{
			this.validator.AggregateLessThanOrEqualTo(selector, aggregator, value, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> AggregateLessThan(Func<T, double> selector, Func<IEnumerable<double>, double> aggregator, double value, string errorMessage = null)
		{
			this.validator.AggregateLessThan(selector, aggregator, value, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> SumEqualTo(Func<T, double> selector, double value, string errorMessage = null)
		{
			this.validator.SumEqualTo(selector, value, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> SumGreaterThanOrEqualTo(Func<T, double> selector, double value, string errorMessage = null)
		{
			this.validator.SumGreaterThanOrEqualTo(selector,  value, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> SumGreaterThan(Func<T, double> selector, double value, string errorMessage = null)
		{
			this.validator.SumGreaterThan(selector, value, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> SumLessThanOrEqualTo(Func<T, double> selector, double value, string errorMessage = null)
		{
			this.validator.SumLessThanOrEqualTo(selector,  value, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> SumLessThan(Func<T, double> selector, double value, string errorMessage = null)
		{
			this.validator.SumLessThan(selector, value, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> MinEqualTo(Func<T, double> selector, double value, string errorMessage = null)
		{
			this.validator.MinEqualTo(selector, value, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> MinGreaterThanOrEqualTo(Func<T, double> selector, double value, string errorMessage = null)
		{
			this.validator.MinGreaterThanOrEqualTo(selector, value, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> MinGreaterThan(Func<T, double> selector, double value, string errorMessage = null)
		{
			this.validator.MinGreaterThan(selector,  value, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> MinLessThanOrEqualTo(Func<T, double> selector, double value, string errorMessage = null)
		{
			this.validator.MinLessThanOrEqualTo(selector,  value, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> MinLessThan(Func<T, double> selector, double value, string errorMessage = null)
		{
			this.validator.MinLessThan(selector, value, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> MaxEqualTo(Func<T, double> selector, double value, string errorMessage = null)
		{
			this.validator.MaxEqualTo(selector, value, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> MaxGreaterThanOrEqualTo(Func<T, double> selector, double value, string errorMessage = null)
		{
			this.validator.MaxGreaterThanOrEqualTo(selector, value, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> MaxGreaterThan(Func<T, double> selector, double value, string errorMessage = null)
		{
			this.validator.MaxGreaterThan(selector, value, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> MaxLessThanOrEqualTo(Func<T, double> selector, double value, string errorMessage = null)
		{
			this.validator.MaxLessThanOrEqualTo(selector, value, errorMessage);
			return this;
		}

		public WrappedCollectionValidator<T> MaxLessThan(Func<T, double> selector, double value, string errorMessage = null)
		{
			this.validator.MaxLessThan(selector, value, errorMessage);
			return this;
		}
	}
}
