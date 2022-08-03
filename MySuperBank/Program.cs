using System;

namespace MySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Kendra", 10000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with ${account.Balance}.");

            account.MakeWithdrawal(120, DateTime.Now, "Hammock");
            Console.WriteLine($"Your balance is now ${account.Balance}.");
            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine($"Your balance is now ${account.Balance}.");
            account.MakeDeposit(100, DateTime.Now, "Refund");
            Console.WriteLine($"Your balance is now ${account.Balance}.");

            Console.WriteLine(account.GetAccountHistory());

            // Test for a negative balance.
            try
            {
                account.MakeWithdrawal(750000, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }

            // Test that the initial balances must be positive.
            //BankAccount invalidAccount; was in example but not needed
            try
            {
                var invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
                // return; was in example but not needed
            }

            account.MakeWithdrawal(50, DateTime.Now, "Groceries");
            Console.WriteLine($"Your balance is now ${account.Balance}.");
            Console.WriteLine("");

            Console.WriteLine($"Account {account.Number} for {account.Owner}:");
            Console.WriteLine(account.GetAccountHistory());

            // <GiftCardAccount and InterestEarningAccount tests>
            var giftCard = new GiftCardAccount("Gift card", 100, 50);
            Console.WriteLine($"Gift Card Account:");
            giftCard.MakeWithdrawal(20, DateTime.Now, "Coffees");
            giftCard.MakeWithdrawal(50, DateTime.Now, "Groceries");
            giftCard.PerformMonthEndTransactions();
            // can make additional deposits:
            giftCard.MakeDeposit(27.50m, DateTime.Now, "Add some additional funds");
            Console.WriteLine(giftCard.GetAccountHistory());

            var savings = new InterestEarningAccount("Savings account", 10000);
            Console.WriteLine($"Interest Earnings Account:");
            savings.MakeDeposit(750, DateTime.Now, "Save some money");
            savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
            savings.MakeWithdrawal(250, DateTime.Now, "Paying monthly bills");
            savings.PerformMonthEndTransactions();
            Console.WriteLine(savings.GetAccountHistory());
            // </GiftCardAccount and InterestEarningAccount tests>


        }

    }
}

// https://www.youtube.com/watch?v=xLhm3bEG__c&list=PLdo4fOcmZ0oVxKLQCHpiUWun7vlJJvUiN&index=17
// https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/classes