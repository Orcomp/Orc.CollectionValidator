namespace Orc.CollectionValidator.SpecificValidators
{
	public class AggregateValidationResult : ValidationResult
	{

	}

	public class AggregateValidationResult<T> : AggregateValidationResult
	{
		public T ActualValue { get; set; }
	}
}
