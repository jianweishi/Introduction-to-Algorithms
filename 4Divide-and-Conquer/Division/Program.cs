using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int num in MaxSubArray(new int[] { 1, 23, 43, 2, 12, 2, -1, -43, 23, 31 }, 0, 9))
            {
                Console.WriteLine(num);
            }
            foreach (int num in NormalMaxSubArray(new int[] { 1, 23, 43, 2, 12, 2, -1, -43, 23, 31 }))
            {
                Console.WriteLine(num);
            }
        }
        /// <summary>
        /// 跨越中点的最大子数组
        /// </summary>
        /// <param name="myArray">该数组</param>
        /// <param name="low">数组的最小索引</param>
        /// <param name="mid">中点</param>
        /// <param name="high">数组的最大索引</param>
        /// <returns>返回一个数组，该数组元素依次为所求的最小子数组的开始位置索引、结束位置索引、和</returns>
        public static int[] MaxCrossSubArray(int[] myArray, int low, int mid, int high)
        {

            int leftSum = int.MinValue, sum = 0, maxLeft = mid;
            for (int i = mid; i >= low; i--)
            {
                sum += myArray[i];
                if (sum > leftSum)
                {
                    leftSum = sum;
                    maxLeft = i;
                }
            }
            int rightSum = int.MinValue, maxRight = mid;
            sum = 0;
            for (int j = mid + 1; j <= high; j++)
            {
                sum += myArray[j];
                if (sum > rightSum)
                {
                    rightSum = sum;
                    maxRight = j;
                }
            }
            return new int[] { maxLeft, maxRight, leftSum + rightSum };
        }
        /// <summary>
        /// 求最大子数组（该子数组的和最大）
        /// </summary>
        /// <param name="myArray">该数组</param>
        /// <param name="low">最小索引</param>
        /// <param name="high">最大索引</param>
        /// <returns>返回一个数组，该数组元素依次为所求的最小子数组的开始位置索引、结束位置索引、和</returns>
        public static int[] MaxSubArray(int[] myArray, int low, int high)
        {
            if (low == high)
                return new int[] { low, high, myArray[low] };
            else
            {
                int mid = (low + high) / 2;
                int[] leftSubArray = MaxSubArray(myArray, low, mid);
                int[] midSubArray = MaxCrossSubArray(myArray, low, mid, high);
                int[] rightSubArray = MaxSubArray(myArray, mid + 1, high);
                if (leftSubArray[2] >= rightSubArray[2] && leftSubArray[2] >= midSubArray[2])
                {
                    return leftSubArray;
                }
                else if (rightSubArray[2] >= leftSubArray[2] && rightSubArray[2] >= midSubArray[2])
                {
                    return rightSubArray;
                }
                else
                {
                    return midSubArray;
                }
            }
        }
        public static int[] NormalMaxSubArray(int[] myArray)
        {
            int n = myArray.Length, low = 0, high = 0;
            int[] newArray = new int[n + 1];
            newArray[0] = 0;
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += myArray[i - 1];
                newArray[i] = sum;
            }
            int maxValue = 0;
            for (int i = 0; i <= n; i++)
            {
                for (int j = i + 1; j <= n; j++)
                {
                    if (newArray[j] - newArray[i] >= maxValue)
                    {
                        maxValue = newArray[j] - newArray[i];
                        low = i; high = j;
                    }
                }
            }
            return new int[] { low, high - 1, maxValue };
        }
    }
}
