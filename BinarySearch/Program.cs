using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Quicksort and Binary Search practice
//Ryan Clark
namespace BinarySearch
{    
    class BinarySearch
    {
        public int[] array;
        
        public BinarySearch(int[] x){
            array=x;
        }

        public int partition(int []a ,int left, int right){
            int index = left+(right-left)/ 2;
            int value = a[index];
            int store = left;

            int temp = a[index];    //Moving pivot to the end of the array
            a[index] = a[right];
            a[right] = temp;
       
            for (int i = store; i < right; i++)
            {
                if (a[i] <= value)
                {
                    temp = a[i];
                    a[i] = a[store];
                    a[store] = temp;
                    store = store + 1;
                }
            }
            
            temp = a[store];       //Moving pivot back into sorted array
            a[store] = a[right];
            a[right] = temp;

            return store;
        }

        public void QuickSort(int[] list,int i , int k)
        {
            if (i < k)
            {
                int p = partition(list, i, k);
                QuickSort(list, i, p - 1);
                QuickSort(list, p + 1, k);
            }
        }

        public int BSearch(int key)
        {
            int min , max, middle;
            min = 0;
            max = array.Count()-1;
            
            while (min < max)
            {
                middle=MidPoint(min, max);    
                if (array[middle] == key)
                    return middle;
                else if (key < array[middle])        //Lower subarray
                {
                    max = middle - 1;
                }
                else                                 //Upper subarray
                {
                    min = middle + 1;
                }
            }

            return 0;               
        }

        private int MidPoint(int min, int max)
        {
            return min + ((max - min) / 2);
        }

        public void Display()
        {
            foreach (int x in this.array)
            {   
                Console.Write(x + " ");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Search value: ");
            var key = Convert.ToInt32(Console.ReadLine());

            int [] unsorted ={22,1,3,4,5,67,88,44,32,13,7,10,11,55};
            BinarySearch test = new BinarySearch(unsorted);

            Console.WriteLine("Unsorted Array");
            test.Display();

            Console.WriteLine("Sorted Array");
            test.QuickSort(unsorted, 0, unsorted.Length-1);
            test.Display();

            int keyValue= test.BSearch(key);
            if (test.array[keyValue] == key)
            {
                Console.WriteLine("Index of value: " + keyValue);
            }
            else
            {
                Console.WriteLine("Value not found");
            }     
        }
    }
}
