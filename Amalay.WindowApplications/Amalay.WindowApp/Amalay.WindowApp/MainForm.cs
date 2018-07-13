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
        }

        public Form Child { get; set; }

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
            //QuickSort.Instance.Demo(lblInputText, lblInput, lblOutputText, lblOutput);
        }

        private void mergeSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MergeSort.Instance.Demo(lblInputText, lblInput, lblOutputText, lblOutput);
        }


        #endregion

        #region "Design Patterns"

        private void designPatternsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateAndActivateChildForm(typeof(ChildForm));
        }

        private void singletonPatternToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void factoryPatternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FactoryClient.Instance.Demo(lblInputText, lblInput, lblOutputText, lblOutput);
        }

        private void sample1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DesignPatterns.AbstractFactoryPattern.Sample1.AbstractFactoryClient.Instance.Demo(lblInputText, lblInput, lblOutputText, lblOutput);
        }

        private void sample2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DesignPatterns.AbstractFactoryPattern.Sample2.AbstractFactoryClient.Instance.Demo(lblInputText, lblInput, lblOutputText, lblOutput);
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

        private void nonGenericDelegateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DelegateSamples.Instance.UseOfNonGenericDelegate();
        }

        private void genericDelegateSample1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DelegateSamples.Instance.UseOfGenericDelegate_Sample1();
        }

        private void genericDelegateSample2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DelegateSamples.Instance.UseOfGenericDelegate_Sample2();
        }

        private void genericDelegateSample3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DelegateSamples.Instance.UseOfGenericDelegate_Sample3();
        }

        #endregion
        
        #region "Tasks"

        private void taskChainingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskChaining.Instance.Method1();
            TaskChaining.Instance.Method2();
        }

        private void task1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskDemo.Instance.UseOfTask();
        }

        private void task2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskDemo.Instance.UseOfTaskIOBound();
        }

        #endregion

        #region "Thread Safe"

        private void notThreadSafeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThreadSafeDemo.Instance.UseOfNotThreadSafe();
        }

        private void threadSafeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ThreadSafeDemo.Instance.UseOfThreadSafe();
        }

        private void mutexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThreadSafeDemo.Instance.UseOfMutex();
        }

        private void semaphoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThreadSafeDemo.Instance.UseOfSemaphore();
        }
        #endregion

        #region "Inheritance"

        private void shadowingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shadowing.Instance.UseOfShadowing();
        }
        #endregion

        #region "Multi Threading"
        private void contextSwitchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiThreading.Instance.UseOfContextSwitching();
        }

        private void resourceSharingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiThreading.Instance.UseOfResourceSharing();
        }

        private void localMemorySharingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiThreading.Instance.UseOfLocalMemorySharing();
        }

        private void threadPoolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiThreading.Instance.UseOfThreadPool();
        }

        private void sleepAndJoinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiThreading.Instance.UseOfSleepAndJoin();
        }

        private void exceptionHandllingInMultiThreadingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiThreading.Instance.UseOfExceptionHandlling();
        }

        #endregion

        #region "String Manipulations"

        private void stringComparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringDemo.Instance.UseOfStringComparison();
        }

        private void stringFormattingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringDemo.Instance.UseOfStringFormating();
        }

        private void stringTwinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringDemo.Instance.FindTwins();
        }

        #endregion

        #region "Yield"

        private void yieldSample1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            YieldDemo.Instance.UseOfYield();
        }

        private void yieldSample2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region "Generals"

        private void staticVariableSample1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StaticVariablesDemo.Instance.UseOfStaticVariables();
        }

        private void nullVariableSample1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NullVariablesDemo.Instance.UseOfNullVariables();
        }

        #endregion

        #region "Exceptions"

        private void tryCatchFinallySample1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TryCatchFinallyDemo.Instance.UseOfTryCatchFinallyDemo();
        }

        private void TryCatchImplementationSample1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TryCatchFinallyDemo.Instance.TryCatchImplementation_1();
        }

        #endregion

        #region "Service Bus"

        private void serviceBusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateAndActivateChildForm(typeof(ServiceBusForm));
        }

        private void CreateAndActivateChildForm(Type childType)
        {
            if (this.Child == null || this.Child.GetType() != childType || this.Child.IsDisposed)
            {                
                if(this.Child != null)
                {
                    this.Child.Close();
                }

                this.Child = (Form)Activator.CreateInstance(childType);
                this.Child.MdiParent = this;
                this.Child.Dock = DockStyle.Fill;
                this.Child.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                //this.Child.WindowState = FormWindowState.Maximized;
                //this.Child.ControlBox = false;
                //this.Child.TopLevel = false;

                this.Child.Show();
            }
        }

        #endregion
    }
}
