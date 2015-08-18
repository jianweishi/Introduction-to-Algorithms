using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第二章算法基础
{
    class Program
    {
       
        static void Main(string[] args)
        {

            int[] myArray = new int[50]; 
            Random random = new Random();
            for(int i=0;i<myArray.Length;i++)
            {
                myArray[i] = random.Next(1,100);
            }
            
            foreach(int num in myArray)
            {
                Console.Write(num+" ");
            }
            BubbleSort(myArray);
            Console.WriteLine();
            Console.WriteLine("****************************");
            foreach(int num in myArray)
            {
                Console.Write(num+" ");
            }
            int[] testArray = new int[] { 2, 3, 7, 2, 6 };
            Console.WriteLine();
            Console.WriteLine(InverseMerge(testArray, 0, 2, 4));
           

        }
        /// <summary>
        /// 插入排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myAarray"></param>
        static void InsertSort<T>(T[]myAarray)where T:IComparable<T>
        {
            if(myAarray.Length>=2)
            {
                for(int j=1;j<myAarray.Length;j++)
                {
                    T key = myAarray[j];
                    int i = j - 1;
                    while(i>= 0&&myAarray[i].CompareTo(key)>0)
                    {
                        myAarray[i + 1] = myAarray[i];
                        i--;
                    }
                    myAarray[i + 1] = key;
                }
            }
        }
        /// <summary>
        /// 用递归方式进行插入排序
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="myArray">要排序的数组</param>
        /// <param name="n">排序结束位置的索引</param>
        public static void RecursiveInsertSort<T>(T[] myArray,int n)where T:IComparable<T>
        {
            if (n >= 1)
            {
                T v = myArray[n];
                RecursiveInsertSort(myArray, n-1);
                Insertion(myArray,n,v);
            }
            
        }
        public static void Insertion<T>(T[] myArray,int n, T v) where T : IComparable<T>
        {
            int i = n - 1;
            while(i>=0&&myArray[i].CompareTo(v)>0)
            {
                myArray[i + 1] = myArray[i];
                i--;
            }
            myArray[i + 1] = v;
        }
        /// <summary>
        /// 线性查找
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myArray"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static int LinnerSearch<T>(T[]myArray ,T v)where T:IComparable<T>
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i].Equals(v))
                {
                    return i;
                }  
            }
            return -1;

        }
       /// <summary>
       /// 二分递归查找
       /// 要求数组已经排好序的
       /// 时间复杂度为o(log(n))
       /// </summary>
       /// <typeparam name="T">泛型类型</typeparam>
       /// <param name="myArray">要查找的数组</param>
       /// <param name="v">查找的数</param>
       /// <param name="low">开始查找处的索引</param>
       /// <param name="high">结束查找处的索引</param>
       /// <returns>返回该数在数组的索引，如果没有则返回-1</returns>
        public static  int RecursiveBinarySearch<T>(T[]myArray,T v,int low,int high)where T:IComparable<T>
        {
            if (low <= high)
            {
                int middle = (low + high) / 2;
                if (myArray[middle].Equals(v))
                    return middle;
                else if (myArray[middle].CompareTo(v) >0)
                {
                    high = middle - 1;
                    return RecursiveBinarySearch(myArray, v, low, high);
                }
                else
                {
                    low = middle + 1;
                    return RecursiveBinarySearch(myArray, v, low, high);
                }
            }
            return -1;
        }
        /// <summary>
        /// 不用递归的二分查找
        /// 要求数组已经排好序的
        /// 时间复杂度为o(log(n))
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="myArray">要查找的数组</param>
        /// <param name="v">查找的数</param>
        /// <param name="low">开始查找处的索引</param>
        /// <param name="high">结束查找处的索引</param>
        /// <returns>返回该数在数组的索引，如果没有则返回-1</returns>
        public static int BinarySearch<T>(T[] myArray, T v, int low, int high) where T : IComparable<T>
        {
            
            while (low <= high)
            {
                int middle = (low + high) / 2;
                if (myArray[middle].Equals(v))
                    return middle;
                else if (myArray[middle].CompareTo(v) > 0)
                {
                    high = middle - 1;
                }
                else
                {
                    low = middle + 1;
                }
            }
            return -1;
        }
        /// <summary>
        /// 以按位与的方式求两个二进制数组的和
        /// </summary>
        /// <param name="leftArray">第一个数组</param>
        /// <param name="rightArray">第二个数组</param>
        /// <returns></returns>
        public static int[] BinaryAdd(int[]leftArray,int[]rightArray)
        {
            int length = leftArray.Length;
            int[] BinaryAddArray = new int[length + 1];
            if(leftArray.Length==rightArray.Length)
            {
                for(int i=0;i<=length;i++)
                {
                    BinaryAddArray[i] = 0;
                }
                for(int i=0;i<length;i++)
                {
                    if((BinaryAddArray[i] = BinaryAddArray[i] + leftArray[i] + rightArray[i])>=2)
                    {
                        BinaryAddArray[i] = BinaryAddArray[i] - 2;
                        BinaryAddArray[i + 1]++;
                    }
                }
            }
            return BinaryAddArray;
        }
        /// <summary>
        /// 自底向上的归并排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myArray">要排序的数组</param>
        public static void MergeSort<T>(T[]myArray)where T:IComparable<T>
        {
            List<int> SplitArray = new List<int>();//存贮数组中每次要归并部分开始位置的索引
            int length = myArray.Length;
            for(int i=0;i<=length;i++)
            {
                SplitArray.Add(i);
            }
            while(SplitArray.Count!=2)//当索引数组的长度大于2时就进行归并
            {
                int count = SplitArray.Count;
                for(int i=0;i<count-2;i=i+2)
                {
                    Merge(myArray, SplitArray[i], SplitArray[i + 1]-1, SplitArray[i + 2] - 1);
                }
                int j = 1;
                while(j<SplitArray.Count-1)
                {
                    SplitArray.RemoveAt(j);//删除处于奇数位的数
                    j = j + 1;
                }
            }
            
        }
        /// <summary>
        /// 用递归的方式进行归并排序
        /// </summary>
        /// <typeparam name="T">泛形类型</typeparam>
        /// <param name="myArray">要排序的数组</param>
        /// <param name="p">要排序数组开始的索引</param>
        /// <param name="r">结束的索引</param>
        public static void RecursiveMergeSort<T>(T[]myArray,int p,int r) where T:IComparable<T>
        {
            if(p<r)
            {
                int q = (p + r) / 2;
                RecursiveMergeSort(myArray, p, q);
                RecursiveMergeSort(myArray, q+1, r);
                Merge(myArray, p, q, r);
            }
        }
        /// <summary>
        /// 归并已经排序好的牌无哨兵牌
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myAarray">要归并的数组</param>
        /// <param name="p">要归并左数组在数组中开始部分的索引</param>
        /// <param name="q">做数组结束位置的索引</param>
        /// <param name="r">有数组结束位置的索引</param>
        public static void Merge<T>(T[]myAarray,int p,int q,int r)where T:IComparable<T>
        {
            //int inverse = 0;
            int n1=q-p+1;
            int n2=r-q;
            T[]leftArray=new T[n1];
            T[]rightArray=new T[n2];
            
            for(int i=0;i<n1;i++)
            {
                leftArray[i] = myAarray[i + p];
            }
            for(int i=0;i<n2;i++)
            {
                rightArray[i] = myAarray[i + q + 1];
            }
            /*
            *无哨兵牌与有哨兵牌相结合的归并排序：
            *如何左边数组的最大值大于右边数组的最大值则交换位置，
            *在比较完成后不需要将剩下的进行复制，
            *因为原数组中没有赋值的牌恰好为，要被复制过来的牌。
            */
            /*
            if (leftArray.Max().CompareTo(rightArray.Max())>0)
            {
               T[] tempArray=rightArray.Concat(leftArray).ToArray();
                for (int i=p;i<=r;i++)
                {
                    myAarray[i] = tempArray[i];
                }
            }
            */
            int m = 0, n = 0,j=p;
            while(m<n1&&n<n2)
            {
                if(leftArray[m].CompareTo(rightArray[n])<=0)
                {
                    myAarray[j] = leftArray[m];
                    m++;j++;
                }
                else
                {
                    myAarray[j] = rightArray[n];
                    n++;j++;
                }
            }
           
            for(int i=j;i<=r;i++)
            {
                if(m==n1)//如果左数组的牌已添加到最终的数组中，
                {
                    myAarray[i] = rightArray[i - j+n];//那么只需要将右数组从n开始的牌复制过去即可
                }
                else
                {
                    myAarray[i] = leftArray[i-j+m];
                }
            }
            
        }
        /// <summary>
        /// <name>归并排序</name>
        /// <shuoming1>有哨兵牌哨兵牌设为数组的最大值</shuoming1>
        /// </c>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myArray"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        public static void Merge2<T>(T[]myArray,int p,int q,int r)where T:IComparable<T>
        {
            T[] leftArray = new T[q - p+2];
            for(int i=0;i<leftArray.Length-1;i++)
            {
                leftArray[i] = myArray[i + p];
            }
            leftArray[q - p + 1] =myArray.Max();
            T[] rightArray = new T[r - q+1];
            for(int i=0;i<rightArray.Length-1;i++)
            {
                rightArray[i] = myArray[q + i+1];
            }
            rightArray[r - q] = myArray.Max();
            int m = 0, n = 0;
            for(int i=p;i<=r;i++)
            {
                if(leftArray[m].CompareTo(rightArray[n])<0)
                {
                    myArray[i] = leftArray[m];
                    m++;
                }
                else
                {
                    myArray[i] = rightArray[n];
                    n++;
                }
            }
        }
        
        /// <summary>
        /// 选择排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myArray"></param>
        public static void SelectSort<T>(T[]myArray) where T:IComparable<T>
        {
            for(int i=0;i<myArray.Length-1;i++)
            {
                for(int j=i+1;j<myArray.Length;j++)
                {
                    T temp = myArray[j];
                    if(myArray[i].CompareTo(temp)>0)
                    {
                        myArray[j] = myArray[i];
                        myArray[i] = temp;
                    }
                }
            }
        }
        /// <summary>
        /// Horner多项式
        /// </summary>
        /// <param name="polyArray">多项式的系数向量，从低位到高位</param>
        /// <param name="x">多项式待赋值的x</param>
        /// <returns>多项式的值</returns>
        public static double  Horner(double[] polyArray,double x)
        {
            int n = polyArray.Length - 1;
            double polyval=polyArray[n];
            for(int i=n-1;i>=0;i--)
            {
                polyval = polyArray[i] + x * polyval;
            }
            return polyval;
        }
        public static void BubbleSort<T>(T[] myArray)where T:IComparable<T>
        {
            int l = myArray.Length;
            for(int i=0;i< l;i++)
            {
                for(int j=0;j<l- i-1;j++)
                {
                    T left = myArray[j];
                    T right = myArray[j + 1];
                    if(left.CompareTo(right)>0)
                    {
                        myArray[j] = right;
                        myArray[j + 1] = left;
                    }
                }
            }
        }
        public static int InverseMerge(int[]A,int p, int q,int r)
        {
            int inverse = 0;
            int n1 = q - p + 1, n2 = r - q;
            int[] leftArray = new int[n1 + 1], righArray = new int[n2 + 1];
            for(int i=0;i< n1;i++)
            {
                leftArray[i] = A[p + i];
            }
            for(int j=0;j<n2;j++)
            {
                righArray[j] = A[q + j + 1];
            }
            leftArray[n1] = int.MaxValue;righArray[n2] = int.MaxValue;
            int i1 = 0,j1 = 0;
            for (int k = p; k <= r; k++)
            {
                if(leftArray[i1]<=righArray[j1])
                {
                    A[k] = leftArray[i1];
                    i1++;
                }
                else
                {
                    A[k] = righArray[j1];
                    j1++;
                    inverse+=n1-i1;
                }
            }
            return inverse;
        }
    }
}
/*关于递归函数在编译器中的调用方式的说明
编译器在调用递归函数时会记录一个调用栈，即用栈记录离场情境和返回地址
在遇到情况退出时，会返回该函数的调用栈
*/
