using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace LotteryTicket
{
    class LotteryTicket
    {
        public String number { get; private set; }
   
        public LotteryTicket()
        {
            CreateNewNumber();
        }

        public void CreateNewNumber()
        {
            string fmt = "000000";
            Random random = new Random();
            int number = random.Next(1000000);
            this.number = number.ToString(fmt);
        }
    }
}
