using System.Collections;
using System.Collections.Generic;

namespace Platinio.TweenEngine
{
    public class ReadOnlyHashSet<T> : IReadOnlyCollection<T>
    {
        private HashSet<T> _hashset;

        public ReadOnlyHashSet(HashSet<T> hashset)
        {
            _hashset = hashset;
        }

        public int Count => _hashset.Count;

        public IEnumerator<T> GetEnumerator() => _hashset.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _hashset.GetEnumerator();
    }
}
