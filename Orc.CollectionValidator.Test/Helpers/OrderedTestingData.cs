namespace Orc.CollectionValidator.Test.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

	public class OrderedTestingData<T>
	{
		public IEnumerable<T> Collection { get; set; }
	}

}
