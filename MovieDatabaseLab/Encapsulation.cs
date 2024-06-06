namespace Encapsulation;

public class BankAccount
{
	public decimal Balance { get; set; }

	public BankAccount (decimal balance)
	{
		Balance = balance;
	}

	public void Withdraw(decimal amount)
	{
		Balance -= amount;
	}
	public void Deposit(decimal amount)
	{
		Balance += amount;
	}
		
}
