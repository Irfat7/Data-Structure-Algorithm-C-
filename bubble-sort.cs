class BubbleSort
{
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
    
    public static List<int> bubbleSort(List<int> numbers)
    {
        int length = numbers.Count;
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    int temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;
                }
            }
        }

        return numbers;
    }

    public static void Main(string[] args)
    {
        List<int> numbers = generateNumbers();

        numbers = bubbleSort(numbers);

        Console.WriteLine("Selection Sort");
        foreach (int i in numbers)
        {
            Console.Write(i + " ");
        }
    }
}