using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwimmingPool
{
    /// <summary>
    /// General class for a waiting queue
    /// </summary>
    class EntranceWaitingQueue
    {
        private Label myLabelNr;
        private object myLock;
        private int myNoOfWaiting;

        private delegate void DisplayDelegate();

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="aLbl">Label for GUI update</param>
        public EntranceWaitingQueue(Label aLbl)
        {
            myLock = new object();
            myLabelNr = aLbl;
        }

        /// <summary>
        /// Returns if there are any waiting and decremnts if true
        /// </summary>
        /// <returns>If there are any people waiting or not</returns>
        public bool GetWaiting()
        {
            bool value;
            Monitor.Enter(myLock);
            try
            {
                if (myNoOfWaiting > 0)
                {

                    myNoOfWaiting--;
                    UpdateDisplay();

                    value = true;
                }
                else
                {
                    value = false;
                }
            }
            finally
            {
                Monitor.Exit(myLock);
            }

            return value;
        }

        /// <summary>
        /// Adds people to the waiting queue
        /// </summary>
        public void AddToQueue()
        {
            Monitor.Enter(myLock);
            try
            {
                myNoOfWaiting++;
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
            if (myLabelNr.InvokeRequired)
            {
                DisplayDelegate callback = new DisplayDelegate(Write);
                myLabelNr.Invoke(callback);
            }
            else
            {
                Write();
            }

        }
        /// <summary>
        /// Writes to the label
        /// </summary>
        private void Write()
        {
            myLabelNr.Text = "Waiting " + myLabelNr.Name + myNoOfWaiting; 
        }
    }
}
