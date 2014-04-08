using System;

public class Deposit : Account, IWithdrawable
{
    public Deposit(Customer customer, decimal balance, decimal interestRate, byte months)
    {
        this.Customer = customer;
        this.Balance = balance;
        this.InterestRate = interestRate;
        this.Months = months;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("Withdraw amount must be bigger than 0.");
        }
        if ((this.Balance - amount) < 0)
        {
            throw new ArgumentOutOfRangeException("Not enough money in balance to cover withdrawal.");
        }
        this.Balance -= amount;
    }

    public override decimal InterestAmount()
    {
        if (this.Balance > 0 && this.Balance < 1000)
        {
            return 0;
        }
        return this.InterestRate * this.Months;
    }
}