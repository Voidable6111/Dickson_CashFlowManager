using System;
using System.Collections.Generic;
using System.Text;

namespace Dickson_CashFlowManager
{
    class Salaried : Employee
    {
        string fname;
        string lname;
        string sosh;
        double money;
        public Salaried(string first, string last, string ssn, double salary) : base(first, last, ssn)
        {
            fname = first;
            lname = last;
            sosh = ssn;
            money = salary;
        }
        public override decimal Earnings()
        {
            return (decimal)money;
        }
        public override IPayable.LedgerType getType()
        {
            return IPayable.LedgerType.Salaried;
        }
        public override void printInfo()
        {
            Console.WriteLine(getType() + " employee: " + fname + " " + lname + "\nSSN: " + sosh + "\nWeekly Salary: $" + money + "\nEarned: $" + money + "\n");
        }
        public override decimal GetPayableAmount()
        {
            return Earnings();
        }
    }
}
