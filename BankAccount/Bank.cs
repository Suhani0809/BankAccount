using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BankAccount
{
    public class Account
    {
        string AccountHolderName;
        int AccountNumber;
        enum AccountType {
            savings,
            current
        };
        int type;
        DateTime AccountCreationDate;
        Double AccountBalance;
        static int id = 1001;

        public string AccountHolderName1 { get => AccountHolderName; set => AccountHolderName = value; }
        public int AccountNumber1 { get => AccountNumber; set => AccountNumber = value; }
        public DateTime AccountCreationDate1 { get => AccountCreationDate; set => AccountCreationDate = value; }
        public double AccountBalance1 { get => AccountBalance; set => AccountBalance = value; }
        public int Type { get => type; set => type = value; }

        public Account(string name,int type,DateTime date,double balance) {
            this.AccountHolderName = name;
            this.AccountNumber = id++;
            this.AccountCreationDate = date;
            this.AccountBalance = balance;
            this.type = type;
        }
    }
    public class Transaction {
        int TransactionID;
        string TransactionType;
        int AccountNumber;
        DateTime TransactionDate;
        Double TransactionAmount;
        static int id = 101;

        public int TransactionID1 { get => TransactionID; set => TransactionID = value; }
        public string TransactionType1 { get => TransactionType; set => TransactionType = value; }
        public int AccountNumber1 { get => AccountNumber; set => AccountNumber = value; }
        public DateTime TransactionDate1 { get => TransactionDate; set => TransactionDate = value; }
        public double TransactionAmount1 { get => TransactionAmount; set => TransactionAmount = value; }

        public Transaction(string type,int number,double amount, int a_num) {
            this.TransactionID = id++;
            this.TransactionAmount = amount;
            this.TransactionDate1 = DateTime.Today;
            this.TransactionType = type;
            this.AccountNumber = a_num;
        }
    }
    public class PerformActions{

        
        public static List<Account> Accounts = new List<Account>();
        public static List<Transaction> Transactions = new List<Transaction>();
         public void CreateAccount() {
           // SqlConnection connection = new SqlConnection("Server=(local);Database=Bank;Integrated Security= true");
            Console.WriteLine("Enter the details of the Account in the order:");
            Console.WriteLine("Name, Type of Account, Balance");
            string name = Console.ReadLine();
            int type = Convert.ToInt32(Console.ReadLine());
            DateTime date = DateTime.Today;
            Double balance = Convert.ToDouble(Console.ReadLine());
            Account account = new Account(name, type, date, balance);
            Accounts.Add(account);
            Console.WriteLine("Account added successfully");
            Console.WriteLine("Your Account number is : " + account.AccountNumber1);
        }
        public void RemoveAccount() {
            Console.WriteLine("Enter the Account Number to be removed.");
            int number = Convert.ToInt32(Console.ReadLine());
            foreach (Account a in Accounts) {
                if (a.AccountNumber1 == number) {
                    Accounts.Remove(a);
                    break;
                }
            }
            Console.WriteLine("Account removed successfully");
        }
        public void WithdrawAmount() {
            Console.WriteLine("Enter the account number");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter amount to be withdrawn");
            Double amount= Convert.ToDouble(Console.ReadLine());
            foreach (Account a in Accounts) {
                if (a.AccountNumber1 == number)
                {
                    if (a.AccountBalance1 >= amount)
                    {
                        a.AccountBalance1 -= amount;
                        Transactions.Add(new Transaction("Debit", number, amount,a.AccountNumber1));
                        Console.WriteLine("Withdrawn Successfull");
                        break;
                    }
                    else
                    {
                        throw new zeroException("Not enough balance, please enter valid amount");
                    }
                }
            }
            
        }

        public void DepositAmount() {
            Console.WriteLine("Enter the account number");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter amount to be deposited");
            Double amount = Convert.ToDouble(Console.ReadLine());
            foreach (Account a in Accounts) {
                if (a.AccountNumber1 == number) {
                    a.AccountBalance1 += amount;
                    Transactions.Add(new Transaction("Credit", number, amount,a.AccountNumber1));
                    Console.WriteLine("Amount deposited successfully");
                }
            }
            
        }
        public void PrintDetails() {
            Console.WriteLine("Enter the account number");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Account details are:");
            foreach(Account a in Accounts)
            {
                if (a.AccountNumber1 == i) {
                    Console.WriteLine("Account holder name: " + a.AccountHolderName1);
                    Console.WriteLine("Account number: " + a.AccountNumber1);
                    Console.WriteLine("Account balance: " + a.AccountBalance1);
                }
            }
            Console.WriteLine("Transaction details are: ");
            foreach (Transaction t in Transactions) {
                if (t.AccountNumber1 == i) {
                    Console.WriteLine("Transaction number: " + t.TransactionID1);
                    Console.WriteLine("Transaction type: " + t.TransactionType1);
                    Console.WriteLine("Transaction amount: " + t.TransactionAmount1);
                    Console.WriteLine("Transaction date: " + t.TransactionDate1);
                }
                
            }
        }

        public void Queries() {
            var res1 = from i in Accounts where i.AccountBalance1 > 50000 select i;
            Console.WriteLine("Account balance more than 50000");
            foreach (var j in res1) {
                Console.WriteLine("Account number " + j.AccountNumber1);
            }
            var res2 = (from i in Accounts select i.AccountBalance1).Max();
            Console.WriteLine("Maximum balance is " + res2);
        }
    }
    public class zeroException : ApplicationException {
        public zeroException(string msg) : base(msg) { }
    }
}
