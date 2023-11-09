class InsertionSort
{
    public static List<int> numbers = new List<int>();
    public static List<int> generateNumbers()
    {
        Random random = new Random();
        List<int> numbers = new List<int>();
        for (int i = 0; i < 20; i++)
        {
            numbers.Add(random.Next(1, 101));
        }
        return numbers;
    }
    public static void insertionSort()
    {
        int length = numbers.Count;

        for(int i = 1; i < length; i++)
        {
            int location=i;
            for(int j = i-1; j >= 0; j--)
            {
                if (numbers[i] < numbers[j])
                {
                    location--;
                }
            }

            for(int x=i; x > location; x--)
            {
                swap(x, x - 1);
            }
        }
    }

    public static void swap(int i, int j)
    {
        int temp = numbers[i];
        numbers[i] = numbers[j];
        numbers[j] = temp;
    }

    public static void Main(string[] args)
    {
        numbers = generateNumbers();
        //numbers = new List<int>() { 7, 3, 2, 16 };
        insertionSort();

        Console.WriteLine("Insertion Sort");
        foreach (int i in numbers)
        {
            Console.Write(i + " ");
        }
    }
}