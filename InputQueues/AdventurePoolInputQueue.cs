using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SwimmingPool
{
    /// <summary>
    /// AdventurePool input queue class
    /// </summary>
    class AdventurePoolInputQueue
    {
        /// <summary>
        /// Between MINWAIT and MAXWAIT a time is randomly chosen before a new person is put in the queue
        /// </summary>
        private const int MAXWAIT = 1000, MINWAIT = 700;

        private AdventurePool myAdvPool;
        private CommonPool myCommonPool;
        private EntranceWaitingQueue myEntranceWaitingQueue;
        private Random myRandom;

        /// <summary>
        /// Default input queue constructor
        /// </summary>
        /// <param name="aAdvPool">Adventurepool object</param>
        /// <param name="aCommonPool">Commonpool object</param>
        /// <param name="aAdventureEntranceQueue">Entrance queue for adventurepool</param>
        public AdventurePoolInputQueue(AdventurePool aAdvPool, CommonPool aCommonPool, EntranceWaitingQueue aAdventureEntranceQueue)
        {
            myRandom = new Random();
            myAdvPool = aAdvPool;
            myCommonPool = aCommonPool;
            myEntranceWaitingQueue = aAdventureEntranceQueue;
        }

        /// <summary>
        /// Method for thread, handles the adv queue
        /// </summary>
        public void RunAdventureInput()
        {
            Customer cust;
            while (true)
            {
                int rndValue = myRandom.Next(0, 2);
                if (rndValue == 0) //New VIP customer tries to enter AdvPool
                {
                    if (!myAdvPool.IsFull && myEntranceWaitingQueue.GetWaiting())
                    {
                        myAdvPool.Entry(new Customer(true)); //Enters a VIP customer to adv pool
                    }
                }
                else if (!myCommonPool.IsFull && !myCommonPool.IsEmpty && 
                        (cust = myCommonPool.GetCustomerToAdventure()) != null) //Try to get VIP from Common to adv
                {
                    myAdvPool.Entry(cust);
                }

                Thread.Sleep(myRandom.Next(MINWAIT, MAXWAIT));
            }
        }
    }
}
