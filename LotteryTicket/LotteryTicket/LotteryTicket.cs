using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace LotteryTicket
{
    class LotteryTicket
    {
        private String number;

        public String Number
        {
            get { return number; }
            set { number = value; }
        }

        public LotteryTicket()
        {
            string fmt = "000000";
            Random random = new Random();
            int number = random.Next(1000000);
            this.number = number.ToString(fmt);
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
