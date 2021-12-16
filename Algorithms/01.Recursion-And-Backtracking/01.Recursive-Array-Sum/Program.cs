int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();


Console.WriteLine(RecursiveSum(arr, 0));

int RecursiveSum(int[] array, int i)
{
    if (i == array.Length - 1)
    {
        return array[i];
    }

    return array[i] + RecursiveSum(array, i + 1);
}