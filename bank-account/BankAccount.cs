using System;
using System.Runtime.CompilerServices;

public class BankAccount
{
    private bool isClose = true;
    private Decimal balance;

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Open()
    {
        isClose = false;
        balance = 0;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Close() => isClose = true;

    public float Balance
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return isClose ? throw new InvalidOperationException() : (float)balance;
        }
    }


    [MethodImpl(MethodImplOptions.Synchronized)]
    public void UpdateBalance(float change)
    {
        if (isClose)
            throw new InvalidOperationException();

        balance += (Decimal)change;
    }
}