public class Tree<T>
{
    public T Root { get; set; }
    public Tree(T root)
    {
        Root = root;
    }
    public List<T> InPrint { get; set; } = new List<T>();
    public List<T> PrePrint { get; set; } = new List<T>();
    public List<T> PostPrint { get; set; } = new List<T>();

    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> LeftChild { get; set; } = null;
        public Node<T> RightChild { get; set; } = null;
        public bool NotVisited { get; set; } = true;

        public Node(T value)
        {
            Value = value;
        }
    }

    public void inOrder(Node<T> node)
    {
        if(node != null)
        {
            inOrder(node.LeftChild);
            InPrint.Add(node.Value);
            inOrder(node.RightChild);
        }
    }

    public void preOrder(Node<T> node)
    {
        if (node != null)
        {
            PrePrint.Add(node.Value);
            preOrder(node.LeftChild);
            preOrder(node.RightChild);
        }
    }

    public void postOrder(Node<T> node)
    {
        if (node != null)
        {
            postOrder(node.LeftChild);
            postOrder(node.RightChild);
            PostPrint.Add(node.Value);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Tree<char> characterTree = new Tree<char>('A');

        //Node Creation
        Tree<char>.Node<char> a = new Tree<char>.Node<char>('A');
        Tree<char>.Node<char> b = new Tree<char>.Node<char>('B');
        Tree<char>.Node<char> c = new Tree<char>.Node<char>('C');
        Tree<char>.Node<char> d = new Tree<char>.Node<char>('D');
        Tree<char>.Node<char> e = new Tree<char>.Node<char>('E');
        Tree<char>.Node<char> f = new Tree<char>.Node<char>('F'); 
        Tree<char>.Node<char> g = new Tree<char>.Node<char>('G');
        Tree<char>.Node<char> h = new Tree<char>.Node<char>('H');
        Tree<char>.Node<char> i = new Tree<char>.Node<char>('I');

        a.LeftChild = b; a.RightChild = c;
        b.LeftChild = d;
        c.LeftChild = e; c.RightChild = f;
        e.RightChild = g;
        f.LeftChild = h; f.RightChild= i;


        characterTree.inOrder(a);
        Console.WriteLine("Inorder Tree Traversal");
        foreach(var value in characterTree.InPrint)
        {
            Console.Write(value + " ");
        }

        characterTree.preOrder(a);
        Console.WriteLine("\nPreorder Tree Traversal");
        foreach (var value in characterTree.PrePrint)
        {
            Console.Write(value + " ");
        }

        characterTree.postOrder(a);
        Console.WriteLine("\nPostorder Tree Traversal");
        foreach (var value in characterTree.PostPrint)
        {
            Console.Write(value + " ");
        }
    }
}