using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Core.Execution
{
    internal class StronglyConnectedComponent<T> : IEnumerable<Vertex<T>>
    {
        private readonly LinkedList<Vertex<T>> _list;

        public StronglyConnectedComponent ()
        {
            _list = new LinkedList<Vertex<T>> ();
        }

        public StronglyConnectedComponent (IEnumerable<Vertex<T>> collection)
        {
            _list = new LinkedList<Vertex<T>> (collection);
        }

        public void Add (Vertex<T> vertex)
        {
            _list.AddLast (vertex);
        }

        public IEnumerator<Vertex<T>> GetEnumerator ()
        {
            return _list.GetEnumerator ();
        }

        public int Count
        {
            get { return _list.Count; }
        }

        IEnumerator IEnumerable.GetEnumerator ()
        {
            return _list.GetEnumerator ();
        }

        public bool IsCycle
        {
            get { return _list.Count > 1; }
        }
    }
}