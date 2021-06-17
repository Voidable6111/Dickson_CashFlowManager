using System;
using System.Collections.Generic;
using System.Text;

namespace Dickson_CashFlowManager
{
    class Invoice : IPayable
    {
        string invID;
        int number;
        string desc;
        double cost;
        public Invoice(string partNum, int quantity, string partDesc, double price)
        {
            invID = partNum;
            number = quantity;
            desc = partDesc;
            cost = price;
        }
        public decimal GetPayableAmount()
        {
            return (decimal)Math.Round((cost*number), 2);
        }
        public IPayable.LedgerType getType()
        {
            return IPayable.LedgerType.Invoice;
        }
        public void printInfo()
        {
            Console.WriteLine(getType() + ": " + invID + "\nQuantity: " + number + "\nPart Description: " + desc + "\nUnit Price: $" + cost + "\nExtended Price: $" + cost * number + "\n");
        }
    }
}
