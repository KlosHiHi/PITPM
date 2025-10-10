using System.Collections;

namespace UnitTest
{
    public class SumDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { 4, 5, 9},
            new object[] { 3, 1, 4},
            new object[] { -2, -3, -5}
        };

        public IEnumerator<object[]> GetEnumerator()
            => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
