using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwimmingPool
{
    public partial class Form1 : Form
    {
        private const int ADVPOOLMAX = 10;
        private const int COMPOOLMAX = 15;

        //Pools
        AdventurePool myAdvPool;
        CommonPool myComPool;

        //Doorways
        Reception myReception;
        CustomerExit myCustomerExit;

        //Input queues
        AdventurePoolInputQueue myAdvInputQueue;
        CommonPoolInputQueue myComInputQueue;

        //EntranceQueues
        EntranceWaitingQueue myAdvEntranceQueue;
        EntranceWaitingQueue myComEntranceQueue;

        //Threads
        Thread myReceptionThread;
        Thread myAdvInputQueueThread;
        Thread myComInputQueueThread;
        Thread myCustomerExitThread;

        bool ThreadsStarted = false;

        Random myRandom;

        public Form1()
        {
            InitializeComponent();
            InitalizeObjects();
            InitalizeThreads();
        }

        /// <summary>
        /// Starts or closes the pool
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void poolBtn_Click(object sender, EventArgs e)
        {
            //Makes sure we only start the threads when we need them
            if(!ThreadsStarted)
            {
                myAdvInputQueueThread.Start();
                myComInputQueueThread.Start();
                myCustomerExitThread.Start();
                ThreadsStarted = true;
            }

            if(!myReception.IsOpen)
            {
                myReceptionThread = new Thread(myReception.RunReception);
                myReception.IsOpen = true;
                myReceptionThread.Start();
                statusLbl.Text = "Current status: Open";
                poolBtn.Text = "Close pool";
            }
            else
            {
                myReception.IsOpen = false;
                statusLbl.Text = "Current status: Closed";
                poolBtn.Text = "Open pool";
            }
        }

        /// <summary>
        /// Initalizes and starts all threads except Reception thread
        /// </summary>
        private void InitalizeThreads()
        {
            myAdvInputQueueThread = new Thread(myAdvInputQueue.RunAdventureInput);
            myComInputQueueThread = new Thread(myComInputQueue.RunCommonInput);
            myCustomerExitThread = new Thread(myCustomerExit.RandomExit);
        }

        /// <summary>
        /// Method used to initalize all objects and set max labels
        /// </summary>
        private void InitalizeObjects()
        {
            myRandom = new Random();

            myAdvPool = new AdventurePool(ADVPOOLMAX, advVisitorsLbl);
            myComPool = new CommonPool(COMPOOLMAX, comVisitorsLbl);

            myAdvEntranceQueue = new EntranceWaitingQueue(advWaitingLbl);
            myComEntranceQueue = new EntranceWaitingQueue(comWaitingLbl);

            myAdvInputQueue = new AdventurePoolInputQueue(myAdvPool, myComPool, myAdvEntranceQueue);
            myComInputQueue = new CommonPoolInputQueue(myAdvPool, myComPool, myComEntranceQueue);

            myReception = new Reception(myAdvEntranceQueue, myComEntranceQueue, myRandom);
            myCustomerExit = new CustomerExit(myAdvPool, myComPool, myRandom, advExitLbl, comExitsLbl);

            advLimitLbl.Text = "Limit: " + ADVPOOLMAX;
            comLimitLbl.Text = "Limit: " + COMPOOLMAX;

            advWaitingLbl.Name = "adventure pool: ";
            comWaitingLbl.Name = "common pool: ";
        }

        /// <summary>
        /// Safe closing for the forms GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }


    }
}
