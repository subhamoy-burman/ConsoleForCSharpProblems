using System.Collections.Generic;

namespace ConsoleNeetCode.RevisionOne.Graphs

{
    public class DisjointSetRevision1
    {
        private readonly List<int> _rank = new();
        private readonly List<int> _parent = new();

        public DisjointSetRevision1(int size)
        {
            for (int i = 0; i <= size; i++)
            {
                _rank.Add(0);
                _parent.Add(i);
            }
        }

        public int FindUltimateParent(int node)
        {
            if (node == _parent[node])
            {
                return node;
            }

            return _parent[node] = FindUltimateParent(_parent[node]);
        }

        public void UnionByRank(int u, int v)
        {
            var ultimateOfU = FindUltimateParent(u);
            var ultimateOfV = FindUltimateParent(v);
            
            if(ultimateOfU == ultimateOfV) return;

            if (_rank[ultimateOfU] < _rank[ultimateOfV])
            {
                _parent[ultimateOfU] = _parent[ultimateOfV];
            }
            else if (_rank[ultimateOfV] < _rank[ultimateOfU])
            {
                _parent[ultimateOfV] = ultimateOfU;
            }
            else
            {
                _parent[ultimateOfV] = ultimateOfU;
                _rank[ultimateOfU] = _rank[ultimateOfU]+1;

            }

        }
    }
}