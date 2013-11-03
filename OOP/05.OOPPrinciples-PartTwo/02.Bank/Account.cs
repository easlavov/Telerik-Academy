using System;

public abstract class Account: IDepositable
{
    private Customer customer;
    private decimal balance;
    private decimal interestRate;
    private byte months;    

    public Customer Customer
    {
        get
        {
            return this.customer;
        }
        set
        {
            this.customer = value;
        }
    }

    public decimal Balance
    {
        get
        {
            return this.balance;
        }
        set
        {
            this.balance = value;
        }
    }

    public decimal InterestRate
    {
        get
        {
            return this.interestRate;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Interest rate can't be less than 0.");
            }
            this.interestRate = value;
        }
    }

    public byte Months
    {
        get
        {
            return this.months;
        }
        set
        {
            this.months = value;
        }
    }

    // All accounts can calculate their interest amount for a given period
    // (in months). In the common case its is calculated as follows: 
    // number_of_months * interest_rate.
    public virtual decimal InterestAmount()
    {
        return this.InterestRate * this.Months;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("Deposit amount must be bigger than 0.");
        }
        this.Balance += amount;
    }

    public override string ToString()
    {
        Type type = this.GetType();
        string info = string.Format(
            "Type: {0}, Holder: {1}, {2}, Balance: {3}, Interest rate: {4}, Months: {5}",
            type.Name, this.Customer.Name, this.Customer.GetType().Name, this.Balance,
            this.InterestRate, this.Months);
        return info;
    }
}