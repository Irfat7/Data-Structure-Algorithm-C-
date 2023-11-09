public class DeQueue<T>
{
    public T[] Value { get; set; }
    public int Front { get; set; } = -1;
    public int Rear { get; set; } = -1;
    public int Size { get; set; }
    public DeQueue(int size)
    {
        Size = size;
        Value = new T[Size];
        for (int i = 0; i < Size; i++)
            Value[i] = default(T);
    }
    public void FrontEnqueue(T item)
    {
        if ((Front == 0 && Rear == Size - 1) || Front == Rear + 1)
        {
            Console.WriteLine("Overflow can not front enqueue\n");
            return;
        }
        if(Front == -1 && Rear == -1)
        {
            Front++;
            Rear++;
        }
        else if( Front == 0 && Rear != Size - 1)
        {
            Front = Size - 1;
        }
        else
        {
            Front--;
        }
        Value[Front] = item;
        Console.WriteLine($"{item} added and Front Index = {Front}, RearIndex = {Rear}\n");
    }
    public void RearEnqueue(T item)
    {
        if ((Front == 0 && Rear == Size - 1) || Front == Rear + 1)
        {
            Console.WriteLine("Overflow can not rear enqueue\n");
            return;
        }
        if (Front == -1 && Rear == -1)
        {
            Front++;
            Rear++;
        }
        else if (Rear == Size - 1 && Front != 0)
        {
            Rear = 0;
        }
        else
        {
            Rear++;
        }
        Value[Rear] = item;
        Console.WriteLine($"{item} added and Front Index = {Front}, RearIndex = {Rear}\n");
    }
    public void FrontDequeue()
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
        else if(Front == Size - 1)
        {
            Front = 0;
        }
        else
        {
            Front++;
        }        

        Console.WriteLine($"{temp} deleted and Front Index = {Front}, RearIndex = {Rear}\n");
    }
    public void RearDequeue()
    {
        if (Front <= -1)
        {
            Console.WriteLine("Underflow can not dequeue\n");
            return;
        }

        T temp = Value[Rear];
        Value[Rear] = default(T);

        if (Front == Rear)
        {
            Front = -1;
            Rear = -1;
        }
        else if (Rear == 0)
        {
            Rear = Size - 1;
        }
        else
        {
            Rear--;
        }

        Console.WriteLine($"{temp} deleted and Front Index = {Front}, RearIndex = {Rear}\n");
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
            Console.WriteLine("Queue is empty\n");
            return;
        }
        Console.WriteLine($"Front is {Value[Front]}\n");
    }
    public void ShowRear()
    {
        if (Front <= -1)
        {
            Console.WriteLine("Queue is empty\n");
            return;
        }
        Console.WriteLine($"Rear is {Value[Rear]}\n");
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

        DeQueue<int> numbers = new DeQueue<int>(size);

        Console.WriteLine("E = Front Enqueue, e = Rear Enqueue, D = Front Dequeue, d = Rear Dequeue, F = Show Front, R = Show Rear, P = Print (Any other key to exit)");
        string instruction = Console.ReadLine();

        while (instruction == "E" ||
               instruction == "e" ||
               instruction == "D" ||
               instruction == "d" ||
               instruction == "F" ||
               instruction == "R" ||
               instruction == "P")
        {
            Console.Clear();
            switch (instruction)
            {
                case "E":
                    Console.WriteLine("Enter item to front enqueue");
                    string tempStringValueFront = Console.ReadLine();
                    bool tempSuccessFront = int.TryParse(tempStringValueFront, out int tempStringFront);
                    if (!tempSuccessFront)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Data\n");
                        Console.WriteLine("E = Front Enqueue, e = Rear Enqueue, D = Front Dequeue, d = Rear Dequeue, F = Front, R = Show Rear, P = Print (Any other key to exit)");
                        instruction = Console.ReadLine();
                        continue;
                    }
                    Console.Clear();
                    numbers.FrontEnqueue(tempStringFront);
                    break;
                case "e":
                    Console.WriteLine("Enter item to rear enqueue");
                    string tempStringValueRear = Console.ReadLine();
                    bool tempSuccessRear = int.TryParse(tempStringValueRear, out int tempStringRear);
                    if (!tempSuccessRear)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Data\n");
                        Console.WriteLine("E = Front Enqueue, e = Rear Enqueue, D = Front Dequeue, d = Rear Dequeue, F = Front, R = Show Rear, P = Print (Any other key to exit)");
                        instruction = Console.ReadLine();
                        continue;
                    }
                    Console.Clear();
                    numbers.RearEnqueue(tempStringRear);
                    break;
                case "D":
                    numbers.FrontDequeue();
                    break;
                case "d":
                    numbers.RearDequeue(); 
                    break;
                case "P":
                    numbers.Print();
                    break;
                case "F":
                    numbers.ShowFront();
                    break;
                case "R":
                    numbers.ShowRear();
                    break;
                default:
                    break;
            }
            Console.WriteLine("E = Front Enqueue, e = Rear Enqueue, D = Front Dequeue, d = Rear Dequeue, F = Front, R = Show Rear, P = Print (Any other key to exit)");
            instruction = Console.ReadLine();
        }
    }
}