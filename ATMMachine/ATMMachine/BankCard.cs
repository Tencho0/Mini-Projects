using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMMachine
{
    internal class BankCard
    {
        public BankCard(int cardNum, string ownerFirstName, string ownerLastName, string PIN)
        {
            this.OwnerFirstName = ownerFirstName;
            this.OwnerLastName = ownerLastName;
            this.CardNum = cardNum;
            this.CurrentBalance = 0;
            this.PIN = PIN;
        }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public int CardNum { get; set; }
        public decimal CurrentBalance { get; set; }
        public string PIN { get; set; }
    }
}
