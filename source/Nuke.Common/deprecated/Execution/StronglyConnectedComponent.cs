// ReSharper disable All
#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Core.Execution
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
