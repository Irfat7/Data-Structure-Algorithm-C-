public class BinarySearchTree<T>
{
    public TreeNode<T> Root { get; set; } = null;
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    public void Add(T data)
    {
        TreeNode<T> newNode = new TreeNode<T>(data);

        if (Root == null)
        {
            Root = newNode;
            Console.WriteLine($"{newNode.Data} added\n");
        }
        else
        {
            InsertRecursively(Root, newNode);
        }
    }
    private void InsertRecursively(TreeNode<T> currentNode, TreeNode<T> newNode)
    {
        if (Comparer<T>.Default.Compare(newNode.Data, currentNode.Data) < 0)
        {
            if (currentNode.Left == null)
            {
                currentNode.Left = newNode;
                Console.WriteLine($"{newNode.Data} added\n");
            }
            else
            {
                InsertRecursively(currentNode.Left, newNode);
            }
        }
        else
        {
            if (currentNode.Right == null)
            {
                currentNode.Right = newNode;
                Console.WriteLine($"{newNode.Data} added\n");
            }
            else
            {
                InsertRecursively(currentNode.Right, newNode);
            }
        }
    }
    public void Search(T data)
    {
        SearchRecursively(Root, data);
    }
    private void SearchRecursively(TreeNode<T> currentNode, T data)
    {
        if (currentNode == null)
        {
            Console.WriteLine($"{data} not found\n");
            return;
        }

        if (EqualityComparer<T>.Default.Equals(currentNode.Data, data))
        {
            Console.WriteLine($"{data} found\n");
            return;
        }

        if (Comparer<T>.Default.Compare(data, currentNode.Data) < 0)
        {
            SearchRecursively(currentNode.Left, data);
        }
        else
        {
            SearchRecursively(currentNode.Right, data);
        }
    }
    public void Print(int x)
    {
        if (Root == null)
        {
            Console.WriteLine("Tree is empty\n");
            return;
        }
        switch(x)
        {
            case 1:
                BFS();
                break;
            case 2:
                DFS();
                break;
            case 3:
                InOrder(Root);
                Console.WriteLine("\n");
                break;
            case 4:
                PreOrder(Root);
                Console.WriteLine("\n");
                break;
            case 5:
                PostOrder(Root);
                Console.WriteLine("\n");
                break;
            default:
                break;
        }
    }
    private void BFS()
    {
        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            TreeNode<T> current = queue.Dequeue();
            Console.Write(current.Data + " ");

            if (current.Left != null)
            {
                queue.Enqueue(current.Left);
            }

            if (current.Right != null)
            {
                queue.Enqueue(current.Right);
            }
        }
        Console.WriteLine("\n");
    }
    private void DFS()
    {
        Stack<TreeNode<T>> treeNodes = new Stack<TreeNode<T>>();
        treeNodes.Push(Root);

        while(treeNodes.Count > 0)
        {
            TreeNode<T> current = treeNodes.Pop();
            Console.Write(current.Data + " ");
            if (current.Right != null)
            {
                treeNodes.Push(current.Right);
            }
            if (current.Left != null)
            {
                treeNodes.Push(current.Left);
            }
        }
        
        Console.WriteLine("\n");
    }
    private void InOrder(TreeNode<T> node)
    {
        if(node != null)
        {
            InOrder(node.Left);
            Console.Write(node.Data + " ");
            InOrder(node.Right);
        }
    }
    private void PreOrder(TreeNode<T> node)
    {
        if (node != null)
        {
            Console.Write(node.Data + " ");
            PreOrder(node.Left);
            PreOrder(node.Right);
        }
    }
    private void PostOrder(TreeNode<T> node)
    {
        if (node != null)
        {
            PostOrder(node.Left);
            PostOrder(node.Right);
            Console.Write(node.Data + " ");
        }
    }
}
class Program
{
    public static void Main(string[] args)
    {
        BinarySearchTree<int> numbers = new BinarySearchTree<int>();

        Console.WriteLine("A = Add, S = Search, B = BFS, D = DFS, IO = InOrder, Pro = PreOrder, PO = PostOrder (Any other key to exit)");
        string instruction = Console.ReadLine();

        while (instruction == "A" ||
               instruction == "S" ||
               instruction == "B" ||
               instruction == "D" ||
               instruction == "IO" ||
               instruction == "Pro" ||
               instruction == "PO" )
        {
            Console.Clear();
            switch (instruction)
            {
                case "A":
                    Console.WriteLine("Enter item to add");
                    string tempStringInsertion = Console.ReadLine();
                    bool tempSuccessInsertion = int.TryParse(tempStringInsertion, out int tempInsertionValue);
                    if (!tempSuccessInsertion)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Data\n");
                        Console.WriteLine("A = Add, S = Search, B = BFS, D = DFS, IO = InOrder, Pro = PreOrder, PO = PostOrder (Any other key to exit)");
                        instruction = Console.ReadLine();
                        continue;
                    }
                    Console.Clear();
                    numbers.Add(tempInsertionValue);
                    break;
                case "S":
                    Console.WriteLine("Enter the item to search");
                    string tempStringSearch = Console.ReadLine();
                    bool tempSuccessSearch = int.TryParse(tempStringSearch, out int tempSearchValue);
                    if (!tempSuccessSearch)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Data\n");
                        Console.WriteLine("A = Add, S = Search, B = BFS, D = DFS, IO = InOrder, Pro = PreOrder, PO = PostOrder (Any other key to exit)");
                        instruction = Console.ReadLine();
                        continue;
                    }
                    Console.Clear();
                    numbers.Search(tempSearchValue);
                    break;
                case "B":
                    numbers.Print(1);
                    break;
                case "D":
                    numbers.Print(2);
                    break;
                case "IO":
                    numbers.Print(3);
                    break;
                case "Pro":
                    numbers.Print(4);
                    break;
                case "PO":
                    numbers.Print(5);
                    break;
                default:
                    break;
            }
            Console.WriteLine("A = Add, S = Search, B = BFS, D = DFS, IO = InOrder, Pro = PreOrder, PO = PostOrder (Any other key to exit)");
            instruction = Console.ReadLine();

        }
    }
}