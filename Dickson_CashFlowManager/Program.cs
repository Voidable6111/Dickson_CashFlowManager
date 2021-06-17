using System;
using System.Collections.Generic;

// Cole Dickson
// IT112 
// NOTES: Well, hopefully this is what you wanted. Not sure what else to say here, other than thanks for teaching.
// BEHAVIORS NOT IMPLEMENTED AND WHY: I don't believe I am missing anything.
namespace Dickson_CashFlowManager
{
    class Program
    {
        private static string getInventoryNum()
        {
            Random rng = new Random();
            int part1 = rng.Next(100000, 1000000);
            int part2 = rng.Next(1000, 10000);
            string invNum = part1.ToString() + "_" + part2.ToString();
            return invNum;
        }
        static void Main(string[] args)
        {
            bool make = true;
            Console.WriteLine("Welcome to the Cash Flow Manager.");
            Hourly joel = new Hourly("Joel", "Aiden", "136-01-7701", 15.50, 45);
            Hourly sol = new Hourly("Sol", "Badguy", "184-60-2030", 25.75, 32);
            Hourly alm = new Hourly("Albein", "Rudolf", "216-15-2017", 20.00, 40);
            Salaried mario = new Salaried("Mario", "Mario", "100-07-1981", 732.01);
            Salaried ky = new Salaried("Ky", "Kiske", "531-25-1225", 850.00);
            Salaried brenda = new Salaried("Brenda", "Whitefang", "555-55-556", 800.50);
            Invoice car = new Invoice(getInventoryNum(), 2, "Vroom Vroom", 2000.00);
            Invoice vboy = new Invoice(getInventoryNum(), 6, "Virtual Boy", 329.99);
            Invoice fseal = new Invoice(getInventoryNum(), 1, "Fireseal", 207.06);
            List<IPayable> list = new List<IPayable>();
            list.Add(joel);
            list.Add(brenda);
            list.Add(car);
            list.Add(sol);
            list.Add(alm);
            list.Add(mario);
            list.Add(vboy);
            list.Add(ky);
            list.Add(fseal);
            while (make)
            {
                int choice;
                Console.WriteLine("Choose an option:\n1. Add Hourly Employee\n2. Add Salaried Employee\n3. Add Invoice\n4. Print Final Report");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter first name:");
                        string first = Console.ReadLine();
                        Console.WriteLine("Enter last name:");
                        string last = Console.ReadLine();
                        Console.WriteLine("Enter SSN:");
                        string ssn = Console.ReadLine();
                        Console.WriteLine("Enter Hourly Wage Salary:");
                        double wage = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter number of hours worked:");
                        double hours = Convert.ToDouble(Console.ReadLine());
                        Hourly hr = new Hourly(first, last, ssn, wage, hours);
                        list.Add(hr);
                        Console.WriteLine("Hourly employee added!");
                        break;
                    case 2:
                        Console.WriteLine("Enter first name:");
                        string f = Console.ReadLine();
                        Console.WriteLine("Enter last name:");
                        string l = Console.ReadLine();
                        Console.WriteLine("Enter SSN:");
                        string sosh = Console.ReadLine();
                        Console.WriteLine("Enter Weekly Salary:");
                        double salary = Convert.ToDouble(Console.ReadLine());
                        Salaried sld = new Salaried(f, l, sosh, salary);
                        list.Add(sld);
                        Console.WriteLine("Salaried employee added!");
                        break;
                    case 3:
                        Console.WriteLine("Enter product description:");
                        string description = Console.ReadLine();
                        Console.WriteLine("Enter cost:");
                        double costmoney = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter quantity of product:");
                        int howMuch = Convert.ToInt32(Console.ReadLine());
                        Invoice inv = new Invoice(getInventoryNum(), howMuch, description, costmoney);
                        list.Add(inv);
                        Console.WriteLine("Invoice added!");
                        break;
                    case 4:
                        decimal sum = 0;
                        decimal hsum = 0;
                        decimal ssum = 0;
                        decimal isum = 0;
                        Console.WriteLine("Weekly Cash Flow Analysis is as follows:");
                        for (int i = 0; i < list.Count; i++)
                        {
                            list[i].printInfo();
                            sum += list[i].GetPayableAmount();
                            switch (list[i].getType().ToString())
                            {
                                case "Hourly":
                                    hsum += list[i].GetPayableAmount();
                                    break;
                                case "Salaried":
                                    ssum += list[i].GetPayableAmount();
                                    break;
                                case "Invoice":
                                    isum += list[i].GetPayableAmount();
                                    break;
                                default:
                                    break;
                            }
                        }
                        Console.WriteLine("Total Weekly Payout: $" + sum + "\nCategory Breakdown:\n  Invoices: $" + isum + "\n  Salaried Payroll: $" + ssum + "\n  Hourly Payroll: $" + hsum);
                        make = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Try again.");
                        break;
                }
                
            }
        }
    }
}
