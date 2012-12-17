Orc.CollectionValidator
=======================

Is a library to validate a collection of objects.

    var collection = new List<int>{1,2,3,4,5};
    var validator = new CollectionValidator<int>().CountGreaterThan(3).Unique();
    var validationResults = validator.Validate(collection);

	if(!validationResults.IsValid)
	{
		// Process validationResults
	}

Some of the methods available are:

    Unique();
	Unique( x => x.Property);
	Unique( x => x.Property1, x => x.Property2, etc...);
	CountGreaterThan(number);
	CountGreaterThanOrEqualTo(number);
	CountLessThan(number);
	CountLessThanOrEqualTo(number);
	Singular();