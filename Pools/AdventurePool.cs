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
    class AdventurePool
    {

        //Readonly to be set in constructor
        private readonly int MAXGUESTS;

        private Queue<Customer> myAdvQueue;
        private Label myLabel;


        private object myLock;
        
        /// <summary>
        /// Displaydelegate used for updating the label string in GUI
        /// </summary>
        private delegate void DisplayDelegate();

        /// <summary>
        /// Property to check if the adventure pool is empty or not
        /// </summary>
        public bool IsEmpty
        {
            get { return myAdvQueue.Count == 0; }
        }
        /// <summary>
        /// Property to check if the adventure pool is full or not
        /// </summary>
        public bool IsFull
        {
            get { return myAdvQueue.Count >= MAXGUESTS; }
        }

        /// <summary>
        /// Default constructor for the adventure pool
        /// </summary>
        /// <param name="aMax">Max amount of customers inside the adventure pool</param>
        /// <param name="aLabel">Label to update the value on the GUI</param>
        public AdventurePool(int aMax, Label aLabel)
        {
            myAdvQueue = new Queue<Customer>();
            MAXGUESTS = aMax;
            myLabel = aLabel;
            myLock = new object();
        }

        /// <summary>
        /// Puts a customer inside the adventurepool
        /// </summary>
        /// <param name="aCust">Customer to be put inside the pool</param>
        public void Entry(Customer aCust)
        {
            Monitor.Enter(myLock);
            try
            {
                myAdvQueue.Enqueue(aCust);
                UpdateDisplay();
            }
            finally
            {
                Monitor.Exit(myLock);
            }
        }

        /// <summary>
        /// Returns a customer and removes him from the common pool
        /// </summary>
        /// <returns>Returns a customer, if advpool is empty returns null</returns>
        public Customer GetCustomerToCommon()
        {
            Customer cust;
            Monitor.Enter(myLock);
            try
            {
                if (myAdvQueue.Count > 0)
                {
                    cust = myAdvQueue.Dequeue();
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
            return cust;
        }

        /// <summary>
        /// Default method for removing a customer
        /// </summary>
        public void RemoveCustomer()
        {
            Monitor.Enter(myLock);
            try
            {
                myAdvQueue.Dequeue();
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
        /// Displays text on GUI
        /// </summary>
        private void Display()
        {
            myLabel.Text = "Current visitors: " + myAdvQueue.Count;
        }


    }
}
