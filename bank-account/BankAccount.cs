using System;

public class BankAccount
{
    private float currentBalance;
    private bool isClose = false;
    private object lockObject = new object();

    public void Open()
    {
        lock (lockObject)
        {
            currentBalance = 0.0f;
            isClose = false;
        }

    }

    public void Close() => isClose = true;

    public float Balance
    {
        get
        {
            return isClose ? throw new InvalidOperationException() : currentBalance;
        }
    }

    public void UpdateBalance(float change)
    {
        lock (lockObject)
        {
            currentBalance += change;
        }
    }
}
