using Amalay.WindowApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp
{
    public class DelegateSamples
    {
        #region "Singleton Intance"

        private static readonly DelegateSamples _Instance = new DelegateSamples();

        private DelegateSamples()
        {

        }

        public static DelegateSamples Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        #region "Covariance"

        #region "Non Generic Delegate"

        // Define the delegate.  
        public delegate First MyCovarianceDelegate(Second input);

        public void UseOfNonGenericDelegate()
        {
            // Assigning a method with a exact matching signature to a non-generic delegate. No conversion is necessary.  
            MyCovarianceDelegate dNonGeneric = ASecondRFirst;

            var result1 = dNonGeneric.Invoke(new Second() { FirstNumber = 1, SecondNumber = 2 });

            // Assigning a method with a more derived return type and less derived argument type to a non-generic delegate. The implicit conversion is used.  
            MyCovarianceDelegate dNonGenericConversion = AFirstRSecond;

            //++++++++++++++++++++++++++++++++++++
            MyCovarianceDelegate dNonGeneric1 = AFirstRFirst;
            MyCovarianceDelegate dNonGeneric2 = ASecondRSecond;
        }

        #endregion

        #region "Generic Delegate - Generic Return Type"

        public delegate T MyCovarianceGenericDelegate<A, T>(A a);

        public void UseOfGenericDelegate_Sample1()
        {
            // Assigning a method with a exact matching signature to a generic delegate. No conversion is necessary.  
            MyCovarianceGenericDelegate<Second, First> dGeneric = ASecondRFirst;

            // Assigning a method with a more derived return type and less derived argument type to a generic delegate. The implicit conversion is used.  
            MyCovarianceGenericDelegate<Second, First> dGenericConversion = AFirstRSecond;

            //++++++++++++++++++++++++++++++++++++
            MyCovarianceDelegate dNonGeneric1 = AFirstRFirst;
            MyCovarianceDelegate dNonGeneric2 = ASecondRSecond;
        }

        #endregion
             
        #region "Variance in Generic Type Parameters"

        // Type T is declared covariant by using the out keyword.  
        public delegate T SampleGenericDelegate<out T>();

        public void UseOfGenericDelegate_Sample2()
        {
            SampleGenericDelegate<String> dString = () => " ";

            // You can assign delegates to each other,  
            // because the type T is declared covariant.  
            SampleGenericDelegate<Object> dObject = dString;
        }

        public delegate T SampleGenericDelegate1<T>();

        public void UseOfGenericDelegate_Sample3()
        {
            SampleGenericDelegate1<String> dString1 = () => " ";

            // You can assign the dObject delegate  
            // to the same lambda expression as dString delegate  
            // because of the variance support for   
            // matching method signatures with delegate types.  
            SampleGenericDelegate1<Object> dObject1 = () => " ";
        }

        #endregion

        #region "Methods"

        // Exact Matching signature and argument type is more derived.  
        private First ASecondRFirst(Second input)
        {
            return new First() { FirstNumber = input.FirstNumber };
        }

        // No exact matching but the argument type is less derived.  
        private First AFirstRFirst(First first)
        {
            return new First();
        }

        // No exact matching but the return type is more derived.  
        private Second ASecondRSecond(Second input)
        {
            return new Second();
        }

        // No exact matching but the return type is more derived and the argument type is less derived.  
        private Second AFirstRSecond(First first)
        {
            return new Second();
        }

        #endregion

        #region "Event handler that accepts a parameter of the EventArgs type."

        //private void MultiHandler(object sender, System.EventArgs e)
        //{
        //    label1.Text = System.DateTime.Now.ToString();
        //}

        //public Form1()
        //{
        //    InitializeComponent();

        //    // You can use a method that has an EventArgs parameter,  
        //    // although the event expects the KeyEventArgs parameter.  
        //    this.button1.KeyDown += this.MultiHandler;

        //    // You can use the same method   
        //    // for an event that expects the MouseEventArgs parameter.  
        //    this.button1.MouseClick += this.MultiHandler;

        //}

        #endregion

        #endregion
    }

    //delegate void StackEventHandler<T, U>(T sender, U eventArgs);

    //class Stack<T>
    //{
    //    public class StackEventArgs : System.EventArgs { }
    //    public event StackEventHandler<Stack<T>, StackEventArgs> stackEvent;

    //    protected virtual void OnStackChanged(StackEventArgs a)
    //    {
    //        stackEvent(this, a);
    //    }
    //}

    //class SampleClass
    //{
    //    public void HandleStackChange<T>(Stack<T> stack, Stack<T>.StackEventArgs args) { }
    //}

    //public static void Test()
    //{
    //    Stack<double> s = new Stack<double>();
    //    SampleClass o = new SampleClass();
    //    s.stackEvent += o.HandleStackChange;
    //}

}
