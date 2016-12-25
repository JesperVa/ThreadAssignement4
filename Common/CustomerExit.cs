using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SwimmingPool
{
    /// <summary>
    /// Class used for Customer exits
    /// </summary>
    class CustomerExit
    {
        /// <summary>
        /// Delay between each removal
        /// </summary>
        private const int WAITTIME = 7500;

        private AdventurePool myAdventurePool;
        private CommonPool myCommonPool;
        private int myNrOfExitsAdv;
        private int myNrOfExitsCom;
        private Label myAdvLbl;
        private Label myComLbl;
        private Random myRandom;

        delegate void DisplayDelegate(Label aLbl, int i);

        /// <summary>
        /// Default constructor for CustomerExit
        /// </summary>
        /// <param name="aAdventurePool">Adventurepool object</param>
        /// <param name="aCommonPool">Commonpool object</param>
        /// <param name="aRnd">Random object initalized outside of class</param>
        public CustomerExit(AdventurePool aAdventurePool, CommonPool aCommonPool, Random aRnd, Label aAdvLbl, Label aComLbl)
        {
            myAdventurePool = aAdventurePool;
            myCommonPool = aCommonPool;
            myRandom = aRnd;
            myAdvLbl = aAdvLbl;
            myComLbl = aComLbl;
        }

        /// <summary>
        /// Method for thread to run in
        /// </summary>
        public void RandomExit()
        {
            while(true)
            {
                //Starts with sleeptime to make sure we don't remove something directly when the thread starts
                Thread.Sleep(WAITTIME);
                int randValue = myRandom.Next(0, 4);
                if(randValue == 0 && !myAdventurePool.IsEmpty) //Removes from AdvPool
                {
                    myAdventurePool.RemoveCustomer();
                    myNrOfExitsAdv++;
                    UpdateDisplay(myAdvLbl, myNrOfExitsAdv);
                }
                else if(!myCommonPool.IsEmpty)
                {
                    myCommonPool.RemoveCustomer();
                    myNrOfExitsCom++;
                    UpdateDisplay(myComLbl, myNrOfExitsCom);
                }
            }
        }

        /// <summary>
        /// Updates the display with callback
        /// </summary>
        private void UpdateDisplay(Label aLbl, int i)
        {
            if (aLbl.InvokeRequired)
            {
                DisplayDelegate callback = new DisplayDelegate(Display);
                aLbl.Invoke(callback, new object[] { aLbl, i });
            }
            else
            {
                Display(aLbl,i);
            }

        }

        /// <summary>
        /// Displays the info on the label
        /// </summary>
        /// <param name="aLbl">Label to be updated</param>
        /// <param name="i">Value to be added on the label</param>
        private void Display(Label aLbl, int i)
        {
            aLbl.Text = "Exits: " + i;
        }
    }
}
