public class MyQueue<T>
{
    public T[] Value { get; set; }
    public int Front { get; set; } = -1;
    public int Rear { get; set; } = -1;
    public int Size { get; set; }
    public MyQueue(int size)
    {
        Size = size;
        Value = new T[Size];
        for (int i = 0; i < Size; i++)
            Value[i] = default(T);
    }
    public void Enqueue(T item)
    {
        if (Rear >= Size - 1)
        {
            Console.WriteLine("Overflow can not enqueue\n");
            return;
        }
        if(Front == -1 && Rear == -1)
        {
            Front++;
            Rear++;
            Value[Rear] = item;
        }
        else
        {
            Rear++;
            Value[Rear] = item;
        }
        Console.WriteLine($"{item} added\n");
    }
    public void Dequeue()
    {
        if (Front <= -1)
        {
            Console.WriteLine("Underflow can not dequeue\n");
            return;
        }

        T temp = Value[Front];
        Value[Front] = default(T);

        if (Front == Rear)
        {
            Front = -1;
            Rear = -1;
        }
        else
        {
            Front++;
        }        

        Console.WriteLine($"{temp} deleted\n");
    }
    public void Print()
    {
        if (Front <= -1)
        {
            Console.WriteLine("Queue is empty\n");
            return;
        }
        for (int i = 0; i < Size; i++)
        {
            Console.Write(Value[i] + " ");
        }
        Console.WriteLine("(Here 0 means empty)\n");
    }
    public void ShowFront()
    {
        if (Front <= -1)
        {
            Console.WriteLine("Queue is Empty\n");
            return;
        }
        Console.WriteLine($"Front is {Value[Front]}\n");
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

        MyQueue<int> numbers = new MyQueue<int>(size);

        Console.WriteLine("E = Enqueue, D = Dequeue, P = Print, F = Front (Any other key to exit)");
        string instruction = Console.ReadLine();

        while (instruction == "E" ||
              instruction == "D" ||
              instruction == "P" ||
              instruction == "F")
        {
            Console.Clear();
            switch (instruction)
            {
                case "E":
                    Console.WriteLine("Enter item to enqueue");
                    string tempStringValue = Console.ReadLine();
                    bool tempSuccess = int.TryParse(tempStringValue, out int tempString);
                    if (!tempSuccess)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Data\n");
                        Console.WriteLine("E = Enqueue, D = Dequeue, P = Print, F = Peek");
                        instruction = Console.ReadLine();
                        continue;
                    }
                    Console.Clear();
                    numbers.Enqueue(tempString);
                    break;
                case "D":
                    numbers.Dequeue();
                    break;
                case "P":
                    numbers.Print();
                    break;
                case "F":
                    numbers.ShowFront();
                    break;
                default:
                    break;
            }
            Console.WriteLine("E = Enqueue, D = Dequeue, P = Print, F = Peek");
            instruction = Console.ReadLine();
        }
    }
}