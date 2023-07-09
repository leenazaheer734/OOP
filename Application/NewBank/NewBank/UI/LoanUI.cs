using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewBank.BL;
using NewBank.DL;


namespace NewBank.UI
{
    class LoanUI
    {
        public static void reqSubmitted()
        {
            Console.WriteLine(" Your loan Request has been submitted!");
        }
        public static void invalidReq()
        {
            Console.WriteLine("  You cannot request loan as you have a salary account!!");
        }
        public static string approveORrejectRequests()
        {
            Console.WriteLine("   1. Approve Loan");
            Console.WriteLine("   2. Reject Request");
            string option = Console.ReadLine();
            return option;
        }
        public static bool checkClientMatch(Client u, Loan l)
        {
            if (l.Loanclient.GetPerson().getName() == u.GetPerson().getName() && l.Loanclient.getAccount().GetACCnumber() == u.getAccount().GetACCnumber())
                return true;
            else
                return false;
        }
        public static Property takeInputForProperty()
        {
            Console.Write("   How much is the value of your property?  ");
            double value = double.Parse(Console.ReadLine());
            Console.Write("   What is the addresss of property?  ");
            string address = Console.ReadLine();
            Property p = new Property(address, value);
            return p;
        }
        public static Gold takeInputForGold()
        {
            Console.Write("   How much is the value of gold?   ");
            double value = double.Parse(Console.ReadLine());
            Console.Write("   How much is the weight of gold?   ");
            double weight = double.Parse(Console.ReadLine());
            Console.Write("   What is the purity of gold(in karats)?   ");
            string purety = Console.ReadLine();
            Gold g = new Gold(purety, weight, value);
            return g;
        }
        public static void displayLoanDetails(Client u)
        {
            foreach (Loan l in LoanDL.getLoanList())
            {
                if (checkClientMatch(u, l))
                {
                    // displaying loan details
                    Console.WriteLine("   Your loan details are given below: ");
                    if (l.PledgeItem is Gold && l.LoanStatus == 1)
                    {
                        Console.WriteLine("   Request Date" + "\t\t" + "Requested Amount" + "\t   " + "Loan Status" + "\t" + "Pledge Item" + "\t" + "Purpose");
                        Console.WriteLine("   " + l.ReqDate + "\t\t" + l.ReqAmount + "\t      " + "Requested" + "\t" + "Gold" + " \t" + l.Purpose);
                    }

                    else if (l.PledgeItem is Property && l.LoanStatus == 1)
                    {
                        Console.WriteLine("   Request Date" + "\t  " + "Requested Amount" + "\t" + "Loan Status" + "\t" + "Pledge Item" + "\t" + "Purpose");
                        Console.WriteLine("   " + l.ReqDate + "\t  " + l.ReqAmount + "\t" + "Requested" + "\t" + "Property" + " \t" + l.Purpose);
                    }
                    else if (l.LoanStatus == 2)
                    {
                        Console.WriteLine("   " + "Loan Status" + "\t" + "Approval Date     " + "\t  " + "Approved Amount" + "\t" + "Interest" + "\t" + "Returning Date");
                        Console.WriteLine("   " + "Approved" + "\t" + l.ApprovalDate + "\t  " + l.GivenAmount + "\t" + l.Interset + "\t  " + l.ReturningDate);
                    }
                }
            }
        }
        public static void viewApprovedLoans()
        {
            foreach (Loan l in LoanDL.getLoanList())
            {
                if (l.LoanStatus == 2)
                {
                    Console.WriteLine("   " + "Account Number " + "\t" + "Client Name" + "\t" + "Approval Date" + "\t  " + "Approved Amount" + "\t" + "Interest Percent" + "\t" + "Returning Date");
                    Console.WriteLine("   " + l.Loanclient.getAccount().GetACCnumber() + "\t" + l.Loanclient.GetPerson().getName() + "\t" + l.ApprovalDate + "\t  " + l.GivenAmount + "\t" + l.Interset + "\t" + l.ReturningDate);
                }
            }

        }
        public static void showLoanRequests()
        {
            Console.WriteLine("    Following are the requests for laon:");
            Console.WriteLine();
            Console.WriteLine("   AccNumber\tName\tRequestAmount\tRequestDate\tPledgeValue\tPurpose");
            foreach (Loan l in LoanDL.getLoanList())
            {
                Console.WriteLine("  " + l.Loanclient.getAccount().GetACCnumber() + "\t" + l.Loanclient.GetPerson().getName() + "\t" + l.ReqAmount + "\t" + l.ReqDate + "\t  " + l.PledgeItem.getValue() + l.Purpose);
            }
        }
        public static Loan requestLoan(Client c1)
        {
            Loan l = LoanUI.findClientLoan(c1);
            if (l == null)
            {
                if (c1.getAccount().getType() == "current")
                {
                    Console.Write("   How much loan you want to request?   ");
                    double amount = double.Parse(Console.ReadLine());
                    Console.Write("   What is the purpose of Loan?   ");
                    string purpose = Console.ReadLine();
                    Console.WriteLine("   What surety are you giving for Loan pledge?");
                    Console.WriteLine("   1.Gold");
                    Console.WriteLine("   2.Property");
                    Console.Write("    ");
                    int surety = int.Parse(Console.ReadLine());

                    if (surety == 1)
                    {
                        Gold g = takeInputForGold();
                        Loan l1 = new Loan(c1, DateTime.Now, amount, purpose, g);
                        return l1;
                    }
                    else if (surety == 2)
                    {
                        Property p = takeInputForProperty();
                        Loan l2 = new Loan(c1, DateTime.Now, amount, purpose, p);
                        return l2;
                    }
                }
                else
                {
                    invalidReq();
                }
            }
            else
            {
                Console.WriteLine("   You cannot request Loan!");
            }

            return null;
        }
        public static Loan findClientLoan(Client u)
        {
            foreach (Loan l in LoanDL.getLoanList())
            {
                if (checkClientMatch(u, l))
                {
                    return l;
                }
            }
            return null;
        }

        public static void giveLoanToClient(Client c1)
        {
            displayLoanDetails(c1);
            Loan l = findClientLoan(c1);
            if (l != null && l.LoanStatus == 1)
            {
                l.LoanStatus = 2;
                l.ApprovalDate = DateTime.Now;
                l.ReturningDate = l.ApprovalDate.AddDays(365);
                l.GivenAmount = l.ReqAmount + (l.ReqAmount * 0.1);
                l.Interset = 10;
                Console.WriteLine("    You have Given Loan to " + c1.GetPerson().getName());

            }
            else
            {
                Console.WriteLine("   You cannot give Loan to this person");
            }
        }

        public static void returnLoan(Client c)
        {
            Loan l = findClientLoan(c);
            if (l != null)
            {
                if (l.LoanStatus == 1)
                {
                    Console.WriteLine("   Your Loan is not approved Yet!");
                }
                else if (l.GivenAmount > 0 && l.LoanStatus == 2)
                {
                    Console.Write("   How much amount are u returning?  ");
                    double ret = double.Parse(Console.ReadLine());
                    if (c.getAccount().getBalance() >= ret)
                    {
                        if (ret <= l.GivenAmount)
                        {
                            l.GivenAmount = l.GivenAmount - ret;

                            double finalBalance = c.getAccount().getBalance() - ret;
                            c.getAccount().setBalance(finalBalance);
                            ClientDL.UpdateClientDataInFile();
                        }
                        else if (ret > l.GivenAmount)
                        {
                            double finalBalance = c.getAccount().getBalance() - l.GivenAmount;
                            c.getAccount().setBalance(finalBalance);
                            ClientDL.UpdateClientDataInFile();
                            LoanDL.deleteLoanReq(c);
                        }

                    }
                    else
                    {
                        Console.WriteLine("   You dont have sufficient balance!");
                    }
                }
                else if (l.GivenAmount == 0)
                {
                    LoanDL.deleteLoanReq(c);
                }
            }
            else
            {
                Console.WriteLine("  This Client has not requested loan");
            }
        }
    }
}
