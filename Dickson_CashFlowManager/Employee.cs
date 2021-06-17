using System;
using System.Collections.Generic;
using System.Text;

namespace Dickson_CashFlowManager
{
    abstract class Employee : IPayable
    {
        public Employee(string first, string last, string ssn)
        {

        }
        public abstract decimal Earnings();
        public abstract decimal GetPayableAmount();
        public abstract IPayable.LedgerType getType();
        public abstract void printInfo();
    }
}
