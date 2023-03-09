// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Utilities
{
    internal class StronglyConnectedComponent<T> : IEnumerable<Vertex<T>>
    {
        private readonly LinkedList<Vertex<T>> _list;

        public StronglyConnectedComponent()
        {
            _list = new LinkedList<Vertex<T>>();
        }

        public void Add(Vertex<T> vertex)
        {
            _list.AddLast(vertex);
        }

        public int Count => _list.Count;

        public bool IsCycle => _list.Count > 1;

        public IEnumerator<Vertex<T>> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
