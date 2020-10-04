using System;
using System.ComponentModel.DataAnnotations;
using static BankDepositLibrary.BankDeposit;

namespace BankDepositProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task #03. Bank deposit\n");

            try
            {
                Console.Write("Enter start deposit: ");
                double startDeposit = double.Parse(Console.ReadLine());
                Console.Write("Enter final deposit: ");
                double finalDeposit = double.Parse(Console.ReadLine());
                Console.Write("Enter contribution percentage: ");
                double percent = double.Parse(Console.ReadLine());
                int month = CalculateMonths(startDeposit, finalDeposit, percent);
                Console.WriteLine("\nTakes months : " + month);
                Console.WriteLine("Final deposit: " + CalculateFinalDeposit(startDeposit, percent, month));
            }
            catch (ValidationException)
            {
                Console.WriteLine("\nError: ValidationException");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nError: FormatException");
            }
        }
    }
}