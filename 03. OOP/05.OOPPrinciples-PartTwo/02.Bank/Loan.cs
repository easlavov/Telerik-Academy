using System;

public class Loan : Account
{
    const int IndvidualGracePeriod = 3;
    const int CompanyGracePeriod = 2;

    public Loan(Customer customer, decimal balance, decimal interestRate, byte months)
    {
        if (balance >= 0)
        {
            throw new ArgumentOutOfRangeException("Initial Loan balance must be less than 0.");
        }
        this.Customer = customer;
        this.Balance = balance;
        this.InterestRate = interestRate;
        this.Months = months;
    }

    // Loan accounts have no interest for the first 3 months if are held by individuals
    // and for the first 2 months if are held by a company.
    public override decimal InterestAmount()
    {
        if (this.Customer is Individual)
        {
            return IndividualInterestAmount();
        }
        if (this.Customer is Company)
        {
            return CompanyInterestAmount();
        }
        return 0;
    }

    private decimal IndividualInterestAmount()
    {
        decimal intAmount = this.InterestRate * (this.Months - IndvidualGracePeriod);
        if (intAmount > 0)
        {
            return intAmount;
        }
        return 0;
    }

    private decimal CompanyInterestAmount()
    {
        decimal intAmount = this.InterestRate * (this.Months - CompanyGracePeriod);
        if (intAmount > 0)
        {
            return intAmount;
        }
        return 0;
    }
}