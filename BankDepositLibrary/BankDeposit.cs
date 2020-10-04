using System;
using System.ComponentModel.DataAnnotations;

namespace BankDepositLibrary
{
    public class BankDeposit
    {
        private const double MINIMUM_DEPOSIT_PERCENTAGE = 0;
        private const double MAXIMUM_DEPOSIT_PERCENTAGE = 25;
        private const double DEPOSIT_ZERO = 0;

        public static double CalculatePercentageInNumber(double percent)
        {
            if (CheckContributionPercentage(percent))
            {
                return 1 + percent / 100;
            }

            throw new ValidationException();
        }

        public static bool CheckContributionPercentage(double percent)
        {
            return percent > MINIMUM_DEPOSIT_PERCENTAGE && percent < MAXIMUM_DEPOSIT_PERCENTAGE;
        }

        public static int CalculateMonths(double startDeposit, double finalDeposit, double percent)
        {
            int month = 0;

            if (!(CheckContributionPercentage(percent)) || startDeposit > finalDeposit || startDeposit <= DEPOSIT_ZERO)
            {
                throw new ValidationException();
            }

            while (startDeposit < finalDeposit)
            {
                startDeposit *= CalculatePercentageInNumber(percent);
                ++month;
            }

            return month;
        }

        public static double CalculateFinalDeposit(double startDeposit, double percent, int month)
        {
            if (!(CheckContributionPercentage(percent)) || startDeposit <= DEPOSIT_ZERO)
            {
                throw new ValidationException();
            }

            while (month != 0)
            {
                startDeposit *= CalculatePercentageInNumber(percent);
                --month;
            }

            return Math.Round(startDeposit, 2);
        }
    }
}