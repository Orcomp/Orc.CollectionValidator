namespace Orc.CollectionValidator.Test.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class UniqueTestingData<T>
    {
        public IEnumerable<T> Collection { get; set; }

        public int[][] ExpectedDuplicates { get; set; }

        public bool IsActualDuplicatesCorrect(int[][] actualDuplicates)
        {
            return this.ExpectedDuplicates.Length == actualDuplicates.Length
                   && !this.ExpectedDuplicates.Where((arr, i) => !arr.SequenceEqual(actualDuplicates[i])).Any();
        }
    }
}
