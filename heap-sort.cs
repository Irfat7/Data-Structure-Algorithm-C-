using System.ComponentModel.DataAnnotations;

class HeapSort
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
    public static void swap(int i, int j) 
    {
        int temp = numbers[i];
        numbers[i] = numbers[j];
        numbers[j] = temp;
    }
    public static void heapify(int currentIndex, int size) 
    {
        int largestIndex = currentIndex;
        int leftChildIndex = 2 * currentIndex + 1;
        int rightChildIndex = 2 * currentIndex + 2;

        if (leftChildIndex < size && numbers[largestIndex] < numbers[leftChildIndex])
        {
            largestIndex = leftChildIndex;
        }

        if (rightChildIndex < size && numbers[largestIndex] < numbers[rightChildIndex])
        {
            largestIndex = rightChildIndex;
        }

        if(largestIndex != currentIndex)
        {
            swap(currentIndex, largestIndex);
            heapify(largestIndex, size);
        }

    }
    public static void heapSort()
    {
        int length = numbers.Count;

        for (int i = (length / 2) - 1; i >= 0; i--)
        {
            heapify(i, length);
        }

        for (int i = length - 1; i >= 0; i--)
        {
            swap(0, i);
            heapify(0, i);
        }
    }
    public static void Main(string[] args)
    {
        numbers = generateNumbers();
        //numbers = new List<int>{2, 8, 5, 3, 9, 1};

        heapSort();

        Console.WriteLine("Heap Sort");
        foreach (int i in numbers)
        {
            Console.Write(i + " ");
        }
    }
}