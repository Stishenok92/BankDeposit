using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static BankDepositLibrary.BankDeposit;

namespace BankDepositLibraryTest
{
    [TestClass]
    public class BankDepositTest
    {
        [TestMethod]
        public void CalculatePercentageInNumber_20_Returned1_2()
        {
            //arrange
            double percent = 20;
            double expected = 1.2;

            //act
            double actual = CalculatePercentageInNumber(percent);

            //assert
            AreEqual(expected, actual);
        }

        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void CalculatePercentageInNumber_Minus5_ValidationException()
        {
            //arrange
            int percent = -5;

            //act + assert
            CalculatePercentageInNumber(percent);
        }


        [TestMethod]
        public void CheckContributionPercentage_15_ReturnedTrue()
        {
            //arrange
            double percent = 15;
            bool expected = true;

            //actual
            bool actual = CheckContributionPercentage(percent);

            //assert
            AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckContributionPercentage_0_ReturnedFalse()
        {
            //arrange
            double percent = 0;
            bool expected = false;

            //actual
            bool actual = CheckContributionPercentage(percent);

            //assert
            AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateMonths_Start1000Final2000Percent20_Returned4()
        {
            //arrange
            double startDeposit = 1000;
            double finalDeposit = 2000;
            double percent = 20;
            int expected = 4;

            //act
            int actual = CalculateMonths(startDeposit, finalDeposit, percent);

            //assert
            AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateMonths_Start1000Final1000Percent20_Returned0()
        {
            //arrange
            double percent = 20;
            double startDeposit = 1000;
            double finalDepisit = 1000;
            int expected = 0;

            //act
            int actual = CalculateMonths(startDeposit, finalDepisit, percent);

            //assert
            AreEqual(expected, actual);
        }

        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void CalculateMonths_Start1000Final1000PercentMinus5_ValidationException()
        {
            //arrange
            double percent = -5;
            double startDeposit = 1000;
            double finalDepisit = 1000;

            //act + assert
            CalculateMonths(startDeposit, finalDepisit, percent);
        }

        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void CalculateMonths_Start2000Final1000Percent5_ValidationException()
        {
            //arrange
            double percent = 5;
            double startDeposit = 2000;
            double finalDepisit = 1000;

            //act + assert
            CalculateMonths(startDeposit, finalDepisit, percent);
        }

        [TestMethod]
        public void CalculateFinalDeposit_Start1000Percent10Month5_Returned1610_51()
        {
            //arrange
            double startDeposit = 1000;
            double percent = 10;
            int month = 5;
            double expected = 1610.51;

            //act
            double actual = CalculateFinalDeposit(startDeposit, percent, month);

            //assert
            AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateFinalDeposit_Start1000Percent10Month0_Returned1610_51()
        {
            //arrange
            double startDeposit = 1000;
            double percent = 10;
            int month = 0;
            double expected = 1000;

            //act
            double actual = CalculateFinalDeposit(startDeposit, percent, month);

            //assert
            AreEqual(expected, actual);
        }
        
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void CalculateFinalDeposit_Start1000Percent0Month10_ValidationException()
        {
            //arrange
            double startDeposit = 1000;
            double percent = 0;
            int month = 10;

            //act + assert
            CalculateFinalDeposit(startDeposit, percent, month);
        }
        
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void CalculateFinalDeposit_StartMinus1000Percent10Month10_ValidationException()
        {
            //arrange
            double startDeposit = -1000;
            double percent = 10;
            int month = 10;

            //act + assert
            CalculateFinalDeposit(startDeposit, percent, month);
        }
    }
}