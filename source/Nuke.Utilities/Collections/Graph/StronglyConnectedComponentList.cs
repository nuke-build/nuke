// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Utilities
{
    internal class StronglyConnectedComponentList<T> : IEnumerable<StronglyConnectedComponent<T>>
    {
        private readonly LinkedList<StronglyConnectedComponent<T>> _collection;

        public StronglyConnectedComponentList()
        {
            _collection = new LinkedList<StronglyConnectedComponent<T>>();
        }

        public void Add(StronglyConnectedComponent<T> scc)
        {
            _collection.AddLast(scc);
        }

        public int Count => _collection.Count;

        public IEnumerator<StronglyConnectedComponent<T>> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        public IEnumerable<StronglyConnectedComponent<T>> IndependentComponents()
        {
            return this.Where(c => !c.IsCycle);
        }

        public IEnumerable<StronglyConnectedComponent<T>> Cycles()
        {
            return this.Where(c => c.IsCycle);
        }
    }
}
