public class MyStack<T>
{
    public T[] Value { get; set; }
    public int Index { get; set; } = -1;
    public int Size { get; set; }
    public MyStack(int size)
    {
        Size = size;
        Value = new T[Size];
    }
    public void Push(T item)
    {
        if(Index >= Size-1)
        {
            Console.WriteLine("Overflow can not push\n");
            return;
        }

        for(int i= Index; i >= 0; i--) 
        {
            Value[i+1] = Value[i];
        }
        Index++;
        Value[0] = item;
        Console.WriteLine($"{item} added\n");
    }
    public void Pop()
    {
        if (Index <= -1)
        {
            Console.WriteLine("Underflow can not pop\n");
            return;
        }
        T temp = Value[0];
        for(int i = 1; i <= Index; i++)
        {
            Value[i-1] = Value[i];
        }
        Index--;
        Console.WriteLine($"{temp} deleted\n");
    }
    public void Print()
    {
        if(Index <= -1)
        {
            Console.WriteLine("Stack is empty\n");
            return;
        }
        for(int i=0; i<= Index; i++)
        {
            Console.Write(Value[i]+ " ");
        }
        Console.WriteLine("\n");
    }
    public void Top()
    {
        if(Index <= -1)
        {
            Console.WriteLine("Stack is Empty\n");
            return;
        }
        Console.WriteLine($"Front is {Value[0]}\n");
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter Size");
        string sizeString = Console.ReadLine();
        bool success = int.TryParse(sizeString, out int size);
        if (!success)
        {
            Console.WriteLine("Non convertable data");
            return;
        }
        Console.Clear();

        MyStack<int> numbers = new MyStack<int>(size);

        Console.WriteLine("P = Push, D = Pop, P = S, T = Top (Any other key to exit)");
        string instruction = Console.ReadLine();

        while (instruction == "P" ||
              instruction == "D" ||
              instruction == "S" ||
              instruction == "T")
        {
            Console.Clear();
            switch (instruction)
            {
                case "P":
                    Console.WriteLine("Enter item to push");
                    string tempStringValue = Console.ReadLine();
                    bool tempSuccess = int.TryParse(tempStringValue, out int tempString);
                    if (!tempSuccess)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Data\n");
                        Console.WriteLine("P = Push, D = Pop, P = S, T = Top (Any other key to exit)");
                        instruction = Console.ReadLine();
                        continue;
                    }
                    Console.Clear();
                    numbers.Push(tempString);
                    break;
                case "D":
                    numbers.Pop();
                    break;
                case "S":
                    numbers.Print();
                    break;
                case "T":
                    numbers.Top();
                    break;
                default:
                    break;
            }
            Console.WriteLine("P = Push, D = Pop, P = S, T = Top (Any other key to exit)");
            instruction = Console.ReadLine();
        }
    }
}