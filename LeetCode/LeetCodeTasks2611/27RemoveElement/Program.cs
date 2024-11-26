namespace _27RemoveElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public int RemoveElement(int[] nums, int val)
        {
            var notValCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[notValCount] = nums[i];
                    notValCount++;
                }
            }

            return notValCount;
        }
    }
}
