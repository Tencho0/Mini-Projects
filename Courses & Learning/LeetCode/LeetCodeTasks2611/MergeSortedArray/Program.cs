namespace MergeSortedArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
            var m = 3;
            var nums2 = new int[] { 2, 5, 6 };
            var n = 3;

            Merge(nums1, m, nums2, n);
        }

        private static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            // Pointers for nums1, nums2, and the current position in nums1
            int p1 = m - 1; // Last valid element in nums1
            int p2 = n - 1; // Last element in nums2
            int p = m + n - 1; // Last position in nums1 array

            // Merge the arrays starting from the end
            while (p1 >= 0 && p2 >= 0)
            {
                if (nums1[p1] > nums2[p2])
                {
                    nums1[p] = nums1[p1];
                    p1--;
                }
                else
                {
                    nums1[p] = nums2[p2];
                    p2--;
                }
                p--;
            }

            // If there are remaining elements in nums2, copy them over
            while (p2 >= 0)
            {
                nums1[p] = nums2[p2];
                p2--;
                p--;
            }
        }
    }
}
