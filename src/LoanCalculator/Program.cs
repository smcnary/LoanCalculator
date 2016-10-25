using System;

namespace LoanCalculator
{
    public class Program
    {
        #region Methods

        public static void Main(string[] args)
        {
            double principal;
            Console.WriteLine("Enter a principal amount: ");
            principal = Convert.ToDouble(Console.ReadLine());
            double years;
            Console.WriteLine("Enter years:");
            years = Convert.ToDouble(Console.ReadLine());
            var months = years * 12;
            double interest;
            Console.WriteLine("Enter interest:");
            interest = Convert.ToDouble(Console.ReadLine());

            var rate = interest / 1200;
            var monthly = rate > 0 ? (rate + rate / (Math.Pow(1 + rate, months) - 1)) * principal : principal / months;
            MonthlyDetails(principal, interest, months, monthly);
            Console.ReadLine();
        }

        public static void MonthlyDetails(double principal, double interest, double months, double monthly)
        {
            var endingBalance = principal;
            var rate = interest / 1200.0;
            var count = 0;
            while (count <= months)
            {
                var interestPaid = endingBalance * rate;
                var principlePaid = monthly - interestPaid;
                endingBalance -= principlePaid;
                count++;

                Console.WriteLine(string.Format("Month: {0}, ", count));
                Console.WriteLine(string.Format("Interest Paid: {0:C}, ", interestPaid));
                Console.WriteLine(string.Format("Principle Paid: {0:C}", principlePaid));
                Console.WriteLine(string.Format("Current Balance: {0:C}", endingBalance));

            }
        }

        #endregion Methods
    }
}