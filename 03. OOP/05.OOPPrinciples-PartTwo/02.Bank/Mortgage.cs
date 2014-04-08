using System;

public class Mortgage : Account
{
    const int IndividualGracePeriod = 6;
    const int CompanyGracePeriod = 12;
    public Mortgage(Customer customer, decimal balance, decimal interestRate, byte months)
    {
        if (balance >= 0)
        {
            throw new ArgumentOutOfRangeException("Initial Mortgage balance must be less than 0.");
        }
        this.Customer = customer;
        this.Balance = balance;
        this.InterestRate = interestRate;
        this.Months = months;
    }

    // Mortgage accounts have ½ interest for the first 12 months for companies
    // and no interest for the first 6 months for individuals.
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
        return this.InterestRate * this.Months;
    }
  
    private decimal CompanyInterestAmount()
    {
        if (this.Months - CompanyGracePeriod <= 0)
        {
            return (this.InterestRate / 2) * this.Months;
        }
        decimal intRate = (this.InterestRate / 2) * CompanyGracePeriod;
        intRate += this.InterestRate * (this.Months - CompanyGracePeriod);
        return intRate;
    }
  
    private decimal IndividualInterestAmount()
    {
        decimal intRate = this.InterestRate * (this.Months - IndividualGracePeriod);
        if (intRate > 0)
        {
            return intRate;
        }
        return 0;
    }
}