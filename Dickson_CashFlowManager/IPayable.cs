using System;
using System.Collections.Generic;
using System.Text;

namespace Dickson_CashFlowManager
{
    interface IPayable
    {
        decimal GetPayableAmount();
        void printInfo();
        LedgerType getType();
        public enum LedgerType
        {
            Salaried,
            Hourly,
            Invoice
        }
    }
}
