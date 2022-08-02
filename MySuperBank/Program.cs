﻿using System;

namespace MySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Kendra", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}.");
        }
    }
}

// https://www.youtube.com/watch?v=xLhm3bEG__c&list=PLdo4fOcmZ0oVxKLQCHpiUWun7vlJJvUiN&index=17