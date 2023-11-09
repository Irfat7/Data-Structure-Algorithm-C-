class LinearSearch 
{
    public static void Main(string[] args)
    {
        List<int> list = new List<int>();
        Console.WriteLine("Enter size of the list");
        string sizeString = Console.ReadLine();
        int.TryParse(sizeString, out int size);

        for(int i=0; i<size; i++)
        {
            Console.WriteLine($"Enter element {i+1}");
            string tempString = Console.ReadLine();
            int.TryParse(tempString, out int temp);
            list.Add(temp);
        }
        Console.WriteLine("Your list");
        foreach(int num in list)
        {
            Console.WriteLine(num);
        }

        Console.WriteLine("Now enter the number which you want to find");
        string targetString = Console.ReadLine();
        int.TryParse(targetString, out int target);

        for (int i = 0; i < size; i++)
        {
            if (list[i] == target)
            {
                Console.WriteLine($"Index of {target} is {i}");
                break;
            }
            else if(i == size - 1)
            {
                Console.WriteLine("Item not found");
            }
        }
    }
}