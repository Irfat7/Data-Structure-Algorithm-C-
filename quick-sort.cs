using System.Collections.Concurrent;

class QucikSort
{
    public static List<int> numbers = new List<int>();
    public static List<int> generateNumbers()
    {
        Random random = new Random();
        List<int> numbers = new List<int>();
        for (int i = 0; i < 6; i++)
        {
            numbers.Add(random.Next(1, 101));
        }
        return numbers;
    }
    
    public static int partition(int start, int end)
    {
        int pivot = numbers[end];
        int i = start - 1;

        for (int j = start; j < end; j++)
        {
            if (numbers[j] < pivot)
            {
                i++;
                int temp1 = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp1;
            }
        }

        int temp2 = numbers[i+1];
        numbers[i+1] = numbers[end];
        numbers[end] = temp2;
        return i + 1;
    }

    public static void quickSort(int start, int end)
    {
        if(start < end)
        {
            int partitionIndex = partition(start, end);
            quickSort(start, partitionIndex-1);
            quickSort(partitionIndex + 1, end);
        }
    }

    public static void Main(string[] args)
    {
        numbers = generateNumbers();
        quickSort(0, numbers.Count-1);

        Console.WriteLine("Quick Sort");
        foreach (int i in numbers)
        {
            Console.Write(i + " ");
        }
    }
}