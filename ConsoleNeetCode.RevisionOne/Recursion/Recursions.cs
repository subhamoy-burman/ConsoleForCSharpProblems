using System.Collections.Generic;
using System.Drawing;

namespace ConsoleNeetCode.RevisionOne.Recursion;

public static class Recursions
{
    public static bool GraphColoring(List<List<int>>  graph, int[] m, int n) {
        // Your code here

        return SolveGraphColoring(graph, m, 0, n);
        
    }

    private static bool SolveGraphColoring(List<List<int>>  graph, int[] color, int node, int noOfColors)
    {
        if (node == graph.Count)
        {
            return true;
        }
        for (int i = 1; i <= noOfColors; i++)
        {
            if (IsColorPossible(graph, i, node, color))
            {
                color[node] = i;
                if (SolveGraphColoring(graph, color, node + 1, noOfColors))
                {
                    return true;
                }

                color[node] = 0;
            }
        }

        return false;
    }

    private static bool IsColorPossible(List<List<int>> graph, int currentColor, int node, int[] color)
    {
        foreach (var item in graph[node])
        {
            if (color[item] == currentColor)
            {
                return false;
            }
        }

        return true;
    }
}