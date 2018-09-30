using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amalay.WindowApp.DataStructures
{
    public class MergeSort
    {

        #region "Singleton Intance"

        private static readonly MergeSort _Instance = new MergeSort();

        private MergeSort()
        {

        }

        public static MergeSort Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        public void Demo(Label lblInputText, Label lblInput, Label lblOutputText, Label lblOutput)
        {
            int[] arr = { 2, 3, 1, 5, 6, 4 };
            //int[] arr = { 2, 3, 1 };
            int[] temp = new int[arr.Length];
            int start = 0;
            int end = arr.Length - 1;

            lblInputText.Text = "Data before merge sort:";
            lblInput.Text = string.Join(", ", arr);

            Function_MergeSort(ref arr, ref temp, start, end);

            lblOutputText.Text = "Data after merge sort:";
            lblOutput.Text = string.Join(", ", arr);
        }

        private void Function_MergeSort(ref int[] arr, ref int[] temp, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;

                Function_MergeSort(ref arr, ref temp, start, mid);
                Function_MergeSort(ref arr, ref temp, mid + 1, end);
                Function_Merge(ref arr, ref temp, start, end, mid);
            }
        }

        private void Function_Merge(ref int[] arr, ref int[] temp, int leftStart, int rightEnd, int mid)
        {
            int start = leftStart;

            int leftEnd = mid;
            int rightStart = leftEnd + 1;
            int size = rightEnd - leftStart + 1;

            int tempIndex = leftStart;

            while (leftStart <= leftEnd && rightStart <= rightEnd)
            {
                if (arr[leftStart] <= arr[rightStart])
                {
                    temp[tempIndex] = arr[leftStart];
                    leftStart++;
                }
                else
                {
                    temp[tempIndex] = arr[rightStart];
                    rightStart++;
                }

                tempIndex++;
            }

            while (leftStart <= leftEnd)
            {
                temp[tempIndex++] = arr[leftStart++];
            }

            while (rightStart <= rightEnd)
            {
                temp[tempIndex++] = arr[rightStart++];
            }

            //for (int i = start; i < size; i++)
            //{
            //    arr[i] = temp[i];
            //}

            //System.Array.Copy(arr, leftStart, temp, tempIndex, leftEnd - leftStart + 1);
            //System.Array.Copy(arr, rightStart, temp, tempIndex, rightEnd - rightStart + 1);
            System.Array.Copy(temp, start, arr, start, size);
        }
    }
}
