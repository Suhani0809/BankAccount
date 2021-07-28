using System;
using System.Linq;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            PerformActions p = new PerformActions();
            Console.WriteLine("Choose the actions to be performed");
            Console.WriteLine(" 1. Create Account \n 2. Remove Account \n 3. Withdraw Amount \n 4. Deposit Amount \n 5. Print details \n 6. Queries \n 7. Enter q to quit ");
            char i = Convert.ToChar(Console.ReadLine());
            while (i != 'q')
            {
                switch (i)
                {
                    case '1':
                        p.CreateAccount();
                        break;
                    case '2':
                        p.RemoveAccount();                        
                        break;
                    case '3':
                        try
                        {
                            p.WithdrawAmount();
                        }
                        catch (zeroException z)
                        {
                            Console.WriteLine(z.Message);
                            p.WithdrawAmount();
                        }
                        break;
                    case '4':
                        p.DepositAmount();                        
                        break;
                    case '5':
                        p.PrintDetails();
                        break;
                    case '6':
                        p.Queries();
                        break;
                }
                Console.WriteLine("Choose the actions to be performed");
                i = Convert.ToChar(Console.ReadLine());
            }
            
        }

    }
}
