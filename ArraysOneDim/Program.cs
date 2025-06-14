namespace ArraysOneDim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = new int[2];    // new
            arr1[0] = 1;
            arr1[1] = 2;

            for (int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine($"{arr1[i]}");
            }

            int[] arr2 = { 1, 2, 3 };   // unsized initialization

            foreach (int el in arr2)
            {
                Console.WriteLine(el);
            }

            int[] arr3 = new int[] { 1, 2, 3 }; // array initializer

            int[] arr4 = [1, 2, 3, 4];      // .Net 8, Collection init
        }

        public static bool IsSymetric(int[] arr)
        {
            bool symetric = true;

            for (int i = 0, j = arr.Length - 1; i < j; i++, j--)
            {
                if (arr[i] != arr[j]) symetric = false;
            }
            return symetric;
        }
    }
}
