/*
Topic: Creating and Using Custom Exceptions
Goal: Represent business-rule violations using meaningful exception types
Key Concepts:
    - Custom exception classes
    - Domain-specific error handling
    - Separating technical errors from business errors
    - Throwing meaningful exceptions

What this file demonstrates:
    - Designing a custom exception
    - Validating business rules
    - Throwing exceptions with meaningful context
    - Handling domain-specific failures separately

Why it matters:
    Custom exceptions improve:
    - Readability
    - Debugging clarity
    - Maintainability
    - Error categorization in large applications
*/

using System;

namespace ExceptionHandling
{
    internal class CustomException
    {
        static void Main()
        {
            Console.WriteLine("Custom Exception Demonstration\n");
            try
            {
                ProcessWithdrawal(balance: 5000, withdrawAmount: 7000);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Transaction failed.");
                Console.WriteLine($"Reason: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        static void ProcessWithdrawal(decimal balance, decimal withdrawAmount)
        {
            Console.WriteLine($"Current Balance: {balance}");
            Console.WriteLine($"Requested Withdrawal: {withdrawAmount}\n");
            if (withdrawAmount > balance)
            {
                throw new InsufficientBalanceException(
                    withdrawAmount,
                    balance);
            }
            balance -= withdrawAmount;
            Console.WriteLine($"Withdrawal successful.");
            Console.WriteLine($"Remaining Balance: {balance}");
        }
    }

    // Domain-specific custom exception
    internal class InsufficientBalanceException : Exception
    {
        public decimal AttemptedAmount { get; }
        public decimal AvailableBalance { get; }
        
        public InsufficientBalanceException(
            decimal attemptedAmount,
            decimal availableBalance)
            : base(
                $"Attempted to withdraw {attemptedAmount}, but available balance is only {availableBalance}.")
        {
            AttemptedAmount = attemptedAmount;
            AvailableBalance = availableBalance;
        }
    }
}
