using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Core.Execution
{
    internal class StronglyConnectedComponentList<T> : IEnumerable<StronglyConnectedComponent<T>>
    {
        private readonly LinkedList<StronglyConnectedComponent<T>> _collection;

        public StronglyConnectedComponentList ()
        {
            _collection = new LinkedList<StronglyConnectedComponent<T>> ();
        }

        public StronglyConnectedComponentList (IEnumerable<StronglyConnectedComponent<T>> collection)
        {
            _collection = new LinkedList<StronglyConnectedComponent<T>> (collection);
        }

        public void Add (StronglyConnectedComponent<T> scc)
        {
            _collection.AddLast (scc);
        }

        public int Count
        {
            get { return _collection.Count; }
        }

        public IEnumerator<StronglyConnectedComponent<T>> GetEnumerator ()
        {
            return _collection.GetEnumerator ();
        }

        IEnumerator IEnumerable.GetEnumerator ()
        {
            return _collection.GetEnumerator ();
        }

        public IEnumerable<StronglyConnectedComponent<T>> IndependentComponents ()
        {
            return Enumerable.Where (this, c => !c.IsCycle);
        }

        public IEnumerable<StronglyConnectedComponent<T>> Cycles ()
        {
            return Enumerable.Where (this, c => c.IsCycle);
        }
    }
}