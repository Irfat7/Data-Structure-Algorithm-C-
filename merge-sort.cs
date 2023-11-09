class MergeSort
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

    public static void merge(List<int> leftList, List<int> rightList, List<int> numbers)
    {
        int leftSize = leftList.Count;
        int rightSize = rightList.Count;
        int i = 0, l = 0, r = 0;
        while(l<leftSize && r<rightSize)
        {
            if (leftList[l] < rightList[r]) 
            {
                numbers[i] = leftList[l];
                i++;
                l++;
            }
            else
            {
                numbers[i] = rightList[r];
                i++;
                r++;
            }
        }

        while (l < leftSize)
        {
            numbers[i] = leftList[l];
            i++;
            l++;
        }
        while (r < rightSize)
        {
            numbers[i] = rightList[r];
            i++;
            r++;
        }
    }
    public static void mergeSort(List<int> numbers)
    {
        int length = numbers.Count;
        if (length <= 1)
            return;
        int middle = (length - 1 )/ 2;

        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();

        for (int i = 0; i <= middle; i++)
            leftList.Add(numbers[i]);

        for (int i = middle + 1; i < length; i++)
            rightList.Add(numbers[i]);

        mergeSort(leftList);
        mergeSort(rightList);
        merge(leftList, rightList, numbers);
    }

    public static void Main(string[] args)
    {
        numbers = generateNumbers();
        //numbers = new List<int>() { 7, 3, 2, 16};
        mergeSort(numbers);

        Console.WriteLine("Merge Sort");
        foreach (int i in numbers)
        {
            Console.Write(i + " ");
        }
    }
}