using System.Collections.Generic;

namespace ConsoleNeetCode.RevisionOne.Graphs
{
    public class DisjointSet
    {
        private readonly List<int> _rank = new();
        private readonly List<int> _parent = new();
        private readonly List<int> _size = new();

        public DisjointSet(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _rank.Add(0);
                _parent.Add(i);
                _size.Add(1);
            }
        }


        public int FindUltimateParent(int node)
        {
            if (node == _parent[node])
                return node;
            return _parent[node] = FindUltimateParent(_parent[node]);
        }

        public void UnionByRank(int u, int v)
        {
            int ultimateParentU = FindUltimateParent(u);
            int ultimateParentV = FindUltimateParent(v);
            
            if(ultimateParentU == ultimateParentV) return;

            if (_rank[ultimateParentU] < _rank[ultimateParentV])
            {
                _parent[ultimateParentU] = ultimateParentV;
            }

            else if (_rank[ultimateParentV] < _rank[ultimateParentU])
            {
                _parent[ultimateParentV] = ultimateParentU;
            }

            else
            {
                _parent[ultimateParentV] = ultimateParentU;
                _rank[ultimateParentU]++;
            }

        }

        public void UnionBySize(int u, int v)
        {
            int ultimateParentU = FindUltimateParent(u);
            int ultimateParentV = FindUltimateParent(v);

            if (_size[ultimateParentU] > _size[ultimateParentV])
            {
                _parent[ultimateParentV] = ultimateParentU;
                _size[ultimateParentU] += _size[ultimateParentV];
            }
            else
            {
                _parent[ultimateParentU] = ultimateParentV;
                _size[ultimateParentV] += _size[ultimateParentU];
            }
        }
    }
}