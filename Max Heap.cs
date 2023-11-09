public class MaxHeap
{
    public static int[] Heapify(int start, int[] numbers)
    {
        int largestIndex = start;
        int leftChildIndex = 2 * largestIndex + 1;
        int rightChildIndex = 2 * largestIndex + 2;

        if(leftChildIndex < numbers.Length)
        {
            if (numbers[leftChildIndex] > numbers[start])
            {
                largestIndex = leftChildIndex;
            }
        }
        if (rightChildIndex < numbers.Length)
        {
            if (numbers[rightChildIndex] > numbers[largestIndex])
            {
                largestIndex = rightChildIndex;
            }
        }

        if(largestIndex != start) 
        {
            int temp = numbers[start];
            numbers[start] = numbers[largestIndex];
            numbers[largestIndex] = temp;
            Heapify(largestIndex, numbers);
        }
        return numbers;
    }
    public static int[] BuildMaxHeap(int[] numbers)
    {
        int length = numbers.Length;
        for(int i = (length/2)-1; i >=0; i--)
        {
            numbers = Heapify(i, numbers);
        }
        return numbers;
    }

    public static void Main(string[] args)
    {
        int[] numbers = { 9, 1, 20, 13, 5, 8 };
        numbers = BuildMaxHeap(numbers);
        foreach(int num in numbers)
        {
            Console.Write(num + " ");
        }
    }
}