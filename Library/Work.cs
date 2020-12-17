using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    public static class Work
    {
        //Bubble is too slow for 1m accounts;
        public static Account[] GetSortedAccounts(Account[] accounts)
        {
            Account temp;
            for (int i = 0; i < accounts.Length - 1; i++)
            {
                for (int j = i + 1; j < accounts.Length; j++)
                {
                    if (accounts[i].Id > accounts[j].Id)
                    {
                        temp = accounts[i];
                        accounts[i] = accounts[j];
                        accounts[j] = temp;
                    }
                }
            }
            return accounts;
        }

        public static int GetAccount(int id, ref Account[] accounts, out int counter)
        {
            int left = 0;
            int right = accounts.Length-1;
            int search = -1;
            counter = 0;

            while (left <= right) 
            {
                int mid = (left + right) / 2; 
                if (id == accounts[mid].Id)
                {  
                    search = mid;
                    counter++;
                    break;           
                }
                if (id <= accounts[mid].Id)
                {
                    right = mid - 1;
                    counter++;
                } 
                     
                else
                {
                    left = mid + 1;
                    counter++;
                }                   
            }
            return search;
        }

        static void Swap(ref Account x, ref Account y)
        {
            var t = x;
            x = y;
            y = t;
        }

        static int Partition(Account[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i].Id < array[maxIndex].Id)
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        static Account[] QuickSort(Account[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        public static Account[] QuickSort(Account[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }

    }
}
