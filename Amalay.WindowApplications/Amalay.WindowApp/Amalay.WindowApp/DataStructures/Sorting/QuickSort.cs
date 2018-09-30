using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amalay.WindowApp.DataStructures
{
    public class QuickSort
    {
        #region "Singleton Intance"

        private static readonly QuickSort _Instance = new QuickSort();

        private QuickSort()
        {

        }

        public static QuickSort Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        public void Demo(Label lblInputText, Label lblInput, Label lblOutputText, Label lblOutput)
        {
            int[] arr = { 35, 33, 42, 10, 14, 19, 27, 44, 26, 31 };
            int start = 0;
            int end = arr.Length - 1;

            lblInputText.Text = "Data before quick sort:";
            lblInput.Text = string.Join(", ", arr);

            Function_QuickSort(ref arr, start, end);

            lblOutputText.Text = "Data after quick sort:";
            lblOutput.Text = string.Join(", ", arr);
        }

        private void Function_QuickSort(ref int[] arr, int start, int end)
        {
            if (start < end)
            {
                int partitionIndex = this.Function_Partition(ref arr, start, end);

                Function_QuickSort(ref arr, start, partitionIndex - 1);
                Function_QuickSort(ref arr, partitionIndex + 1, end);
            }
        }

        private int Function_Partition(ref int[] arr, int start, int end)
        {
            int pivot = arr[end];
            int partitionIndex = start;

            for (int i = start; i < end; i++)
            {
                if (arr[i] <= pivot)
                {
                    Common.Instance.Swap<int>(ref arr[i], ref arr[partitionIndex]);
                    partitionIndex++;
                }
            }

            Common.Instance.Swap<int>(ref arr[partitionIndex], ref arr[end]);

            return partitionIndex;
        }
    }
}
