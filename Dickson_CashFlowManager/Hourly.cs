using System;
using System.Collections.Generic;
using System.Text;

namespace Dickson_CashFlowManager
{
    class Hourly : Employee
    {
        string fname;
        string lname;
        string sosh;
        double wage;
        double time;
        public Hourly(string first, string last, string ssn, double hourlyWage, double hoursWorked) : base(first, last, ssn)
        {
            fname = first;
            lname = last;
            sosh = ssn;
            wage = hourlyWage;
            time = hoursWorked;
        }
        public override decimal Earnings()
        {
            decimal total = 0;
            if (time > 40)
            {
                total += 40 * (decimal)wage;
                total += (decimal)(time-40) * (decimal)(wage * 1.5);
            }
            else
            {
                total += (decimal)time * (decimal)wage;
            }
            return Math.Round(total, 2);
        }
        public override IPayable.LedgerType getType()
        {
            return IPayable.LedgerType.Hourly;
        }
        public override void printInfo()
        {
            Console.WriteLine(getType() + " employee: " + fname + " " + lname + "\nSSN: " + sosh + "\nHourly Wage Salary: $" + wage + "\nHours Worked: " + time + "\nEarned: $" + Earnings() + "\n");
        }
        public override decimal GetPayableAmount()
        {
            return Earnings();
        }
    }
}
