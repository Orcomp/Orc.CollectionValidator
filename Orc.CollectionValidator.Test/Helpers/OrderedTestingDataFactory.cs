namespace Orc.CollectionValidator.Test.Helpers
{
    using System.Collections.Generic;

    public class OrderedTestingDataFactory
    {
		private OrderedTestingDataFactory()
        {
        }

		public static readonly OrderedTestingDataFactory Instance = new OrderedTestingDataFactory();


		public OrderedTestingData<GenericParameter> CreateEmptyData()
		{
			var collection = new List<GenericParameter>();

			return new OrderedTestingData<GenericParameter>
			{
				Collection = collection
			};
		}

		public OrderedTestingData<GenericParameter> CreateOrderedData()
        {
			var collection = new List<GenericParameter>
                                      {
                                          new GenericParameter { ID = 1 },
                                          new GenericParameter { ID = 2 },
                                          new GenericParameter { ID = 3 },
                                          new GenericParameter { ID = 4 },
                                          new GenericParameter { ID = 5 },
                                          new GenericParameter { ID = 6 },
                                      };

			return new OrderedTestingData<GenericParameter>
            {
                Collection = collection
            };
        }

		public OrderedTestingData<GenericParameter> CreateUnorderedData()
		{
			var collection = new List<GenericParameter>
                                      {
                                          new GenericParameter { ID = 2 },
                                          new GenericParameter { ID = 1 },
                                          new GenericParameter { ID = 4 },
                                          new GenericParameter { ID = 6 },
                                          new GenericParameter { ID = 3 },
                                          new GenericParameter { ID = 5 },
                                      };

			return new OrderedTestingData<GenericParameter>
			{
				Collection = collection
			};
		}

		public OrderedTestingData<GenericParameter> CreateUnorderedDataWithDuplicates()
		{
			var collection = new List<GenericParameter>
                                      {
                                          new GenericParameter { ID = 2 },
                                          new GenericParameter { ID = 1 },
                                          new GenericParameter { ID = 6 },
                                          new GenericParameter { ID = 3 },
                                          new GenericParameter { ID = 5 },
                                          new GenericParameter { ID = 4 },
                                          new GenericParameter { ID = 6 },
                                          new GenericParameter { ID = 3 },
                                          new GenericParameter { ID = 5 },
                                          new GenericParameter { ID = 2 },
                                          new GenericParameter { ID = 1 },
                                          new GenericParameter { ID = 4 },
                                      };

			return new OrderedTestingData<GenericParameter>
			{
				Collection = collection
			};
		}

		public OrderedTestingData<GenericParameter> CreateOrderedDataWithDuplicates()
		{
			var collection = new List<GenericParameter>
                                      {
                                          new GenericParameter { ID = 1 },
                                          new GenericParameter { ID = 1 },
                                          new GenericParameter { ID = 2 },
                                          new GenericParameter { ID = 2 },
                                          new GenericParameter { ID = 3 },
                                          new GenericParameter { ID = 3 },
                                      };

			return new OrderedTestingData<GenericParameter>
			{
				Collection = collection
			};
		}


		public OrderedTestingData<int> CreateSimpleOrderedData()
		{
			return new OrderedTestingData<int>
			{
				Collection = new[] { 1, 1, 2, 2, 3, 3}
			};
		}

		public OrderedTestingData<int> CreateSimpleUnorderedData()
		{
			return new OrderedTestingData<int>
			{
				Collection = new[] { 2, 6, 1, 3, 4, 2 }
			};
		}

    }
}
