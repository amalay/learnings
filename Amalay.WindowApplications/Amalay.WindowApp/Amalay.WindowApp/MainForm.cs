using Amalay.WindowApp.DataStructures;
using Amalay.WindowApp.DesignPatterns.FactoryPattern;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amalay.WindowApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Clear();
        }

        #region "Sorting"

        private void bubbleSortToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void insertionSortToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectionSortToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void heapSortToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quickSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuickSort.Instance.Demo(lblInputText, lblInput, lblOutputText, lblOutput);
        }

        private void mergeSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MergeSort.Instance.Demo(lblInputText, lblInput, lblOutputText, lblOutput);
        }


        #endregion

        #region "Design Patterns"

        private void singletonPatternToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void factoryPatternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FactoryClient.Instance.Demo(lblInputText, lblInput, lblOutputText, lblOutput);
        }

        private void sample1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesignPatterns.AbstractFactoryPattern.Sample1.AbstractFactoryClient.Instance.Demo(lblInputText, lblInput, lblOutputText, lblOutput);
        }

        private void sample2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesignPatterns.AbstractFactoryPattern.Sample2.AbstractFactoryClient.Instance.Demo(lblInputText, lblInput, lblOutputText, lblOutput);
        }

        #endregion

        #region "Delegates"

        private void singlecastDelegateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delegates.SinglecastDelegate.Instance.Demo();
        }

        private void multicastDelegateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delegates.MulticastDelegate.Instance.Demo();
        }

        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            lblInputText.Text = string.Empty;
            lblInput.Text = string.Empty;
            lblOutputText.Text = string.Empty;
            lblOutput.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
