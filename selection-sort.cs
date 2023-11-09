class SelectionSort
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
    
    public static List<int> selectionSort(List<int> numbers)
    {
        int length = numbers.Count;
        for(int i=0;i<length; i++)
        {
            int minIndex = i;
            for(int j = i+1; j < length; j++)
            {
                if (numbers[j] < numbers[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = numbers[i];
            numbers[i] = numbers[minIndex];
            numbers[minIndex] = temp;
        }

        return numbers;
    }

    //public static List<int> selectionSort(List<int> numbers)
    //{
    //    List<int> sortedNumbers = new List<int>();

    //    while (numbers.Count > 0)
    //    {
    //        int small = numbers[0];
    //        for (int i = 1; i < numbers.Count; i++)
    //        {
    //            if (numbers[i] < small)
    //            {
    //                small = numbers[i];
    //            }
    //        }
    //        sortedNumbers.Add(small);
    //        numbers.Remove(small);
    //    }

    //    return sortedNumbers;
    //}

    public static void Main(string[] args)
    {
        List<int> numbers = generateNumbers();

        numbers = selectionSort(numbers);

        Console.WriteLine("Selection Sort");
        foreach (int i in numbers)
        {
            Console.Write(i + " ");
        }
    }
}