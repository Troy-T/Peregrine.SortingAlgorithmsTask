namespace SortingAlgorithms
{
    public class Sorting
    {
        // Testing code.
        public static void Main(string[] args)
        {
            /* TASK:
             * Write sorting algorithms to sort the array.
             * Give each algorithms complexity in Big O notation
             * 
             * Sorting algorithms to write (With time complexity):
             * a) MergeSort O(n log n)
             * b) QuickSort O(n log n)
             * c) SelectionSort O(n^2)
             * d) ShellSort O(n log n)
             * e) InsertionSort O(n^2)

             */

            int[] array = new int[] { 9, 1, 8, 2, 7, 3, 6, 4, 5 };
            Sorting arr = new Sorting();

            printArray(array);
            arr.BubbleSort(array);
            printArray(array);
            
            unorderArray(array);
            Console.WriteLine("merge sort");
            MergeSort(array, 0, array.Length - 1);
            printArray(array);

            unorderArray(array);
            Console.WriteLine("quick sort");
            arr.QuickSort(array, 0, array.Length - 1);
            printArray(array);

            unorderArray(array);
            Console.WriteLine("selection sort");
            SelectionSort(array);
            printArray(array);

            unorderArray(array);
            Console.WriteLine("shell sort");
            arr.ShellSort(array);
            printArray(array);

            unorderArray(array);
            Console.WriteLine("insertion sort");
            InsertionSort(array);
            printArray(array);

            Console.ReadLine();
        }

        public void BubbleSort(int[] arr)
        {
            Console.WriteLine("bubble sort");
            int size = arr.Length;
            int i, j, temp;
            for (i = 0; i < (size - 1); i++)
            {
                for (j = 0; j < size - i - 1; j++)
                {
                    if ((arr[j] > arr[j + 1]))
                    {
                        /* Swapping */
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        static public void Merge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, left_end, num_elements, tmp_pos;
            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);
            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }
            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];
            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];
            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }

        //Merge Sort
        //Time complexity: O(n log n)
        static public void MergeSort(int[] numbers, int left, int right)
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort(numbers, left, mid);
                MergeSort(numbers, (mid + 1), right);
                Merge(numbers, left, (mid + 1), right);
            }
        }

        int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                    left++;
                while (arr[right] > pivot)
                    right--;
                if (left < right)
                {
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        //Quick Sort
        //Time complexity: O(n log n)
        void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(arr, left, right);
                QuickSort(arr, left, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, right);
            }
        }

        //Selection Sort
        //Time complexity: O(n^2)
        private static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[min] > array[j])
                    {
                        min = j;
                    }

                }
                //C# said a tuple would work here!
                (array[min], array[i]) = (array[i], array[min]);
            }
        }

        // Shell Short
        //Time complexity: O(n log n)
        private void ShellSort(int[] array)
        {
            int n = array.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    int temp = array[i];
                    int j;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                        array[j] = array[j - gap];
                    array[j] = temp;
                }
            }
        }

        //Insertion Sort
        //Time Complexity: O(n^2)
        private static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int temp = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > temp)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = temp;
            }
        }

        public static void printArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        public static int[] unorderArray(int[] array)
        {
            Console.WriteLine("\nMixing up array.\n");
            int count = array.Length;
            while (count > 1)
            {
                int i = Random.Shared.Next(count--);
                (array[i], array[count]) = (array[count], array[i]);
            }
            printArray(array);
            return array;
        }
    }

}
