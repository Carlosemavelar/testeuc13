using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;
namespace BankTests
{
    [TestClass]
    public class BankAcountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdateBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAcount acount = new BankAcount("Carlin", beginningBalance);
            // Act
            acount.Debit(debitAmount);
            // Assert
            double actual = acount.Balance;

            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 10.00;
            BankAcount acount = new BankAcount("Carlin", beginningBalance);

            // Act
            try
            {
                acount.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAcount.DebitAmountExceedsBalanceMessage);
            }
        }

        [TestMethod]
        public void Credit_WithValidAmount_UpdateBalance()
        {
            // Arrange
            double beginningBalance = 20.55;
            double creditAmount = 100.00;
            double expected = 120.55;
            BankAcount acount = new BankAcount("Carlin", beginningBalance);

            // Act
            acount.Credit(creditAmount);

            // Assert
            double actual = acount.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
        }
    }
}
