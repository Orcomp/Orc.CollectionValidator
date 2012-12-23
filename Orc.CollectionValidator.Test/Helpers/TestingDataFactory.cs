namespace Orc.CollectionValidator.Test.Helpers
{
    public class TestingDataFactory
    {
        public static UniqueTestingDataFactory Unique 
        {
            get
            {
                return UniqueTestingDataFactory.Instance;
            }
        }

        public static ElementValidationTestingDataFactory ElementValidation
        {
            get
            {
                return ElementValidationTestingDataFactory.Instance;
            }
        }

        public static ComposedValidationDataFactory ComposedValidation 
        {
            get
            {
                return ComposedValidationDataFactory.Instance;
            }
        }
    }
}
