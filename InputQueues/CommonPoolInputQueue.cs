using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SwimmingPool
{
    /// <summary>
    /// CommonPoolInputQueue class used for input in pool
    /// </summary>
    class CommonPoolInputQueue
    {
        /// <summary>
        /// Random waittime between MAX and MIN between each input
        /// </summary>
        private const int MAXWAIT = 1000, MINWAIT = 700;

        private AdventurePool myAdvPool;
        private CommonPool myCommonPool;
        private EntranceWaitingQueue myEntranceWaitingQueue;
        private Random myRandom;

        /// <summary>
        /// Default constructor for the commonpool queue
        /// </summary>
        /// <param name="aAdvPool">AdventurePool object</param>
        /// <param name="aCommonPool">Commonpool object</param>
        /// <param name="aCommonPoolEntranceQueue">Commonpool entrancequeue object</param>
        public CommonPoolInputQueue(AdventurePool aAdvPool, CommonPool aCommonPool, EntranceWaitingQueue aCommonPoolEntranceQueue)
        {
            myRandom = new Random();
            myAdvPool = aAdvPool;
            myCommonPool = aCommonPool;
            myEntranceWaitingQueue = aCommonPoolEntranceQueue;
        }
            
        /// <summary>
        /// Main method for thread in input queue
        /// </summary>
        public void RunCommonInput()
        {
            while (true)
            {
                int randValue = myRandom.Next(0, 4); // 1/4th chance of being VIP
                if(!myCommonPool.IsFull && myEntranceWaitingQueue.GetWaiting())
                {
                    if(randValue == 0)
                    {
                        myCommonPool.Entry(new Customer(true)); //Vip enters commonpool first
                    }
                    else
                    {
                        myCommonPool.Entry(new Customer(false));
                    }
                }

                Thread.Sleep(myRandom.Next(MINWAIT, MAXWAIT));
            }
        }
    }
}
