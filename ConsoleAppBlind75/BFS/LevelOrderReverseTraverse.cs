using System.Collections.Generic;

namespace ConsoleAppBlind75.BFS
{
    public class LevelOrderReverseTraverse
    {
        public LinkedList<List<int>> Execute(TreeNode node)
        {
            if (node == null)
            {
                return new LinkedList<List<int>>();
            }
            
            Queue<TreeNode> processingQueue = new Queue<TreeNode>();
            LinkedList<List<int>> processedElements = new LinkedList<List<int>>();
            processingQueue.Enqueue(node);
            
            while (processingQueue.Count != 0)
            {
                int size = processingQueue.Count;
                List<int> levelList = new List<int>();
                for(int i=0;i<size;i++)
                {
                    TreeNode current = processingQueue.Peek();
                    
                    if(current.Left!= null)
                        processingQueue.Enqueue(current.Left);
                    if(current.Right!=null)
                        processingQueue.Enqueue(current.Right);

                    processingQueue.Dequeue();
                    levelList.Add(current.Value);
                }
                processedElements.AddFirst(levelList);
            }

            return processedElements;
        }
    }
}