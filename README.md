Orc.CollectionValidator
=======================

A small validation library for .NET/Mono designed to validate collections. 

    var collection = new List<int>{1,2,3,4,5};
    var validator = new CollectionValidator<int>().CountGreaterThan(3).Unique();
    var validationResults = validator.Validate(collection);

	if(!validationResults.IsValid)
	{
		// Process validationResults
	}

The methods available are:

		Unique()
		
		Unique( x => x.Property1, x => x.Property2, ...)
		
		CountGreaterThan(number)
		
		CountLessThan(number)
		
		CountGreaterOrEqualTo(number)
		
		CountLessOrEqualTo(number)
		
		CountCondition((number) => MeetsCondition(number) );
		
		AggregateCondition((person) => person.Age, (collectionOfAges) => FindMedian(collectionOfAges), numberToTest == 30);
		
		AggregateCondition<K>((person) => person.SomeProperty,  (collectionOfSomeProperty) => someAggregator(collectionOfSomeProperty), (aggregateValue) => MeetsSomeCondition(aggregateValue));
		
		AggregateEqualTo((x) => x.Age, (collectionOfAges) => FindMedian(collectionOfAges), numberToTest);
		
		AggregateGreaterThanOrEqualTo((x) => x.Age, (collectionOfAges) => FindMedian(collectionOfAges), numberToTest);
		
		AggregateGreaterThan((x) => x.Property, (collectionOfAges) => FindMedian(collectionOfAges), numberToTest);
		
		AggregateLessThanOrEqualTo((x) => x.Property, (collectionOfAges) => FindMedian(collectionOfAges), numberToTest);
		
		AggregateLessThan((x) => x.Property, (collectionOfAges) => FindMedian(collectionOfAges), numberToTest);

		SumEqualTo(...);

		SumGreaterThanOrEqualTo(...);

		SumGreaterThan(...);

		SumLessThanOrEqualTo(...);

		SumLessThan(...);

		MinEqualTo(...);

		MinGreaterThanOrEqualTo(...);

		MinGreaterThan(...);

		MinLessThanOrEqualTo(...);

		MinLessThan(...);

		MaxEqualTo(...);

		MaxGreaterThanOrEqualTo(...);

		MaxGreaterThan(...)

		MaxLessThanOrEqualTo(...)

		MaxLessThan(...);

		Single();

For more detailed usage please have a look at the unit tests.

Why Validate Collections?
=========================
Validation is an important aspect of software quality control and design-by-contract. This libary provides developers an easy way to enforce arbitrary conditions on collections or (aggregated values derived from collection items) and to chain them together via a fluent-style interface. For example, a method may require a collection of numbers to be ordered and contain a minimum value greater than a known constant. It may also require that the standard deviation of those numbers maintain a certain condition. More complex scenarios composed of properties from items within the collection can also be validated using arbitrary aggregator functions specified by the client code. A typical production scenario may use Orc.CollectionValidator within Unit Tests, code contracts and/or argument validation.
	
Validating Collections
======================
Validation of collections occurs via the CollectionValidator facade. This class provides an easy-to-use Fluent interface that allows you to chain your specific validations together.

For example 

			var collection = new[] { 2, 4, 6, 8 };
			var validator =
				new CollectionValidator<int>()
					.MinEqualTo(2)
					.MaxEqualTo(8)
					.SumEqualTo(20)
					.Ordered();

			if (!validator.Validate(collection).IsValid)
				throw ...


				
Validating Items
================

Validation of items uses the FluentValidation library which is integrated into the Orc.CollectionValidator library. You can access FluentValidation via the ElementValidation facade method (or ElementValidator specific validator).

For example, testing whether all the numbers are prime:

	var validator =  new CollectionValidator.ElementValidation(x => IsPrime(x));
		
Suppose the collection was composed of Person object whom who's ages you'd like to be prime:

	var validator = 
		new CollectionValidator.ElementValidation(person => person.Age, age => IsPrime(age));


Validating
==========

Once you've constructed your validator, you need to actually validate a collection. This is easily done as follows:

	var validator =  new CollectionValidator<MyType>().chained.validations.here();
	var results = validator.Validate(myCollectionHere)

You can test your results via the

	results.IsValid 
	
property. To view the specific results for the specific validations, you can enumerate the results object 

	foreach (var result in results) {
		..
	}

and get result error message

	result.ErrorMessage

Some specific validations return a sub-classed ValidationResult which contains additional information. For example the UniqueValidationResult contains the property 'DuplicatedItems'.

	if (result is UniqueValidationResults)
		var duplicates = ((UniqueValidationResults)result).DuplicatedItems


	

For Contributors
================

Extending Orc.CollectionValidator is straightfoward. The main facade class that exposes the validators is

	Orc.CollectionValidator.CollectionValidator 

This class provides the fluent-style methods that can be chained together to validate a collection. Before writing your own validator, see if you can overload or reuse any of those methods. Also consider reusing the general-purpose AggregateValidator as it will likely address your requirement. If you need to write your own custom specific validator then you will need to create it in the

	Orc.CollectionValidator\SpecificValidators 

folder. Consider subclassing one of the following specific validators

	AggregateValidator - general-purpose validator accepts a user-defined aggregator
	OrderedValidator - validates the order of a collection
	UniqueValidator - validates uniquess of a collection
	CountValidator - validates the the count of a collection

found in that folder and in the Orc.CollectionValidator.SpecificValidators namespace. Alternatively you can create a new validator in that folder and namespace. To expose your validator out through the fluent facade, add methods for your validator in the 

	Orc.CollectionValidator.Interfaces.IFluentCollectionValidator 
	
interface. Use the IDE to identify the relevant implementations of that interface that will need updating. 

Your specific validator will need to return validation result. If your validator is able to provide additional information in the validation, then consider subclassing the

	Orc.CollectionValidator.ValidationResult
	
class and the additional properties for your result. 

See the class diagram for more information.


Class Diagram
=============

![Alt text](https://raw.github.com/Orcomp/Orc.CollectionValidator/master/ClassDiagram.png)

NuGet
=====		
		
NuGet packages required - <b>FluentValidation</b>

Currently Orc.CollectionValidator is not on NuGet but we will have it up soon.

