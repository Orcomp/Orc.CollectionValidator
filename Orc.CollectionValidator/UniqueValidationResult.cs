namespace Orc.CollectionValidator
{
    public class UniqueValidationResult : ValidationResult
    {
        public int[][] DuplicatedItems { get; set; }
    }
}
