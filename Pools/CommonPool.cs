using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwimmingPool
{
    class CommonPool
    {
        /// <summary>
        /// Constant for max amount of gests
        /// </summary>
        private readonly int MAXGUESTS;

        Queue<Customer> myCommonQueue;

        private Label myLabel;

        private object myLock;

        /// <summary>
        /// Display delegate used when updating the display label
        /// </summary>
        private delegate void DisplayDelegate();

        /// <summary>
        /// Propert to check if the commonpool is empty
        /// </summary>
        public bool IsEmpty
        {
            get { return myCommonQueue.Count == 0; }
        }

        public bool IsFull
        {
            get { return myCommonQueue.Count >= MAXGUESTS; }
        }

        /// <summary>
        /// Default constructor for the common poo
        /// </summary>
        /// <param name="aMax">Max visitors</param>
        /// <param name="aLabel">Label for modification of GUI</param>
        public CommonPool(int aMax, Label aLabel)
        {
            myCommonQueue = new Queue<Customer>();
            MAXGUESTS = aMax;
            myLabel = aLabel;
            myLock = new object();
        }

        /// <summary>
        /// Puts a custom into the common pool and updates the display
        /// </summary>
        /// <param name="aCust">Customer to enter the pool</param>
        public void Entry(Customer aCust)
        {
            Monitor.Enter(myLock);
            try
            {
                myCommonQueue.Enqueue(aCust);

                UpdateDisplay();
            }
            finally
            {
                Monitor.Exit(myLock);
            }
        }

        /// <summary>
        /// Returns a VIP customer from the front of the queue
        /// </summary>
        /// <returns>A VIP customer or NULL</returns>
        public Customer GetCustomerToAdventure()
        {
            Customer cust;
            Monitor.Enter(myLock);
            try
            {
                cust = myCommonQueue.Peek();
                if (cust != null && cust.isVip)
                {
                    cust = myCommonQueue.Dequeue();
                }
                else
                {
                    cust = null;
                }

                UpdateDisplay();
            }
            finally
            {
                Monitor.Exit(myLock);
            }
            //Returns at the end to make sure we can update the display correctly
            return cust;

        }

        /// <summary>
        /// Removes a customer from the front of the queue
        /// </summary>
        public void RemoveCustomer()
        {
            Monitor.Enter(myLock);
            try
            {
                myCommonQueue.Dequeue();
                UpdateDisplay();
            }
            finally
            {
                Monitor.Exit(myLock);
            }
        }

        /// <summary>
        /// Updates the display with callback
        /// </summary>
        private void UpdateDisplay()
        {
            if (myLabel.InvokeRequired)
            {
                DisplayDelegate callback = new DisplayDelegate(Display);
                myLabel.Invoke(callback);
            }
            else
            {
                Display();
            }

        }

        /// <summary>
        /// Default display method
        /// </summary>
        private void Display()
        {
            myLabel.Text = "Current visitors: " + myCommonQueue.Count;
        }

    }
}
