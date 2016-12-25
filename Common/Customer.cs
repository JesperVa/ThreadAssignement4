using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingPool
{
    /// <summary>
    /// General container class for a customer
    /// </summary>
    class Customer
    {
        /// <summary>
        /// Property to check if Customer is vip or not
        /// </summary>
        public bool isVip
        {
            get;
            private set;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="aIsVip">Sets VIP value</param>
        public Customer(bool aIsVip)
        {
            isVip = aIsVip;
        }
    }
}
