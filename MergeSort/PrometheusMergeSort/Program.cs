using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrometheusMergeSort
{
    class Program
    {
                public static void Sort()
        {
            var a = new[]
            {
      11,86,232,28,8,145,588,1,307,179,77,792,693,678,481,888,574,695,624,866,467,434,907,259,130,37,25,373,214,268,108,672,371,866,863,279,22,233,336,830,374,439,144,234,360,617,244,5,566,847,476,493,56,618,202,576,179,972,898,970,119,214,786,38,71,404,420,827,814,201,865,341,358,794,492,27,290,672,899,512,792,20,807,367,792,615,616,753,663,287,99,49,334,366,711,160,652,105,162,955
    };
            int size_t = a.Length;
             void MergeSort(int [] input, int low, int high)
            {
                if (low < high)
                {
                    int middle = size_t % 2;
                    MergeSort(input, low, middle);
                    MergeSort(input, middle, high);
                    Merge(input, low, middle, high);
                }
            }

             
             void Merge(int[] input, int low, int middle, int high)
            {

                int left = low;
                int right = middle + 1;
                int[] tmp = new int[(high - low) + 1];
                int tmpIndex = 0;

                while ((left <= middle) && (right <= high))
                {
                    if (input[left] < input[right])
                    {
                        tmp[tmpIndex] = input[left];
                        left = left + 1;
                    }
                    else
                    {
                        tmp[tmpIndex] = input[right];
                        right = right + 1;
                    }
                    tmpIndex = tmpIndex + 1;
                }

                if (left <= middle)
                {
                    while (left <= middle)
                    {
                        tmp[tmpIndex] = input[left];
                        left = left + 1;
                        tmpIndex = tmpIndex + 1;
                    }
                }

                if (right <= high)
                {
                    while (right <= high)
                    {
                        tmp[tmpIndex] = input[right];
                        right = right + 1;
                        tmpIndex = tmpIndex + 1;
                    }
                }

                for (int i = 0; i < tmp.Length; i++)
                {
                    input[low + i] = tmp[i];
                }

            }

            MergeSort(a, a[0], a[size_t-1]);
                      
            for (int i = 0; i < a.Length; ++i)
            {
                Console.Write($"{a[i]} ");
            }


        }
        static void Main(string[] args)
        {
            Sort();

            Console.ReadKey();
        }
    }
}
