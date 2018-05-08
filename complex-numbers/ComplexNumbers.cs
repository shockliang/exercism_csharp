using System;

public struct ComplexNumber
{
    private readonly double real;
    private readonly double imaginary;

    public ComplexNumber(double real, double imaginary)
    {
        this.real = real;
        this.imaginary = imaginary;
    }

    public double Real() => real;

    public double Imaginary() => imaginary;

    public ComplexNumber Mul(ComplexNumber other)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public ComplexNumber Add(ComplexNumber other)
    {
        return new ComplexNumber(real + other.Real(), imaginary + other.Imaginary());
    }

    public ComplexNumber Sub(ComplexNumber other)
    {
        return new ComplexNumber(real - other.Real(), imaginary - other.Imaginary());
    }

    public ComplexNumber Div(ComplexNumber other)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public double Abs()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public ComplexNumber Conjugate()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public ComplexNumber Exp()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}