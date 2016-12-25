using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SwimmingPool
{
    /// <summary>
    /// Class for the reception that adds new customers to the queue
    /// </summary>
    class Reception
    {
        /// <summary>
        /// Sleeptime between each new customer
        /// </summary>
        private const int SLEEPTIME = 1500;

        private EntranceWaitingQueue myAdventureQueue;
        private EntranceWaitingQueue myCommonQueue;
        private Random myRandom;

        /// <summary>
        /// Property to set or read the Open status, default set is false
        /// </summary>
        public bool IsOpen
        {
            get;
            set;
        }

        /// <summary>
        /// Default constructor for the reception
        /// </summary>
        /// <param name="aAdventureQueue">Adventurequeue object</param>
        /// <param name="aCommonQueue">Commonqueue object</param>
        /// <param name="aRnd">Random object initalized before class</param>
        public Reception(EntranceWaitingQueue aAdventureQueue, EntranceWaitingQueue aCommonQueue, Random aRnd)
        {
            myAdventureQueue = aAdventureQueue;
            myCommonQueue = aCommonQueue;
            myRandom = aRnd;
            IsOpen = false;
        }

        /// <summary>
        /// Main method for the reception thread, runs while reception is open
        /// </summary>
        public void RunReception()
        {
            while(IsOpen)
            {
                int ranValue = myRandom.Next(0, 4);
                if(ranValue == 0) //Person is added to the adv queue
                {
                    myAdventureQueue.AddToQueue();
                }
                else //Person is added to the common queue
                {
                    myCommonQueue.AddToQueue();
                }
                Thread.Sleep(SLEEPTIME);
            }
        }
    }
}
