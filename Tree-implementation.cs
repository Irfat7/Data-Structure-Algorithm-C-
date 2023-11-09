public class Tree<T>
{
    public static Queue<TreeNode<T>> ready = new Queue<TreeNode<T>>();
    public static Queue<T> print = new Queue<T>();

    public static Queue<T> printForDFS = new Queue<T>();
    public static Stack<TreeNode<T>> readyDFS = new Stack<TreeNode<T>>();

    public class TreeNode<T>
    {
        public T Value { get; set; }
        public List<TreeNode<T>> Children { get; set; }
        public bool Visited { get; set; } = false;
        public bool VisitedDFS { get; set; } = false;

        public TreeNode(T value)
        {
            Value = value;
            Children = new List<TreeNode<T>>();
        }

        public void changeValue(T value)
        {
            Value = value;
        }

        public void addChildren(TreeNode<T> node)
        {
            Children.Add(node);
        }

        public void removeChildren(TreeNode<T> node)
        {
            Children.Remove(node);
        }
        //public void traverseDFS()
        //{
        //    Console.Write(Value + " ");
        //    foreach (var child in Children)
        //    {
        //        child.traverseDFS();
        //    }
        //}
    }

    public static void traverseBFS(TreeNode<T> root)
    {
        if (!(root.Visited))
        {
            ready.Enqueue(root);
            root.Visited = true;
        }
        foreach (var child in root.Children)
        {
            if (!(child.Visited))
            {
                ready.Enqueue(child);
                child.Visited = true;
            }
        }
        ready.Dequeue();
        print.Enqueue(root.Value);
        if(ready.Count > 0)
            traverseBFS(ready.FirstOrDefault());
    }

    public static void traverseDFS(TreeNode<T> root)
    {
        if (!(root.VisitedDFS))
        {
            readyDFS.Push(root);
            root.VisitedDFS = true;
        }
        readyDFS.Pop();
        List<TreeNode<T>> tempChildren = root.Children;
        tempChildren.Reverse();
        foreach (var child in tempChildren)
        {
            if (!(child.VisitedDFS))
            {
                readyDFS.Push(child);
                child.VisitedDFS = true;
            }
        }
        printForDFS.Enqueue(root.Value);
        if (readyDFS.Count > 0)
            traverseDFS(readyDFS.Peek());
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Tree<int>.TreeNode<int> root = new Tree<int>.TreeNode<int>(1);

        Tree<int>.TreeNode<int> child1 = new Tree<int>.TreeNode<int>(2);
        Tree<int>.TreeNode<int> child2 = new Tree<int>.TreeNode<int>(3);
        Tree<int>.TreeNode<int> child3 = new Tree<int>.TreeNode<int>(4);

        Tree<int>.TreeNode<int> grandChild1 = new Tree<int>.TreeNode<int>(5);
        Tree<int>.TreeNode<int> grandChild2 = new Tree<int>.TreeNode<int>(6);
        Tree<int>.TreeNode<int> grandChild3 = new Tree<int>.TreeNode<int>(7);

        root.Children.Add(child1);
        root.Children.Add(child2);
        root.Children.Add(child3);

        child1.Children.Add(grandChild1);

        child2.Children.Add(grandChild2);
        child2.Children.Add(grandChild3);

        root.changeValue(11);

        Tree<int>.TreeNode<int> grandChild4 = new Tree<int>.TreeNode<int>(10);
        child1.addChildren(grandChild4);

        //child1.removeChildren(grandChild4);

        //Console.Write("DFS ");
        //root.traverseDFS();

        Tree<int>.traverseBFS(root);

        Console.Write("\nBFS ");
        foreach (var traverse in Tree<int>.print)
        {
            Console.Write(traverse + " ");
        }


        Tree<int>.traverseDFS(root);
        Console.Write("\nDFS ");
        foreach (var traverseDFS in Tree<int>.printForDFS)
        {
            Console.Write(traverseDFS + " ");
        }
    }
}