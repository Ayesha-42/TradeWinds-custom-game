using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Program.Model
{
    public class Directory
    {

        public int Cash { get; set; }
        public int Bank { get; set; }
        public decimal BankInterest { get; set; }
        public string Rank { get; set; }
        public int Debt { get; set; }
        public decimal DebtInterest { get; set; }

        public Directory()
        {
            Rank = "Beggar";
            BankInterest = 1.00M;
            DebtInterest = 2.00M;   
        }

        public string AllotRank()
        {
            int wealth = Cash + Bank - Debt;
            if (Cash==0 && Bank==0 && Debt>10000) { return "Bankrupt"; }
            else if (wealth < 10000) { return "Beggar"; }
            else if (wealth < 100000) { return "Merchant"; }
            else if (wealth < 1000000) { return "Trader"; }
            else if (wealth < 10000000) { return "Commander"; }
            else { return "Sea Dragon"; }

        }

    }
}
