public class LinkedList<T>
{
    public Node<T> Root { get; set; } = null;
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; } = null;
        public Node(T value)
        {
            Value = value;            
        }
    }
    public void Add(T newNodeValue)
    {
        Node<T> newNode = new Node<T>(newNodeValue);
        if(Root == null)
        {
            Root = newNode;
        }
        else
        {
            var currentNode = Root;
            while(currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = newNode;
        }
        Console.WriteLine($"{newNodeValue} added\n");
    }
    public void AddAfter(T afterNodeValue, T newNodeValue)
    {
        if(Root == null)
        {
            Console.WriteLine("List is empty\n");
            return;
        }
        var currentNode = Root;
        while(currentNode.Value != null)
        {
            if (EqualityComparer<T>.Default.Equals(currentNode.Value, afterNodeValue))
            {
                Node<T> middleNode = new Node<T>(newNodeValue) { Next = currentNode.Next };
                currentNode.Next = middleNode;
                Console.WriteLine($"{newNodeValue} added after {afterNodeValue}\n");
                return;
            }
            if (currentNode.Next == null)
            {
                Console.WriteLine($"{afterNodeValue} not found in the list so {newNodeValue} not added\n");
                break;
            }
            currentNode = currentNode.Next;
        }
    }
    public void NewRoot(T newNodeValue)
    {
        Node<T> newNode = new Node<T>(newNodeValue);
        if (Root == null)
        {
            Root = newNode;
            Console.WriteLine($"No previous root. {Root.Value} set as new root\n");
        }
        else
        {
            var prevRoot = Root;
            Root= newNode;
            Root.Next = prevRoot;
            Console.WriteLine($"Old root {prevRoot.Value} updated with new root {Root.Value}\n");
        }
    }
    public void Remove()
    {
        if(Root == null)
        {
            Console.WriteLine("Underflow can not remove\n");
            return;
        }
        else if(Root.Next == null)
        {
            T tempRoot = Root.Value;
            Root = null;
            Console.WriteLine($"{tempRoot} removed from the list\n");
            return;
        }
        var currentNode = Root;
        while(currentNode.Next.Next != null )
        {
            currentNode=currentNode.Next;
        }
        T temp = currentNode.Next.Value;
        currentNode.Next = null;
        Console.WriteLine($"{temp} removed from the list\n");
    }
    public void ShowRoot()
    {
        if(Root == null)
        {
            Console.WriteLine("List is empty\n");
            return;
        }
        Console.WriteLine($"{Root.Value}\n");
    }
    public void Print()
    {        
        if(Root == null)
        {
            Console.WriteLine("Linked list is empty\n");
            return;
        }
        var currentNode = Root;
        while(currentNode.Value != null)
        {
            Console.Write(currentNode.Value + " ");
            
            if(currentNode.Next == null)
            {
                break;
            }
            currentNode = currentNode.Next;
        }
        Console.WriteLine("\n");
    }
}

class Program
{
    public static void Main(string[] args)
    {
        LinkedList<int> numbers = new LinkedList<int>();

        Console.WriteLine("A = Add, B = Add After, R = Remove, H = Root, N = Change Root, P = Print (Any other key to exit)");
        string instruction = Console.ReadLine();

        while (instruction == "A" ||
               instruction == "B" ||
               instruction == "R" ||
               instruction == "H" ||
               instruction == "N" ||
               instruction == "P")
        {
            Console.Clear();
            switch (instruction)
            {
                case "A":
                    Console.WriteLine("Enter item to add");
                    string tempStringValue = Console.ReadLine();
                    bool tempSuccess = int.TryParse(tempStringValue, out int tempString);
                    if (!tempSuccess)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Data\n");
                        Console.WriteLine("A = Add, R = Remove, H = Root, N = Change Root, P = Print (Any other key to exit)");
                        instruction = Console.ReadLine();
                        continue;
                    }
                    Console.Clear();
                    numbers.Add(tempString);
                    break;
                case "B":
                    Console.WriteLine("Enter the value after which you want to add an item");
                    string tempStringAfter = Console.ReadLine();
                    bool tempSuccessAfter = int.TryParse(tempStringAfter, out int tempAfter);
                    Console.Clear();

                    Console.WriteLine("Enter the item to add");
                    string tempStringAfterValue = Console.ReadLine();
                    bool tempSuccessAfterValue = int.TryParse(tempStringAfterValue, out int tempAfterValue);
                    if (!tempSuccessAfter || !tempSuccessAfterValue)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Data\n");
                        Console.WriteLine("A = Add, B = Add After, R = Remove, H = Root, N = Change Root, P = Print (Any other key to exit)");
                        instruction = Console.ReadLine();
                        continue;
                    }
                    Console.Clear();
                    numbers.AddAfter(tempAfter, tempAfterValue);
                    break;
                case "R":
                    numbers.Remove();
                    break;
                case "H":
                    numbers.ShowRoot();
                    break;
                case "N":
                    Console.WriteLine("Enter new root for the list");
                    string tempStringRoot = Console.ReadLine();
                    bool tempSuccessRootChange = int.TryParse(tempStringRoot, out int tempRoot);
                    if (!tempSuccessRootChange)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Data\n");
                        Console.WriteLine("A = Add, R = Remove, H = Root, N = Change Root, P = Print (Any other key to exit)");
                        instruction = Console.ReadLine();
                        continue;
                    }
                    Console.Clear();
                    numbers.NewRoot(tempRoot);
                    break;
                case "P":
                    numbers.Print();
                    break;
                default:
                    break;
            }
            Console.WriteLine("A = Add, B = Add After, R = Remove, H = Root, N = Change Root, P = Print (Any other key to exit)");
            instruction = Console.ReadLine();

        }
    }
}