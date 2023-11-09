class InterpolationSearch
{
    public static int doInterPolationSearch(List<int> list, int size, int target)
    {
        int low = 0;
        int high = size - 1;
        int probe = low + ((high - low)*(target - list[low])) / (list[high] - list[low]);

        while (list[probe] != target & low <= high)
        {
            if (list[probe] > target)
            {
                high = probe-1;
            }
            else
            {
                low = probe+1;
            }
            probe = low + ((high - low) * (target - list[low])) / (list[high] - list[low]);
        }
        if (list[probe] == target)
            return probe;
        else
            return -1;
    }
    public static void Main(string[] args)
    {
        List<int> list = new List<int>();
        Console.WriteLine("Enter size of the list");
        string sizeString = Console.ReadLine();
        int.TryParse(sizeString, out int size);

        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Enter element {i + 1}");
            string tempString = Console.ReadLine();
            int.TryParse(tempString, out int temp);
            list.Add(temp);
        }

        list.Sort();
        Console.WriteLine("Your list");
        foreach (int num in list)
        {
            Console.WriteLine(num);
        }

        Console.WriteLine("Now enter the number which you want to find");
        string targetString = Console.ReadLine();
        int.TryParse(targetString, out int target);

        int result = doInterPolationSearch(list, size ,target);

        if (result != -1)
            Console.WriteLine($"Item found at index {result}");
        else
            Console.WriteLine($"Item not found");
    }
}