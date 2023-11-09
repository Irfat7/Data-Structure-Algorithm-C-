class BinarySearch
{
    public static int doBinarySearch(List<int> list, int target)
    {
        int start = 0;
        int end = list.Count - 1;
        int middle = (start + end) / 2;
        while (list[middle] != target & start <= end)
        {
            if (list[middle] > target)
            {
                end = middle-1;
            }
            else if (list[middle] < target)
            {
                start = middle+1;
            }
            middle = (start + end) / 2;
        }

        if (list[middle] == target)
            return middle;
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

        int result = doBinarySearch(list, target);
        if (result != -1)
            Console.WriteLine($"{target} found at index {result}");

        else
            Console.WriteLine("Item not found");

    }
}