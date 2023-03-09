// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Utilities
{
    internal class StronglyConnectedComponentFinder<T>
    {
        private StronglyConnectedComponentList<T> _stronglyConnectedComponents;
        private Stack<Vertex<T>> _stack;
        private int _index;

        /// <summary>
        /// Calculates the sets of strongly connected vertices.
        /// </summary>
        /// <param name="graph">Graph to detect cycles within.</param>
        /// <returns>Set of strongly connected components (sets of vertices)</returns>
        public StronglyConnectedComponentList<T> DetectCycle(IEnumerable<Vertex<T>> graph)
        {
            _stronglyConnectedComponents = new StronglyConnectedComponentList<T>();
            _index = 0;
            _stack = new Stack<Vertex<T>>();
            foreach (var v in graph)
            {
                if (v.Index < 0)
                    StrongConnect(v);
            }

            return _stronglyConnectedComponents;
        }

        private void StrongConnect(Vertex<T> v)
        {
            v.Index = _index;
            v.LowLink = _index;
            _index++;
            _stack.Push(v);

            foreach (var w1 in v.Dependencies)
            {
                if (w1.Index < 0)
                {
                    StrongConnect(w1);
                    v.LowLink = Math.Min(v.LowLink, w1.LowLink);
                }
                else if (_stack.Contains(w1))
                {
                    v.LowLink = Math.Min(v.LowLink, w1.Index);
                }
            }

            if (v.LowLink != v.Index)
                return;

            var scc = new StronglyConnectedComponent<T>();
            Vertex<T> w2;
            do
            {
                w2 = _stack.Pop();
                scc.Add(w2);
            } while (v != w2);

            _stronglyConnectedComponents.Add(scc);
        }
    }
}
